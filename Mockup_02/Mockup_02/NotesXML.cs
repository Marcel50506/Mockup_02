using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mockup_02
{
	public class NotesXML
	{
        XmlDocument xmlDoc;

		public NotesXML()
		{
            xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\Users\s0139491\Documents\GitHub\Mockup_02\Mockup_02\Mockup_02\Mockup_02_Data.xml");	
        }

        public void addNote(String _note)
        {
            XmlNode notes;

            notes = xmlDoc.SelectSingleNode("/data/notes");

            XmlNode note = xmlDoc.CreateElement("note");
            XmlAttribute name = xmlDoc.CreateAttribute("name");
			name.Value = "Marcel Melching";
            XmlAttribute mail = xmlDoc.CreateAttribute("mail");
			mail.Value = "m.melching@company.com";
            XmlAttribute time = xmlDoc.CreateAttribute("time");
			time.Value = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            XmlAttribute date = xmlDoc.CreateAttribute("date");
			date.Value = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year; 
            note.InnerText = _note;
            note.Attributes.Append(name);
            note.Attributes.Append(mail);
            note.Attributes.Append(time);
            note.Attributes.Append(date);
            notes.PrependChild(note);

            xmlDoc.Save(@"C:\Users\s0139491\Documents\GitHub\Mockup_02\Mockup_02\Mockup_02\Mockup_02_Data.xml");
			
			
        }
	}
}