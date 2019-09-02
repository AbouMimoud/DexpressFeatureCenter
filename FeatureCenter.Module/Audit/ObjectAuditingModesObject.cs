using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.AuditTrail;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Audit {
	[NavigationItem(Captions.AuditGroup), System.ComponentModel.DisplayName(Captions.Audit_ObjectAuditingModes)]
	[Hint(Hints.AuditObjectAuditingModes)]
	[ImageName("Audit.Demo_Audit_Modes")]
	public class ObjectAuditingModesObject : BaseAuditedObject {
		private string auditedProperty1;
		private DateTime auditedProperty2;
		public ObjectAuditingModesObject(Session session)
			: base(session) {
		}
		public string AuditedProperty1 {
			get { return auditedProperty1; }
			set { SetPropertyValue("AuditedProperty1", ref auditedProperty1, value); }
		}
		public DateTime AuditedProperty2 {
			get { return auditedProperty2; }
			set { SetPropertyValue("AuditedProperty2", ref auditedProperty2, value); }
		}
	}

	public class AuditModesController : ViewController {
		SingleChoiceAction chooseAuditMode;

		private void CreateActionItems() {
			chooseAuditMode.Items.Add(new ChoiceActionItem("Full (default)", ObjectAuditingMode.Full));
			chooseAuditMode.Items.Add(new ChoiceActionItem("Lightweight", ObjectAuditingMode.Lightweight));
			chooseAuditMode.Items.Add(new ChoiceActionItem("Creation only", ObjectAuditingMode.CreationOnly));
		}
		private void chooseAuditMode_SelectedItemChanged(object sender, EventArgs e) {
			if(chooseAuditMode.SelectedItem != null) {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
				AuditTrailService.Instance.EndSessionAudit(session);
				AuditTrailService.Instance.ObjectAuditingMode = (ObjectAuditingMode)chooseAuditMode.SelectedItem.Data;
				AuditTrailService.Instance.BeginSessionAudit(session, AuditTrailStrategy.OnObjectChanged);
			}
		}
		protected override void OnActivated() {
			base.OnActivated();
			chooseAuditMode.SelectedItemChanged += new EventHandler(chooseAuditMode_SelectedItemChanged);
			ChoiceActionItem currentItem = chooseAuditMode.Items.Find(ObjectAuditingMode.Full);
			if(currentItem != null) {
				chooseAuditMode.SelectedIndex = chooseAuditMode.Items.IndexOf(currentItem);
			}
		}
		protected override void OnDeactivated() {
			chooseAuditMode.SelectedItemChanged -= new EventHandler(chooseAuditMode_SelectedItemChanged);
			AuditTrailService.Instance.ObjectAuditingMode = ObjectAuditingMode.Full;
			base.OnDeactivated();
		}
		public AuditModesController() {
			TargetObjectType = typeof(ObjectAuditingModesObject);
			TargetViewNesting = Nesting.Root;
			TargetViewType = ViewType.DetailView;
            chooseAuditMode = new SingleChoiceAction(this, "ChooseAuditMode", PredefinedCategory.Edit);
			chooseAuditMode.ItemType = SingleChoiceActionItemType.ItemIsMode;
			chooseAuditMode.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Caption;
			CreateActionItems();
		}
	}
}
