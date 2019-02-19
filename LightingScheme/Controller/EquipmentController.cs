using System.IO;
using System.Collections.Generic;
using System;
using UIKit;
using System.Drawing;
using Xamarin.iOS;
using System.Linq;

namespace LightingScheme
{
    public partial class EquipmentController : UIViewController
    {
        public EquipmentController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var ListForCollectionView = Directory.GetFiles("Image/6/").ToList();

            var source = new CustomCollectionIEquipmentSource(ListForCollectionView);
            var size = (SizeF)this.View.Frame.Size;

            var koef = 20;
            if (DeviceHardware.Model.Contains("iPhone X"))
                koef = 110;

            EquipmentGallery.CollectionViewLayout = new UICollectionViewFlowLayout()
            {
                ItemSize = new CoreGraphics.CGSize((size.Width - koef) / 6, (size.Width - koef) / 6),
                MinimumInteritemSpacing = 10,
                MinimumLineSpacing = 10,
                SectionInset = new UIEdgeInsets(5, 5, 5, 5),
            };

            EquipmentGallery.RegisterClassForCell(typeof(CustomCollectionEquipmentCell), CustomCollectionEquipmentCell.ID);
            EquipmentGallery.Source = source;
        }
    }
}