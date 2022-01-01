using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace Aura.UI.Extensions
{
    public static class TemplatedControlExtensions
    {
        /// <summary>
        /// Gets a control
        /// </summary>
        /// <typeparam name="T">Type of the Control to get</typeparam>
        /// <param name="templatedControl">TemplatedControl owner of the Indicated Control</param>
        /// <param name="e">The TemplateAppliedEventArgs</param>
        /// <param name="name">The Name of the Control to return</param>
        /// <returns>a control with the indicated params</returns>
        public static T GetControl<T>(this TemplatedControl templatedControl,
                                    TemplateAppliedEventArgs e,
                                    string name)
            where T : AvaloniaObject
            => e.NameScope.Find<T>(name);

        /// <summary>
        /// Gets a control
        /// </summary>
        /// <typeparam name="T">Type of the Control to get</typeparam>
        /// <param name="templatedControl">TemplatedControl owner of the Indicated Control</param>
        /// <param name="e">The TemplateAppliedEventArgs</param>
        /// <param name="name">The Name of the Control to return</param>
        /// <param name="avaloniaObj">a control with the indicated params</param>
        public static void GetControl<T>(
            this TemplatedControl templatedControl,
            TemplateAppliedEventArgs e,
            string name,
            out T avaloniaObj) where T : AvaloniaObject
            => avaloniaObj = GetControl<T>(templatedControl, e, name);
    }
}