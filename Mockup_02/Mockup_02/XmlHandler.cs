using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class XmlHandler
	{
        XmlDocument xmlDoc;
        Controller controller;

        Note newNote;

        public XmlHandler()
		{
            xmlDoc = new XmlDocument();

            xmlDoc.Load(@"C:\Users\s0139491\Documents\GitHub\Mockup_02\Mockup_02\Mockup_02\Mockup_02_Data.xml");
        }

        public void Initialize(Controller _controller) 
        {
            controller = _controller;

            createNotesFromXml();
        }
        
        public void addNoteToXml(String _note)
        {
            String note = _note;

            XmlNode xmlNotes;

            xmlNotes = xmlDoc.SelectSingleNode("/data/notes");

            XmlNode newNote = xmlDoc.CreateElement("note");
            XmlAttribute name = xmlDoc.CreateAttribute("name");
			name.Value = "Marcel Melching";
            XmlAttribute mail = xmlDoc.CreateAttribute("mail");
			mail.Value = "m.melching@company.com";
            XmlAttribute time = xmlDoc.CreateAttribute("time");
			time.Value = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            XmlAttribute date = xmlDoc.CreateAttribute("date");
			date.Value = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year; 
            newNote.InnerText = note;
            newNote.Attributes.Append(name);
            newNote.Attributes.Append(mail);
            newNote.Attributes.Append(time);
            newNote.Attributes.Append(date);
            xmlNotes.PrependChild(newNote);

            xmlDoc.Save(@"C:\Users\s0139491\Documents\GitHub\Mockup_02\Mockup_02\Mockup_02\Mockup_02_Data.xml");

        }

        public void createNotesFromXml()
        {
            XmlNodeList nodeList = xmlDoc.SelectNodes("//note");
            foreach (XmlNode n in nodeList)
            {
                newNote = new Note();
                newNote.Name = n.Attributes["name"].Value;
                newNote.Mail = n.Attributes["mail"].Value;
                newNote.Time = n.Attributes["time"].Value;
                newNote.Date = n.Attributes["date"].Value;
                newNote.Note_ = n.InnerText;

                controller.addInitialNotes(newNote);
            }
        }
	}
}