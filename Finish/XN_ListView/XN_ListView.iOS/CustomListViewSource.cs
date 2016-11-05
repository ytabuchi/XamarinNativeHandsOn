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


        public CustomListViewSource()
        {
            Items = new List<TableItem>();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (CircleImageViewCell)tableView.DequeueReusableCell(nameof(CircleImageViewCell), indexPath);
            var item = Items[indexPath.Row];
            cell.Update(item);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => Items.Count;
    }
}
