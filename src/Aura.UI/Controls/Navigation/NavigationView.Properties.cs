﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Media;
using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Navigation
{
    public partial class NavigationView
    {

        #region Properties
        /// <summary>
        /// Get or set the expansion state of the NavigationView
        /// </summary>
        public bool IsOpen
        {
            get { return GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }
        public static readonly StyledProperty<bool> IsOpenProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(IsOpen), false);

        public IBrush PaneBackground
        {
            get => GetValue(PaneBackgroundProperty);
            set => SetValue(PaneBackgroundProperty, value);
        }
        public static readonly StyledProperty<IBrush> PaneBackgroundProperty =
            AvaloniaProperty.Register<NavigationView, IBrush>(nameof(PaneBackground));

        public bool AlwaysOpen
        {
            get { return GetValue(AlwaysOpenProperty); }
            set { SetValue(AlwaysOpenProperty, value); }
        }
        public static readonly StyledProperty<bool> AlwaysOpenProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(AlwaysOpen), false);

        public IImage HeaderIcon
        {
            get => GetValue(HeaderIconProperty);
            set => SetValue(HeaderIconProperty, value);
        }
        public static readonly StyledProperty<IImage> HeaderIconProperty =
            AvaloniaProperty.Register<NavigationView, IImage>(nameof(HeaderIcon));

        /// <summary>
        /// Defines the Material for the AcrylicBorder in the Template
        /// </summary>
        public ExperimentalAcrylicMaterial Material
        {
            get { return GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }
        public static readonly StyledProperty<ExperimentalAcrylicMaterial> MaterialProperty =
            AvaloniaProperty.Register<NavigationView, ExperimentalAcrylicMaterial>(nameof(Material),
                new ExperimentalAcrylicMaterial()
                {
                    TintColor = Colors.White,
                    MaterialOpacity = 0.85,
                    TintOpacity = 0.85
                });
        /// <summary>
        /// Defines if the Material can be visible
        /// </summary>
        public bool MaterialIsVisible
        {
            get { return GetValue(MaterialIsVisibleProperty); }
            set { SetValue(MaterialIsVisibleProperty, value); }
        }
        public static readonly StyledProperty<bool> MaterialIsVisibleProperty =
             AvaloniaProperty.Register<NavigationView, bool>(nameof(MaterialIsVisible), true);
        public object Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public static readonly StyledProperty<object> TitleProperty =
            AvaloniaProperty.Register<NavigationView, object>(nameof(Title), "Title");

        public ITemplate TitleTemplate
        {
            get => GetValue(TitleTemplateProperty);
            set => SetValue(TitleTemplateProperty, value);
        }
        public static readonly StyledProperty<ITemplate> TitleTemplateProperty =
            AvaloniaProperty.Register<NavigationView, ITemplate>(nameof(TitleTemplate));

        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
        public static readonly StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<NavigationView, object>(nameof(Header), "Navigation View");

        public ITemplate HeaderTemplate
        {
            get => GetValue(HeaderTemplateProperty);
            set => SetValue(HeaderTemplateProperty, value);
        }
        public static readonly StyledProperty<ITemplate> HeaderTemplateProperty =
            AvaloniaProperty.Register<NavigationView, ITemplate>(nameof(HeaderTemplate));

        public double CompactPaneLength
        {
            get => GetValue(CompactPaneLengthProperty);
            set => SetValue(CompactPaneLengthProperty, value);
        }
        public static readonly StyledProperty<double> CompactPaneLengthProperty =
            AvaloniaProperty.Register<NavigationView, double>(nameof(CompactPaneLength), 150);

        public double OpenPaneLength
        {
            get => GetValue(OpenPaneLengthProperty);
            set => SetValue(OpenPaneLengthProperty, value);
        }
        public static readonly StyledProperty<double> OpenPaneLengthProperty =
            AvaloniaProperty.Register<NavigationView, double>(nameof(OpenPaneLength), 50);
        #endregion
    }
}