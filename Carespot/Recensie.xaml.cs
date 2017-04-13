using System.Windows;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for Recensie.xaml
    /// </summary>
    public partial class Recensie : Window
    {
        public Recensie()
        {
            InitializeComponent();
            //laad vrijwilliger
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //voeg recensie toe aan vrijwilliger
        }

        private void sldRating_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblRating.Content = sldRating.Value.ToString();
        }
    }
}