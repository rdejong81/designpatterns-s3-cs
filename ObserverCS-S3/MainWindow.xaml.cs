using ObserverCS_S3.Classes;
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

namespace ObserverCS_S3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PointPublisher pointPublisher;
        private PointDrawerSubscriber pointDrawer;
        private PointWriterSubscriber pointWriter;

        public MainWindow(PointPublisher pointPublisher)
        {
            InitializeComponent();

            this.pointPublisher = pointPublisher;
            pointDrawer = new PointDrawerSubscriber();
            pointWriter = new PointWriterSubscriber(pointDrawer.Visual);

            pointPublisher.Subscribe(pointDrawer);
            pointPublisher.Subscribe(pointWriter);

            canvas.Children.Add(pointDrawer);

            this.MouseDown += (obj, eventArgs) =>
            {
                pointPublisher.point = eventArgs.GetPosition(pointDrawer);

            };

            this.MouseMove += (obj, eventArgs) =>
            {
                if(eventArgs.LeftButton == MouseButtonState.Pressed)
                    pointPublisher.point = eventArgs.GetPosition(pointDrawer);

            };

            this.MouseRightButtonDown += (obj, eventArgs) =>
            {
                // lets create a new window
                MainWindow mainWindow = new MainWindow(pointPublisher);

                mainWindow.Show();
            };
        }
    }
}
