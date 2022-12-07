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

namespace PZ12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filename;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            Create create = new Create();
            if (create.ShowDialog() == true)
                filename = create.FileName;

        }
    }
}
