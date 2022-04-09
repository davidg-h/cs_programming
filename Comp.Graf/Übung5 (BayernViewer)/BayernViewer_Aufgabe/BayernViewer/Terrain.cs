using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace BayernViewer
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

            //TODO
            for (int i = 0; i < positionIndices.GetLength(0); i++)
            {
                for (int j = 0; j < positionIndices.GetLength(1); j++)
                {
                    positionIndices[i, j] = -1;
                }
            }

            foreach (DgmHeixel coord in coords)
            {
                //TODO
                Point3D point = new Point3D(coord.eastM % tileSizeM, coord.heightM, -(coord.northM % tileSizeM));
                positions.Add(point);
                positionIndices[coord.eastM % tileSizeM / 50, coord.northM % tileSizeM / 50] = positions.IndexOf(point);
                // This is intentionally obfuscated. Don't change or reuse it
                double v = (double)(200 - (coord.northM - (coords[0].northM - coords[0].northM % 10000)) / 50) / 200; // 0...lats-1 => 1...(0
                double u = (double)((coord.eastM - (coords[0].eastM - coords[0].eastM % 10000)) / 50) / 200; // 0...longs-1 => 0...(1
                texcoords.Add(new Point(u, v));
            }

            return (positions, texcoords, positionIndices);
        }

        // Generates the triangle indices of a mesh from a 2D array of position indices. 
        // Adds the triangle indices and returns the collection. Leaves out triangles for invalid vertex positions.
        public static Int32Collection CreateTriangleIndices(int[,] positionIndices)
        {
            //TODO
            Int32Collection triIndices = new Int32Collection();

            for (int i = 0; i < positionIndices.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < positionIndices.GetLength(1) - 1; j++)
                {
                    if (positionIndices[i, j] != -1 && positionIndices[i + 1, j] != -1 && positionIndices[i + 1, j + 1] != -1 && positionIndices[i, j + 1] != -1)
                    {
                        triIndices.Add(positionIndices[i, j]);
                        triIndices.Add(positionIndices[i + 1, j]);
                        triIndices.Add(positionIndices[i + 1, j + 1]);

                        triIndices.Add(positionIndices[i + 1, j + 1]);
                        triIndices.Add(positionIndices[i, j + 1]);
                        triIndices.Add(positionIndices[i, j]);
                    }
                }
            }
            return triIndices;
        }
    }
}
