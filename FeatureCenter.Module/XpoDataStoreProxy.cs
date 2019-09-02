using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.DC.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;

namespace FeatureCenter.Module {
    public class XpoDataStoreProxy : IDataStore {
        private string northwindConnectionString;
        private string appConnectionString;
        private ReflectionDictionary northwindDictionary;
        private ThreadSafeDataLayer northwindDataLayer;
        private IDataStore northwindDataStore;
        private ThreadSafeDataLayer appDataLayer_;
        private ThreadSafeDataLayer appDataLayer {
            get {
                if(appDataLayer_ == null) {
                    ReflectionDictionary appDictionary = new ReflectionDictionary();
					XPDictionary dictionary = ((XpoTypeInfoSource)((TypesInfo)XafTypesInfo.Instance).FindEntityStore(typeof(XpoTypeInfoSource))).XPDictionary;
                    if(dictionary == null) {
                        throw new InvalidOperationException("dictionary is null"); //it is possible if called before XafTypesInfo initialization
                    }
                    foreach(XPClassInfo ci in dictionary.Classes) {
                        if(IsNorthwindDatabaseTable(ci.TableName)) {
                            northwindDictionary.QueryClassInfo(ci.ClassType);
                        }
                        else {
                            appDictionary.QueryClassInfo(ci.ClassType);
                        }
                    }
                    appDataLayer_ = new ThreadSafeDataLayer(appDictionary, appDataStore);
                }
                return appDataLayer_;
            }
        }
        private IDataStore appDataStore_;
        private IDataStore appDataStore {
            get {
                if(appDataStore_ == null) {
                    ConnectionStringDataStoreProvider dataStoreProvider = new ConnectionStringDataStoreProvider(appConnectionString);
                    IDisposable[] disposableObjects;
                    appDataStore_ = dataStoreProvider.CreateUpdatingStore(true, out disposableObjects);
                }
                return appDataStore_;
            }
        }
        private string[] northwindDatabaseTables = new string[] { "Orders", "Employees", "Customers" };

        private bool IsNorthwindDatabaseTable(string tableName) {
            if(!string.IsNullOrEmpty(tableName)) {
                foreach(string currentTableName in northwindDatabaseTables) {
                    if(tableName.EndsWith(currentTableName)) {
                        return true;
                    }
                }
            }
            return false;
        }
        private void EnsureNorthwindDataLayer() {
            if(northwindDataLayer == null) {
                northwindDataStore = XpoDefault.GetConnectionProvider(northwindConnectionString, AutoCreateOption.DatabaseAndSchema);
                northwindDataLayer = new ThreadSafeDataLayer(northwindDictionary, northwindDataStore);
            }
        }

        public void Initialize(string northwindConnectionString, string appConnectionString) {
            Guard.ArgumentIsNotNullOrEmpty(appConnectionString, "appConnectionString");
            Guard.ArgumentIsNotNullOrEmpty(northwindConnectionString, "northwindConnectionString");

            northwindDictionary = new ReflectionDictionary();
            this.northwindConnectionString = northwindConnectionString;
            this.appConnectionString = appConnectionString;
        }
        public AutoCreateOption AutoCreateOption {
            get { return AutoCreateOption.DatabaseAndSchema; }
        }
        public ModificationResult ModifyData(params ModificationStatement[] dmlStatements) {
            List<ParameterValue> modificationResultIdentities = new List<ParameterValue>();
            foreach(ModificationStatement stm in dmlStatements) {
                ModificationResult modificationResult;
                if(stm.Table != null && IsNorthwindDatabaseTable(stm.Table.Name)) {
                    EnsureNorthwindDataLayer();
                    modificationResult = northwindDataLayer.ModifyData(stm);
                }
                else {
                    modificationResult = appDataLayer.ModifyData(stm);
                }
                if(modificationResult != null) {
                    modificationResultIdentities.AddRange(modificationResult.Identities);
                }
            }

            return new ModificationResult(modificationResultIdentities);
        }
        public SelectedData SelectData(params SelectStatement[] selects) {
            List<SelectStatementResult> resultSet = new List<SelectStatementResult>();
            foreach(SelectStatement stm in selects) {
                SelectedData selectedData;
                if(stm.Table != null && IsNorthwindDatabaseTable(stm.Table.Name)) {
                    EnsureNorthwindDataLayer();
                    selectedData = northwindDataLayer.SelectData(stm);
                }
                else {
                    selectedData = appDataLayer.SelectData(stm);
                }
                if(selectedData != null) {
                    resultSet.AddRange(selectedData.ResultSet);
                }
            }

            return new SelectedData(resultSet.ToArray());
        }
        public UpdateSchemaResult UpdateSchema(bool dontCreateIfFirstTableNotExist, params DBTable[] tables) {
            //List<DBTable> db1Tables = new List<DBTable>();
            List<DBTable> db2Tables = new List<DBTable>();

            foreach(DBTable table in tables) {
                if(IsNorthwindDatabaseTable(table.Name)) {
                    //db1Tables.Add(table);
                }
                else {
                    db2Tables.Add(table);
                }
            }
            //northwindDataStore.UpdateSchema(false, db1Tables.ToArray());
            appDataStore.UpdateSchema(false, db2Tables.ToArray());
            return UpdateSchemaResult.SchemaExists;
        }
    }
}
