using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class ToDoModel: INotifyPropertyChanged
    {
        private string _text;
        private bool _isDone;

        [JsonProperty(PropertyName = "creationData")]
        //public DateTime CreationData { get; set; } = DateTime.Now;      - Оригинал
        public string CreationData
        {
            get
            {
                DateTime dateTimeNow = DateTime.Now;
                return dateTimeNow.ToShortDateString();
            }
            set{return;}
        }


        [JsonProperty(PropertyName = "isDone")]
        public bool IsDone
        { 
            get { return _isDone; }
            set 
            { if (_isDone == value)
                    return;
                _isDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        [JsonProperty(PropertyName = "text")]
        public string Text 
        {
            get { return _text; } 
            set
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
