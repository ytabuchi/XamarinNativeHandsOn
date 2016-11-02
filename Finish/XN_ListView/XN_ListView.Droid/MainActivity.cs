using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XN_ListView.Droid
{
    [Activity(Label = "XN_ListView.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<TableItem> tableItem = new List<TableItem>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            int[] images = {
                Resource.Drawable.monkey1,
                Resource.Drawable.monkey2,
                Resource.Drawable.monkey3,
                Resource.Drawable.monkey4
            };

            var listView = FindViewById<ListView>(Resource.Id.CustomListView);

            // ソースのListにアイテムを追加
            tableItem.Add(new TableItem()
            {
                Main = "Item_1",
                Sub = "Description_1",
                ImageResourceId = images[0]
            });

            // CustomAdapterを作成して適用
            var customAdapter = new CustomListAdapter(this, tableItem);
            listView.Adapter = customAdapter;

            listView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
                var t = tableItem[e.Position];
                Toast.MakeText(this, t.Main, ToastLength.Short).Show();
            };

            var addButton = FindViewById<Button>(Resource.Id.AddButton);
            addButton.Click += (sender, e) =>
            {
                var rdm = new Random();
                // ソースのListにアイテムを追加し、Adapterに変更を通知して画面を更新させる
                tableItem.Insert(0, new TableItem()
                {
                    Main = "Item_" + rdm.Next(),
                    Sub = "Description_" + rdm.Next(),
                    ImageResourceId = images[rdm.Next(0, 4)]
                });
                customAdapter.NotifyDataSetChanged();
            };

            var removeButton = FindViewById<Button>(Resource.Id.RemoveButton);
            removeButton.Click += (sender, e) =>
            {
                if (tableItem.Count > 0)
                {
                    // ソースのListからアイテムを削除し、Adapterに変更を通知して画面を更新させる
                    tableItem.Remove(tableItem[tableItem.Count - 1]);
                    customAdapter.NotifyDataSetChanged();
                }
            };
        }
    }
}


