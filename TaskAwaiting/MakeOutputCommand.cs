using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.PubSubEvents;

namespace TaskAwaiting
{
    public class MakeOutputCommand: ICommand
    {
        private IEventAggregator _eventAggregator;

        public MakeOutputCommand(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
            public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _eventAggregator.GetEvent<UpdateTextboxEvent>().Publish(DateTime.Now + " wheeee!\n");

            _eventAggregator.GetEvent<MoveRectangleEvent>().Publish(null);
        }

        public event EventHandler CanExecuteChanged;
    }


    public class MoveRectangleEvent : PubSubEvent<object>
    {
    }
}
