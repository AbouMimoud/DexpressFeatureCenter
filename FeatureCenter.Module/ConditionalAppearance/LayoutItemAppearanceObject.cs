using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp.ConditionalAppearance;
using System.Drawing;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp;
using DevExpress.Xpo;

namespace FeatureCenter.Module.ConditionalAppearance {
    [ImageName("ConditionalAppearance.ConditionalAppearance")]
    [NavigationItem(Captions.ConditionalAppearanceGroup)]
    [System.ComponentModel.DisplayName(Captions.ConditionalAppearance_Formatting_LayoutItem)]
    [Hint(Hints.ConditionalAppearance_LayoutItemAppearanceObjectHint, ViewType.Any)]
    [Appearance("TargetFormattingProperty.GroupCaption.Red", AppearanceItemType.LayoutItem, "StartsWith(TargetFormattingProperty, 'Red group caption')", TargetItems = "LayoutGroup", FontColor = "Red")]
    public class LayoutItemAppearanceObject : NamedBaseObject {
        private string targetProperty;
        private FontStyle fontStyle;
        private Severity severity = Severity.Moderate;
        private Priority priority = Priority.Normal;

        public LayoutItemAppearanceObject(Session session)
            : base(session) {

        }
        public LayoutItemAppearanceObject(Session session, string name)
            : base(session, name) {

        }

        [ImmediatePostData]
        public Severity Severity {
            get { return severity; }
            set { SetPropertyValue("Severity", ref severity, value); }
        }
        [ImmediatePostData]
        public Priority Priority {
            get { return priority; }
            set { SetPropertyValue("Priority", ref priority, value); }
        }
        [ImmediatePostData]
        public FontStyle FontStyle {
            get { return fontStyle; }
            set { SetPropertyValue("FontStyle", ref fontStyle, value); }
        }
        [Appearance("TargetFormattingProperty.Caption.Bold", AppearanceItemType.LayoutItem, "FontStyle = 'Bold'", FontStyle = FontStyle.Bold)]
        [Appearance("TargetFormattingProperty.Caption.Italic", AppearanceItemType.LayoutItem, "FontStyle = 'Italic'", FontStyle = FontStyle.Italic)]
        [Appearance("TargetFormattingProperty.Caption.Regular", AppearanceItemType.LayoutItem, "FontStyle = 'Regular'", FontStyle = FontStyle.Regular)]
        [Appearance("TargetFormattingProperty.Caption.Strikeout", AppearanceItemType.LayoutItem, "FontStyle = 'Strikeout'", FontStyle = FontStyle.Strikeout)]
        [Appearance("TargetFormattingProperty.Caption.Underline", AppearanceItemType.LayoutItem, "FontStyle = 'Underline'", FontStyle = FontStyle.Underline)]
        [Appearance("TargetFormattingProperty.Caption.BackColor.Red", AppearanceItemType.LayoutItem, "Severity = 'Severe'", BackColor = "Red", FontColor = "Black", Priority = 1)]
        [Appearance("TargetFormattingProperty.Caption.Blue", AppearanceItemType.LayoutItem, "Priority = 'Low'", FontColor = "Blue")]
        [Appearance("TargetFormattingProperty.Caption.FontClor.Red", AppearanceItemType.LayoutItem, "Priority = 'High'", FontColor = "Red")]
        public string TargetFormattingProperty {
            get { return targetProperty; }
            set { SetPropertyValue("TargetProperty", ref targetProperty, value); }
        }
    }
}
