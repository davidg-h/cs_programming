using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Sphere
{
    public partial class MainWindow : Window
    {
        const int Stacks = 64;
        const int Slices = 128;

        public MainWindow()
        {
            InitializeComponent();

            Point3DCollection positions = new Point3DCollection();
            Vector3DCollection normals = new Vector3DCollection();
            PointCollection texcoords = new PointCollection();
            Int32Collection tris = new Int32Collection();

            for (int y = 0; y <= Stacks; y++) // TODO: < or <= ?
            {
                // TODO: make rotation parameters

                // p = Rx*(0,1,0)T
                Vector3D p = new Vector3D(/*TODO*/);

                for (int x = 0; x <= Slices; x++) // TODO: < or <= ?
                {
                    // TODO: make rotation parameters

                    // q = Ry*p, Note: p.X is 0
                    Vector3D q = new Vector3D(/*TODO*/);

                    // Generate 
                    Point3D r = new Point3D();//TODO
                    positions.Add(r);

                    normals.Add(new Vector3D());//TODO
                    texcoords.Add(new Point());//TODO

                    if (y < Stacks && x < Slices) // TODO: < or <= ?
                    {
                        const int Pitch = Slices + 1; // TODO: + 1 or not?
                        int i = y * Pitch + x;
                        tris.Add(i);
                        tris.Add(i + Pitch);
                        tris.Add(i + Pitch + 1);
                        tris.Add(i + Pitch + 1);
                        tris.Add(i + 1);
                        tris.Add(i);
                    }
                }
            }

            sphereModel.Geometry = new MeshGeometry3D
            {
                Positions = positions,
                Normals = normals,
                TextureCoordinates = texcoords,
                TriangleIndices = tris,
            };
        }
    }
}
