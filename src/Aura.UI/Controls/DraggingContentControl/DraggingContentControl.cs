using System;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Metadata;

namespace Aura.UI.Controls
{
    /// <summary>
    /// DraggingContentControl, can be dragged within a <see cref="Canvas"/>
    /// </summary>
    public class DraggingContentControl : Thumb, IContentControl, IContentPresenterHost
    {
        /// <summary>
        /// Defines the <see cref="Content"/> property.
        /// </summary>
        public static readonly StyledProperty<object> ContentProperty =
            ContentControl.ContentProperty.AddOwner<DraggingContentControl>();

        /// <summary>
        /// Defines the <see cref="ContentTemplate"/> property.
        /// </summary>
        public static readonly StyledProperty<IDataTemplate> ContentTemplateProperty =
            ContentControl.ContentTemplateProperty.AddOwner<DraggingContentControl>();

        /// <summary>
        /// Defines the <see cref="HorizontalContentAlignment"/> property.
        /// </summary>
        public static readonly StyledProperty<HorizontalAlignment> HorizontalContentAlignmentProperty =
            ContentControl.HorizontalContentAlignmentProperty.AddOwner<DraggingContentControl>();

        /// <summary>
        /// Defines the <see cref="VerticalContentAlignment"/> property.
        /// </summary>
        public static readonly StyledProperty<VerticalAlignment> VerticalContentAlignmentProperty =
            ContentControl.VerticalAlignmentProperty.AddOwner<DraggingContentControl>();

        static DraggingContentControl()
        {
            ContentProperty.Changed.AddClassHandler<DraggingContentControl>((x, e) => x.ContentChanged(e));
            Canvas.LeftProperty.OverrideDefaultValue<DraggingContentControl>(0);
            Canvas.TopProperty.OverrideDefaultValue<DraggingContentControl>(0);
        }

        /// <summary>
        /// Gets or sets the content to display.
        /// </summary>
        [Content]
        [DependsOn(nameof(ContentTemplate))]
        public object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        /// <summary>
        /// Gets or sets the data template used to display the content of the control.
        /// </summary>
        public IDataTemplate ContentTemplate
        {
            get => GetValue(ContentTemplateProperty);
            set => SetValue(ContentTemplateProperty, value);
        }

        /// <summary>
        /// Gets the presenter from the control's template.
        /// </summary>
        public IContentPresenter Presenter
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the horizontal alignment of the content within the control.
        /// </summary>
        public HorizontalAlignment HorizontalContentAlignment
        {
            get => GetValue(HorizontalContentAlignmentProperty);
            set => SetValue(HorizontalContentAlignmentProperty, value);
        }

        /// <summary>
        /// Gets or sets the vertical alignment of the content within the control.
        /// </summary>
        public VerticalAlignment VerticalContentAlignment
        {
            get => GetValue(VerticalContentAlignmentProperty);
            set => SetValue(VerticalContentAlignmentProperty, value);
        }

        /// <inheritdoc/>
        IAvaloniaList<ILogical> IContentPresenterHost.LogicalChildren => LogicalChildren;

        /// <inheritdoc/>
        bool IContentPresenterHost.RegisterContentPresenter(IContentPresenter presenter)
        {
            return RegisterContentPresenter(presenter);
        }

        /// <summary>
        /// Called when an <see cref="IContentPresenter"/> is registered with the control.
        /// </summary>
        /// <param name="presenter">The presenter.</param>
        protected virtual bool RegisterContentPresenter(IContentPresenter presenter)
        {
            if (presenter.Name == "PART_ContentPresenter")
            {
                Presenter = presenter;
                return true;
            }

            return false;
        }

        private void ContentChanged(AvaloniaPropertyChangedEventArgs e)
        {
            if (e.OldValue is ILogical oldChild)
            {
                LogicalChildren.Remove(oldChild);
            }

            if (e.NewValue is ILogical newChild)
            {
                LogicalChildren.Add(newChild);
            }
        }

        protected override void OnDragDelta(VectorEventArgs e)
        {
            //base.OnDragDelta(e);

            double delta_v, delta_h;

            switch (e.Vector.Y < Bounds.Height - MinHeight)
            {
                case true:
                    delta_v = e.Vector.Y;
                    break;
                case false:
                    delta_v = Bounds.Height - MinHeight;
                    break;
            }
            switch (e.Vector.X < Bounds.Width + MinWidth)
            {
                case true:
                    delta_h = e.Vector.X;
                    break;
                case false:
                    delta_h = Bounds.Width - MinWidth;
                    break;
            }

            Canvas.SetTop(this, Canvas.GetTop(this) + delta_v);
            Canvas.SetLeft(this, Canvas.GetLeft(this) + delta_h);
        }
    }
}