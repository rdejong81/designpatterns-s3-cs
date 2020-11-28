using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ObserverCS_S3.Classes
{
    class PointDrawer : UIElement, IObserver<Point>
    {  
        private DrawingVisual drawing;

        public PointDrawer()
        {
            
            drawing = new DrawingVisual();
            this.AddVisualChild(drawing);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

     
        public void OnNext(Point value)
        {
            DrawingContext drawingContext = drawing.RenderOpen();
            drawingContext.DrawDrawing(drawing.Drawing);
            
            drawingContext.DrawEllipse(Brushes.Red, new Pen(Brushes.Red,1), value, 10, 10);
           
            // Persist the drawing content.
            drawingContext.Close();
        }

        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        protected override Visual GetVisualChild(int index)
        {
            return drawing;
        }


    }
}
