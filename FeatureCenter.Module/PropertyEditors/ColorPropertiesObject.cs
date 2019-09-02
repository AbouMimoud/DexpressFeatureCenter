using System;
using System.Drawing;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace FeatureCenter.Module.PropertyEditors {
    public class ColorValueConverter : ValueConverter {
        public override object ConvertToStorageType(object value) {
            if(!(value is Color)) return null;
            Color color = (Color)value;
            return color.IsEmpty ? -1 : color.ToArgb();
        }
        public override object ConvertFromStorageType(object value) {
            if(!(value is Int32)) return null;
            Int32 argbCode = Convert.ToInt32(value);
            return argbCode == -1 ? Color.Empty : Color.FromArgb(argbCode);
        }
        public override Type StorageType {
            get { return typeof(Int32); }
        }
    }

    [NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top), System.ComponentModel.DisplayName(Captions.PropertyEditors_ColorProperties)]
    [Hint(Hints.ColorPropertiesDescription)]
    [ImageName("PropertyEditors.Demo_Color_Properties")]
    public class ColorPropertiesObject : NamedBaseObject {
        private Color color;
        public ColorPropertiesObject(Session session) : base(session) { }
        [ValueConverter(typeof(ColorValueConverter))]
        public Color Color {
            get { return color; }
            set { SetPropertyValue("Color", ref color, value); }
        }
    }
}
