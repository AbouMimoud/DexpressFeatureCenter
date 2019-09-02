using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using FeatureCenter.Module.Navigation;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Demos;
using System.Drawing;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;

namespace FeatureCenter.Module.ConditionalAppearance {
	public enum Priority { Low, Normal, High}
	public enum Severity { Minor, Moderate, Severe }

	[ImageName("ConditionalAppearance.ConditionalAppearance")]
	[NavigationItem(Captions.ConditionalAppearanceGroup)]
	[System.ComponentModel.DisplayName(Captions.ConditionalAppearance_Formatting)]
    [Hint(Hints.ConditionalAppearance_FormatAppearanceObjectHint, ViewType.Any)]
    public class FormatAppearanceObject : NamedBaseObject {
		private string targetProperty;
		private FontStyle fontStyle;
		private Severity severity = Severity.Moderate;
		private Priority priority = Priority.Normal;

		public FormatAppearanceObject(Session session)
			: base(session) {
			
		}
		public FormatAppearanceObject(Session session, string name)
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
        [Appearance("TargetFormattingProperty.Bold", FontStyle = FontStyle.Bold, Criteria = "FontStyle = 'Bold'")]
        [Appearance("TargetFormattingProperty.Italic", FontStyle = FontStyle.Italic, Criteria = "FontStyle = 'Italic'")]
        [Appearance("TargetFormattingProperty.Regular", FontStyle = FontStyle.Regular, Criteria = "FontStyle = 'Regular'")]
        [Appearance("TargetFormattingProperty.Strikeout", FontStyle = FontStyle.Strikeout, Criteria = "FontStyle = 'Strikeout'")]
        [Appearance("TargetFormattingProperty.Underline", FontStyle = FontStyle.Underline, Criteria = "FontStyle = 'Underline'")]
        [Appearance("TargetFormattingProperty.BackColor.Red", BackColor = "Red", FontColor = "Black", Priority = 1, Criteria = "Severity = 'Severe'")]
        [Appearance("TargetFormattingProperty.Blue", FontColor = "Blue", Criteria = "Priority = 'Low'")]
        [Appearance("TargetFormattingProperty.FontColor.Red", FontColor = "Red", Criteria = "Priority = 'High'")]
        public string TargetFormattingProperty {
			get { return targetProperty; }
			set { SetPropertyValue("TargetProperty", ref targetProperty, value); }
		}

        [Appearance("RelatedObject.BackColor.Yellow", BackColor = "Yellow", Criteria = "Priority = 'Normal'")]
        public FormatAppearanceObject RelatedObject {
            get { return GetPropertyValue<FormatAppearanceObject>("RelatedObject"); }
            set { SetPropertyValue<FormatAppearanceObject>("RelatedObject", value); }
        }
    }
}
