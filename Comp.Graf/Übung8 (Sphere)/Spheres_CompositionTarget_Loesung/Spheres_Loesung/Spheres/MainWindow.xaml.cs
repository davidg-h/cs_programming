using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sphere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double sqrt2plus1 = 1.0 + Math.Sqrt(2.0);
        static long lastTicks = -1;
        static double angle = 0.0;

        public MainWindow()
        {
            InitializeComponent();

            CompositionTarget.Rendering += Update;
        }

        private void Update(object sender, EventArgs e)
        {
            // Determine elapsed time
            RenderingEventArgs renderingArgs = (RenderingEventArgs)e;
            long ticks = renderingArgs.RenderingTime.Ticks;
            if (lastTicks == -1) lastTicks = ticks;
            double elapsedTimeSeconds = (double)(ticks - lastTicks) / TimeSpan.TicksPerSecond;
            lastTicks = ticks;

            // Storyboard to rotate model by 360° in 10 seconds
            angle += 360.0 * elapsedTimeSeconds / 10.0;
            rotation.Angle = angle;

            // Binding of slider to light rotation angle
            lightRot.Angle = rotSlider.Value;
        }
    }
}
