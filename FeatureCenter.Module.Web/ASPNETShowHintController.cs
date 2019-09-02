using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace DevExpress.ExpressApp.Web.Demos {
    public class HintPanel : PlaceHolder {
        private readonly ASPxPanel hintPanel;
        private readonly ASPxLabel hintLabel;
        public HintPanel() {
            hintPanel = new ASPxPanel();
            hintPanel.Style[HtmlTextWriterStyle.MarginBottom] = Unit.Pixel(8).ToString();
            hintPanel.Paddings.Assign(new Paddings(8, 8, 8, 8));
            hintPanel.BackColor = Color.LightGoldenrodYellow;
            hintPanel.ClientVisible = false;

            hintLabel = new ASPxLabel();
            hintPanel.Controls.Add(hintLabel);

            Controls.Add(hintPanel);
        }
        public override string ID {
            get { return hintPanel.ID; }
            set { hintPanel.ID = value; }
        }
        public string Hint {
            get { return hintLabel.Text; }
            set {
                hintLabel.Text = value;
                hintPanel.ClientVisible = !string.IsNullOrEmpty(value);
            }
        }
    }
}
