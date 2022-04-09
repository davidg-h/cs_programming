#define USEMATRIX

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

            for (int y = 0; y <= Stacks; y++)
            {
                // Normalize
                double ny = (double)y / Stacks;

                // Latitude/elevation from stack
#if USEMATRIX
                //p = Rx*(0,1,0)T
                Vector3D o = new Vector3D(0, 1, 0);
                double e = 180.0 * ny; // 0.0 ... 180.0
                Matrix3D rx = Matrix3D.Identity;
                rx.Rotate(new Quaternion(new Vector3D(1, 0, 0), e));
                Vector3D p = rx.Transform(o);
#else
                double e = Math.PI * ny; // 0.0 ... Pi
                double sine = Math.Sin(e);
                double cose = Math.Cos(e);
                Vector3D p = new Vector3D(0, cose, sine);
#endif

                for (int x = 0; x <= Slices; x++)
                {
                    // Normalize
                    double nx = (double)x / Slices;

                    // Longitude/azimuth from slice
#if USEMATRIX
                    // q = Ry*p, Note: p.X is 0
                    double a = 360.0 * nx; // 0.0° ... 360.0°
                    Matrix3D ry = Matrix3D.Identity;
                    ry.Rotate(new Quaternion(new Vector3D(0, 1, 0), a));
                    Vector3D q = ry.Transform(p);
#else
                    double a = 2 * Math.PI * nx;
                    double sina = Math.Sin(a);
                    double cosa = Math.Cos(a);
                    Vector3D q = new Vector3D(sina * p.Z, p.Y, cosa * p.Z);
#endif

                    // Generate 
                    Point3D r = new Point3D() + q;
                    positions.Add(r);

                    normals.Add(q);
                    texcoords.Add(new Point(nx, ny));

                    if (y < Stacks && x < Slices)
                    {
                        const int Pitch = Slices + 1;
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
