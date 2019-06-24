using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using CubeXNative.Services;
using CubeXNative.Helpers;
using System.Collections.Generic;

using Autofac;

namespace CubeXNative
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> Items { get; set; }
        //public ObservableRangeCollection<ItemVerticalList> verticalListItems { get; set; }

        public Command LoadItemsCommand { get; set; }
        public Command AddItemCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableRangeCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new Command<Item>(async (Item item) => await AddItem(item));
        }

        //async Task ExecuteLoadItemsCommand()
        //{
        //    if (IsBusy)
        //        return;

        //    IsBusy = true;

        //    var _items = await getVertcalList();

        //    verticalListItems.ReplaceRange(_items.itemVerticals);

        //}

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
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task AddItem(Item item)
        {
            Items.Add(item);
            await DataStore.AddItemAsync(item);
        }
    }
}
