using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.Drawing;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.ListEditors {
    public interface IPictureItem {
        string ID { get; }
        Image Image { get; }
        string Text { get; }
    }

    [Hint(Hints.CustomListEditorObjectHint)]
    [System.ComponentModel.DisplayName(Captions.ListEditors_CustomListEditor)]
    [ImageName("ListEditors.Demo_ListEditors_Custom")]
    public class CustomListEditorDemoObject : BaseObject, IPictureItem {
        public CustomListEditorDemoObject(Session session) : base(session) { }
        [DisplayName]
        public string Title {
            get { return GetPropertyValue<string>("Title"); }
            set { SetPropertyValue<string>("Title", value); }
        }
        [ValueConverter(typeof(ImageValueConverter))]
        public Image Cover {
            get { return GetPropertyValue<Image>("Cover"); }
            set { SetPropertyValue<Image>("Cover", value); }
        }
        public String Director {
            get { return GetPropertyValue<String>("Director"); }
            set { SetPropertyValue<String>("Director", value); }
        }
        #region IPictureItem Members
        Image IPictureItem.Image {
            get { return Cover; }
        }
        string IPictureItem.Text {
            get { return String.Format("{0} by {1}", Title, Director); }
        }
        string IPictureItem.ID {
            get { return Oid.ToString(); }
        }
        #endregion
    }

}
