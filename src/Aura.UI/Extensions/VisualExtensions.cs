using Avalonia;
using Avalonia.VisualTree;
using System.Linq;

namespace Aura.UI.Extensions
{
    public static class VisualExtensions
    {
        public static T? GetParentTOfVisual<T>(this Visual visual) where T : class
        {
            return visual.GetSelfAndVisualAncestors().OfType<T>().FirstOrDefault<T>();
        }
    }
}