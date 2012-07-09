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

namespace Mockup_02
{
    class MatlabPort
    {
        private MLApp.MLApp matlabExe;
        Image image;
		int iter;
        String path;
        String imPath; //The path where the images are at (path + \img)
        String name;
        String temp;

        //Constructor needs the path, an Image container, and a string, which will be the name of the image in the /img folder
        public MatlabPort(String _path, Image _image, string _str)
        {
            //Define the image path
            path = _path;
            imPath = _path + @"\img\";
            
            System.IO.Directory.CreateDirectory(imPath);

            //Define the image name
            name = _str;

            //Create a Matlab instance
            matlabExe = new MLApp.MLApp();

            //Set the image container
            image = _image;
        }

        //Runner will only neet a string for the designated value change
        public void matlabRun(String par)
        {
            //Set the matlab directory right
            matlabExe.Execute("cd " + imPath + ";");

            //Define the parameters for the name (filename) and parameter
            matlabExe.Execute("name  = '" + name + iter + "';");
            temp = "y  = " + par + ";";
            matlabExe.Execute(temp);

            //Run the script
            matlabExe.Execute("matScript");
            
            refresh();
        }

        public void refresh()
        {
            //Renew the image source
            image.Source = new BitmapImage(new Uri(imPath + name + iter + ".png", UriKind.Absolute));

            //Delete old image (3 images back)
            if (File.Exists(imPath + name + (iter - 3) + ".png"))
            {
                File.Delete(imPath + name + (iter - 3) + ".png");
            }

            //Set counter for next iteration
            iter++;
        }
    }
}
