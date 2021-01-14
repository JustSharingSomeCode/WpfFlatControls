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

namespace WpfFlatControlsLib.Scrolls
{
    /// <summary>
    /// Lógica de interacción para FlatScroll.xaml
    /// </summary>
    public partial class FlatScroll : UserControl
    {
        public FlatScroll()
        {
            InitializeComponent();
        }

        private bool IsPressed = false;

        #region ValueProperty
        [Category("FlatScroll Properties")]
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(FlatScroll), new FrameworkPropertyMetadata((double)0, ValueProperty_OnPropertyChanged));

        private static void ValueProperty_OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FlatScroll fs = (FlatScroll)d;
            if((double)e.NewValue < 0)
            {
                fs.SetValue(ValueProperty, (double)0);
            }
            else if((double)e.NewValue > 100)
            {
                fs.SetValue(ValueProperty, (double)100);
            }
            fs.CalculatePosition();
        }
        #endregion

        #region ShowButtonsProperty
        [Category("FlatScroll Properties")]
        public bool ShowButtons
        {
            get { return (bool)GetValue(ShowButtonsProperty); }
            set { SetValue(ShowButtonsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowButtons.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowButtonsProperty =
            DependencyProperty.Register("ShowButtons", typeof(bool), typeof(FlatScroll), new FrameworkPropertyMetadata(true, ShowButtonsProperty_OnPropertyChanged));

        private static void ShowButtonsProperty_OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FlatScroll fs = (FlatScroll)d;
            if ((bool)e.NewValue)
            {
                fs.UpBtn.Visibility = Visibility.Visible;
                fs.DownBtn.Visibility = Visibility.Visible;
            }
            else
            {
                fs.UpBtn.Visibility = Visibility.Hidden;
                fs.DownBtn.Visibility = Visibility.Hidden;
            }
            fs.UpBtn_SizeChanged(fs, null);
        }
        #endregion

        #region RoundingProperty
        [Category("FlatScroll Properties")]
        public FlatLabel.Rounding Rounding
        {
            get { return (FlatLabel.Rounding)GetValue(RoundingProperty); }
            set { SetValue(RoundingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Rounding.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RoundingProperty =
            DependencyProperty.Register("Rounding", typeof(FlatLabel.Rounding), typeof(FlatScroll), new PropertyMetadata(FlatLabel.Rounding.Custom));
        #endregion

        #region CornerRadiusProperty
        [Category("FlatScroll Properties")]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(FlatScroll), new PropertyMetadata(new CornerRadius(0)));
        #endregion

        #region ScrollMarginProperty
        [Category("FlatScroll Properties")]
        public double ScrollMargin
        {
            get { return (double)GetValue(ScrollMarginProperty); }
            set { SetValue(ScrollMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScrollMargin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScrollMarginProperty =
            DependencyProperty.Register("ScrollMargin", typeof(double), typeof(FlatScroll), new FrameworkPropertyMetadata((double)0, ScrollMarginProperty_OnPropertyChanged));

        private static void ScrollMarginProperty_OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FlatScroll fs = (FlatScroll)d;
            fs.UpBtn_SizeChanged(fs, null);
        }
        #endregion

        #region IconSizeProperty
        [Category("FlatScroll Properties")]
        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof(double), typeof(FlatScroll), new PropertyMetadata((double)10));
        #endregion

        private void MainControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        private void UpBtn_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int i = (ShowButtons) ? 1 : 0;
            ScrollBcg.Height = Math.Max(0, ActualHeight - ((UpBtn.ActualHeight * 2 * i) + (ScrollMargin * 2)));
            ScrollBcg.Margin = new Thickness(0, UpBtn.ActualHeight * i + ScrollMargin, 0, DownBtn.ActualHeight * i + ScrollMargin);
        }

        #region ScrollControl       
        private void ScrollBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsPressed = true;
        }

        private void ScrollBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsPressed = false;
        }

        private void ScrollBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsPressed)
            {
                CalculateValue(e);
            }
        }        

        private void ScrollActiveRegion_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsPressed = false;
        }

        private void ScrollActiveRegion_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsPressed)
            {
                CalculateValue(e);
            }
        }

        private void CalculateValue(MouseEventArgs e)
        {
            Value = (e.GetPosition(ScrollBcg).Y - (ScrollBtn.ActualHeight / 2)) * 100 / (ScrollBcg.ActualHeight - ScrollBtn.ActualHeight);
            //CalculatePosition();
        }

        private void CalculatePosition()
        {
            ScrollBtn.Margin = new Thickness(0, (ScrollBcg.ActualHeight - ScrollBtn.ActualHeight) * Value / 100, 0, 0);
        }

        private void ScrollActiveRegion_MouseLeave(object sender, MouseEventArgs e)
        {
            if(!ScrollBtn.IsMouseOver)
            {
                IsPressed = false;
            }            
        }

        private void UpBtn_Click(object sender)
        {
            Value--;
        }

        private void DownBtn_Click(object sender)
        {
            Value++;
        }
        #endregion
    }
}
