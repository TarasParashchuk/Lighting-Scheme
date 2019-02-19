using CoreGraphics;
using System;
using UIKit;
using System.Drawing;
using FFImageLoading;

namespace LightingScheme
{
    public partial class AboutViewController : UIViewController
    {
        public AboutViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var size = (SizeF)this.View.Frame.Size;
            var width = size.Width;
            var height = size.Height;

            var ImageScheme = new UIImageView();
            ImageScheme.Frame = new CGRect(size.Width * 0.35f, size.Height * 0.1f, size.Width * 0.3f, size.Height * 0.07f);
            ImageScheme.Image = new UIImage("Lightscheme.png");
            AboutView.AddSubview(ImageScheme);

            var ImageSchemeMain = new UIImageView();
            ImageSchemeMain.Frame = new CGRect((size.Width - size.Height * 0.5f * 0.75f) / 2, size.Height * 0.22f, size.Height * 0.5f * 0.75f, size.Height * 0.5f);
            ImageSchemeMain.Image = new UIImage("LogoScheme.png");
            AboutView.AddSubview(ImageSchemeMain);

            UILabel Label = new UILabel();
            Label.Frame = new CGRect(width * 0.15f, height * 0.74f, width * 0.7f, height * 0.08f);
            Label.TextAlignment = UITextAlignment.Center;
            Label.Font = UIFont.FromName("Arial", height * 0.035f);
            Label.TextColor = UIColor.FromRGB(23, 32, 42);//FromRGB(102, 207, 120);
            Label.Text = "Copyright© 2018 Lighting Scheme";
            AboutView.AddSubview(Label);

            UILabel Label1 = new UILabel();
            Label1.Frame = new CGRect(width * 0.15f, height * 0.78f, width * 0.7f, height * 0.08f);
            Label1.TextAlignment = UITextAlignment.Center;
            Label1.Font = UIFont.FromName("Arial", height * 0.035f);
            Label1.TextColor = UIColor.FromRGB(23, 32, 42);//FromRGB(102, 207, 120);
            Label1.Text = "Lighting Scheme All Rights Reserved";
            AboutView.AddSubview(Label1);

            UILabel Label2 = new UILabel();
            Label2.Frame = new CGRect(width * 0.15f, height * 0.82f, width * 0.7f, height * 0.08f);
            Label2.TextAlignment = UITextAlignment.Center;
            Label2.Font = UIFont.FromName("Arial", height * 0.035f);
            Label2.TextColor = UIColor.FromRGB(23, 32, 42);//FromRGB(102, 207, 120);
            Label2.Text = "© BS GROUP";
            AboutView.AddSubview(Label2);

            var ButtonMenu = new UIButton();
            ButtonMenu.SetImage(new UIImage("baseline_menu_black_36pt_2x.png"), UIControlState.Normal);
            ButtonMenu.Frame = new CGRect(height * 0.02f, height * 0.04f, width * 0.08f, width * 0.06f);
            ButtonMenu.TintColor = UIColor.FromRGB(247, 220, 111);
            AboutView.AddSubview(ButtonMenu);

            ButtonMenu.TouchUpInside += (sender, e) =>
            {
                PerformSegue("ShowMenuAbout", this);
            };
        }
    }
}