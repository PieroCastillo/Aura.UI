using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;

namespace Aura.UI.Dragging
{
    public class ControlObject : IDataObject
    {
        public ControlObject(Control data)
        {
            Source = data;
        }
        
        public Control Source
        {
            get;
            private set;
        }
        
        public IEnumerable<string> GetDataFormats()
        {
            return new List<string>(){nameof(Control)};
        }

        public bool Contains(string dataFormat)
        {
            if (dataFormat == nameof(Control))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string? GetText()
        {
            return nameof(Control);
        }

        public IEnumerable<string>? GetFileNames()
        {
            return null;
        }

        public object? Get(string dataFormat)
        {
            return Source;
        }
    }
}