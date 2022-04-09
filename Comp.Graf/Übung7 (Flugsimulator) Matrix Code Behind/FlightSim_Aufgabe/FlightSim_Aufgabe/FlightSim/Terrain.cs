using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace FlightSim
{
    class Terrain
    {
        // Creates 3 collections from a list of DGM height cells (heixels):
        // 1. a collection of 3D positions
        // 2. a collection of corresponding texcoords
        // 3. a 2D array indicating the 0-based index of each added position/texcoord (-1 if missing).
        public static (Point3DCollection, PointCollection, int[,]) CreatePositions(List<DgmHeixel> coords)
        {
            // Coordinate systems:
            //
            //          -Z=northM=negz
            //          ^
            //          |
            //    lats  +-----------------+ texcoordV=0
            //    lats-1+----------------+|
            //          |                ||
            //          |                ||
            //          |     coords     || texture
            //          |                ||
            //          |                ||
            //          |                ||
            // ---------+----------------++----------> X=eastM=texcoordU
            //         0|          longs-1
            //          |                 longs

            const int tileSizeM = 10000; // Assume square tiles covering 10000 x 10000 m²
            const int spacingM = 50; // DGM50
            int lats = tileSizeM / spacingM; // this includes the west and south, but not east and north borders of a tile
            int longs = tileSizeM / spacingM;

            Point3DCollection positions = new Point3DCollection(coords.Count);
            PointCollection texcoords = new PointCollection(coords.Count);

            // Set all indices indicating the location of a heixel in the collections to -1 = missing
            int[,] positionIndices = new int[lats, longs];
            for (int negz = 0; negz < lats; negz++)
                for (int x = 0; x < longs; x++)
                    positionIndices[negz, x] = -1;

            // Determine the UTM32 location of the tile from its first heixel
            int westCornerM = coords[0].eastM - coords[0].eastM % tileSizeM;
            int southCornerM = coords[0].northM - coords[0].northM % tileSizeM;

            foreach (DgmHeixel coord in coords)
            {
                // the tile is put into the X/-Z quadrant, i.e. north values are mapped to -Z
                int northRelativeM = coord.northM - southCornerM;
                int eastRelativeM = coord.eastM - westCornerM;
                Point3D p = new Point3D(eastRelativeM, coord.heightM, -northRelativeM);

                // Store index within the positions (and texcoords) collection in the array
                int negz = northRelativeM / spacingM; // 0...lats-1
                int x = eastRelativeM / spacingM; // 0...longs-1
                positionIndices[negz, x] = positions.Count;

                positions.Add(p);

                // Texcoords must match the aerial photo, which covers the entire tile including the north and east border
                double v = (double)(lats - negz) / lats; // 0...lats-1 => 1...(0
                double u = (double)x / longs; // 0...longs-1 => 0...(1
                texcoords.Add(new Point(u, v));
            }

            return (positions, texcoords, positionIndices);
        }

        // Generates the triangle indices of a mesh from a 2D array of position indices. 
        // Adds the triangle indices and returns the collection. Leaves out triangles for invalid vertex positions.
        public static Int32Collection CreateTriangleIndices(int[,] positionIndices)
        {
            int lats = positionIndices.GetLength(0);
            int longs = positionIndices.GetLength(1);
            Int32Collection triangleIndices = new Int32Collection(lats * longs * 6);

            for (int negz = 0; negz < lats - 1; negz++)
            {
                for (int x = 0; x < longs - 1; x++)
                {
                    // 4 corners counterclockwise (note that negz refers to points in the -Z quadrant)
                    int i0 = positionIndices[negz, x];
                    int i1 = positionIndices[negz, x + 1];
                    int i2 = positionIndices[negz + 1, x + 1];
                    int i3 = positionIndices[negz + 1, x];                    

                    if (i0 >= 0 && i1 >= 0 && i2 >= 0)
                    {
                        triangleIndices.Add(i0);
                        triangleIndices.Add(i1);
                        triangleIndices.Add(i2);
                    }

                    if (i2 >= 0 && i3 >= 0 && i0 >= 0)
                    {
                        triangleIndices.Add(i2);
                        triangleIndices.Add(i3);
                        triangleIndices.Add(i0);
                    }
                }
            }
            return triangleIndices;
        }
    }
}
