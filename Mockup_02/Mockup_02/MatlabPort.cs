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
using System.IO;
using System.Net.Cache;
using System.Diagnostics;
using MLApp;

namespace MatlabGraph
{
    class MatlabPort
    {
        private MLApp.MLApp matlabExe;
        int iter;
        Image image;
        String input;
        String path;
        String name;
        String function;

        //Constructor needs the path, an Image container, and a string, which will be the name of the image in the /img folder
        public MatlabPort(Image _image, String _str, String _function)
        {
            name = _str;
            image = _image;

            path = System.IO.Path.GetTempPath() + "matlabPort\\";

            System.IO.Directory.CreateDirectory(path);

            //Define the image name
            name = _str;

            //Create a Matlab instance
            matlabExe = new MLApp.MLApp();

            //Set the image container
            image = _image;

            //set the current function
            function = "h = @(x) "+ _function + ";";
        }

        //Runner will only neet a string for the designated value change
        public void matlabRun(String _input)
        {
			//function = "h = @(x) "+ input.Text + ";";

            input = _input;

            //Set the matlab directory right
            matlabExe.Execute("cd " + path + ";");

            //Define the parameters for the name (filename) and parameter
            matlabExe.Execute("name  = '" + name + iter + "';");
            matlabExe.Execute("y  = " + input + ";");
            matlabExe.Execute(function);
            matlabExe.Execute("figh = ezplot(h);");
            matlabExe.Execute("set(figh,'Color','red','linewidth',3);");
            matlabExe.Execute("set(gca,'linewidth', 2);");
            matlabExe.Execute("set(gcf,'visible','off');");
            matlabExe.Execute("saveas(gcf,name,'png');");
            
            refresh();
        }

        public void refresh()
        {
            //Renew the image source
            image.Source = new BitmapImage(new Uri(path + name + iter + ".png", UriKind.Absolute));

            //Delete old image (3 images back)
            if (File.Exists(path + name + (iter - 3) + ".png"))
            {
                File.Delete(path + name + (iter - 3) + ".png");
            }

            //Set counter for next iteration
            iter++;
        }
    }
}
