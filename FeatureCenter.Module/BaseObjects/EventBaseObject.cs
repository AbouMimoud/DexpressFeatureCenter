using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace FeatureCenter.Module {
	[NavigationItem(false)]
	[DefaultProperty("Subject")]
	[ImageName("ListEditors.Demo_ListEditors_Scheduler")]
	public class EventBaseObject : Event {
		public EventBaseObject(Session session) : base(session) { }
	}

	//public class EventBaseObject : BaseObject, IEvent {
	//    private bool allDay;
	//    private string appointmentId;
	//    private string description;
	//    private DateTime endOn;
	//    private int label;
	//    private string location;
	//    private string resourceId;
	//    private DateTime startOn;
	//    private int status;
	//    private string subject;
	//    private int type;

	//    public EventBaseObject(Session session) : base(session) { }

	//    public string AppointmentId {
	//        get { return appointmentId; }
	//        set { SetPropertyValue("AppointmentId", ref appointmentId, value); }
	//    }

	//    #region IEvent Members
	//    public bool AllDay {
	//        get { return allDay; }
	//        set { SetPropertyValue("AllDay", ref allDay, value); }
	//    }
	//    string IEvent.AppointmentId {
	//        get { return AppointmentId; }
	//    }
	//    public string Description {
	//        get { return description; }
	//        set { SetPropertyValue("Description", ref description, value); }
	//    }
	//    public DateTime EndOn {
	//        get { return endOn; }
	//        set { SetPropertyValue("EndOn", ref endOn, value); }
	//    }
	//    public int Label {
	//        get { return label; }
	//        set { SetPropertyValue("Label", ref label, value); }
	//    }
	//    public string Location {
	//        get { return location; }
	//        set { SetPropertyValue("Location", ref location, value); }
	//    }
	//    public string ResourceId {
	//        get { return resourceId; }
	//        set { SetPropertyValue("ResourceId", ref resourceId, value); }
	//    }
	//    public DateTime StartOn {
	//        get { return startOn; }
	//        set { SetPropertyValue("StartOn", ref startOn, value); }
	//    }
	//    public int Status {
	//        get { return status; }
	//        set { SetPropertyValue("Status", ref status, value); }
	//    }
	//    public string Subject {
	//        get { return subject; }
	//        set { SetPropertyValue("Subject", ref subject, value); }
	//    }
	//    public int Type {
	//        get { return type; }
	//        set { SetPropertyValue("Type", ref type, value); }
	//    }
	//    #endregion
	//}
}
