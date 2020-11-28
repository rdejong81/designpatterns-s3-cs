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
        private PointPublisher pointMonitor;
        private PointDrawerSubscriber pointDrawer;
        private PointWriterSubscriber pointWriter;

        public MainWindow()
        {
            InitializeComponent();

            pointMonitor = new PointPublisher(new Point(1, 1));
            pointDrawer = new PointDrawerSubscriber();
            pointWriter = new PointWriterSubscriber();
            
            pointMonitor.Subscribe(pointDrawer);
            pointMonitor.Subscribe(pointWriter);

            canvas.Children.Add(pointDrawer);
            canvasbottom.Children.Add(new PointDrawerSubscriber());

            this.MouseDown += (obj, eventArgs) =>
            {
                pointMonitor.point = eventArgs.GetPosition(this);

            };

            this.MouseMove += (obj, eventArgs) =>
            {
                if(eventArgs.LeftButton == MouseButtonState.Pressed)
                    pointMonitor.point = eventArgs.GetPosition(canvas);

            };
        }
    }
}
