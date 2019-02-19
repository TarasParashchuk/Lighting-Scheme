using CoreGraphics;
using CoreAnimation;
using Foundation;
using UIKit;
using FFImageLoading;

namespace LightingScheme
{
    public class CustomCollectionImageCell : UICollectionViewCell
    {
        public static NSString ID = new NSString("ImageCellID");

        [Export("initWithFrame:")]
        public CustomCollectionImageCell(CGRect frame) : base(frame)
        {
            ImageView = new UIImageView(Bounds);
            ImageView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
            ImageView.ContentMode = UIViewContentMode.ScaleToFill;
            ImageView.ClipsToBounds = true;
            ImageView.Layer.EdgeAntialiasingMask = CAEdgeAntialiasingMask.LeftEdge | CAEdgeAntialiasingMask.RightEdge | CAEdgeAntialiasingMask.BottomEdge | CAEdgeAntialiasingMask.TopEdge;
            ContentView.AddSubview(ImageView);
        }

        public UIImageView ImageView { get; private set; }

        public void UpdateRow(string element)
        {
            ImageService.Instance.LoadFile(element).Into(ImageView);   
        }
    }
}
