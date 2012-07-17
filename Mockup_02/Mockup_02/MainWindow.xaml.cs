using System;
using System.Collections;
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
		MatlabPort matlabPort;

        XmlHandler xmlHandler;
		
        public MainWindow()
        {
            InitializeComponent();

            //add the MatlabPort to run matlab
            matlabPort = new MatlabPort(input1, image1, "test1","(sqrt(x)^y)");

            //add the XmlHandler
            xmlHandler = new XmlHandler(this);
        }
		
		private void matLab1_Click(object sender, RoutedEventArgs e)
        {
            matlabPort.matlabRun();
        }

        private void submitNote_btnClick(object sender, RoutedEventArgs e)
        {
            xmlHandler.addNote(noteBox.Text);
        }
    }
}
