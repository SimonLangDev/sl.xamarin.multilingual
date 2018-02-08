using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Multilingual.Example.Models;
using Multilingual.Example.Pages;
using Multilingual.Example.Resources.Languages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Multilingual.Example.PageModels
{
    public class LanguagePageModel
    {
        public List<Language> Languages { get; set; }
        public int SelectedIndex { get; set; }

        public LanguagePageModel()
        {
            ReadLanguagesResources();
        }

        private void ReadLanguagesResources()
        {
            using (var stream = this.GetType().Assembly.GetManifestResourceStream("Multilingual.Example.Resources.Languages.Languages.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    //Set languages picker
                    var json = JObject.Parse(reader.ReadToEnd());
                    Languages = JsonConvert.DeserializeObject<List<Language>>(JsonConvert.SerializeObject(json["languages"]));

                    //Get current culture info
                    var info = MultilingualCore.Current.CurrentCultureInfo;

                    for (var i=0; i<Languages.Count ;i++)
                    {
                        if (Languages[i].Abbreviation == info.TwoLetterISOLanguageName)
                            SelectedIndex = i;
                    }
                }
            }
        }

        public ICommand AcceptCommand
        {
            get
            {
                return new Command(() =>
                {
                    var test = Languages[SelectedIndex].Abbreviation;
                    MultilingualCore.Current.CurrentCultureInfo = new CultureInfo(test);
                    AppResources.Culture = MultilingualCore.Current.CurrentCultureInfo;

                    var page = new NavigationPage(new HomePage())
                    {
                        BarBackgroundColor = Color.FromHex("#212121")
                    };
                    Application.Current.MainPage = page;
                });
            }
        }
    }
}
