//#define PerspectiveCamera

using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Controls;

namespace FlightSim
{
    class HID
    {
        const double degreesPerSecond = 16.0; // degrees per half window size and second
        const double meterPerSecond = 900; // world units (meter) per second
        static Point3D restartPosition = new Point3D(0, 1500, 10000); // note that heights are exaggerated by 3

        static long lastTicks;
        static Point3D lastPosition;
        static double elevation;
        static double azimuth;
        static Point3D position;
        static MainWindow window;
        static Viewport3D viewport3D;
#if PerspectiveCamera
        static PerspectiveCamera perspectiveCamera;
#else
        static MatrixCamera matrixCamera;
#endif
        public static void Restart(MainWindow window)
        {
            lastTicks = -1;
            lastPosition = restartPosition;
            elevation = 0.0;
            azimuth = 0.0;
            position = restartPosition;
            HID.window = window;
            viewport3D = window.viewport3D;
#if PerspectiveCamera
            perspectiveCamera = window.perspectiveCamera;
#else
            matrixCamera = window.matrixCamera;
#endif
        }

        public static void UpdateCamera(object sender, EventArgs e)
        {
            // Determine elapsed time
            RenderingEventArgs renderingArgs = (RenderingEventArgs)e;
            long ticks = renderingArgs.RenderingTime.Ticks;
            if (lastTicks == -1) lastTicks = ticks;
            double elapsedTimeSeconds = (double)(ticks - lastTicks) / TimeSpan.TicksPerSecond;
            lastTicks = ticks;

            // Transform mouse position from viewport coordinates to normalized device coordinates (-1.0 ... 1.0)
            Point mousePosition = Mouse.GetPosition(viewport3D);
            Vector mousePositionNormalized = new Vector(
                2 * mousePosition.X / viewport3D.ActualWidth - 1,
                -2 * mousePosition.Y / viewport3D.ActualHeight + 1);

            // Update camera rotation, only while left mouse button is pressed
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                elevation = elevation + mousePositionNormalized.Y * degreesPerSecond * elapsedTimeSeconds;
                // TODO: Update azimuth from horizontal mouse position
                azimuth = azimuth + mousePositionNormalized.X * degreesPerSecond * elapsedTimeSeconds;
            }

            // Standard basis
            Vector3D unitX = new Vector3D(1, 0, 0);
            Vector3D unitY = new Vector3D(0, 1, 0);
            Vector3D unitZ = new Vector3D(0, 0, 1);

            // Rotation about world X axis according to up-down mouse movement
            Matrix3D rotX = Matrix3D.Identity; rotX.Rotate(new Quaternion(unitX, elevation));

            // Rotation about world Y axis according to left-right mouse movement           
            // TODO: Create rotation
            Matrix3D rotY = Matrix3D.Identity; rotY.Rotate(new Quaternion(unitY, -azimuth));

            // Combined rotation
            Matrix3D rot = rotX;
            // TODO: Append transformations
            rot.Append(rotY);
            // Transform to camera base vectors, right (U), up (V) and back (W) or look direction (-W)            
            Vector3D cameraW = rot.Transform(unitZ);
            //TODO: more base vectors...
            Vector3D cameraU = rot.Transform(unitX);
            Vector3D cameraV = rot.Transform(unitY);
            // TODO: In the following sections, add handling of W, A, S, D keys
            // W key is somewhat prepared...

            // Determine WASD keys state
            bool wKeyDown = Keyboard.IsKeyDown(Key.W);
            //TODO
            bool sKeyDown = Keyboard.IsKeyDown(Key.S);
            bool aKeyDown = Keyboard.IsKeyDown(Key.A);
            bool dKeyDown = Keyboard.IsKeyDown(Key.D);

            // Update camera position
            if (wKeyDown)
            {
                //TODO
                position = position + (-cameraW) * meterPerSecond * elapsedTimeSeconds;
            }
            if (sKeyDown)
            {
                //TODO
                position = position + cameraW * meterPerSecond * elapsedTimeSeconds;
            }
            if (dKeyDown)
            {
                //TODO
                position = position + cameraU * meterPerSecond * elapsedTimeSeconds;
            }
            if (aKeyDown)
            {
                //TODO
                position = position + (-cameraU) * meterPerSecond * elapsedTimeSeconds;
            }
#if PerspectiveCamera
            // write back
            perspectiveCamera.LookDirection = -cameraW;
            perspectiveCamera.UpDirection = cameraV;
            perspectiveCamera.Position = position;
#else
            rot.Translate((Vector3D)position);
            Matrix3D cameraBase = rot;

            Matrix3D viewMatrix = cameraBase; viewMatrix.Invert();

            // Create perspective projection matrix
            double fieldOfView = Math.PI / 4;//45 degrees, WPF default
            double fieldOfViewRadians = fieldOfView;//2 * Math.PI * fieldOfView / 360.0;
            double aspectRatio = viewport3D.ActualWidth / viewport3D.ActualHeight;
            double n = 8;//nearPlaneDistance, WPF default
            double f = double.PositiveInfinity;//farPlaneDistance, infinite is WPF default
            double a = 1 / Math.Tan(fieldOfViewRadians / 2);//n/2w
            double b = aspectRatio * a;//w/h=(2n/h)/(2n/w)=W/H
            double c = double.IsNaN(f / (n - f)) ? -1 : f / (n - f);
            double d = double.IsNaN(n * f / (n - f)) ? -1 : n * f / (n - f);
            Matrix3D projectionMatrix = new Matrix3D(
                a, 0, 0, 0,
                0, b, 0, 0,
                0, 0, c, -1,
                0, 0, d, 0);

            matrixCamera.ViewMatrix = viewMatrix;
            matrixCamera.ProjectionMatrix = projectionMatrix;
#endif
            // update HUD, don't change this
            window.Altitude.Text = ((int)position.Y).ToString() + " m";
            window.Longitude.Text = ((int)position.X).ToString() + " m";
            window.Latitude.Text = ((int)position.Z).ToString() + " m";
            double speed = (position - lastPosition).Length / elapsedTimeSeconds;
            lastPosition = position;
            window.Speed.Text = ((int)speed).ToString() + " m/sec";
            window.Framerate.Text = ((int)(1.0 / elapsedTimeSeconds)).ToString() + " fps";
        }
    }
}
