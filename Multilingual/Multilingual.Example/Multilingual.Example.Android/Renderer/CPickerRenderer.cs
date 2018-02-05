using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Util;
using Android.Widget;
using Multilingual.Example.Controls;
using Multilingual.Example.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using PickerRenderer = Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer;
using TextAlignment = Android.Views.TextAlignment;

[assembly: ExportRenderer(typeof(CPicker), typeof(CPickerRenderer))]
namespace Multilingual.Example.Droid.Renderer
{
    public class CPickerRenderer : Xamarin.Forms.Platform.Android.PickerRenderer
    {
        private IElementController ElementController => Element as IElementController;
        private AlertDialog _dialog;
        private string _positiveText;
        private string _negativeText;

        public CPickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null || e.OldElement != null)
                return;

            _positiveText = ((CPicker)e.NewElement).PositiveText;
            _negativeText = ((CPicker)e.NewElement).NegativeText;

            Control.Click += Control_Click;
        }

        protected override void Dispose(bool disposing)
        {
            Control.Click -= Control_Click;
            base.Dispose(disposing);
        }

        private void Control_Click(object sender, EventArgs e)
        {
            var model = Element;

            var picker = new NumberPicker(Context);
            if (model.Items != null && model.Items.Any())
            {
                picker.MaxValue = model.Items.Count - 1;
                picker.MinValue = 0;
                picker.SetDisplayedValues(model.Items.ToArray());
                picker.WrapSelectorWheel = false;
                picker.Value = model.SelectedIndex;
            }

            var layout = new LinearLayout(Context) { Orientation = Orientation.Vertical };
            layout.AddView(picker);

            ElementController.SetValueFromRenderer(VisualElement.IsFocusedProperty, true);

            var builder = new AlertDialog.Builder(Context);
            builder.SetView(layout);
            builder.SetTitle(model.Title ?? "");
            builder.SetNegativeButton(_negativeText, (s, a) =>
            {
                ElementController.SetValueFromRenderer(VisualElement.IsFocusedProperty, false);
                
                //Clear focus to hold control about picker
                Control?.ClearFocus();
                _dialog = null;
            });
            builder.SetPositiveButton(_positiveText, (s, a) =>
            {
                ElementController.SetValueFromRenderer(Picker.SelectedIndexProperty, picker.Value);
                
                if (Element != null)
                {
                    if (model.Items.Count > 0 && Element.SelectedIndex >= 0)
                        Control.Text = model.Items[Element.SelectedIndex];
                    ElementController.SetValueFromRenderer(VisualElement.IsFocusedProperty, false);

                    //Clear focus to hold control about picker
                    Control?.ClearFocus();
                }
                _dialog = null;
            });

            _dialog = builder.Create();
            _dialog.DismissEvent += (ssender, args) =>
            {
                ElementController?.SetValueFromRenderer(VisualElement.IsFocusedProperty, false);
            };
            _dialog.Show();
        }
    }
}
