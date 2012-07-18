using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MatlabGraph;

namespace Mockup_02
{
    public class Controller
    {
        MatlabPort matlabPort;
        XmlHandler xmlHandler;
        MainWindow mainWindow;
        ObservableCollection<Note> noteCollection;

        public Controller(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;

            noteCollection = new ObservableCollection<Note>();

            //add the MatlabPort to run matlab
            matlabPort = new MatlabPort(mainWindow.image1, "test1", "(sqrt(x)^y)");

            //add the XmlHandler
            xmlHandler = new XmlHandler();
        }

        public void Initialize(){
            xmlHandler.Initialize(this);
        }

        public void addInitialNotes(Note _note)
        {
            Note newNote = _note;
            noteCollection.Add(newNote);
        }

        public void addNote()
        {
            String _text = mainWindow.noteBox.Text;

            Note n = new Note("Marcel Melching",
                "m.melching@company.com",
                DateTime.Now.Hour + ":" + DateTime.Now.Minute,
                DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year,
                _text);
            xmlHandler.addNoteToXml(_text);
        }

        public void matlabRun()
        {
            matlabPort.matlabRun(mainWindow.input1.Text);
        }
    }
}
