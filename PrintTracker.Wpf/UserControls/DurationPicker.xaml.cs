using System.Windows;
using System.Windows.Controls;

namespace PrintTracker.Wpf.UserControls
{
    /// <summary>
    /// Interaktionslogik für DurationPicker.xaml
    /// </summary>
    public partial class DurationPicker : UserControl
    {


        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register(
                "Duration",
                typeof(TimeSpan),
                typeof(DurationPicker),
                new FrameworkPropertyMetadata(TimeSpan.Zero, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public TimeSpan Duration
        {
            get => (TimeSpan)GetValue(DurationProperty);
            set => SetValue(DurationProperty, value);
        }

        public DurationPicker()
        {
            InitializeComponent();
        }


        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            string input = textBox.Text;

            if (int.TryParse(input, out int number))
            {
                this.Duration = TimeSpan.FromHours(number);
            }
            else if (TimeSpan.TryParse(input, out TimeSpan result))
            {
                this.Duration = result;
            }
            else if (double.TryParse(input.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double hours))
            {
                this.Duration = TimeSpan.FromHours(hours);
            }
            else if (input.Contains(':'))
            {
                var parts = input.Split(':');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int h) &&
                    int.TryParse(parts[1], out int m))
                {
                    this.Duration = new TimeSpan(h, m, 0);
                }
            }

            textBox.Text = $"{(int)this.Duration.TotalHours:00}:{this.Duration.Minutes:00}";
        }

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if(textBox == null) return;
            textBox.Text = "";
        }
    }
}
