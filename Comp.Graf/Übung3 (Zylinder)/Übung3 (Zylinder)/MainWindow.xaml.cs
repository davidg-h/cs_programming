using System;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Cylinder
{
    public partial class MainWindow : Window
    {
        const int N = 128;
        public MainWindow()
        {
            InitializeComponent();
            // added
            bottomModel.Geometry = Disk(false);
            topModel.Geometry = Disk(true);
            body.Geometry = Body();
            //hat.Geometry = Hat();
        }
        // Replace square geometry by a disk
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
        static Point3DCollection Circle(double y)
        {
            Point3DCollection positions = new Point3DCollection();
            Circle(positions, y);
            return positions;
        }
        static void Circle(Point3DCollection positions, double y)
        {
            for (int i = 0; i < N; i++)
            {
                double z = Math.Cos(i * 2 * Math.PI / N);
                double x = Math.Sin(i * 2 * Math.PI / N);
                positions.Add(new Point3D(x, y, z));
            }
        }

        static MeshGeometry3D Body()
        {
            MeshGeometry3D bod = new MeshGeometry3D();

            Point3DCollection positions = Circle(0);
            Circle(positions, 1);
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

        static MeshGeometry3D Hat()
        {
            MeshGeometry3D hat = new MeshGeometry3D();
            Point3DCollection position = Circle(1);
            position.Add(new Point3D(0, 2, 0));
            hat.Positions = position;
            for (int i = 0; i < N; i++)
            {
                hat.TriangleIndices.Add(N);
                hat.TriangleIndices.Add(i);
                hat.TriangleIndices.Add((i + 1) % N);
            }
            return hat;
        }
    }
}
