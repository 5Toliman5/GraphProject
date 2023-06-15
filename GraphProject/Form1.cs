using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;

namespace GraphProject
{
    public partial class Form1 : Form
    {
        private PlotView plotView;
        public Form1()
        {
            InitializeComponent();
            plotView = new PlotView();
            plotView.Dock = DockStyle.Fill;
            panel1.Controls.Add(plotView);

            // Create the circular transformation graph
            var model = new PlotModel { Title = "Circular Transformation" };

            // Define the parameters of the circular transformation
            double centerX = 0; // X-coordinate of the center
            double centerY = 0; // Y-coordinate of the center
            double radius = 1; // Radius of the circle

            // Number of points to be plotted
            int numPoints = 360;

            // Calculate and add the transformed points to the graph
            var lineSeries = new LineSeries();
            for (int i = 0; i < numPoints; i++)
            {
                // Calculate the angle in radians
                double angle = 2 * Math.PI * i / numPoints;

                // Apply the circular transformation
                double x = centerX + radius * Math.Cos(angle);
                double y = centerY + radius * Math.Sin(angle);

                lineSeries.Points.Add(new DataPoint(x, y));
            }

            model.Series.Add(lineSeries);
            plotView.Model = model;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}