using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureCenter.Module.Win.PropertyEditors {
    [NavigationItem(Captions.PropertyEditorsGroup)]
    [ImageName("PropertyEditors.Demo_Spreadsheet_Properties")]
    [Hint(Hints.WinSpreadsheetPropertiesHint)]
    [System.ComponentModel.DisplayName("Spreadsheet Properties")]
    public class WinSpreadsheetProperties : NamedBaseObject {
        private byte[] spreadsheetEditor;
        private byte[] spreadsheetEditorWithBars;
        public WinSpreadsheetProperties(Session session) : base(session) {
        }        
        [EditorAlias(EditorAliases.SpreadsheetPropertyEditor)]
        public byte[] SpreadsheetEditorWithBars {
            get { return spreadsheetEditorWithBars; }
            set { SetPropertyValue("SpreadsheetEditorWithBars", ref spreadsheetEditorWithBars, value); }
        }
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.SpreadsheetPropertyEditor)]
        [VisibleInListView(true)]
        public byte[] SpreadsheetEditorWithoutBars {
            get { return spreadsheetEditor; }
            set { SetPropertyValue("SpreadsheetEditorWithoutBars", ref spreadsheetEditor, value); }
        }
    }
}
