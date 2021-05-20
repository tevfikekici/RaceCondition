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

namespace RaceCondition
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Index();
            MessageBox.Show(result);
        }

        public int Count = 5;
        string result = "Password : ";

        static object locker = new object();

        public void Index()
        {
            Task t1 = Task.Factory.StartNew(SendStar);
            Task t2 = Task.Factory.StartNew(SendPlus);
            Task t3 = Task.Factory.StartNew(SendDolar);

            Task[] taskList = new Task[] { t1, t2, t3 };
            Task.WaitAll(taskList);
            
        }

        public void SendStar()
        {
            lock (locker)
            {
                for (int i = 0; i < Count; i++)
                {
                    Task.Delay(1000);
                    result += "*";
                }
            }
        }
        public void SendPlus()
        {
            lock (locker)
            {
                for (int i2 = 0; i2 < Count; i2++)
                {
                    Task.Delay(1000);
                    result += "+";
                }
            }
        }
        public void SendDolar()
        {
            lock (locker)
            {
                for (int i3 = 0; i3 < Count; i3++)
                {
                    Task.Delay(1000);
                    result += "$";
                }
            }
        }
    }
}
