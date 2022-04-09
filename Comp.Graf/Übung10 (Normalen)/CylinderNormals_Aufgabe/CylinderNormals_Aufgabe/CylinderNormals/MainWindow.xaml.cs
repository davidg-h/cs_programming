using System.Windows;
using System.Windows.Media.Media3D;
using System;

namespace CylinderNormals
{
    public partial class MainWindow : Window
    {
        const int N = 16;

        public MainWindow()
        {
            InitializeComponent();

            // added
            bottomModel.Geometry = Disk(false);
            topModel.Geometry = Disk(true);
            bodyModel.Geometry = Body();
        }

        static MeshGeometry3D Disk(bool isTop)
        {
            double y = isTop ? 1 : 0;

            MeshGeometry3D disk = new MeshGeometry3D();

            // TODO: Supply correct normal vector for top or bottom disk circumference
            #region Aufgabe 1
            double normY = isTop ? 1 : -1;
            #endregion
            Circle(disk, new Point3D(0, y, 1), new Vector3D(0, normY, 0));

            // Center of disk has index N
            disk.Positions.Add(new Point3D(0, y, 0));
            // TODO: Add correct normal vector for top or bottom disk center point
            disk.Normals.Add(new Vector3D(0, normY, 0));
            // disk.Normals.Clear(); // Test: Our normals should be the same as WPF computed ones

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

        static MeshGeometry3D Body()
        {
            MeshGeometry3D body = new MeshGeometry3D();

            // TODO: Supply correct normal vector of the body to be rotated about the Y axis
            Circle(body, new Point3D(0, 0, 1), new Vector3D(0, 0, 1));
            Circle(body, new Point3D(0, 1, 1), new Vector3D(0, 0, 1));
            // body.Normals.Clear(); // Test: Our normals should be the same as WPF computed ones

            for (int i = 0; i < N; i++)
            {
                // Draw 2 tris connecting indices i, i+1, i+1+numberOfPoints, i+numberOfPoints
                body.TriangleIndices.Add(i);
                body.TriangleIndices.Add((i + 1) % N);
                body.TriangleIndices.Add((i + 1) % N + N);

                body.TriangleIndices.Add((i + 1) % N + N);
                body.TriangleIndices.Add(i + N);
                body.TriangleIndices.Add(i);
            }

            return body;
        }

        static void Circle(MeshGeometry3D mesh, Point3D position, Vector3D normal, double normalRotationOffset = 0.0)
        {
            for (int i = 0; i < N; i++)
            {
                double sina = Math.Sin(i * 2 * Math.PI / N);
                double cosa = Math.Cos(i * 2 * Math.PI / N);

                #region Aufgabe 4
                double a = i * 360 / N;
                Matrix3D rotY = Matrix3D.Identity; rotY.Rotate(new Quaternion(0, 1, 0, a));
                #endregion

                /*double x = cosa * position.X + sina * position.Z;
                double y = position.Y;
                double z = -sina * position.X + cosa * position.Z;*/
                Point3D p = rotY.Transform(position);
                mesh.Positions.Add(p);

                /*double nx = cosa * normal.X + sina * normal.Z;
                double ny = normal.Y;
                double nz = -sina * normal.X + cosa * normal.Z;*/
                Vector3D n = rotY.Transform(normal);
                mesh.Normals.Add(n);
            }
        }
    }
}
