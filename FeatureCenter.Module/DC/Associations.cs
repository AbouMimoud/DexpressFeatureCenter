using System.Collections.Generic;
using DevExpress.ExpressApp.DC;

namespace FeatureCenter.Module.DC {
    [DomainComponent]
    public interface ICompany {
        string Name { get; set; }
        // one-to-many Company-Owners relationship
        IList<IOwner> Owners { get; }
        // one-to-many Company-Departments relationship
        [Aggregated]
        IList<IDepartment> Departments { get; }
        // many-to-many Companies-Addresses relationship
        IList<IAddress> Addresses { get; }
    }

    [DomainComponent]
    public interface IOwner {
        string Name { get; set; }
        // one-to-many Company-Owners relationship
        ICompany Company { get; set; }
    }

    [DomainComponent]
    public interface IDepartment {
        string Title { get; set; }
        // one-to-many Company-Departments relationship
        ICompany Company { get; set; }
    }

    [DomainComponent]
    public interface IAddress {
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        // many-to-many Companies-Addresses relationship
        IList<ICompany> Companies { get; }
    }
}
