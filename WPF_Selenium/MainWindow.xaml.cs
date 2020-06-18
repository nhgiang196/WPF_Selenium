using OpenQA.Selenium.Chrome;
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
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WPF_Selenium
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChromeDriver cDriver = new ChromeDriver();
            
            cDriver.Url = "http://localhost:4200/#/";
            cDriver.Navigate();
            try
            {
                cDriver.FindElementByName("Username").SendKeys("giang.nh");
                cDriver.FindElementByName("Password").SendKeys("ASDFLKJ");
                var button = cDriver.FindElementByClassName("btn-primary");
                button.Click();
                WebDriverWait wait = new WebDriverWait(cDriver, TimeSpan.FromSeconds(1));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("version_button")));
                cDriver.FindElementById("version_button").Click();
                lbComplete.Background = Brushes.Green;
            }
            catch (Exception)
            {
                lbComplete.Background = Brushes.Red;
            }
            cDriver.Quit();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
