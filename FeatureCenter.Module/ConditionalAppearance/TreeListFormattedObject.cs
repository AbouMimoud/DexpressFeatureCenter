using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base.General;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using System.Drawing;

namespace FeatureCenter.Module.ConditionalAppearance {
    [ImageName("ConditionalAppearance.ConditionalAppearance")]
    [NavigationItem(Captions.ConditionalAppearanceGroup)]
    [System.ComponentModel.DisplayName(Captions.ConditionalAppearance_Formatting_TreeList)]
    [Appearance("TreeView.Bold", TargetItems = "Name", FontStyle = FontStyle.Bold, Criteria = "FontStyle = 'Bold'")]
    [Appearance("TreeView.Italic", TargetItems = "Name", FontStyle = FontStyle.Italic, Criteria = "FontStyle = 'Italic'")]
    [Appearance("TreeView.Regular", TargetItems = "Name", FontStyle = FontStyle.Regular, Criteria = "FontStyle = 'Regular'")]
    [Appearance("TreeView.Strikeout", TargetItems = "Name", FontStyle = FontStyle.Strikeout, Criteria = "FontStyle = 'Strikeout'")]
    [Appearance("TreeView.Underline", TargetItems = "Name", FontStyle = FontStyle.Underline, Criteria = "FontStyle = 'Underline'")]
    [Appearance("TreeView.BackColor.Red", TargetItems = "Name", BackColor = "Red", FontColor = "Black", Priority = 1, Criteria = "Severity = 'Severe'")]
    [Appearance("TreeView.Blue", TargetItems = "Name", FontColor = "Blue", Criteria = "Priority = 'Low'")]
    [Appearance("TreeView.FontColor.Red", TargetItems = "Name", FontColor = "Red", Criteria = "Priority = 'High'")]
    [Hint(Hints.ConditionalAppearance_TreeListFormattedObjectHint, ViewType.Any)]
    public class TreeListFormattedObject : NamedBaseObject, ITreeNode {
        private FontStyle fontStyle;
        private Severity severity = Severity.Moderate;
        private Priority priority = Priority.Normal;
        private string description;
        private TreeListFormattedObject parentObject;
		[Browsable(false)]
        public TreeListFormattedObject(Session session)
            : base(session) { }
        public TreeListFormattedObject(Session session, string name)
            : base(session, name) { }

        public string Description {
            get { return description; }
            set { SetPropertyValue("Description", ref description, value); }
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

        [Browsable(false)]
        [Association("FormatTreeListObject-FormatTreeListObject")]
        public TreeListFormattedObject ParentObject {
            get { return parentObject; }
            set { SetPropertyValue<TreeListFormattedObject>("ParentObject", ref parentObject, value); }
        }
        [Browsable(false)]
        [Association("FormatTreeListObject-FormatTreeListObject"), Aggregated]
        public XPCollection<TreeListFormattedObject> NestedObjects {
            get { return GetCollection<TreeListFormattedObject>("NestedObjects"); }
        }

        ITreeNode ITreeNode.Parent {
            get { return ParentObject; }
        }
        System.ComponentModel.IBindingList ITreeNode.Children {
            get { return NestedObjects; }
        }
    }
}
