// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XN_ListView.iOS
{
    [Register ("CircleImageViewCell")]
    partial class CircleImageViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView CircleImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MainLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SubLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CircleImage != null) {
                CircleImage.Dispose ();
                CircleImage = null;
            }

            if (MainLabel != null) {
                MainLabel.Dispose ();
                MainLabel = null;
            }

            if (SubLabel != null) {
                SubLabel.Dispose ();
                SubLabel = null;
            }
        }
    }
}