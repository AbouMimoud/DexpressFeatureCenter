using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Templates.ActionControls;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.Controls;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.Win.Templates;
using DevExpress.ExpressApp.Win.Templates.Utils;
using DevExpress.Utils.Frames;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using FeatureCenter.Module.Win.Templates;
using DevExpress.ExpressApp.Win.Utils;

namespace FeatureCenter.Module.Win {
    public partial class MainForm : XtraForm, IActionControlsSite, IContextMenuHolder, IWindowTemplate, IDockManagerHolder, IBarManagerHolder, ISupportViewChanged, IXafDocumentsHostWindow, ISupportUpdate, IViewSiteTemplate, ISupportStoreSettings, IHintTemplate, ICaptionPanelHolder {
        private static readonly object viewChanged = new object();
        private static readonly object settingsReloaded = new object();
        private UIType uiType;
        private StatusMessagesHelper statusMessagesHelper;

        protected virtual void InitializeImages() {
            ImageOptionsHelper.AssignImage(barMdiChildrenListItem.ImageOptions, "Action_WindowList");
            ImageOptionsHelper.AssignImage(barSubItemPanels.ImageOptions, "Action_Navigation");
        }
        protected virtual void SynchronizeBarAndDockingControllerWithDefault() {
            barAndDockingController.PropertiesBar.ScaleEditors = BarAndDockingController.Default.PropertiesBar.ScaleEditors;
            barAndDockingController.PropertiesRibbon.ScaleEditors = BarAndDockingController.Default.PropertiesRibbon.ScaleEditors;
        }
        protected virtual void OnUITypeChanged() {
            UIType uiType = ((IXafDocumentsHostWindow)this).UIType;
            if(uiType == UIType.TabbedMDI) {
                SetupTabbedMdi();
            }
            else if(uiType == UIType.StandardMDI) {
                SetupStandardMdi();
            }
            else {
                SetupSdi();
            }
        }
        protected void SetupSdi() {
            barManager.MdiMenuMergeStyle = BarMdiMenuMergeStyle.Never;
            documentManager.View = noDocumentsView;
            documentManager.ViewCollection.Remove(nativeMdiView);
            documentManager.ViewCollection.Remove(tabbedView);
            viewSiteControlPanel.Visible = true;
            documentManager.ClientControl = viewSitePanel;
            barMdiChildrenListItem.Visibility = BarItemVisibility.Never;
        }
        protected void SetupStandardMdi() {
            barManager.MdiMenuMergeStyle = BarMdiMenuMergeStyle.OnlyWhenChildMaximized;
            documentManager.View = nativeMdiView;
            documentManager.ViewCollection.Remove(noDocumentsView);
            documentManager.ViewCollection.Remove(tabbedView);
            SetupMdiCommon();
        }
        protected void SetupTabbedMdi() {
            barManager.MdiMenuMergeStyle = BarMdiMenuMergeStyle.Always;
            documentManager.View = tabbedView;
            documentManager.ViewCollection.Remove(noDocumentsView);
            documentManager.ViewCollection.Remove(nativeMdiView);
            SetupMdiCommon();
        }
        private void SetupMdiCommon() {
            viewSiteControlPanel.Visible = false;
            documentManager.MdiParent = this;
            barMdiChildrenListItem.Visibility = BarItemVisibility.Always;
        }

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

        protected override FormShowMode ShowMode {
            get { return FormShowMode.AfterInitialization; }
        }

        public MainForm() {
            InitializeComponent();
            InitializeImages();
            SynchronizeBarAndDockingControllerWithDefault();
            barManager.ForceLinkCreate();
            statusMessagesHelper = new StatusMessagesHelper(barContainerStatusMessages);
            OnUITypeChanged();
        }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            hintPanel.UpdateInfoImage();
        }
        
        #region IActionControlsSite Members
        IEnumerable<IActionControl> IActionControlsSite.ActionControls {
            get { return barManager.ActionControls; }
        }
        IEnumerable<IActionControlContainer> IActionControlsSite.ActionContainers {
            get { return barManager.ActionContainers; }
        }
        IActionControlContainer IActionControlsSite.DefaultContainer {
            get { return actionContainerDefault; }
        }
        #endregion

        #region IFrameTemplate Members
        void IFrameTemplate.SetView(DevExpress.ExpressApp.View view) {
            viewSiteManager.SetView(view);
            RaiseViewChanged(view);
        }
        ICollection<IActionContainer> IFrameTemplate.GetContainers() {
            return new IActionContainer[] { navigation };
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

        #region IDockManagerHolder Members
        DevExpress.XtraBars.Docking.DockManager IDockManagerHolder.DockManager {
            get { return dockManager; }
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

        #region IDocumentsHostWindow Members
        bool IDocumentsHostWindow.DestroyOnRemovingChildren {
            get { return true; }
        }
        DocumentManager IDocumentsHostWindow.DocumentManager {
            get { return documentManager; }
        }
        #endregion

        #region IXafDocumentsHostWindow Members
        UIType IXafDocumentsHostWindow.UIType {
            get { return uiType; }
            set {
                if(uiType != value) {
                    uiType = value;
                    OnUITypeChanged();
                }
            }
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
            formStateModelSynchronizer.Model = templatesHelper.GetFormStateNode();
            navigation.Model = templatesHelper.GetNavBarCustomizationNode();
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
