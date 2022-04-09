using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace BayernViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Brush whiteBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        public MainWindow()
        {
            InitializeComponent();

            // Load a nice heightfield, assuming we are in bin\Debug\netcoreapp3.1 (or bin\Release\netcoreapp3.1) and heixel files are in the project folder.
            LoadHeightfield(@"..\..\..\64_549t50dgm.txt");
            LoadTexture(@"..\..\..\64_549t250dop.png");
        }

        private void Button_Load_Heightfield(object sender, RoutedEventArgs e)
        {
            // Get path of .txt file, e.g. @"..\..\..\64_549t50dgm.txt"
            string path = Loader.GetFilePath("64_549t50dgm.txt", ".txt", "Text files|*.txt");

            // if file selection has not been cancelled go on
            if (path != null)
            {
                LoadHeightfield(path);
                diffuseMaterial.Brush = whiteBrush;
            }
        }

        private void Button_Load_Texture(object sender, RoutedEventArgs e)
        {
            // Get path of texture file 
            string path = Loader.GetFilePath("64_549t250dop.png", ".png", "Image files|*.png");

            if (path != null) LoadTexture(path);
            else diffuseMaterial.Brush = whiteBrush;
        }

        private void LoadHeightfield(string path)
        {
            // Make list of heixels
            var coords = Loader.ReadDgmFile(path);

            // Return collections of cartesian and texture coordinates , and indices (contains -1 if none)
            (Point3DCollection positions, PointCollection texcoords, int[,] positionIndices) = 
                Terrain.CreatePositions(coords);
            mesh.Positions = positions;
            mesh.TextureCoordinates = texcoords;

            // Add triangles with valid vertices to the mesh
            Int32Collection triangleIndices = Terrain.CreateTriangleIndices(positionIndices);
            mesh.TriangleIndices = triangleIndices;
        }

        private void LoadTexture(string path)
        {
            // Create ImageSource
            BitmapImage bi = new BitmapImage();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block.
            bi.BeginInit();
            bi.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            bi.EndInit();

            // Create and attach ImageBrush
            ImageBrush ib = new ImageBrush(bi);
            ib.ViewportUnits = BrushMappingMode.Absolute;
            ib.ImageSource = bi;
            diffuseMaterial.Brush = ib;
        }
    }
}
