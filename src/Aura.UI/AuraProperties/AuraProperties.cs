using Avalonia;
using Avalonia.Controls;
using System;

namespace Aura.UI
{
    public partial class AuraProperties : AvaloniaObject
    {
        static AuraProperties()
        {
            HeaderTypeProperty.Changed.Subscribe(x =>
            {
                if (x.Sender is TextBlock tb)
                {
                    switch (GetHeaderType(tb))
                    {
                        case HeaderType.H1:
                            tb.FontSize = 32;
                            break;
                        case HeaderType.H2: 
                            tb.FontSize = 28;
                            break;
                        case HeaderType.H3: 
                            tb.FontSize = 18.72;
                            break;
                        case HeaderType.H4: 
                            tb.FontSize = 16;
                            break;
                        case HeaderType.H5:
                            tb.FontSize = 13.28;
                            break;
                        case HeaderType.H6: 
                            tb.FontSize = 10.72; 
                            break;
                        case HeaderType.None: return;
                    }
                }
            });
        }
        
        public static HeaderType GetHeaderType(TextBlock textBlock) => textBlock.GetValue(HeaderTypeProperty);
        public static void SetHeaderType(TextBlock textBlock, HeaderType value) => textBlock.SetValue(HeaderTypeProperty, value);
        
        public static readonly AttachedProperty<HeaderType> HeaderTypeProperty =
            AvaloniaProperty.RegisterAttached<AuraProperties, TextBlock, HeaderType>("HeaderType", HeaderType.None);
    }
}