using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GhostNews.Models
{
    public class CarouselItem : INotifyPropertyChanged
    {
        double _xopacity;
        double _position;

        public double Ring { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public string ButtonText { get; set; }


        public CarouselItem()
        {
            XOpacity = 1;
        }

        public double Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }
        public double XOpacity
        {
            get => _xopacity;
            set
            {
                _xopacity = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
