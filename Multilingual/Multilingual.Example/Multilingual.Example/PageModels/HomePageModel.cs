using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Multilingual.Example.Pages;
using Xamarin.Forms;

namespace Multilingual.Example.PageModels
{
    public class HomePageModel
    {
        public ICommand ChangeLanguageCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new LanguagePage());
                });
            }
        }
    }
}
