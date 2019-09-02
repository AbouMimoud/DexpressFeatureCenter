using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;
using DevExpress.Data.Filtering;

namespace FeatureCenter.Module.StateMachine {

    public enum BillStatus { Active, InDispute, Overdue }

    [NavigationItem]
    [ImageName("BO_Invoice")]
    public class PaymentTask : Task {

        public override void AfterConstruction() {
            base.AfterConstruction();
            PaymentStatus = Session.FindObject<Status>(new BinaryOperator("Caption", "New"));
        }

        public PaymentTask(Session session)
            : base(session) {
            
        }
        public override string ToString() {
            return Subject;
        }
        public Status PaymentStatus {
            get { return GetPropertyValue<Status>("PaymentStatus"); }
            set { SetPropertyValue<Status>("PaymentStatus", value); }
        }
        public BillStatus BillStatus {
            get { return GetPropertyValue<BillStatus>("BillStatus"); }
            set { SetPropertyValue<BillStatus>("BillStatus", value); }
        }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        [FileTypeFilter("AllFiles", 2, "*.*")]
        public FileData Bill {
            get { return GetPropertyValue<FileData>("Bill"); }
            set { SetPropertyValue<FileData>("Bill", value); }
        }
    }
}
