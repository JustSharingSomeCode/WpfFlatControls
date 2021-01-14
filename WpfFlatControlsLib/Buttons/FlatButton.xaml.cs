using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WpfFlatControlsLib.Labels;

namespace WpfFlatControlsLib.Buttons
{
    /// <summary>
    /// Lógica de interacción para FlatButton.xaml
    /// </summary>
    public partial class FlatButton : UserControl
    {
        public FlatButton()
        {
            InitializeComponent();
        }

        #region Click
        private bool IsPressed = false;
        public delegate void OnClick(object sender);
        public event OnClick Click;
        #endregion

        #region BackgroundProperty
        [Category("FlatButton Properties")]
        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Background.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(FlatButton), new PropertyMetadata(Brushes.Gray));
        #endregion

        #region IconBackgroundProperty
        [Category("FlatButton Properties")]
        public Brush IconBackground
        {
            get { return (Brush)GetValue(IconBackgroundProperty); }
            set { SetValue(IconBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconBackgroundProperty =
            DependencyProperty.Register("IconBackground", typeof(Brush), typeof(FlatButton), new PropertyMetadata(Brushes.DarkGray));
        #endregion

        #region ForegroundProperty
        [Category("FlatButton Properties")]
        public new Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Foreground.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(Brush), typeof(FlatButton), new PropertyMetadata(Brushes.Black));
        #endregion

        #region IconForegroundProperty
        [Category("FlatButton Properties")]
        public Brush IconForeground
        {
            get { return (Brush)GetValue(IconForegroundProperty); }
            set { SetValue(IconForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Foreground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconForegroundProperty =
            DependencyProperty.Register("IconForeground", typeof(Brush), typeof(FlatButton), new PropertyMetadata(Brushes.Black));
        #endregion

        #region BorderBrushProperty
        [Category("FlatButton Properties")]
        public new Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderBrush.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(FlatButton), new PropertyMetadata(Brushes.Black));
        #endregion

        #region TextProperty
        [Category("FlatButton Properties")]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(FlatButton), new PropertyMetadata("Button"));
        #endregion

        #region IconTextProperty
        [Category("FlatButton Properties")]
        public string IconText
        {
            get { return (string)GetValue(IconTextProperty); }
            set { SetValue(IconTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconTextProperty =
            DependencyProperty.Register("IconText", typeof(string), typeof(FlatButton), new PropertyMetadata("\uE0E7"));
        #endregion

        #region BorderThicknessProperty
        [Category("FlatButton Properties")]
        public new Thickness BorderThickness
        {
            get { return (Thickness)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderThickness.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(FlatButton), new FrameworkPropertyMetadata(new Thickness(0)));        
        #endregion
        
        #region CornerRadiusProperty
        [Category("FlatButton Properties")]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(FlatButton), new PropertyMetadata(new CornerRadius(0), CornerRadiusProperty_OnPropertyChanged));

        private static void CornerRadiusProperty_OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FlatButton fb = (FlatButton)d;                      
            fb.UpdateUI();
        }
        #endregion

        #region MaintainProportionsProperty
        [Category("FlatButton Properties")]
        public bool MaintainProportions
        {
            get { return (bool)GetValue(MaintainProportionsProperty); }
            set { SetValue(MaintainProportionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaintainProportions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaintainProportionsProperty =
            DependencyProperty.Register("MaintainProportions", typeof(bool), typeof(FlatButton), new FrameworkPropertyMetadata(false, MaintainProportionsProperty_OnPropertyChanged));

        private static void MaintainProportionsProperty_OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FlatButton fb = (FlatButton)d;
            fb.MainControl_SizeChanged(fb, null);
        }
        #endregion

        #region ShowIconProperty
        [Category("FlatButton Properties")]
        public bool ShowIcon
        {
            get { return (bool)GetValue(ShowIconProperty); }
            set { SetValue(ShowIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowIconProperty =
            DependencyProperty.Register("ShowIcon", typeof(bool), typeof(FlatButton), new PropertyMetadata(true, ShowIconProperty_OnPropertyChanged));

        private static void ShowIconProperty_OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FlatButton fb = (FlatButton)d;
            fb.UpdateUI();
            fb.ControlIcon_SizeChanged(null, null);
        }
        #endregion

        #region BorderRoundingProperty
        [Category("FlatButton Properties")]
        public FlatLabel.Rounding BorderRounding
        {
            get { return (FlatLabel.Rounding)GetValue(BorderRoundingProperty); }
            set { SetValue(BorderRoundingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderRounding.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderRoundingProperty =
            DependencyProperty.Register("BorderRounding", typeof(FlatLabel.Rounding), typeof(FlatButton), new FrameworkPropertyMetadata(FlatLabel.Rounding.Custom, BorderRoundingProperty_OnPropertyChanged));

        private static void BorderRoundingProperty_OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FlatButton fb = (FlatButton)d;            
            fb.UpdateUI();
        }
        #endregion

        #region IconMarginProperty
        [Category("FlatButton Properties")]
        public double IconMargin
        {
            get { return (double)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconMargin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register("IconMargin", typeof(double), typeof(FlatButton), new PropertyMetadata((double)0));
        #endregion

        #region IconFontProperty
        [Category("FlatButton Properties")]
        public FontFamily IconFont
        {
            get { return (FontFamily)GetValue(IconFontProperty); }
            set { SetValue(IconFontProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconFont.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconFontProperty =
            DependencyProperty.Register("IconFont", typeof(FontFamily), typeof(FlatButton), new PropertyMetadata(new FontFamily("Segoe MDL2 Assets")));
        #endregion

        #region IconSizeProperty
        [Category("FlatButton Properties")]
        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof(double), typeof(FlatButton), new PropertyMetadata((double)12));
        #endregion

        private void MainControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {            
            if (MaintainProportions)
            {                
                Height = ActualWidth;
            }
            UpdateUI();
        }

        private void ControlIcon_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(ControlIcon.Visibility == Visibility.Visible)
            {
                ControlText.TextPadding = new Thickness(ControlIcon.ActualWidth, 0, 0, 0);
            }
            else
            {
                ControlText.TextPadding = new Thickness(0, 0, 0, 0);
            }
        }

        private void MainControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (ShowIcon)
            {                
                ControlIcon.Visibility = Visibility.Visible;
            }
            else
            {                
                ControlIcon.Visibility = Visibility.Hidden;
            }

            if (BorderRounding == FlatLabel.Rounding.Custom)
            {
                ControlIcon.CornerRadius = new CornerRadius(ControlIcon.ActualHeight * CornerRadius.BottomLeft / ActualHeight);
                ControlBorder.CornerRadius = CornerRadius;
            }
            else
            {
                ControlBorder.CornerRadius = new CornerRadius(Math.Min(ActualHeight / 2, ActualWidth / 2));
            }            
        }

        #region ClickControl
        private void MainControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsPressed = true;
        }

        private void MainControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(IsPressed)
            {
                IsPressed = false;
                Click?.Invoke(this);                
            }
        }

        private void MainControl_MouseLeave(object sender, MouseEventArgs e)
        {
            IsPressed = false;
        }
        #endregion
    }
}
