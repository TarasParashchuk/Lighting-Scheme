// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace LightingScheme
{
    [Register ("ImageController")]
    partial class ImageController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView GalleryViewItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (GalleryViewItem != null) {
                GalleryViewItem.Dispose ();
                GalleryViewItem = null;
            }
        }
    }
}