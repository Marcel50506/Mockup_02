using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Mockup_02
{
    public class Note
    {
        private String name;
        private String mail;
        private String time;
        private String date;
        private String note;

        public Note(String _name, String _mail, String _time, String _date, String _note)
        {
            this.Name = _name;
            this.Mail = _mail;
            this.Time = _time;
            this.Date = _date;
            this.Note_ = _note;
        }
        public Note()
        {

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Mail
        {
            get
            {
                return this.mail;
            }
            set
            {
                this.mail = value;
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public string Note_
        {
            get
            {
                return this.note;
            }
            set
            {
                this.note = value;
            }
        }
    }
}
