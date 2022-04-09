using System;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Teapot
{
    public partial class MainWindow : Window
    {
        const int N = 128;

        public MainWindow()
        {
            InitializeComponent();

            var (pMin, pMax) = BoundingBox(teapot.Positions);
            boundingBox.Text = "Min = (" + pMin.X + ", " + pMin.Y + ", " + pMin.Z + "), Max = (" + pMax.X + ", " + pMax.Y + ", " + pMax.Z + ")";

            bottomModel.Geometry = Disk(false);
            body.Geometry = Body();
        }

        static (Point3D pMin, Point3D pMax) BoundingBox(Point3DCollection positions)
        {
            if (positions.Count > 0)
            {
                Point3D pMin = positions[0];
                Point3D pMax = positions[0];

                foreach (Point3D p in positions)
                {
                    pMin.X = Math.Min(pMin.X, p.X);
                    pMin.Y = Math.Min(pMin.Y, p.Y);
                    pMin.Z = Math.Min(pMin.Z, p.Z);

                    pMax.X = Math.Max(pMax.X, p.X);
                    pMax.Y = Math.Max(pMax.Y, p.Y);
                    pMax.Z = Math.Max(pMax.Z, p.Z);
                }

                pMin.X = Math.Round(pMin.X * 1000.0) / 1000.0;
                pMin.Y = Math.Round(pMin.Y * 1000.0) / 1000.0;
                pMin.Z = Math.Round(pMin.Z * 1000.0) / 1000.0;

                pMax.X = Math.Round(pMax.X * 1000.0) / 1000.0;
                pMax.Y = Math.Round(pMax.Y * 1000.0) / 1000.0;
                pMax.Z = Math.Round(pMax.Z * 1000.0) / 1000.0;

                return (pMin, pMax);
            }
            else
            {
                throw new ArgumentException("Non-empty Point3DCollection expected");
            };
        }

        static MeshGeometry3D Disk(bool isTop)
        {
            double y = isTop ? 1 : 0;
            MeshGeometry3D disk = new MeshGeometry3D();
            disk.Positions = Circle(y);
            // Center of disk has index N
            disk.Positions.Add(new Point3D(0, y, 0));
            for (int i = 0; i < N; i++)
            {
                disk.TriangleIndices.Add(N);
                if (isTop)
                {
                    disk.TriangleIndices.Add(i);
                    disk.TriangleIndices.Add((i + 1) % N);
                }
                else
                {
                    disk.TriangleIndices.Add((i + 1) % N);
                    disk.TriangleIndices.Add(i);
                }
            }
            return disk;
        }
        static Point3DCollection Circle(double y, double r = 0)
        {
            Point3DCollection positions = new Point3DCollection();
            Circle(positions, y, r);
            return positions;
        }
        static void Circle(Point3DCollection positions, double y, double r = 0)
        {
            for (int i = 0; i < N; i++)
            {
                double z = Math.Cos(i * 2 * Math.PI / N) + r;
                double x = Math.Sin(i * 2 * Math.PI / N) + r;
                positions.Add(new Point3D(x, y, z));
            }
        }

        static MeshGeometry3D Body()
        {
            MeshGeometry3D bod = new MeshGeometry3D();

            Point3DCollection positions = Circle(0);
            Circle(positions, 2);
            bod.Positions = positions;
            for (int i = 0; i < positions.Count; i++)
            {
                bod.TriangleIndices.Add(i);
                bod.TriangleIndices.Add((i + 1) % N);
                bod.TriangleIndices.Add(N + ((i + 1) % N));

                bod.TriangleIndices.Add(i);
                bod.TriangleIndices.Add(N + ((i + 1) % N));
                bod.TriangleIndices.Add(N + i);

            }
            return bod;
        }
    }
}