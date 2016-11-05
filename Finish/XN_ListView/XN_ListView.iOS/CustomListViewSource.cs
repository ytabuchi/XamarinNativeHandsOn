using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using CoreGraphics;

namespace XN_ListView.iOS
{
    public class CustomListViewSource : UITableViewSource
    {
        public List<TableItem> Items { get; }

        private readonly string[] images;

        public CustomListViewSource()
        {
            Items = new List<TableItem>();
            images = System.IO.Directory.GetFiles("monkeys", "*.jpg");
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(nameof(TableItem), indexPath);
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, nameof(TableItem));
            }
            var item = Items[indexPath.Row];
            cell.TextLabel.Text = item.Main;
            cell.DetailTextLabel.Text = item.Sub;
            cell.ImageView.Image = UIImage.FromFile(images[item.ImageResourceId]);
            // まるく表示
            cell.ImageView.Layer.CornerRadius = cell.ContentView.Bounds.Height / 2;
            cell.ImageView.Layer.BorderWidth = 2;
            cell.ImageView.Layer.BorderColor = UIColor.FromRGB(0x34, 0x98, 0xdb).CGColor;
            cell.ImageView.ClipsToBounds = true;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => Items.Count;
    }
}
