using Aura.UI.Data;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuraTabViewMVVMSample.ViewModels
{
    public class TabItemVM : ViewModelBase, IAuraTabItemTemplate
    {
        public object Content { get; set; }

        public object Header { get; set; }

        public bool IsClosable { get; set; } = false;

        public IImage? Icon => null;
    }
}
