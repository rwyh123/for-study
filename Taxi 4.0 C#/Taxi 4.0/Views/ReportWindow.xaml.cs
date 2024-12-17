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
using System.Windows.Shapes;
using Taxi_4._0.ViewModel;

namespace Taxi_4._0.Views
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow(ReportWindowViewModel reportWindowViewModel)
        {
            InitializeComponent();
            DataContext = reportWindowViewModel;
        }
        public ReportWindow()
        { 
        }
    }
}
