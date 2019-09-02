using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using DevExpress.ExpressApp.Demos;
using DevExpress.Xpo;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Xml;
using System.Drawing;

namespace FeatureCenter.Module.ListEditors {
	[NavigationItem(false)]
	[Hint(Hints.SchedulerListEditorDemoObjectHint)]
	[ImageName("ListEditors.Demo_ListEditors_Scheduler_LargeData")]
	public class SchedulerListEditorDemoObject : EventBaseObject, IObjectPropertiesInitializer {
		private static List<Guid> resourceKeys;
		public SchedulerListEditorDemoObject(Session session) : base(session) { }

		#region IObjectPropertiesInitializer Members
		public void InitializeObject(int index) {
			if(resourceKeys == null) {
				resourceKeys = new List<Guid>();
				for(int i = 0; i < 5; i++) {
					DevExpress.Persistent.BaseImpl.Resource res = new DevExpress.Persistent.BaseImpl.Resource(Session);
					res.Caption = "Resource " + i.ToString();
					if(i == 0) res.Color = Color.Blue;
					else if(i == 1) res.Color = Color.Red;
					else if(i == 2) res.Color = Color.Brown;
					res.Save();
					((UnitOfWork)Session).CommitChanges();
					resourceKeys.Add(res.Oid);
				}
			}
			this.Subject = "Test event #" + index;

			Random random = new Random((int)DateTime.Now.Ticks);

			this.AllDay = (index % (8 * random.Next(2) + 10) == 0 && index != 0);
			int days = (int)(index / 8);
			this.StartOn = DateTime.Today.Date.AddDays(days - 500).AddHours(9 + random.Next(12));
			this.EndOn = this.StartOn.AddHours(random.Next(1) + 1);
			if(index % (random.Next(1) + 1) == 0) {
				this.Resources.Add(Session.GetObjectByKey<DevExpress.Persistent.BaseImpl.Resource>(resourceKeys[random.Next(resourceKeys.Count - 1)]));
			}
			if(index % (8 * (random.Next(5) + 15)) == 0) {
				RecurrenceInfo recurrenceInfo = new RecurrenceInfo(this.StartOn, 10);
				RecurrenceInfoXmlPersistenceHelper persistenceHelper = new RecurrenceInfoXmlPersistenceHelper(recurrenceInfo);
				this.Type = (int)AppointmentType.Pattern;
				this.RecurrenceInfoXml = persistenceHelper.ToXml();
			}
			this.Save();
		}
		#endregion
	}

	[NavigationItem(false)]
	//[ListViewAutoFilterRowAttribute(true)]
	//[DefaultListViewOptionsAttribute(true, NewItemRowPosition.Top)]
	[ListViewFilter("AllData", "", "All Data", true, Index = 0)]
	[ListViewFilter("Event", "StartsWith(Subject, 'Event')" , "Subject begins with 'Event'", Index = 1)]
    [ListViewFilter("NotEvent", "not StartsWith(Subject, 'Event')", "Subject not begins with 'Event'", Index = 2)]
	[ImageName("Demo_ListEditors_Scheduler_Filter")]
	[Hint(Hints.SchedulerListEditorFilterDemoObjectHint)]
	public class SchedulerListEditorFilterDemoObject : EventBaseObject {
		public SchedulerListEditorFilterDemoObject(Session session) : base(session) { }
	}
	
	[NavigationItem(false)]
	[ImageName(TreeListEditorFilterByTextObject.FilterByTextImageName)]
	[Hint(Hints.SchedulerListEditorFilterByTextDemoObjectHint)]
	public class SchedulerListEditorFilterByTextDemoObject : EventBaseObject {
		public SchedulerListEditorFilterByTextDemoObject(Session session) : base(session) { }
	}

}
