using Foundation;
using System.Collections.Generic;
using System;
using UIKit;
using System.Drawing;
using Xamarin.iOS;

namespace LightingScheme
{
    public partial class GalleryController : UIViewController
    {
        public List<string> ListForCollectionView { get; set; }
        CustomCollectionImagesSource source;

        public GalleryController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            source = new CustomCollectionImagesSource(ListForCollectionView, this);
            var size = (SizeF)this.View.Frame.Size;

            var koef = 20;
            if (DeviceHardware.Model.Contains("iPhone X"))
                koef = 110;

            var width = (size.Width - koef) / 2;
            var height = width * 1170 / 2048;

            Gallery.CollectionViewLayout = new UICollectionViewFlowLayout()
            {
                ItemSize = new CoreGraphics.CGSize(width, height),
                MinimumInteritemSpacing = 10,
                MinimumLineSpacing = 10,
                SectionInset = new UIEdgeInsets(5, 5, 5, 5),
            };

            Gallery.RegisterClassForCell(typeof(CustomCollectionImageCell), CustomCollectionImageCell.ID);
            Gallery.Source = source;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var imageView = segue.DestinationViewController as ImageController;
            if (imageView != null)
            {
                imageView.data = source.data;
            }
        }
    }
}