using System;
using System.Drawing;
using System.Collections.Generic;
using Foundation;
using CoreGraphics;
using UIKit;
using System.IO;
using System.Linq;

namespace LightingScheme
{
    public partial class ViewController : UIViewController
    {
        List<string> ImagesList;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public UIButton CreateButton(float y, float width, float height, string text)
        {
            UIButton button = new UIButton();
            button.Frame = new CGRect(width * 0.15f, y, width * 0.7f, height * 0.11f);
            button.SetTitle(text, UIControlState.Normal);
            button.Font = UIFont.FromName("Arial-BoldMT", height * 0.065f);
            button.SetTitleColor(UIColor.FromRGB(247, 220, 111), UIControlState.Normal);
            button.BackgroundColor = UIColor.FromRGB(153, 163, 164);//FromRGB(202, 255, 240);

            button.Layer.CornerRadius = 10;
            return button;
        }

        public void ButtonEvent(UIButton Button, string segue, int index)
        {
            if(index != 0) ImagesList = GetListAddress(index);
            PerformSegue(segue, this);
            Button.Layer.BorderWidth = 2;
            Button.Layer.BorderColor = UIColor.FromRGB(247, 220, 111).CGColor;//FromRGB(102, 207, 120).CGColor;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var size = (SizeF)this.View.Frame.Size;
            var width = 0f;
            var height = 0f;

            if (size.Width < size.Height)
            {
                width = size.Height;
                height = size.Width;
            }  
            else 
            {
                width = size.Width;
                height = size.Height;
            }

            UILabel Label = new UILabel();
            Label.Frame = new CGRect(width * 0.15f, height * 0.02f, width * 0.7f, height * 0.12f);
            Label.TextAlignment = UITextAlignment.Center;
            Label.Font = UIFont.FromName("Arial-BoldMT", height * 0.075f);
            Label.TextColor = UIColor.FromRGB(153, 163, 164);//FromRGB(102, 207, 120);
            Label.Text = "Lighting Scheme";
            MainView.AddSubview(Label);

            UIButton LightingScheme1 = CreateButton(height * 0.125f, width, height, "1 LightingScheme");
            MainView.AddSubview(LightingScheme1);
            LightingScheme1.TouchDown += (sender, e) =>
            {
                ButtonEvent(LightingScheme1, "ShowGallery", 1);
            };

            UIButton LightingScheme2 = CreateButton(height * 0.25f, width, height, "2 LightingScheme");
            MainView.AddSubview(LightingScheme2);
            LightingScheme2.TouchUpInside += (sender, e) =>
            {
                ButtonEvent(LightingScheme2, "ShowGallery", 2);
            };

            UIButton LightingScheme3 = CreateButton(height * 0.375f, width, height, "3 LightingScheme");
            MainView.AddSubview(LightingScheme3);
            LightingScheme3.TouchUpInside += (sender, e) =>
            {
                ButtonEvent(LightingScheme3, "ShowGallery", 3);
            };

            UIButton LightingScheme4 = CreateButton(height * 0.5f, width, height, "4 or more Sources of Light");
            MainView.AddSubview(LightingScheme4);
            LightingScheme4.TouchUpInside += (sender, e) =>
            {
                ButtonEvent(LightingScheme4, "ShowGallery", 4);
            };

            UIButton LightingScheme5 = CreateButton(height * 0.625f, width, height, "Mobile Photo Tricks");
            MainView.AddSubview(LightingScheme5);
            LightingScheme5.TouchUpInside += (sender, e) =>
            {
                ButtonEvent(LightingScheme5, "ShowGallery", 5);
            };

            UIButton Equipment = CreateButton(height * 0.75f, width, height, "Equipment & Marking");
            MainView.AddSubview(Equipment);
            Equipment.TouchUpInside += (sender, e) =>
            {
                ButtonEvent(Equipment, "ShowEquipment", 6);
            };

            UIButton About = CreateButton(height * 0.875f, width, height, "About");
            MainView.AddSubview(About);
            About.TouchUpInside += (sender, e) =>
            {
                ButtonEvent(About, "ShowAbout", 0);
            };
        }

        public List<string> GetListAddress(int number_category)
        {
            var list = new List<string>();
            string[] array = Directory.GetFiles("Image/" + number_category + "/");
            return array.ToList();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var imagesCollection = segue.DestinationViewController as GalleryController;
            if (imagesCollection != null)
            {
                imagesCollection.ListForCollectionView = ImagesList;
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
