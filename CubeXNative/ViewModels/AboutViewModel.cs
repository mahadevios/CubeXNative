using System.Windows.Input;
using System;
using Autofac;
using CubeXNative.Services;

namespace CubeXNative
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Plugin.Share.CrossShare.Current.OpenBrowser("https://xamarin.com/platform"));

           

            //setDbValues();
        }

        public async void callLoginApi()
        {
            using (var scope = App.Container.BeginLifetimeScope())
            {

                IApiStore apiStore = App.Container.Resolve<IApiStore>();

                User user = new User();
                user.username = "m@m.com";
                user.password = "123";
                user.deviceToken = "flnpMiK5tR8:APA91bGSkUvqnmWoBMkxUI-FGwY5QdOz6tSANyQL8Vi4RvhRI8S-njUAGuPN35Io-vTE0OlTlYBAItB0dR7nyEe4IuPqjn2Iz9W76gKHq17-KACQpJHtC8u8EekIPvsysCZ11Ru3hsDp";
                var response = await apiStore.login(user);
            };
        }

        public async void setDbValues()
        {
            User user = new User();
            user.id = "1";
            user.name = "abc";
            user.role = "admin";
            user.username = "testUser";
            user.password = "123";
            user.deviceToken = "";
            await App.Database.SaveUserAsync(user);
            var userObj = await App.database.GetUserAsync();
            Console.WriteLine("User = "+userObj.name);
        }

        public ICommand OpenWebCommand { get; }
    }
}
