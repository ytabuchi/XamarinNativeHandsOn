using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XN_ListView.Droid
{
    class CustomListAdapter : BaseAdapter<TableItem>
    {
        Activity _context;
        List<TableItem> _items;
        public CustomListAdapter(Activity context, List<TableItem> items)
        {
            _context = context;
            _items = items;
        }

        public override TableItem this[int position]
        {
            get
            {
                return _items[position];
            }
        }

        public override int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];

            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);

            //BaseAdapter<T>の対応するプロパティを割り当て
            view.FindViewById<TextView>(Resource.Id.mainText).Text = item.Main;
            view.FindViewById<TextView>(Resource.Id.subText).Text = item.Sub;
            view.FindViewById<ImageView>(Resource.Id.imageView).SetImageResource(item.ImageResourceId);

            return view;
        }
    }
}