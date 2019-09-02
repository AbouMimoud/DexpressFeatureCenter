using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.Drawing;
using DevExpress.Xpo.Metadata;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.PropertyEditors {

    [NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top), System.ComponentModel.DisplayName(Captions.PropertyEditors_ImageProperties)]
    [Hint(Hints.ImagePropertiesHint)]
    [ImageName("PropertyEditors.Demo_Image_Properties")]
    public class ImagePropertiesObject : NamedBaseObject {

        public ImagePropertiesObject(Session session) : base(session) { }
        [DevExpress.Xpo.Size(SizeAttribute.Unlimited)]
        [VisibleInListViewAttribute(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 40)]
        public byte[] ImageProperty {
            get { return GetPropertyValue<byte[]>("ImageProperty"); }
            set { SetPropertyValue<byte[]>("ImageProperty", value); }
        }

        [DevExpress.Xpo.Size(SizeAttribute.Unlimited), Delayed()]
        [VisibleInListViewAttribute(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PopupPictureEdit, DetailViewImageEditorMode = ImageEditorMode.DropDownPictureEdit)]
        public byte[] ImageDelayedProperty {
            get { return GetDelayedPropertyValue<byte[]>("ImageDelayedProperty"); }
            set { SetDelayedPropertyValue<byte[]>("ImageDelayedProperty", value); }
        }
    }
}
