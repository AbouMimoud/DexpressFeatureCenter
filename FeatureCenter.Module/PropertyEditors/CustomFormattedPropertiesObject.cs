using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;

namespace FeatureCenter.Module.PropertyEditors {
    [NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top)]
    [Hint(Hints.CustomFormattedPropertiesHint)]
    [ImageName("PropertyEditors.Demo_String_InSpecialFormat_Properties")]
    public class CustomFormattedProperties : NamedBaseObject {
        private string _PhoneString;
        private DateTime _DateAndTimeOfDay;
        private string _UrlString;
        private double _LargePrecisionNumber;
        public CustomFormattedProperties(Session session) : base(session) { }
        private const string UrlStringEditMask = @"(((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})";
        [VisibleInListView(true)]
        [ModelDefault("EditMaskType", "RegEx")]
        [ModelDefault("EditMask", UrlStringEditMask)]
        [ToolTip("Specify a web or email address in the following format: " + UrlStringEditMask, null, DevExpress.Utils.ToolTipIconType.Information)]
        public string UrlString {
            get {
                return _UrlString;
            }
            set {
                SetPropertyValue("UrlString", ref _UrlString, value);
            }
        }
        private const string PhoneStringEditMask = "(000)000-0000";
        [VisibleInListView(true)]
        [ModelDefault("EditMaskType", "Simple")]
        [ModelDefault("DisplayFormat", "{0:" + PhoneStringEditMask + "}")]
        [ModelDefault("EditMask", PhoneStringEditMask)]
        [ToolTip("Specify a phone number in the following format: " + PhoneStringEditMask, null, DevExpress.Utils.ToolTipIconType.Information)]
        public string PhoneString {
            get {
                return _PhoneString;
            }
            set {
                SetPropertyValue("PhoneString", ref _PhoneString, value);
            }
        }
        private const string DateAndTimeOfDayEditMask = "MM/dd/yyyy HH:mm:ss";
        [VisibleInListView(true)]
        [ModelDefault("DisplayFormat", "{0:" + DateAndTimeOfDayEditMask + "}")]
        [ModelDefault("EditMask", DateAndTimeOfDayEditMask)]
        [ToolTip("Specify a date and time of day in the following format: " + DateAndTimeOfDayEditMask, null, DevExpress.Utils.ToolTipIconType.Information)]
        public DateTime DateAndTimeOfDay {
            get {
                return _DateAndTimeOfDay;
            }
            set {
                SetPropertyValue("DateAndTimeOfDay", ref _DateAndTimeOfDay, value);
            }
        }
        private const string LargePrecisionNumberEditMask = "#,###,##0.##############################";
        [VisibleInListView(true)]
        [ModelDefault("DisplayFormat", "{0:" + LargePrecisionNumberEditMask + "}")]
        [ModelDefault("EditMask", LargePrecisionNumberEditMask)]
        [ToolTip("Specify a number with a large precision in the following format: " + LargePrecisionNumberEditMask, null, DevExpress.Utils.ToolTipIconType.Information)]
        public double LargePrecisionNumber {
            get {
                return _LargePrecisionNumber;
            }
            set {
                SetPropertyValue("LargePrecisionNumber", ref _LargePrecisionNumber, value);
            }
        }
        //private const string NumberFromZeroTo999EditMask = @"^([0-9]|[1-9][0-9]|[1-9][0-9][0-9])$";
        //private int _NumberFromZeroTo999;
        //[VisibleInListView(true)]
        //[ModelDefault("EditMaskType", "RegEx")]
        //[ModelDefault("EditMask", NumberFromZeroTo999EditMask)]
        //[ToolTip("Specify a value from the 0-999 range in the following format: " + NumberFromZeroTo999EditMask, null, DevExpress.Utils.ToolTipIconType.Information)]
        //public int NumberFromZeroTo999 {//Dennis: Waiting for S170928.
        //    get {
        //        return _NumberFromZeroTo999;
        //    }
        //    set {
        //        SetPropertyValue("NumberFromZeroTo999", ref _NumberFromZeroTo999, value);
        //    }
        //}
    }
}
