using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp.Web.Templates;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Web.Demos;
using DevExpress.ExpressApp.Web.Controls;

public partial class Default : BaseXafPage, IHintTemplate {
    private HintPanel hintPanel;
    public override Control InnerContentPlaceHolder {
        get {
            return this.Content;
        }
    }
    protected override void OnInit(EventArgs e) {
        if(templateContent != null) {
            ViewSiteControl viewSiteControl = templateContent.ViewSiteControl as ViewSiteControl;
            if(viewSiteControl != null) {
                XafUpdatePanel updatePanel = viewSiteControl.Parent as XafUpdatePanel;
                if(updatePanel != null) {
                    hintPanel = new HintPanel();
                    hintPanel.ID = "hintPanel";
                    updatePanel.Controls.AddAt(0, hintPanel);
                }
            }
        }
        base.OnInit(e);
    }
    protected override ContextActionsMenu CreateContextActionsMenu() {
        return new ContextActionsMenu(this, "Edit", "RecordEdit", "ObjectsCreation", "ListView", "Reports");
    }
    #region IHintTemplate Members

    public string Hint {
        get {
            if(hintPanel != null) {
                return hintPanel.Hint;
            }
            return string.Empty;

        }
        set {
            if(hintPanel != null) {
                hintPanel.Hint = value;
            }
        }
    }

    #endregion
}
