using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Core;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.Windows.Media.Animation;

namespace tagVisualizationTest
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
           
            Blink();

          
            
            

           
            

           /* RotateTransform rt = new RotateTransform();

            //  "img" is Image added in XAML
            img.RenderTransform = rt;
            img.RenderTransformOrigin = new Point(0.5, 0.5);
            rt.BeginAnimation(RotateTransform.AngleProperty, myanimation);*/

        }

        public void Blink()
        {
            TimeSpan fadeInTime = new TimeSpan(0, 0, 0, 0, 100);
            TimeSpan fadeOutTime = new TimeSpan(0, 0, 0, 0, 100);


            Image image = img;
            Image image2 = img2;
          

            var fadeInAnimation = new DoubleAnimation(0d, fadeInTime);

            fadeInAnimation.RepeatBehavior = RepeatBehavior.Forever;

            if (image.Source != null)
            {
                Console.WriteLine("HERE");
                var fadeOutAnimation = new DoubleAnimation(1d, fadeOutTime);


                fadeOutAnimation.Completed += (o, e) =>
                {
                    //image.Source = source;
                    image.BeginAnimation(Image.OpacityProperty, fadeInAnimation);
                    image2.BeginAnimation(Image.OpacityProperty, fadeInAnimation);
                };

                image.BeginAnimation(Image.OpacityProperty, fadeOutAnimation);
                image2.BeginAnimation(Image.OpacityProperty, fadeOutAnimation);
            }
            else
            {
                image.Opacity = 1d;
                image2.Opacity = 1d;
                // image.Source = source;
                image.BeginAnimation(Image.OpacityProperty, fadeInAnimation);
                image2.BeginAnimation(Image.OpacityProperty, fadeInAnimation);
            }
        }
        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
          /*  // ... Create a new BitmapImage.
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri("Bitmap1.bmp");
            b.EndInit();

            // ... Get Image reference from sender.
            var image = sender as Image;
            // ... Assign Source.
            image.Source = b;*/
        }


        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        private void OnVisualizationAdded(object sender, TagVisualizerEventArgs e)
        {
            TagVisualization1 tag = (TagVisualization1)e.TagVisualization;

            Console.WriteLine(tag.VisualizedTag.Value);
        }

        private void SurfaceWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void OnVisualizationAdded(object sender, System.Windows.Input.TouchEventArgs e)
        {
        }

        private void onVisualizerLoaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void bet_button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Bet");
        }

        private void stand_button_click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Stand");
        }

    }
}