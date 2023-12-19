using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace ModernUi.WPF.Common
{
    /// <summary>
    /// Represents a custom TextBox with additional properties for placeholder text.
    /// </summary>
    public class Entry : TextBox
    {




        public CornerRadius BorderRadius
        {
            get { return (CornerRadius)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderRadiusProperty =
            DependencyProperty.Register("BorderRadius", typeof(CornerRadius), typeof(Entry), new PropertyMetadata(new CornerRadius(1)));





        /// <summary>
        /// Gets or sets the font size of the placeholder text.
        /// </summary>
        public double PlaceHolderFontSize
        {
            get { return (double)GetValue(PlaceHolderFontSizeProperty); }
            set { SetValue(PlaceHolderFontSizeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="PlaceHolderFontSize"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PlaceHolderFontSizeProperty =
            DependencyProperty.Register(
                "PlaceHolderFontSize",
                typeof(double),
                typeof(Entry),
                new PropertyMetadata(double.NaN));

        /// <summary>
        /// Gets or sets the color of the placeholder text.
        /// </summary>
        public Brush PlaceHolderColor
        {
            get { return (Brush)GetValue(PlaceHolderColorProperty); }
            set { SetValue(PlaceHolderColorProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="PlaceHolderColor"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PlaceHolderColorProperty =
            DependencyProperty.Register(
                "PlaceHolderColor",
                typeof(Brush),
                typeof(Entry),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets a value indicating whether the text is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return (bool)GetValue(IsEmptyProperty); }
            private set { SetValue(IsEmptyPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey IsEmptyPropertyKey =
            DependencyProperty.RegisterReadOnly("IsEmpty", typeof(bool), typeof(Entry), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the <see cref="IsEmpty"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsEmptyProperty = IsEmptyPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets or sets the placeholder text.
        /// </summary>
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Placeholder"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(Entry), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Initializes a new instance of the <see cref="Entry"/> class.
        /// </summary>
        static Entry()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Entry), new FrameworkPropertyMetadata(typeof(Entry)));
        }

        /// <summary>
        /// Called when the text in the TextBox changes.
        /// </summary>
        /// <param name="e">The event data for the <see cref="TextBoxBase.TextChanged"/> event.</param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            IsEmpty = string.IsNullOrEmpty(Text);
            base.OnTextChanged(e);
        }

        /// <summary>
        /// Called when the control is first initialized.
        /// </summary>
        /// <param name="e">The event data for the <see cref="FrameworkElement.Initialized"/> event.</param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // If PlaceHolderColor is not explicitly set, use the Foreground color as the default
            if (PlaceHolderColor == null)
            {
                PlaceHolderColor = Foreground;
            }

            // If PlaceHolderFontSize is not explicitly set, use the FontSize as the default
            if (double.IsNaN(PlaceHolderFontSize))
            {
                PlaceHolderFontSize = FontSize;
            }
        }
    }

}
