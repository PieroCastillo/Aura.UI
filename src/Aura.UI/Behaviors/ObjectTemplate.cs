using Avalonia.Metadata;
using Avalonia.Styling;
using System;

namespace Aura.UI.Behaviors
{
    public class ObjectTemplate : ITemplate
    {
        [Content]
        [TemplateContent]
        public object? Content { get; set; }

        object? ITemplate.Build()
        {
            if (Content is Func<IServiceProvider, object> direct)
            {
                return direct(null!);
            }
            throw new ArgumentException(nameof(Content));
        }
    }
}