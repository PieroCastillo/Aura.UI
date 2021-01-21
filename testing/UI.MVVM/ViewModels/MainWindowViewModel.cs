using Avalonia.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using Aura.UI.Controls;

namespace UI.MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";

        public IEnumerable<object> items
        {
            get => new AvaloniaList<object>
            {
                new AuraTabItem{ Header = "Tab 1" },
                new AuraTabItem{ Header = "Tab 2" },
                new AuraTabItem{ Header = "Tab 3" },
                new AuraTabItem{ Header = "Tab 4" }
            };
        }
    }
}
