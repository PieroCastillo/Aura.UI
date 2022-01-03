using Avalonia.ReactiveUI;
using Avalonia.Web.Blazor;

namespace Aura.UI.Gallery.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        WebAppBuilder.Configure<Aura.UI.Gallery.App>()
            .UseReactiveUI()
            .SetupWithSingleViewLifetime();
    }
}