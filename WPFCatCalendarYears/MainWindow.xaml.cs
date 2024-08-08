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

namespace WPFCatCalendarYears
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HandleSubmit()
        {
            try
            {
                int iCatAge = Int32.Parse(txtCatAge.Text);
                string sResultHumanAge = "";

                if (iCatAge >= 0 && iCatAge <= 1)
                {
                    sResultHumanAge = "0-15";
                    resultTextBlock.Text = "Your cat is " + sResultHumanAge + " years old in human years.";
                } else if (iCatAge >=2 && iCatAge <25)
                {
                     sResultHumanAge = ((iCatAge - 2) * 4 + 24).ToString();
                    resultTextBlock.Text = "Your cat is " + sResultHumanAge + " years old in human years.";
                } else
                {
                    resultTextBlock.Text = "You entered a valuie that is not between 0-25. " +
                                             "Your cat must be super old or not yet born!";
                }

            } catch (Exception exception)
            {
                MessageBox.Show("Not a valid number, please enter a numberic value! " + exception.Message);
            }
        }

        private void txtCatAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                HandleSubmit();
            }
        }
    }
}