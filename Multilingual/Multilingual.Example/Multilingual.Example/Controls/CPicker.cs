using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Multilingual.Example.Controls
{
    public class CPicker : Picker
    {
        public static readonly BindableProperty PositiveTextProperty =
            BindableProperty.Create("PositiveText", typeof(string), typeof(CPicker), "");
        public static readonly BindableProperty NegativeTextProperty =
            BindableProperty.Create("NegativeText", typeof(string), typeof(CPicker), "");

        /// <summary>
        /// Set text for postitive button.
        /// </summary>
        public string PositiveText
        {
            get { return (string)GetValue(PositiveTextProperty); }
            set { SetValue(PositiveTextProperty, value); }
        }

        /// <summary>
        /// Set text for negative button.
        /// </summary>
        public string NegativeText
        {
            get { return (string)GetValue(NegativeTextProperty); }
            set { SetValue(NegativeTextProperty, value); }
        }
    }
}
