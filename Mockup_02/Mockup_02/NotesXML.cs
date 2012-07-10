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

        public void addNote()
        {
            XmlNode notes;

            notes = xmlDoc.SelectSingleNode("/data/notes");

            XmlNode note = xmlDoc.CreateElement("note");
            XmlAttribute name = xmlDoc.CreateAttribute("naam");
            XmlAttribute mail = xmlDoc.CreateAttribute("mailadres");
            XmlAttribute time = xmlDoc.CreateAttribute("tijd");
            XmlAttribute date = xmlDoc.CreateAttribute("datum");
            note.InnerText = "De notitie waar het dan allemaal om gaat";
            note.Attributes.Append(name);
            note.Attributes.Append(mail);
            note.Attributes.Append(time);
            note.Attributes.Append(date);
            notes.PrependChild(note);

            xmlDoc.Save(@"C:\Users\s0139491\Documents\GitHub\Mockup_02\Mockup_02\Mockup_02\Mockup_02_Data.xml");
        }
	}
}