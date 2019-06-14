using System.Windows.Input;
using System;

namespace CubeXNative
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Plugin.Share.CrossShare.Current.OpenBrowser("https://xamarin.com/platform"));
            

            this.setDbValues();
        }

        public async void setDbValues()
        {
            User user = new User();
            user.Id = "1";
            user.Name = "abc";
            user.Role = "admin";
            await App.Database.SaveUserAsync(user);
            var userObj = await App.database.GetUserAsync();
            Console.WriteLine("User = "+userObj.Name);
        }

        public ICommand OpenWebCommand { get; }
    }
}
