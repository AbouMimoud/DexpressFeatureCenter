using System;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo.DB;

namespace FeatureCenter.Module {
    public class FeatureCenterXpoDataStoreProvider : IXpoDataStoreProvider {
        private XpoDataStoreProxy proxy;
        public FeatureCenterXpoDataStoreProvider() {
            proxy = new XpoDataStoreProxy();
        }
        public string ConnectionString {
            get { return ""; }
        }
        public IDataStore CreateUpdatingStore(bool allowUpdateSchema, out IDisposable[] disposableObjects) {
            disposableObjects = null;
            return proxy;
        }
        public IDataStore CreateWorkingStore(out IDisposable[] disposableObjects) {
            disposableObjects = null;
            return proxy;
        }
        public void Initialize(string northwindConnectionString, string appConnectionString) {
            proxy.Initialize(northwindConnectionString, appConnectionString);
        }
        public IDataStore CreateSchemaCheckingStore(out IDisposable[] disposableObjects) {
            disposableObjects = null;
            return proxy;
        }
    }
}
