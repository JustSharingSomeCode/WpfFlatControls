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

namespace WpfFlatControlsLib.Labels
{
    /// <summary>
    /// Lógica de interacción para FlatLabel.xaml
    /// </summary>
    public partial class FlatLabel : UserControl
    {
        public FlatLabel()
        {
            InitializeComponent();
            //[Category("FlatLabel Properties")]            
        }

        public enum Rounding
        {
            Auto,
            Custom
        }

        #region BackgroundProperty
        [Category("FlatLabel Properties")]
        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Background.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(FlatLabel), new PropertyMetadata(Brushes.Transparent));
        #endregion

        #region ForegroundProperty
        [Category("FlatLabel Properties")]
        public new Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Foreground.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(Brush), typeof(FlatLabel), new PropertyMetadata(Brushes.Black));
        #endregion

        #region BorderBrushProperty
        [Category("FlatLabel Properties")]
        public new Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderBrush.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(FlatLabel), new PropertyMetadata(Brushes.Black));
        #endregion

        #region TextProperty
        [Category("FlatLabel Properties")]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(FlatLabel), new PropertyMetadata("Label"));
        #endregion

        #region BorderThicknessProperty
        [Category("FlatLabel Properties")]
        public new Thickness BorderThickness
        {
            get { return (Thickness)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderThickness.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(FlatLabel), new PropertyMetadata(new Thickness(0)));
        #endregion

        #region CornerRadiusProperty
        [Category("FlatLabel Properties")]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(FlatLabel), new PropertyMetadata(new CornerRadius(0)));
        #endregion

        #region MaintainProportionsProperty
        [Category("FlatLabel Properties")]
        public bool MaintainProportions
        {
            get { return (bool)GetValue(MaintainProportionsProperty); }
            set { SetValue(MaintainProportionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaintainProportions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaintainProportionsProperty =
            DependencyProperty.Register("MaintainProportions", typeof(bool), typeof(FlatLabel), new FrameworkPropertyMetadata(false, MaintainProportionsProperty_OnPropertyChanged));

        private static void MaintainProportionsProperty_OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FlatLabel fl = (FlatLabel)d;
            fl.MainControl_SizeChanged(fl, null);
        }
        #endregion

        #region BorderRoundingProperty
        [Category("FlatLabel Properties")]
        public Rounding BorderRounding
        {
            get { return (Rounding)GetValue(BorderRoundingProperty); }
            set { SetValue(BorderRoundingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderRounding.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderRoundingProperty =
            DependencyProperty.Register("BorderRounding", typeof(Rounding), typeof(FlatLabel), new FrameworkPropertyMetadata(Rounding.Custom, BorderRoundingProperty_OnPropertyChanged));

        private static void BorderRoundingProperty_OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FlatLabel fl = (FlatLabel)d;
            fl.MainControl_SizeChanged(fl, null);
        }
        #endregion

        #region TextPaddingProperty
        [Category("FlatLabel Properties")]
        public Thickness TextPadding
        {
            get { return (Thickness)GetValue(TextPaddingProperty); }
            set { SetValue(TextPaddingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextPadding.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextPaddingProperty =
            DependencyProperty.Register("TextPadding", typeof(Thickness), typeof(FlatLabel), new PropertyMetadata(new Thickness(0)));
        #endregion

        private void MainControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            if(MaintainProportions)
            {
                Width = ActualHeight;                
            }
            
            if(BorderRounding == Rounding.Auto)
            {
                CornerRadius = new CornerRadius(Math.Min(ActualHeight / 2, ActualWidth / 2));
            }
        }
    }
}
