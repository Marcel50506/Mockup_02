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
using MatlabGraph;

namespace Mockup_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		MatlabPort matlab1;
        NotesXML notes;
		
        public MainWindow()
        {
            InitializeComponent();

            matlab1 = new MatlabPort(input1, image1, "test1","(sqrt(x))");

            //add note
            notes = new NotesXML();
            //notes.addNote();
        }
		
		private void matLab1_Click(object sender, RoutedEventArgs e)
        {
            matlab1.matlabRun();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            notes.addNote();
        }
    }
}
