using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace Aura.UI.Extensions
{
    public static class TemplatedControlExtensions
    {
        /// <summary>
        /// Get an control in the indicated template, this method can be within "protected overrive void OnTemplateApplied(e)" method only
        /// </summary>
        /// <typeparam name="T">Type of the Control to return</typeparam>
        /// <param name="templatedControl">TemplatedControl owner of the IndicatedControl</param>
        /// <param name="e">The TemplateAppliedEventArgs</param>
        /// <param name="name">The Name of the Control to return</param>
        /// <returns>a control with the indicated params</returns>
        public static T GetControl<T>(this TemplatedControl templatedControl,
                                    TemplateAppliedEventArgs e,
                                    string name) 
            where T : AvaloniaObject
            => e.NameScope.Find<T>(name);
    }
}