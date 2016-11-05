using System;
using UIKit;

namespace XN_ListView.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        private static Random rnd = new Random();

        private string[] images;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CustomListView.Source = new CustomListViewSource();
            images = System.IO.Directory.GetFiles("monkeys", "*.jpg");

            AddButton.TouchUpInside += (sender, e) =>
            {
                var item = new TableItem
                {
                    Main = $"Item_{rnd.Next()}",
                    Sub = $"Description_{rnd.Next()}",
                    ImagePath = images[rnd.Next(0, 4)]
                };
                // 新規アイテムを追加して再読み込みさせる
                var src = CustomListView.Source as CustomListViewSource;
                src.Items.Add(item);
                CustomListView.ReloadData();
            };

            RemoveButton.TouchUpInside += (sender, e) =>
            {
                // 末尾のアイテムを削除して再読み込みさせる
                var src = CustomListView.Source as CustomListViewSource;
                if (src.Items.Count < 1)
                    return;
                src.Items.RemoveAt(src.Items.Count - 1);
                CustomListView.ReloadData();
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

