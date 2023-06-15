using OxyPlot.Series;
using OxyPlot;
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
using OxyPlot.Axes;

namespace GraphProject3D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PlotModel PlotModel { get; set; }
        public MainWindow()
        {

            InitializeComponent();
            // Create the 3D graph
            PlotModel = new PlotModel { Title = "Helical Transformation" };

            // Define the parameters of the helical transformation
            double radius = 1; // Radius of the helix
            double height = 5; // Height of the helix
            int numPoints = 360; // Number of points to be plotted

            // Create the x-axis
            var xAxis = new LinearAxis { Position = AxisPosition.Bottom };
            PlotModel.Axes.Add(xAxis);

            // Create the y-axis
            var yAxis = new LinearAxis { Position = AxisPosition.Left };
            PlotModel.Axes.Add(yAxis);

            // Create the z-axis
            var zAxis = new LinearAxis { Position = AxisPosition.Right };
            PlotModel.Axes.Add(zAxis);

            // Create the helical transformation series
            var scatterSeries = new ScatterSeries();

            // Calculate and add the transformed points to the scatter series
            for (int i = 0; i < numPoints; i++)
            {
                // Calculate the angle in radians
                double angle = 2 * Math.PI * i / numPoints;

                // Apply the helical transformation
                double x = radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);
                double z = height * angle / (2 * Math.PI);

                scatterSeries.Points.Add(new ScatterPoint(x, y, z));
            }

            // Add the scatter series to the model
            PlotModel.Series.Add(scatterSeries);

            DataContext = this;
        }
    }
}
