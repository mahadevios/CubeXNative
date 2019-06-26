using CubeXNative.Helpers;
using System.Threading.Tasks;
using Autofac;
using CubeXNative.Services;
using Acr.UserDialogs;

namespace CubeXNative
{ 
    public class SampleViewModel:BaseViewModel
    {
        public ObservableRangeCollection<ItemVerticalList> verticalItemLists { get; set; }

        public Command loadVerticalItemsCommand { get; set; }

        public SampleViewModel()
        {
            verticalItemLists = new ObservableRangeCollection<ItemVerticalList>();
            loadVerticalItemsCommand = new Command(async() => await ExecuteLoadVerticalItemsCommand());
        }


        async Task ExecuteLoadVerticalItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            UserDialogs.Instance.ShowLoading("Loading..", MaskType.Black);

            var _items = await getVertcalList();

            UserDialogs.Instance.HideLoading();

            verticalItemLists.ReplaceRange(_items.itemVerticals);

        }

        async Task<ItemVerticals> getVertcalList()
        {
            using (var scope = App.Container.BeginLifetimeScope())
            {

                IApiStore apiStore = App.Container.Resolve<IApiStore>();

                User user = new User();
                user.username = "m@m.com";
                user.password = "123";
                user.deviceToken = "flnpMiK5tR8:APA91bGSkUvqnmWoBMkxUI-FGwY5QdOz6tSANyQL8Vi4RvhRI8S-njUAGuPN35Io-vTE0OlTlYBAItB0dR7nyEe4IuPqjn2Iz9W76gKHq17-KACQpJHtC8u8EekIPvsysCZ11Ru3hsDp";
                user.itemName = "vertical";
                ItemVerticals _verticalItems = await apiStore.mobileItemVerticalList(user);

                return _verticalItems;
            };
        }
    }

   

}