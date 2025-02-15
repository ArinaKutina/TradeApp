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
using TradeApp.DB;
using TradeApp.Views;

namespace TradeApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int idUser {  get; set; }
        int idRole { get; set; }
        TradeBaseEntities tradeBase = new TradeBaseEntities();
        private int failedAttempts = 0;
        private const int maxFailedAttempts = 3;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text != null && PassBox.Password != null)
            {
                try
                {
                    var id = tradeBase.User.Where(p => p.UserLogin == LoginBox.Text && p.UserPassword == PassBox.Password).Select(p => new { p.UserID, p.RoleID }).Single();
                    failedAttempts = 0;
                    if (id.RoleID == 1)
                    {
                        AdminWindow adminWin = new AdminWindow();
                        Close();
                        adminWin.Show();
                    }
                    else if (id.RoleID == 2)
                    {
                        ManagerWindow manageWindow = new ManagerWindow();
                        Close();
                        manageWindow.Show();
                    }
                    else if (id.RoleID == 3)
                    {                       
                        ClientWindow clientWindow = new ClientWindow(id.UserID, id.RoleID);
                        Close();
                        clientWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели неккоректные данные");
                    }
                }
                catch
                {
                    failedAttempts++;
                    MessageBox.Show("Неверный логин или пароль");
                    if (failedAttempts >= maxFailedAttempts)
                    {
                        CaptchaWindow captchaWindow = new CaptchaWindow();
                        captchaWindow.ShowDialog();
                        failedAttempts = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter the username and password of the user!");
            }
        }

        private void LogInAsGuestBtn_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow guestWindow = new GuestWindow();
            guestWindow.Show();
            this.Close();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
        
            
