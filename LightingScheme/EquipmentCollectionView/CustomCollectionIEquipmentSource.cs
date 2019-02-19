using System;
using Foundation;
using System.Collections.Generic;
using UIKit;
using System.IO;

namespace LightingScheme
{
    public class CustomCollectionIEquipmentSource : UICollectionViewSource
    {
        public List<string> list { get; set; }

        public CustomCollectionIEquipmentSource(List<string> list)
        {
            this.list = list;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return list.Count;
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

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (CustomCollectionEquipmentCell)collectionView.DequeueReusableCell(CustomCollectionEquipmentCell.ID, indexPath);

            cell.UpdateRow(list[indexPath.Row], Path.GetFileNameWithoutExtension(list[indexPath.Row]));

            return cell;
        }

    }
}
