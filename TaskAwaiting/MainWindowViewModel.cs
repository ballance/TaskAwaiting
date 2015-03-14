using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;

namespace TaskAwaiting
{
    public class MainWindowViewModel : BindableBase
    {
        public MakeOutputCommand MakeOutput { get; private set; }

        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            MakeOutput = new MakeOutputCommand(eventAggregator);
            RectangleLocation = "Left";
        }
        private string _output;
        public string Output
        {
            get { return _output; }
            set { SetProperty(ref _output, value); }
        }

        private string _rectangleLocation;
        public string RectangleLocation
        {
            get { return _rectangleLocation; }
            set { SetProperty(ref _rectangleLocation, value); }
        }


        public void ToggleRectangle()
        {
            RectangleLocation = RectangleLocation == "Left" ? "Right" : "Left";
        }
    }
}
