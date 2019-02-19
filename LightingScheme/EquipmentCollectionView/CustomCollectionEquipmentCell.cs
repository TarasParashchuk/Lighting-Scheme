using CoreGraphics;
using CoreAnimation;
using Foundation;
using UIKit;
using FFImageLoading;

namespace LightingScheme
{
    public partial class CustomCollectionEquipmentCell : UICollectionViewCell
    {
        public static NSString ID = new NSString("EquipmentCellID");

        [Export("initWithFrame:")]
        public CustomCollectionEquipmentCell(CGRect frame) : base(frame)
        {
            ImageView = new UIImageView(Bounds);
            ImageView.ContentMode = UIViewContentMode.ScaleToFill;
            ImageView.Frame = new CGRect((frame.Width - frame.Height * 0.9f) / 2, 0, frame.Height * 0.9f, frame.Height * 0.9f);
            ContentView.AddSubview(ImageView);

            Label = new UILabel(Bounds);
            Label.Frame = new CGRect(0, frame.Height * 0.9f, frame.Width, frame.Height * 0.1f);
            Label.Font = UIFont.FromName("Arial-BoldMT", frame.Height * 0.095f);
            Label.TextAlignment = UITextAlignment.Center;
            ContentView.AddSubview(Label);
        }

        public UIImageView ImageView { get; private set; }
        public UILabel Label { get; private set; }

        public void UpdateRow(string element, string name_element)
        {
            ImageService.Instance.LoadFile(element).Into(ImageView);
            Label.Text = name_element;
        }
    }
}

