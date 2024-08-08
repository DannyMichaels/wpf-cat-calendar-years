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
        public TextBlock txtBlockResult;
        public TextBox txtCatAge;
        StackPanel pnlMainVerticalStackPanel;

        public MainWindow()
        {
            InitializeComponent();

            Image imgBackground = new Image() { Source = new BitmapImage(new Uri("pack://application:,,,/Images/cat.jpg")) };
            imgBackground.Width = 200;
            imgBackground.Height = 200;
            txtBlockResult = new TextBlock() { Text = "Your cat is" , FontSize = 18 };

            txtCatAge = new TextBox() 
            { 
                Width = 120, 
                Height = 30, 
                TextAlignment = TextAlignment.Center, 
                FontSize = 16,
                Margin = new Thickness(5, 0, 0, 0)
            };

            txtCatAge.KeyDown += txtCatAge_KeyDown;

            TextBlock txtBlockUserQuestion = new TextBlock() { Text = "How old is your cat?", FontSize = 18 };

            StackPanel pnlHorizontalStackPanel = new StackPanel() { 
                Orientation = Orientation.Horizontal, 
                Margin =  new Thickness(1,5,0,0)
            };

            pnlHorizontalStackPanel.Children.Add(txtBlockUserQuestion);
            pnlHorizontalStackPanel.Children.Add(txtCatAge);

            pnlMainVerticalStackPanel = new StackPanel() { Orientation = Orientation.Vertical, HorizontalAlignment = HorizontalAlignment.Left};
            pnlMainVerticalStackPanel.Children.Add(pnlHorizontalStackPanel);
            pnlMainVerticalStackPanel.Children.Add(txtBlockResult);
            pnlMainVerticalStackPanel.Children.Add(imgBackground);

            windowMain.Content = pnlMainVerticalStackPanel;
        }

        /// <summary>
        /// Handle the enter key pressed on textbox event, calculate the human age of the cat and display the result.
        /// </summary>
        private void HandleSubmit()
        {
            try
            {
                int iCatAge = Int32.Parse(txtCatAge.Text);
                string sResultHumanAge = "";

                if (iCatAge >= 0 && iCatAge <= 1)
                {
                    sResultHumanAge = "0-15";
                    txtBlockResult.Text = "Your cat is " + sResultHumanAge + " years old in human years.";
                }
                else if (iCatAge >= 2 && iCatAge < 25)
                {
                    sResultHumanAge = ((iCatAge - 2) * 4 + 24).ToString();
                    txtBlockResult.Text = "Your cat is " + sResultHumanAge + " years old in human years.";
                }
                else
                {
                    txtBlockResult.Text = "You entered a valuie that is not between 0-25. " +
                                             "Your cat must be super old or not yet born!";
                }

                TextBlock txtBlockExtra = new TextBlock() { Text = "Underneath the cat", FontSize = 18 };
                pnlMainVerticalStackPanel.Children.Add(txtBlockExtra);
                Button btnDeleteExtra = new Button() { Content = "Delete Extra" };
                btnDeleteExtra.Click += (sender, e) => pnlMainVerticalStackPanel.Children.Remove(txtBlockExtra);
                pnlMainVerticalStackPanel.Children.Add(btnDeleteExtra);
            }
            catch (Exception exception)
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