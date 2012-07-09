using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Mockup_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		MatlabPort matlab;
        String path;
		
        public MainWindow()
        {
            InitializeComponent();
			
			path = System.IO.Directory.GetCurrentDirectory();
            matlab = new MatlabPort(path,image1,"test");
        }
		
		private void matLab1_Click(object sender, RoutedEventArgs e)
        {
            String val01 = input01.Text;
            matlab.matlabRun(val01);
        }
    }
}
