using DevExpress.ExpressApp.DC;

namespace FeatureCenter.Module.DC {
    [DomainComponent]
    public interface IWorker {
        string Name { get; set; }
    }
    // IManager is IWorker
    [DomainComponent]
    public interface IManager : IWorker {
        string Company { get; set; }
    }
    // IEvangelist is IWorker
    [DomainComponent]
    public interface IEvangelist : IWorker {
        string Technology { get; set; }
    }
    // IOfficeManager is IManager
    [DomainComponent]
    public interface IOfficeManager : IManager {
        string Address { get; set; }
    }
    // IProductManager aggregates IManager and IEvangelist
    [DomainComponent]
    public interface IProductManager : IManager, IEvangelist {
        string Product { get; set; }
    }
}
