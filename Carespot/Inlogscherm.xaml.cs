using System.Windows;
using Carespot.DAL.Repositorys;

namespace Carespot
{
    /// <summary>
    ///     Interaction logic for Inlogscherm.xaml
    /// </summary>
    public partial class Inlogscherm : Window
    {
        public Inlogscherm()
        {
            InitializeComponent();
        }

        private void btAanmelden_Click(object sender, RoutedEventArgs e)
        {
            //'GebruikerAanmaken' openen
            var aanmaken = new GebruikerAanmaken();
            aanmaken.Show();
            Close();
        }

        private void btInloggen_Click(object sender, RoutedEventArgs e)
        {
            //Controleer gegevens en log in, indien er meerdere soorten gebruik binnen die persoon mogelijk zijn, opent eerst het scherm 'Keuzescherm'
            if (AuthRepository.CheckAuth(tbEmail.Text, pbWachtwoord.Password))
                MessageBox.Show("ey");
            else
                MessageBox.Show("Foute inloggegevens.");
        }
    }
}