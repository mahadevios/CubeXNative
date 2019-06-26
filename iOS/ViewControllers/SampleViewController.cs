using UIKit;
using Foundation;
using System;
using System.Collections.Specialized;

namespace CubeXNative.iOS
{
    public partial class SampleViewController : UIViewController
    {
        //public SampleViewController() : base("SampleViewController", null)
        //{
        //}
        public SampleViewController(IntPtr handle) : base(handle)
        {
            Console.WriteLine("");
        }


        public SampleViewModel ViewModel { get; set; }
        public override void ViewDidLoad()
        {
            
            base.ViewDidLoad();
            ViewModel = new SampleViewModel();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            ViewModel.verticalItemLists.CollectionChanged += VerticalItemLists_CollectionChanged;
            tableView.Source = new VerticalItemDataSource(ViewModel);
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            //UserDialogs.Instance.ShowLoading("Loading..", MaskType.Black);
            if (ViewModel.verticalItemLists.Count == 0)
                ViewModel.loadVerticalItemsCommand.Execute(null);

            //UserDialogs.Instance.HideLoading();
        }


        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }

        void VerticalItemLists_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvokeOnMainThread(() => tableView.ReloadData());
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    class VerticalItemDataSource:UITableViewSource
    {
        static readonly NSString cellIdentifier = new NSString("cell");

        SampleViewModel sampleViewModel;

        public VerticalItemDataSource(SampleViewModel _sampleViewModel)
        {
            this.sampleViewModel = _sampleViewModel;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => sampleViewModel.verticalItemLists.Count;

        public override nint NumberOfSections(UITableView tableView) => 1;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath);

            var verticalList = sampleViewModel.verticalItemLists[indexPath.Row];

            cell.TextLabel.Text = verticalList.vertical_name;

            return cell;
        }

    }
}

