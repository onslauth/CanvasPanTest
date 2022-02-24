using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CanvasPanTest.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage : Page
    {
        private Image image;

        public TestPage( )
        {
            this.InitializeComponent( );
        }

        private void image_PointerWheelChanged( object sender, PointerRoutedEventArgs e )
        {
            this.UpdateLayout();
            System.Diagnostics.Debug.WriteLine( "Mousewheel scrolled" );
            var width = image.ActualWidth;
            var height = image.ActualHeight;

            System.Diagnostics.Debug.WriteLine( $"Width: {0}, Height: {1}", width, height );

            this.image.Measure( new Size( double.PositiveInfinity, double.PositiveInfinity ) );
            width = this.image.ActualWidth;
            height = this.image.ActualHeight;

            System.Diagnostics.Debug.WriteLine( $"Width: {0}, Height: {1}", width, height );

        }

        private void TestPage_Loaded( object sender, RoutedEventArgs e )
        {
            System.Diagnostics.Debug.WriteLine( "Page Loaded" );
            image = new Image( );
            image.ImageOpened += Image_ImageOpened;
            image.Source = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage( new System.Uri( "ms-appx:/Assets/test.jpg" ) );
            canvas.Children.Add( image );

            image.PointerWheelChanged += image_PointerWheelChanged;
        }

        private void Image_ImageOpened( object sender, RoutedEventArgs e )
        {
            System.Diagnostics.Debug.WriteLine( $" image.height: {0}", image.Height );
        }

        private void Grid_Loaded( object sender, RoutedEventArgs e )
        {
            System.Diagnostics.Debug.WriteLine( $"Grid.Height = {0}", grid.ActualHeight );
        }
    }
}
