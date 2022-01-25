using JetBrains.Annotations;
using System.Windows.Input;

namespace Aura.UI.Data
{
    public interface ICardControlTemplate
    {
        public ICommand Command { get; set; }
        [CanBeNull] public object CommandParameter { get; set; }
        public object Header { get; set; }
        public object SecondaryHeader { get; set; }
        public object Content { get; set; }
    }
}