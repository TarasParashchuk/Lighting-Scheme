using System;
using Foundation;
using System.Collections.Generic;
using UIKit;

namespace LightingScheme
{
    public class CustomCollectionImagesSource: UICollectionViewSource
    {
        List<string> item_list { get; set; }
        UIViewController view;
        public ModelData data { get; set; }

        public CustomCollectionImagesSource(List<string> _item_list, UIViewController _view)
        {
            item_list = _item_list;
            view = _view;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return item_list.Count;
        }

        public override bool ShouldSpringLoadItem(UICollectionView collectionView, NSIndexPath indexPath, IUISpringLoadedInteractionContext context)
        {
            return true;
        }

        public UIStoryboard MainStoryboard
        {
            get { return UIStoryboard.FromName("Main", NSBundle.MainBundle); }
        }

        public UIViewController GetViewController(UIStoryboard storyboard, string viewControllerName)
        {
            return storyboard.InstantiateViewController(viewControllerName);
        }

        [Export("collectionView:didSelectItemAtIndexPath:")]
        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var image_controller = GetViewController(MainStoryboard, "GalleryController");
            data = new ModelData(indexPath.Row, item_list[indexPath.Row], item_list);
            view.PerformSegue("ShowImage", image_controller);
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (CustomCollectionImageCell)collectionView.DequeueReusableCell(CustomCollectionImageCell.ID,indexPath);

            cell.UpdateRow(item_list[indexPath.Row]);

            return cell;
        }

    }
}
