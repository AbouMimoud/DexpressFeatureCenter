using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace FeatureCenter.Module.DC {
    [DomainComponent]
    public interface IPerson {
        [ImmediatePostData]
        string FirstName { get; set; }
        [ImmediatePostData]
        string LastName { get; set; }
        string DisplayName { get; }
    }
    [DomainLogic(typeof(IPerson))]
    public class IPerson_Logic {
        public string Get_DisplayName(IPerson person) {
            return person.FirstName + " " + person.LastName;
        }
    }

    [DomainComponent]
    public interface IClient : IPerson {
        [ImmediatePostData]
        string ClientID { get; set; }
    }
    [DomainLogic(typeof(IClient))]
    public class IClient_Logic {
        public string Get_DisplayName(IClient client) {
            return client.ClientID;
        }
    }
}
