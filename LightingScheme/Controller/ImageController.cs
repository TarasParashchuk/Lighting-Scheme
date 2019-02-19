using CoreGraphics;
using System;
using UIKit;
using System.Drawing;
using FFImageLoading;

namespace LightingScheme
{
    public partial class ImageController : UIViewController
    {
        public ModelData data { get; set; }

        public ImageController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var size = (SizeF)this.View.Frame.Size;
            var width = size.Width * 0.8f;
            var height = size.Height;

            var ImageScheme = new UIImageView();
            ImageScheme.Frame = new  CGRect(width * 0.125f, (height - width / 1.75f) / 2, width, width / 1.75f);
            ImageService.Instance.LoadFile(data.path).Into(ImageScheme);
            GalleryViewItem.AddSubview(ImageScheme);

            var ButtonLeft = new UIButton();
            ButtonLeft.SetImage(new UIImage("left_arrow_black_36pt_2x.png"), UIControlState.Normal);
            ButtonLeft.Frame = new CGRect(size.Width * 0.02f, (height - width * 0.1f) / 2, width * 0.1f, width * 0.1f);
            //ButtonLeft.BackgroundColor = UIColor.LightGray;
            GalleryViewItem.AddSubview(ButtonLeft);

            var ButtonRight = new UIButton();
            ButtonRight.SetImage(new UIImage("right_arrow_black_36pt_2x.png"), UIControlState.Normal);
            ButtonRight.Frame = new CGRect(size.Width * 0.9f, (height - width * 0.1f) / 2, width * 0.1f, width * 0.1f);
            //ButtonRight.BackgroundColor = UIColor.LightGray;
            GalleryViewItem.AddSubview(ButtonRight);

            var ButtonMenu = new UIButton();
            ButtonMenu.SetImage(new UIImage("baseline_menu_black_36pt_2x.png"), UIControlState.Normal);
            ButtonMenu.Frame = new CGRect(height * 0.02f, height * 0.04f, width * 0.08f, width * 0.06f);
            GalleryViewItem.AddSubview(ButtonMenu);

            var item = string.Empty;
            var currentID = data.id;
            ButtonLeft.TouchUpInside += (sender, e) =>
            {
                currentID--;
                if (currentID == -1)
                    currentID = data.listFiles.Count - 1;
                ImageService.Instance.LoadFile(data.listFiles[currentID]).Into(ImageScheme);
            };

            ButtonRight.TouchUpInside += (sender, e) =>
            {
                currentID++;
                if (currentID == data.listFiles.Count)
                    currentID = 0; 
                ImageService.Instance.LoadFile(data.listFiles[currentID]).Into(ImageScheme);
            };

            ButtonMenu.TouchUpInside += (sender, e) =>
            {
                PerformSegue("ShowMainMenu", this);
            };
        }
    }
}