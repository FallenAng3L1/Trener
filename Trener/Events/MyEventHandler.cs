using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using JKang.EventBus;

namespace Trener.Events
{
    class MyEventHandler : IEventHandler<MyEvent>
    {
        public Task HandleEventAsync(MyEvent @event)
        {
            MessageBox.Show("Pomyślnie wprowadzono nową sesję.", _makeSessionViewModel.Name, MessageBoxButton.OK, MessageBoxImage.Information);
            @event.session.Time
            return Task.CompletedTask;
        }
    }
}
