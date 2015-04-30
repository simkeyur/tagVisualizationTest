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
using System.Collections;

namespace tagVisualizationTest
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        Image[] imgArray = new Image[10];
        Rectangle[] rectArray = new Rectangle[10];
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
           // Console.WriteLine("Bet");
        }

        private void stand_button_click(object sender, RoutedEventArgs s)
        {
          //  Console.WriteLine("Stand");
            imgArray[0] = img1;
            imgArray[1] = img2;
            imgArray[2] = img3;
            imgArray[3] = img4;
            imgArray[4] = img5;
            imgArray[5] = img6;
            imgArray[6] = img7;
            imgArray[7] = img8;
            imgArray[8] = img9;
            imgArray[9] = img10;

            string WhiteSpace = " ";
            string result = "M";
            string binary;
            char[] binArray;
            string transferString = result + WhiteSpace;
            binArray = transferString.ToCharArray();
            int location = 0;
            while (location < binArray.Length)
            {
                binary = ConvertToBinary(binArray[location]);
                blink(binary);
                location++;
            }
            

        }

        private void blink(string binary)
        {
            int binLength = binary.Length - 1;
            
          //  Console.WriteLine("HERE");
        //    Console.WriteLine(binary);
            TimeSpan fadeInTime = new TimeSpan(0, 0, 0, 0, 500);
            TimeSpan fadeOutTime = new TimeSpan(0, 0, 0, 0, 500);
            var fadeInAnimation = new DoubleAnimation(0d, fadeInTime);
            var fadeOutAnimation = new DoubleAnimation(1d, fadeOutTime);
          //  fadeInAnimation.RepeatBehavior = new RepeatBehavior(count: 1);
            ArrayList list = new ArrayList();

            for (int i = 0; i < binLength; i++)
            {
                if (binary[i] == '1')
                {
                    list.Add(i);
                }
            }

           

            fadeOutAnimation.Completed += (o, e) =>
            {
             //   int count=list.Count-1;
              //  while (count >= 0)
              //  {
                for (int i = 0; i < binLength; i++)
                {
                    if (binary[i] == '1')
                    {
                        imgArray[i].Margin = new Thickness(600, 100 + i * 50, 0, 0);
                        imgArray[i].BeginAnimation(Image.OpacityProperty, fadeInAnimation);

                    }
                }
                  //  count = count - 1;
               // }
            };
            int count2 = list.Count - 1;
          //  while (count2 >= 0)
          //  {
            for (int i=0; i < binLength; i++)
            {
                if (binary[i] == '1')
                {
                    imgArray[i].Margin = new Thickness(600, 100 + i * 50, 0, 0);
                    imgArray[i].BeginAnimation(Image.OpacityProperty, fadeOutAnimation);

                }
            }

              /*  Console.WriteLine((int)list[count2]);
                imgArray[(int)list[count2]].Margin = new Thickness(600, 100 + (int)list[count2]*50, 0, 0);
                imgArray[(int)list[count2]].BeginAnimation(Image.OpacityProperty, fadeOutAnimation);
                count2 = count2 - 1;*/
         //   }
           // image.BeginAnimation(Image.OpacityProperty, fadeOutAnimation);
           

          /*  for (int i = 0; i < binLength; i++)
            {
                if (binary[i] == '1')
                {
                    list.Add(i);
                }
                 /*   fadeOutAnimation.Completed += (o, e) =>
                    {
                        if (binary[i] == '1')
                        {
                            imgArray[i].Margin = new Thickness(600, 300 + i * 60, 0, 0);
                            imgArray[i].BeginAnimation(Image.OpacityProperty, fadeInAnimation);
                        }
                    };*/
           /*     if (binary[i] == '1')
                {
                    imgArray[i].Margin = new Thickness(600, 300 + i * 60, 0, 0);
                    imgArray[i].BeginAnimation(Image.OpacityProperty, fadeOutAnimation);
                }
             
              
            }*/
           
        }

       

        public static string ConvertToBinary(char asciiString)
        {
            string result = string.Empty;

            result += Convert.ToString((int)asciiString, 2);

            return result;
        }

    }
}