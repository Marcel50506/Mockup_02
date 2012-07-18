using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.XPath;
using MatlabGraph;

namespace Mockup_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller; 
        CollectionViewSource notesListView;
		
        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller(this);
            controller.Initialize();

            notesListView = (CollectionViewSource)(this.Resources["notesListView"]);
        }
		
		private void matLab1_Click(object sender, RoutedEventArgs e)
        {
            controller.matlabRun();
        }

        private void submitNote_btnClick(object sender, RoutedEventArgs e)
        {
            controller.addNote();
        }
    }
}
