using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.PubSubEvents;

namespace TaskAwaiting
{
    public partial class MainWindow : Window
    {
        private IEventAggregator _eventAggregator;
        private MainWindowViewModel _owner;

        public MainWindow()
        {
            InitializeComponent();
            _eventAggregator = new EventAggregator();
            _owner = new MainWindowViewModel(_eventAggregator);

            this.DataContext = _owner;
            _eventAggregator.GetEvent<UpdateTextboxEvent>().Subscribe(UpdateTextboxAction);

            _eventAggregator.GetEvent<MoveRectangleEvent>().Subscribe(MoveRectangleActoin);
        }

        private void MoveRectangleActoin(object obj)
        {
            _owner.ToggleRectangle();
        }

        private void UpdateTextboxAction(object obj)
        {
            _owner.Output += "Oh Hai there! " + DateTime.Now +"\n";
        }
    }
}