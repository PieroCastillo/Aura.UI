using Avalonia;
using Avalonia.Controls.Primitives;

namespace Aura.UI.Controls
{
    public class CardCollection : HeaderedItemsControl
    {
        public CardCollectionTileMode TileMode
        {
            get => GetValue(TileModeProperty);
            set => SetValue(TileModeProperty, value);
        }

        public static readonly StyledProperty<CardCollectionTileMode> TileModeProperty =
            AvaloniaProperty.Register<CardCollection, CardCollectionTileMode>(nameof(TileMode), CardCollectionTileMode.UniformDisposition);

        public bool ShowHeader
        {
            get => GetValue(ShowHeaderProperty);
            set => SetValue(ShowHeaderProperty, value);
        }

        public static readonly StyledProperty<bool> ShowHeaderProperty =
            AvaloniaProperty.Register<CardCollection, bool>(nameof(ShowHeader));

        public int Rows
        {
            get => GetValue(RowsProperty);
            set => SetValue(RowsProperty, value);
        }

        public static readonly StyledProperty<int> RowsProperty =
            AvaloniaProperty.Register<CardCollection, int>(nameof(Columns));

        public int Columns
        {
            get => GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }

        public static readonly StyledProperty<int> ColumnsProperty =
            AvaloniaProperty.Register<CardCollection, int>(nameof(Columns));
    }

    public enum CardCollectionTileMode
    {
        HorizontalDisposition,
        VerticalDisposition,
        UniformDisposition
    }
}