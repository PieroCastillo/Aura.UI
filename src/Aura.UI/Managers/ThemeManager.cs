using Aura.UI.Attributes;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Styling;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlTypes;

namespace Aura.UI.Managers
{
    /// <summary>
    /// DO NOT USE THIS CLASS
    /// </summary>
    [Experimental]
    [InDeveloping]
    public class ThemeManager
    {
        public ThemeManager(Themes themes)
        {
            Themes = themes;


        }

        public Theme SelectedTheme { get; set; }

        public Themes Themes { get; set; }

        public bool ApplyOn<TControl>(TControl control,string ThemeID) where TControl : Control
        {
            try
            {
                var styles = Themes.Single(x => x.Name == ThemeID).Styles;
                control.Styles.AddRange(styles);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public void SaveThemes()
        {

        }
    }
    /// <summary>
    /// DO NOT USE THIS CLASS
    /// </summary>
    public struct Theme
    {
        public Theme(Styles styles, string name)
        {
            Styles = styles;
            Name = name;
        }

        public Styles Styles;
        public string Name;
    }
    /// <summary>
    /// DO NOT USE THIS CLASS
    /// </summary>
    public class Themes : AvaloniaList<Theme>, IList, IList<Theme>, IEnumerable, IEnumerable<Theme>
    {

    }
}
