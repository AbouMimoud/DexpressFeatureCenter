using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Templates.ActionControls;
using DevExpress.ExpressApp.Win.Controls;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.Win.Templates;
using DevExpress.ExpressApp.Win.Templates.Utils;
using DevExpress.Utils.Frames;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using FeatureCenter.Module.Win.Templates;

namespace FeatureCenter.Module.Win {
    public partial class DetailForm : XtraForm, IActionControlsSite, IContextMenuHolder, IWindowTemplate, IBarManagerHolder, ISupportViewChanged, ISupportUpdate, IViewSiteTemplate, ISupportStoreSettings, IHintTemplate, ICaptionPanelHolder {
        private static readonly object viewChanged = new object();
        private static readonly object settingsReloaded = new object();
        private StatusMessagesHelper statusMessagesHelper;

        protected virtual void RaiseViewChanged(DevExpress.ExpressApp.View view) {
            EventHandler<TemplateViewChangedEventArgs> handler = (EventHandler<TemplateViewChangedEventArgs>)Events[viewChanged];
            if(handler != null) {
                handler(this, new TemplateViewChangedEventArgs(view));
            }
        }
        protected virtual void RaiseSettingsReloaded() {
            EventHandler handler = (EventHandler)Events[settingsReloaded];
            if(handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        public DetailForm() {
            InitializeComponent();
            barManager.ForceLinkCreate();
            statusMessagesHelper = new StatusMessagesHelper(barContainerStatusMessages);
        }

        #region IActionControlsSite Members
        IEnumerable<IActionControl> IActionControlsSite.ActionControls {
            get { return barManager.ActionControls; }
        }
        IEnumerable<IActionControlContainer> IActionControlsSite.ActionContainers {
            get { return barManager.ActionContainers; }
        }
        IActionControlContainer IActionControlsSite.DefaultContainer {
            get { return actionContainerView; }
        }
        #endregion

        #region IFrameTemplate Members
        void IFrameTemplate.SetView(DevExpress.ExpressApp.View view) {
            viewSiteManager.SetView(view);
            RaiseViewChanged(view);
        }
        ICollection<IActionContainer> IFrameTemplate.GetContainers() {
            { return new IActionContainer[0]; }
        }
        IActionContainer IFrameTemplate.DefaultContainer {
            get { return null; }
        }
        #endregion

        #region IWindowTemplate Members
        void IWindowTemplate.SetCaption(string caption) {
            Text = caption;
        }
        void IWindowTemplate.SetStatus(ICollection<string> statusMessages) {
            statusMessagesHelper.SetMessages(statusMessages);
        }
        bool IWindowTemplate.IsSizeable {
            get { return FormBorderStyle == FormBorderStyle.Sizable; }
            set { FormBorderStyle = (value ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog); }
        }
        #endregion

        #region IBarManagerHolder Members
        BarManager IBarManagerHolder.BarManager {
            get { return barManager; }
        }
        event EventHandler IBarManagerHolder.BarManagerChanged {
            add { }
            remove { }
        }
        #endregion

        #region IContextMenuHolder
        PopupMenu IContextMenuHolder.ContextMenu {
            get { return contextMenu; }
        }
        #endregion

        #region ISupportViewChanged Members
        event EventHandler<TemplateViewChangedEventArgs> ISupportViewChanged.ViewChanged {
            add { Events.AddHandler(viewChanged, value); }
            remove { Events.RemoveHandler(viewChanged, value); }
        }
        #endregion

        #region ISupportUpdate Members
        void ISupportUpdate.BeginUpdate() {
            barManager.BeginUpdate();
        }
        void ISupportUpdate.EndUpdate() {
            barManager.EndUpdate();
        }
        #endregion

        #region IViewSiteTemplate Members
        object IViewSiteTemplate.ViewSiteControl {
            get { return viewSiteManager.ViewSiteControl; }
        }
        #endregion

        #region ISupportStoreSettings Members
        void ISupportStoreSettings.SetSettings(IModelTemplate settings) {
            IModelTemplateWin templateModel = (IModelTemplateWin)settings;
            TemplatesHelper templatesHelper = new TemplatesHelper(templateModel);
            IModelFormState formState;
            if(viewSiteManager.View != null) {
                formState = templatesHelper.GetFormStateNode(viewSiteManager.View.Id);
            }
            else {
                formState = templatesHelper.GetFormStateNode();
            }
            formStateModelSynchronizer.Model = formState;
        }
        void ISupportStoreSettings.ReloadSettings() {
            modelSynchronizationManager.ApplyModel();
            RaiseSettingsReloaded();
        }
        void ISupportStoreSettings.SaveSettings() {
            SuspendLayout();
            try {
                modelSynchronizationManager.SynchronizeModel();
            }
            finally {
                ResumeLayout();
            }
        }
        event EventHandler ISupportStoreSettings.SettingsReloaded {
            add { Events.AddHandler(settingsReloaded, value); }
            remove { Events.RemoveHandler(settingsReloaded, value); }
        }
        #endregion

        #region IHintTemplate Members
        string IHintTemplate.Hint {
            get {
                return hintPanel.Text;
            }
            set {
                hintPanel.Text = value;
                hintPanel.Visible = !string.IsNullOrEmpty(value);
            }
        }
        #endregion

        #region ICaptionPanelHolder Members
        ApplicationCaption8_1 ICaptionPanelHolder.CaptionPanel {
            get { return captionPanel; }
        }
        #endregion
    }
}
