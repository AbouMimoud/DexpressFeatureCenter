using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Demos;
using DevExpress.Utils.Frames;
using DevExpress.ExpressApp.SystemModule;
using System.Windows.Forms;
using FeatureCenter.Module;
using FeatureCenter.Module.Win;
using FeatureCenter.Module.Win.Templates;

namespace FeatureCenter.Module.Win {
    public class WinCaptionController : ViewController {
        protected override void OnActivated() {
            base.OnActivated();
            if(Frame.Template is ICaptionPanelHolder) {
                ApplicationCaption8_1 captionPanel = ((ICaptionPanelHolder)Frame.Template).CaptionPanel;
                captionPanel.Text = View.Caption;
                captionPanel.Visible = !string.IsNullOrEmpty(captionPanel.Text);
            }
        }
        public WinCaptionController() {
            this.TargetViewNesting = Nesting.Root;
        }
    }
}
