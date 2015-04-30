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

        Image[] imgArray = new Image[10];
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();

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

        private void stand_button_click(object sender, RoutedEventArgs s)
        {
            Console.WriteLine("Stand");

            TimeSpan fadeInTime = new TimeSpan(0, 0, 0, 0, 100);
            TimeSpan fadeOutTime = new TimeSpan(0, 0, 0, 0, 100);

            Image image1 = img1;
            Image image2 = img2;

            image1.Margin = new Thickness(1600, 300, 0, 0);
            image2.Margin = new Thickness(1700, 300, 0, 0);

            var fadeInAnimation = new DoubleAnimation(0d, fadeInTime);

            fadeInAnimation.RepeatBehavior = new RepeatBehavior(count: 10);

            Console.WriteLine("HERE");
            var fadeOutAnimation = new DoubleAnimation(1d, fadeOutTime);

            fadeOutAnimation.Completed += (o, e) =>
                {
                    image1.BeginAnimation(Image.OpacityProperty, fadeInAnimation);
                    image2.BeginAnimation(Image.OpacityProperty, fadeInAnimation);
                };

            image1.BeginAnimation(Image.OpacityProperty, fadeOutAnimation);
            image2.BeginAnimation(Image.OpacityProperty, fadeOutAnimation);
           
        }

    }
}