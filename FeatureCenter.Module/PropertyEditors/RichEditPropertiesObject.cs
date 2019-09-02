using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Editors;

namespace FeatureCenter.Module.PropertyEditors {
    [NavigationItem(Captions.PropertyEditorsGroup)]
    [ImageName("PropertyEditors.Demo_RichText_Properties")]
    [Hint(Hints.RichTextPropertiesHint)]
    [System.ComponentModel.DisplayName("Rich Text Properties")]
    public class RichTextProperties : NamedBaseObject {
        private byte[] richText;
        private byte[] richTextEditorWithBars;
        public RichTextProperties(Session session) : base(session) {
        }
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.RichTextPropertyEditor)]
        [VisibleInListView(true)]
        public byte[] RichTextEditorWithBars {
            get { return richTextEditorWithBars; }
            set { SetPropertyValue("RichTextEditorWithBars", ref richTextEditorWithBars, value); }
        }
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.RichTextPropertyEditor)]
        [VisibleInListView(true)]
        public byte[] RichTextEditor {
            get { return richText; }
            set { SetPropertyValue("RichText", ref richText, value); }
        }  
    }
}
