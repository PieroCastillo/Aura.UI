using System.Windows.Input;

namespace Aura.UI.Data
{
    public interface ICardControlTemplate
    {
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }
        public object Header { get; set; }
        public object SecondaryHeader { get; set; }
        public object Content { get; set; }
    }
}