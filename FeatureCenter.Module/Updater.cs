using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Dashboards;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Kpi;
using DevExpress.ExpressApp.StateMachine.Utils;
using DevExpress.ExpressApp.StateMachine.Xpo;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.AuditTrail;
using DevExpress.Xpo;
using DevExpress.XtraRichEdit;
using FeatureCenter.Module.Actions.CustomizeAction;
using FeatureCenter.Module.Audit;
using FeatureCenter.Module.ConditionalAppearance;
using FeatureCenter.Module.CustomFields;
using FeatureCenter.Module.DC;
using FeatureCenter.Module.Filtering;
using FeatureCenter.Module.KeyProperty;
using FeatureCenter.Module.Layout;
using FeatureCenter.Module.ListEditors;
using FeatureCenter.Module.Localization;
using FeatureCenter.Module.Navigation;
using FeatureCenter.Module.Notifications;
using FeatureCenter.Module.Performance;
using FeatureCenter.Module.PropertyEditors;
using FeatureCenter.Module.Skins;
using FeatureCenter.Module.StateMachine;
using FeatureCenter.Module.Validation;
using FeatureCenter.Module.ViewVariants;

namespace FeatureCenter.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            UpdateStatus("FeatureCenter.Module.Updater.UpdateDatabaseAfterUpdateSchema", "", "Creating initial demo data...");
            if(ObjectSpace is XPObjectSpace) {
                CreateDefaultFocusedItemObjects();
                CreateViewVariantsObjects();
                CreateStructPropertiesObjects();
                CreateDateTimePropertiesObjects();
                CreateStringPropertiesObjects();
                CreateBooleanPropertiesObjects();
                CreateColorPropertiesObjects();
                CreateEnumPropertiesObjects();
                CreateFileAttachmentPropertiesObjects();
                CreateImagePropertiesObjects();
                CreateReferencePropertiesObjects();
                CreateNumericPropertiesObjects();
                CreateCollectionPropertiesObjects();
                CreateCriteriaPropertiesObjects();
                CreateKeyPropetiesObjects();
                CreateCustomFieldsObjects();
                CreateCustomFormattedPropertiesObjects();
                CustomPropertyEditorsObjects();
                CreateRuleRequiredFieldObjects();
                CreateRuleCriteriaObjects();
                CreateRuleRangeObjects();
                CreateRuleValueComparisonObjects();
                CreateRuleStringComparisonObjects();
                CreateRuleRegularExpressionObjects();
                CreateRuleFromBoolPropertyObjects();
                CreateRuleObjectExistsObjects();
                CreateRuleUniqueValueObjects();
                CreateRuleIsReferencedObjects();
                CreateRuleCombinationOfPropertiesIsUniqueObjects();

                CreateCodeRuleObjects();
                CreateCustomRuleObjects();
                CreateValidationTemplatesObjects();
                CreateSimpleValidationSettingsObjects();
                CreateComplexValidationSettingsObjects();
                CreateMiscellaneousValidationFeaturesObjects();
                CreateValidationErrorsAndWarningsFeatureObjects();
                CreateClientSideValidationObjects();

                CreateSkinDemoObjects();

                CreateLocalizationDemoObjects();


                CreateFilterByTextObjects();

                CreateNavigationObjects();
                CreateListEditorsDemoObjects();

                CreateSimplePropertiesAuditedObjects();
                CreateCollectionPropertiesAuditedObjects();
                CreateAuditSettingsObjects();
                CreateAuditObjectAuditingModesObjects();
                CreateConditionalAppearanceObjects();
                CreateKpiObjects();
                CreateCustomListEditorObjects();

                CreateDCData();

                CreateStateMachineObjects();

                CreateReportData();
                CreateEditableReport();
                CreateCustomEmployee();

                CreateMapsListEditorsData();
                CreateMapsPropertyEditorsData();

                CreateWebMasterDetailData();

                CreateCustomizeActionObjects();
                InitializeDashboards();
                CreateOrderBandsObjects();
                CreateOfficeObject();
                CreateMailMergeData();
            }

            ObjectSpace.CommitChanges();
        }
        private void CreateOfficeObject() {
            string documentName = "Demo Document";
            RichTextProperties richText = ObjectSpace.FindObject<RichTextProperties>(CriteriaOperator.Parse("Name = ?", documentName));
            if(richText == null) {
                richText = ObjectSpace.CreateObject<RichTextProperties>();
                richText.Name = documentName;
                byte[] document = GetDemoDocument("DemoDocument");
                richText.RichTextEditor = document;
                richText.RichTextEditorWithBars = document;
            }
        }
        private byte[] GetDemoDocument(string name) {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames();
            var resourceName = resourceNames.FirstOrDefault(p => p.Contains(name));
            byte[] buffer = null;
            using(Stream stream = assembly.GetManifestResourceStream(resourceName)) {
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
            }
            return buffer;
        }
        private void CreateCustomEmployee() {
            CustomEmployee michael = ObjectSpace.FindObject<CustomEmployee>(null);
            if(michael == null) {
                michael = ObjectSpace.CreateObject<CustomEmployee>();
                michael.FirstName = "Michael";
                michael.LastName = "Bond";
            }
        }
        private void CreateOrderBandsObjects() {
            ContactBands michael = ObjectSpace.FindObject<ContactBands>(CriteriaOperator.Parse("Name='Michael Suyama'"));
            if(michael == null) {
                michael = ObjectSpace.CreateObject<ContactBands>();
                michael.Name = "Michael Suyama";
                michael.Email = "MichaelSuyama@xafFeatureCenter.com";
                michael.Phone = "(555)493-8440";
            }

            ContactBands steven = ObjectSpace.FindObject<ContactBands>(CriteriaOperator.Parse("Name='Steven Buchanan'"));
            if(steven == null) {
                steven = ObjectSpace.CreateObject<ContactBands>();
                steven.Name = "Steven Buchanan";
                steven.Email = "StevenBuchanan@xafFeatureCenter.com";
                steven.Phone = "(555)421-0059";
            }

            ContactBands margaret = ObjectSpace.FindObject<ContactBands>(CriteriaOperator.Parse("Name='Margaret Peacock'"));
            if(margaret == null) {
                margaret = ObjectSpace.CreateObject<ContactBands>();
                margaret.Name = "Margaret Peacock";
                margaret.Email = "MargaretPeacock@xafFeatureCenter.com";
                margaret.Phone = "(555)756-2345";
            }

            ProductBands clam = ObjectSpace.FindObject<ProductBands>(CriteriaOperator.Parse("Name='Jack`s New England Clam Chowder'"));
            if(clam == null) {
                clam = ObjectSpace.CreateObject<ProductBands>();
                clam.Name = "Jack`s New England Clam Chowder";
                clam.Company = "Hanari Carnes";
                clam.Country = "Brazil";
                clam.Region = "RJ";
                clam.UnitPrice = 7.7;
            }

            ProductBands apples = ObjectSpace.FindObject<ProductBands>(CriteriaOperator.Parse("Name='Manjimup Dried Apples'"));
            if(apples == null) {
                apples = ObjectSpace.CreateObject<ProductBands>();
                apples.Name = "Manjimup Dried Apples";
                apples.Company = "Hanari Carnes";
                apples.Country = "Brazil";
                apples.Region = "RJ";
                apples.UnitPrice = 42.4;
            }

            ProductBands tofu = ObjectSpace.FindObject<ProductBands>(CriteriaOperator.Parse("Name='Tofu'"));
            if(tofu == null) {
                tofu = ObjectSpace.CreateObject<ProductBands>();
                tofu.Name = "Tofu";
                tofu.Country = "Germany";
                tofu.Company = "Toms Spezialitaten";
                tofu.UnitPrice = 18.6;
            }

            ProductBands mozzarella = ObjectSpace.FindObject<ProductBands>(CriteriaOperator.Parse("Name='Mozzarella di Giovanni'"));
            if(mozzarella == null) {
                mozzarella = ObjectSpace.CreateObject<ProductBands>();
                mozzarella.Name = "Mozzarella di Giovanni";
                mozzarella.Company = "Vins et alcools Chevalier";
                mozzarella.Country = "France";
                mozzarella.UnitPrice = 38.4;
            }

            OrderBands mozzarellaOrder = ObjectSpace.FindObject<OrderBands>(CriteriaOperator.Parse("Name='MozzarellaOrder'"));
            if(mozzarellaOrder == null) {
                mozzarellaOrder = ObjectSpace.CreateObject<OrderBands>();
                mozzarellaOrder.Name = "MozzarellaOrder";
                mozzarellaOrder.Product = mozzarella;
                mozzarellaOrder.Contact = steven;
                mozzarellaOrder.Qty = 5;
                mozzarellaOrder.Date = new DateTime(2015, 11, 5);
            }

            OrderBands tofuOrder = ObjectSpace.FindObject<OrderBands>(CriteriaOperator.Parse("Name='TofuOrder'"));
            if(tofuOrder == null) {
                tofuOrder = ObjectSpace.CreateObject<OrderBands>();
                tofuOrder.Name = "TofuOrder";
                tofuOrder.Product = tofu;
                tofuOrder.Contact = michael;
                tofuOrder.Qty = 9;
                tofuOrder.Date = new DateTime(2015, 4, 5);
            }

            OrderBands applesOrder = ObjectSpace.FindObject<OrderBands>(CriteriaOperator.Parse("Name='ApplesOrder'"));
            if(applesOrder == null) {
                applesOrder = ObjectSpace.CreateObject<OrderBands>();
                applesOrder.Name = "ApplesOrder";
                applesOrder.Product = apples;
                applesOrder.Contact = michael;
                applesOrder.Qty = 40;
                applesOrder.Date = new DateTime(2015, 8, 5);
            }

            OrderBands clamOrder = ObjectSpace.FindObject<OrderBands>(CriteriaOperator.Parse("Name='ClamOrder'"));
            if(clamOrder == null) {
                clamOrder = ObjectSpace.CreateObject<OrderBands>();
                clamOrder.Name = "ClamOrder";
                clamOrder.Product = clam;
                clamOrder.Contact = margaret;
                clamOrder.Qty = 10;
                clamOrder.Date = new DateTime(2015, 7, 5);
            }
        }
        void CreateMailMergeData() {
            DevExpress.Persistent.BaseImpl.RichTextMailMergeData template = ObjectSpace.FindObject<DevExpress.Persistent.BaseImpl.RichTextMailMergeData>(CriteriaOperator.Parse("Name == 'Appreciation Letter'"));
            if(template == null) {
                template = ObjectSpace.CreateObject<DevExpress.Persistent.BaseImpl.RichTextMailMergeData>();
                template.Name = "Appreciation Letter";
                template.DataType = typeof(Reports.ContactForReport);

                var assembly = Assembly.GetExecutingAssembly();
                RichEditDocumentServer richEditControl = new RichEditDocumentServer();
                Stream stream = assembly.GetManifestResourceStream("FeatureCenter.Module.Resources.Template.docx");
                richEditControl.LoadDocument(stream);
                template.Template = richEditControl.OpenXmlBytes;
            }
            ObjectSpace.CommitChanges();
        }
        private byte[] GetByteArrayFromAssembly(string name) {
            UnmanagedMemoryStream stream = (UnmanagedMemoryStream)GetType().Assembly.GetManifestResourceStream(name);
            stream.Position = 0;
            byte[] result = new byte[stream.Length];
            stream.Read(result, 0, (Int32)stream.Length);
            return result;
        }
        private void CreateReportData() {
            FeatureCenter.Module.Reports.Position developerPosition = ObjectSpace.FindObject<FeatureCenter.Module.Reports.Position>(CriteriaOperator.Parse("Title == 'Developer'"));
            if(developerPosition == null) {
                developerPosition = ObjectSpace.CreateObject<FeatureCenter.Module.Reports.Position>();
                developerPosition.Title = "Developer";
            }
            FeatureCenter.Module.Reports.Position managerPosition = ObjectSpace.FindObject<FeatureCenter.Module.Reports.Position>(CriteriaOperator.Parse("Title == 'Manager'"));
            if(managerPosition == null) {
                managerPosition = ObjectSpace.CreateObject<FeatureCenter.Module.Reports.Position>();
                managerPosition.Title = "Manager";
            }

            FeatureCenter.Module.Reports.ContactForReport contactJohn = ObjectSpace.FindObject<FeatureCenter.Module.Reports.ContactForReport>(CriteriaOperator.Parse("FirstName == 'John' && LastName == 'Nilsen'"));
            if(contactJohn == null) {
                contactJohn = ObjectSpace.CreateObject<FeatureCenter.Module.Reports.ContactForReport>();
                contactJohn.FirstName = "John";
                contactJohn.LastName = "Nilsen";
                contactJohn.Email = "john_nilsen@md.com";
                contactJohn.Birthday = new DateTime(1981, 10, 3);
                contactJohn.Position = developerPosition;
            }
            FeatureCenter.Module.Reports.PhoneNumberReportContact johnPhoneNumber_1 = ObjectSpace.FindObject<FeatureCenter.Module.Reports.PhoneNumberReportContact>(CriteriaOperator.Parse("Number == '888-111-222'"));
            if(johnPhoneNumber_1 == null) {
                johnPhoneNumber_1 = ObjectSpace.CreateObject<FeatureCenter.Module.Reports.PhoneNumberReportContact>();
                johnPhoneNumber_1.Number = "888-111-222";
                contactJohn.PhoneNumbers.Add(johnPhoneNumber_1);
            }
            FeatureCenter.Module.Reports.PhoneNumberReportContact johnPhoneNumber_2 = ObjectSpace.FindObject<FeatureCenter.Module.Reports.PhoneNumberReportContact>(CriteriaOperator.Parse("Number == '888-333-222'"));
            if(johnPhoneNumber_2 == null) {
                johnPhoneNumber_2 = ObjectSpace.CreateObject<FeatureCenter.Module.Reports.PhoneNumberReportContact>();
                johnPhoneNumber_2.Number = "888-333-222";
                contactJohn.PhoneNumbers.Add(johnPhoneNumber_2);
            }

            ObjectSpace.CommitChanges();

            FeatureCenter.Module.Reports.ContactForReport contactMary = ObjectSpace.FindObject<FeatureCenter.Module.Reports.ContactForReport>(CriteriaOperator.Parse("FirstName == 'Mary' && LastName == 'Tellitson'"));
            if(contactMary == null) {
                contactMary = ObjectSpace.CreateObject<FeatureCenter.Module.Reports.ContactForReport>();
                contactMary.FirstName = "Mary";
                contactMary.LastName = "Tellitson";
                contactMary.Email = "mary_tellitson@md.com";
                contactMary.Birthday = new DateTime(1980, 11, 27);
                contactMary.Position = managerPosition;
            }
            FeatureCenter.Module.Reports.PhoneNumberReportContact maryPhoneNumber_1 = ObjectSpace.FindObject<FeatureCenter.Module.Reports.PhoneNumberReportContact>(CriteriaOperator.Parse("Number == '999-999-999'"));
            if(maryPhoneNumber_1 == null) {
                maryPhoneNumber_1 = ObjectSpace.CreateObject<FeatureCenter.Module.Reports.PhoneNumberReportContact>();
                maryPhoneNumber_1.Number = "999-999-999";
                contactMary.PhoneNumbers.Add(maryPhoneNumber_1);
            }
            FeatureCenter.Module.Reports.PhoneNumberReportContact maryPhoneNumber_2 = ObjectSpace.FindObject<FeatureCenter.Module.Reports.PhoneNumberReportContact>(CriteriaOperator.Parse("Number == '999-999-777'"));
            if(maryPhoneNumber_2 == null) {
                maryPhoneNumber_2 = ObjectSpace.CreateObject<FeatureCenter.Module.Reports.PhoneNumberReportContact>();
                maryPhoneNumber_2.Number = "999-999-777";
                contactMary.PhoneNumbers.Add(maryPhoneNumber_2);
            }

            ObjectSpace.CommitChanges();
        }
        private void CreateEditableReport() {
            string reportName = "Contacts Report (editable)";
            DevExpress.Persistent.BaseImpl.ReportDataV2 reportData = ObjectSpace.FindObject<DevExpress.Persistent.BaseImpl.ReportDataV2>(new BinaryOperator("DisplayName", reportName));
            if(reportData == null) {
                reportData = ObjectSpace.CreateObject<DevExpress.Persistent.BaseImpl.ReportDataV2>();
                DevExpress.XtraReports.UI.XtraReport rep = new DevExpress.XtraReports.UI.XtraReport();
                MemoryStream stream = new MemoryStream(FeatureCenter.Module.Reports.ContactReportLayout.ReportLayout);
                rep.LoadLayout(stream);
                DevExpress.ExpressApp.ReportsV2.ReportDataProvider.ReportsStorage.SaveReport(reportData, rep);
            }
        }
        private void CreateStateMachineObjects() {
            Employee employee1 = ObjectSpace.FindObject<Employee>(new BinaryOperator("FirstName", "John"));
            if(employee1 == null) {
                employee1 = ObjectSpace.CreateObject<Employee>();
                employee1.FirstName = "John";
                employee1.LastName = "Smith";
            }
            Employee employee2 = ObjectSpace.FindObject<Employee>(new BinaryOperator("FirstName", "Mary"));
            if(employee2 == null) {
                employee2 = ObjectSpace.CreateObject<Employee>();
                employee2.FirstName = "Mary";
                employee2.LastName = "Tellitson";
            }
            Status status1 = ObjectSpace.FindObject<Status>(new BinaryOperator("Caption", "New"));
            if(status1 == null) {
                status1 = ObjectSpace.CreateObject<Status>();
                status1.Caption = "New";
            }
            Status status2 = ObjectSpace.FindObject<Status>(new BinaryOperator("Caption", "Pending"));
            if(status2 == null) {
                status2 = ObjectSpace.CreateObject<Status>();
                status2.Caption = "Pending";
            }
            Status status3 = ObjectSpace.FindObject<Status>(new BinaryOperator("Caption", "Returned"));
            if(status3 == null) {
                status3 = ObjectSpace.CreateObject<Status>();
                status3.Caption = "Returned";
            }
            Status status4 = ObjectSpace.FindObject<Status>(new BinaryOperator("Caption", "Canceled"));
            if(status4 == null) {
                status4 = ObjectSpace.CreateObject<Status>();
                status4.Caption = "Canceled";
            }
            Status status5 = ObjectSpace.FindObject<Status>(new BinaryOperator("Caption", "Paid"));
            if(status5 == null) {
                status5 = ObjectSpace.CreateObject<Status>();
                status5.Caption = "Paid";
            }

            ObjectSpace.CommitChanges();

            Task task1 = ObjectSpace.FindObject<Task>(new BinaryOperator("Subject", "Fix breakfast"));
            if(task1 == null) {
                task1 = ObjectSpace.CreateObject<Task>();
                task1.Subject = "Fix breakfast";
                task1.AssignedTo = employee1;
            }

            PaymentTask task2 = ObjectSpace.FindObject<PaymentTask>(new BinaryOperator("Subject", "Track the bill"));
            if(task2 == null) {
                task2 = ObjectSpace.CreateObject<PaymentTask>();
                task2.Subject = "Track the bill";
                task2.AssignedTo = employee2;
            }

            XpoStateMachine machine1 = ObjectSpace.FindObject<XpoStateMachine>(new BinaryOperator("Name", "Payment"));
            if(machine1 == null) {
                machine1 = ObjectSpace.CreateObject<XpoStateMachine>();
                machine1.Name = "Payment";
                machine1.Active = true;
                machine1.TargetObjectType = typeof(PaymentTask);
                machine1.StatePropertyName = new StringObject("PaymentStatus");

                XpoState newState = ObjectSpace.CreateObject<XpoState>();
                newState.Marker = new MarkerObject(status1);
                XpoState pendingState = ObjectSpace.CreateObject<XpoState>();
                pendingState.TargetObjectCriteria = "[BillStatus] <> 'Active'";
                pendingState.Marker = new MarkerObject(status2);
                XpoState returnedState = ObjectSpace.CreateObject<XpoState>();
                returnedState.Marker = new MarkerObject(status3);
                XpoState canceledState = ObjectSpace.CreateObject<XpoState>();
                canceledState.Marker = new MarkerObject(status4);
                XpoState paidState = ObjectSpace.CreateObject<XpoState>();
                paidState.TargetObjectCriteria = "[BillStatus] = 'Active'";
                paidState.Marker = new MarkerObject(status5);
                XpoStateAppearance appearance1 = ObjectSpace.CreateObject<XpoStateAppearance>();
                appearance1.TargetItems = "Bill";
                appearance1.Enabled = false;
                paidState.Appearance.Add(appearance1);

                newState.AddTransition(pendingState);
                newState.AddTransition(returnedState);
                newState.AddTransition(canceledState);
                newState.AddTransition(paidState);
                pendingState.AddTransition(returnedState);
                pendingState.AddTransition(canceledState);
                pendingState.AddTransition(paidState);

                machine1.StartState = newState;
                machine1.States.Add(newState);
                machine1.States.Add(pendingState);
                machine1.States.Add(returnedState);
                machine1.States.Add(canceledState);
                machine1.States.Add(paidState);

            }
        }
        private void CreateDCData() {
            if(ObjectSpace.GetObjects<IPersistentPropertiesPresenter>().Count == 0) {
                IPersistentPropertiesPresenter persistentProperties = ObjectSpace.CreateObject<IPersistentPropertiesPresenter>();

                IContact contact = ObjectSpace.CreateObject<IContact>();
                contact.Name = "Anthony Peterson";
                contact.Birthday = new DateTime(1982, 7, 27);
                persistentProperties.Contact = contact;

                Organization organization = ObjectSpace.CreateObject<Organization>();
                organization.Name = "Peterson Associates Inc.";
                contact.Organization = organization;

                IPhone phone1 = ObjectSpace.CreateObject<IPhone>();
                phone1.Number = "(555)756-2314";
                contact.Phones.Add(phone1);

                IPhone phone2 = ObjectSpace.CreateObject<IPhone>();
                phone2.Number = "(555)414-0922";
                contact.Phones.Add(phone2);
            }
            if(ObjectSpace.GetObjects<IAssociationsPresenter>().Count == 0) {
                IAssociationsPresenter associationsPresenter = ObjectSpace.CreateObject<IAssociationsPresenter>();

                ICompany company = ObjectSpace.CreateObject<ICompany>();
                company.Name = "Peterson Associates Inc.";
                associationsPresenter.Company = company;

                IOwner owner1 = ObjectSpace.CreateObject<IOwner>();
                owner1.Name = "Anthony Peterson";
                company.Owners.Add(owner1);

                IOwner owner2 = ObjectSpace.CreateObject<IOwner>();
                owner2.Name = "Anita Ryan";
                company.Owners.Add(owner2);

                IOwner owner3 = ObjectSpace.CreateObject<IOwner>();
                owner3.Name = "Alfred Nolan";
                company.Owners.Add(owner3);

                IOwner owner4 = ObjectSpace.CreateObject<IOwner>();
                owner4.Name = "Barbara Chapman";
                company.Owners.Add(owner4);

                IDepartment department1 = ObjectSpace.CreateObject<IDepartment>();
                department1.Title = "Marketing";
                company.Departments.Add(department1);

                IDepartment department2 = ObjectSpace.CreateObject<IDepartment>();
                department2.Title = "Sales";
                company.Departments.Add(department2);

                IDepartment department3 = ObjectSpace.CreateObject<IDepartment>();
                department3.Title = "Development";
                company.Departments.Add(department3);

                IAddress address1 = ObjectSpace.CreateObject<IAddress>();
                address1.AddressLine1 = "13673 Pearl Dr #7";
                address1.AddressLine2 = "Monroe, MI 48161";
                company.Addresses.Add(address1);

                IAddress address2 = ObjectSpace.CreateObject<IAddress>();
                address2.AddressLine1 = "420234 Rogge St";
                address2.AddressLine2 = "Detroit, MI 48234";
                company.Addresses.Add(address2);

                IAddress address3 = ObjectSpace.CreateObject<IAddress>();
                address3.AddressLine1 = "1198 Theresa Cir";
                address3.AddressLine2 = "Whitinsville, MA 01582";
                company.Addresses.Add(address3);

                IAddress address4 = ObjectSpace.CreateObject<IAddress>();
                address4.AddressLine1 = "115636 Hodges Ln";
                address4.AddressLine2 = "Moundville, AL 35474";
                company.Addresses.Add(address4);

                IAddress address5 = ObjectSpace.CreateObject<IAddress>();
                address5.AddressLine1 = "1268 Bright St";
                address5.AddressLine2 = "Jersey City, NJ 07308";
                company.Addresses.Add(address5);

                IAddress address6 = ObjectSpace.CreateObject<IAddress>();
                address6.AddressLine1 = "114840 Interlake Ave N";
                address6.AddressLine2 = "Seattle, WA 98131";
                company.Addresses.Add(address6);
            }
            if(ObjectSpace.GetObjects<IMultipleInheritancePresenter>().Count == 0) {
                IMultipleInheritancePresenter multipleInheritancePresenter = ObjectSpace.CreateObject<IMultipleInheritancePresenter>();

                IOfficeManager officeManager1 = ObjectSpace.CreateObject<IOfficeManager>();
                officeManager1.Name = "Anthony Peterson";
                officeManager1.Address = "1268 Bright St, Jersey City, NJ 07308";
                officeManager1.Company = "Bunkelman Productions";

                IOfficeManager officeManager2 = ObjectSpace.CreateObject<IOfficeManager>();
                officeManager2.Name = "Barbara Chapman";
                officeManager2.Address = "114840 Interlake Ave N, Seattle, WA 98131";
                officeManager2.Company = "Nolan Group Inc.";

                IOfficeManager officeManager3 = ObjectSpace.CreateObject<IOfficeManager>();
                officeManager3.Name = "Alfred Nolan";
                officeManager3.Address = "13673 Pearl Dr #7, Monroe, MI 48161";
                officeManager3.Company = "Peterson Associates Inc.";

                IProductManager productManager1 = ObjectSpace.CreateObject<IProductManager>();
                productManager1.Name = "Anita Ryan";
                productManager1.Company = "Bevington Beverages";
                productManager1.Product = "UltraLock";
                productManager1.Technology = "Security Systems";

                IProductManager productManager2 = ObjectSpace.CreateObject<IProductManager>();
                productManager2.Name = "Annie Vicars";
                productManager2.Company = "Boucher Technology";
                productManager2.Product = "NaviTron";
                productManager2.Technology = "Navigation Devices";

            }
            if(ObjectSpace.GetObjects<IDomainLogicForPropertiesPresenter>().Count == 0) {
                IDomainLogicForPropertiesPresenter domainLogicForPropertiesPresenter = ObjectSpace.CreateObject<IDomainLogicForPropertiesPresenter>();

                IProduct product = ObjectSpace.CreateObject<IProduct>();
                product.Name = "NaviTron";
                product.Price = 15;
                product.Price = 25;
                domainLogicForPropertiesPresenter.Product = product;

                IReview review1 = ObjectSpace.CreateObject<IReview>();
                review1.ProductName = "NaviTron";
                review1.Text = "Great product! Will buy again.";

                IReview review2 = ObjectSpace.CreateObject<IReview>();
                review2.ProductName = "NaviTron";
                review2.Text = "At this price it is a steal.";

                IReview review3 = ObjectSpace.CreateObject<IReview>();
                review3.ProductName = "NaviTron";
                review3.Text = "Support is second to no one. I recommend this to all my friends.";

                IReview review4 = ObjectSpace.CreateObject<IReview>();
                review4.ProductName = "NaviTron";
                review4.Text = "Nice features. Solid build.";

                IReview review5 = ObjectSpace.CreateObject<IReview>();
                review5.ProductName = "NaviTron";
                review5.Text = "Cool!";
            }
            if(ObjectSpace.GetObjects<IDomainLogicForMethodsPresenter>().Count == 0) {
                IDomainLogicForMethodsPresenter domainLogicForMethodsPresenter = ObjectSpace.CreateObject<IDomainLogicForMethodsPresenter>();

                ITask task = ObjectSpace.CreateObject<ITask>();
                task.Description = "Review reports";
                task.DueDate = DateTime.Today.AddMonths(1);
                domainLogicForMethodsPresenter.Task = task;
            }
            if(ObjectSpace.GetObjects<IDomainLogicInheritancePresenter>().Count == 0) {
                IDomainLogicInheritancePresenter domainLogicInheritancePresenter = ObjectSpace.CreateObject<IDomainLogicInheritancePresenter>();

                IPerson person = ObjectSpace.CreateObject<IPerson>();
                person.FirstName = "Carolyn";
                person.LastName = "Baker";
                domainLogicInheritancePresenter.Person = person;

                IClient client = ObjectSpace.CreateObject<IClient>();
                client.FirstName = "Beverly";
                client.LastName = "Oneil";
                client.ClientID = "CL415";
                domainLogicInheritancePresenter.Client = client;
            }
        }
        private void CreateKpiObjects() {
            KpiDefinition obj1 = ObjectSpace.FindObject<KpiDefinition>(CriteriaOperator.Parse("Name='Sales'"));
            if(obj1 == null) {
                obj1 = ObjectSpace.CreateObject<KpiDefinition>();
                obj1.Name = "Sales";
                obj1.TargetObjectType = typeof(FeatureCenter.Module.Northwind.Order);
                obj1.Criteria = "OrderDate >= '@RangeStart' And OrderDate <= '@RangeEnd'";
                obj1.Expression = "Sum(Freight)";
                obj1.Range = DateRangeRepository.FindRange("Rolling 1996");
                obj1.Compare = true;
                obj1.RangeToCompare = DateRangeRepository.FindRange("Rolling 1995");
                obj1.MeasurementFrequency = TimeIntervalType.Month;
                obj1.Save();
            }
            KpiDefinition obj4 = ObjectSpace.FindObject<KpiDefinition>(CriteriaOperator.Parse("Name='Sales growing totals'"));
            if(obj4 == null) {
                obj4 = ObjectSpace.CreateObject<KpiDefinition>();
                obj4.Name = "Sales growing totals";
                obj4.TargetObjectType = typeof(FeatureCenter.Module.Northwind.Order);
                obj4.Criteria = "OrderDate >= '@RangeStart' And OrderDate <= '@RangeEnd'";
                obj4.Expression = "Sum(Freight)";
                obj4.Range = DateRangeRepository.FindRange("Rolling 1996");
                obj4.Compare = true;
                obj4.RangeToCompare = DateRangeRepository.FindRange("Rolling 1995");
                obj4.MeasurementFrequency = TimeIntervalType.Month;
                obj4.MeasurementMode = MeasurementMode.RunningTotal;
                obj4.Save();
            }
            KpiDefinition obj6 = ObjectSpace.FindObject<KpiDefinition>(CriteriaOperator.Parse("Name='Outdated shippings count'"));
            if(obj6 == null) {
                obj6 = ObjectSpace.CreateObject<KpiDefinition>();
                obj6.Name = "Outdated shippings count";
                obj6.TargetObjectType = typeof(FeatureCenter.Module.Northwind.Order);
                obj6.Criteria = "OrderDate >= '@RangeStart' And OrderDate <= '@RangeEnd' And ShippedDate is not null And RequiredDate is not null";
                obj6.Expression = "Count";
                obj6.Range = DateRangeRepository.FindRange("Rolling 1996");
                obj6.Compare = true;
                obj6.RangeToCompare = DateRangeRepository.FindRange("Rolling 1995");
                obj6.MeasurementFrequency = TimeIntervalType.Month;
                obj6.Direction = Direction.LowIsBetter;
                obj6.GreenZone = 5;
                obj6.RedZone = 15;
                obj6.Save();
            }
            KpiScorecard obj2 = ObjectSpace.FindObject<KpiScorecard>(CriteriaOperator.Parse("Name='Sales'"));
            if(obj2 == null) {
                obj2 = ObjectSpace.CreateObject<KpiScorecard>();
                obj2.Name = "Sales";
                obj2.Save();
            }
            KpiInstance obj3 = ObjectSpace.FindObject<KpiInstance>(CriteriaOperator.Parse("KpiName='Sales'"));
            if(obj3 != null) {
                obj2.Indicators.Add(obj3);
                obj2.Save();
            }
            KpiInstance obj5 = ObjectSpace.FindObject<KpiInstance>(CriteriaOperator.Parse("KpiName='Sales growing totals'"));
            if(obj5 != null) {
                obj2.Indicators.Add(obj5);
                obj2.Save();
            }
            KpiInstance obj7 = ObjectSpace.FindObject<KpiInstance>(CriteriaOperator.Parse("KpiName='Outdated shippings count'"));
            if(obj7 != null) {
                obj2.Indicators.Add(obj7);
                obj2.Save();
            }
        }

        private void CreateCustomListEditorObjects() {
            CustomListEditorDemoObject obj1 = ObjectSpace.FindObject<CustomListEditorDemoObject>(CriteriaOperator.Parse("Title='Eternally Yours'"));
            if(obj1 == null) {
                obj1 = ObjectSpace.CreateObject<CustomListEditorDemoObject>();
                obj1.Title = "Eternally Yours";
                obj1.Cover = ImageLoader.Instance.LoadFromResource(GetType().Assembly, "FeatureCenter.Module.Images.ListEditors.Demo_ListEditors_Custom_EternallyYours.png");
                obj1.Director = "Tay Garnett";
                obj1.Save();
            }
            CustomListEditorDemoObject obj2 = ObjectSpace.FindObject<CustomListEditorDemoObject>(CriteriaOperator.Parse("Title='Sherlock Holmes - Dressed to Kill'"));
            if(obj2 == null) {
                obj2 = ObjectSpace.CreateObject<CustomListEditorDemoObject>();
                obj2.Title = "Sherlock Holmes - Dressed to Kill";
                obj2.Cover = ImageLoader.Instance.LoadFromResource(GetType().Assembly, "FeatureCenter.Module.Images.ListEditors.Demo_ListEditors_Custom_DressedToKill.png");
                obj2.Director = "Roy William Neill";
                obj2.Save();
            }
            CustomListEditorDemoObject obj3 = ObjectSpace.FindObject<CustomListEditorDemoObject>(CriteriaOperator.Parse("Title='The Last Time I Saw Paris'"));
            if(obj3 == null) {
                obj3 = ObjectSpace.CreateObject<CustomListEditorDemoObject>();
                obj3.Title = "The Last Time I Saw Paris";
                obj3.Cover = ImageLoader.Instance.LoadFromResource(GetType().Assembly, "FeatureCenter.Module.Images.ListEditors.Demo_ListEditors_Custom_TheLastTimeISawParis.png");
                obj3.Director = "Richard Brooks";
                obj3.Save();
            }
            CustomListEditorDemoObject obj4 = ObjectSpace.FindObject<CustomListEditorDemoObject>(CriteriaOperator.Parse("Title='Captain Kidd'"));
            if(obj4 == null) {
                obj4 = ObjectSpace.CreateObject<CustomListEditorDemoObject>();
                obj4.Title = "Teenagers from Outer Space";
                obj4.Director = "Tom Graeff";
                obj4.Save();
            }
        }
        private static void SetPropertyValue(Type type, object obj, string name, object value) {
            ITypeInfo ti = XafTypesInfo.Instance.FindTypeInfo(type);
            if(ti != null) {
                IMemberInfo mi = ti.FindMember(name);
                if(mi != null) {
                    mi.SetValue(obj, value);
                }
            }
        }
        private void CreateConditionalAppearanceObjects() {
            FormatAppearanceObject obj1 = ObjectSpace.FindObject<FormatAppearanceObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject1'"));
            if(obj1 == null) {
                obj1 = ObjectSpace.CreateObject<FormatAppearanceObject>();
                obj1.Name = "FormatAppearanceObject1";
                obj1.TargetFormattingProperty = "Target formatting property value";
                obj1.Save();
            }
            FormatAppearanceObject obj2 = ObjectSpace.FindObject<FormatAppearanceObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject2'"));
            if(obj2 == null) {
                obj2 = ObjectSpace.CreateObject<FormatAppearanceObject>();
                obj2.Name = "FormatAppearanceObject2";
                obj2.TargetFormattingProperty = "Target formatting property value (bold)";
                obj2.FontStyle = FontStyle.Bold;
                obj2.Save();
            }
            FormatAppearanceObject obj3 = ObjectSpace.FindObject<FormatAppearanceObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject3'"));
            if(obj3 == null) {
                obj3 = ObjectSpace.CreateObject<FormatAppearanceObject>();
                obj3.Name = "FormatAppearanceObject3";
                obj3.TargetFormattingProperty = "Target formatting property value (italic)";
                obj3.FontStyle = FontStyle.Italic;
                obj3.Save();
            }
            FormatAppearanceObject obj4 = ObjectSpace.FindObject<FormatAppearanceObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject4'"));
            if(obj4 == null) {
                obj4 = ObjectSpace.CreateObject<FormatAppearanceObject>();
                obj4.Name = "FormatAppearanceObject4";
                obj4.TargetFormattingProperty = "Target formatting property value (strikeout)";
                obj4.FontStyle = FontStyle.Strikeout;
                obj4.Save();
            }
            FormatAppearanceObject obj5 = ObjectSpace.FindObject<FormatAppearanceObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject5'"));
            if(obj5 == null) {
                obj5 = ObjectSpace.CreateObject<FormatAppearanceObject>();
                obj5.Name = "FormatAppearanceObject5";
                obj5.TargetFormattingProperty = "Target formatting property value (back color is Red)";
                obj5.Severity = Severity.Severe;
                obj5.Save();
            }
            FormatAppearanceObject obj6 = ObjectSpace.FindObject<FormatAppearanceObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject6'"));
            if(obj6 == null) {
                obj6 = ObjectSpace.CreateObject<FormatAppearanceObject>();
                obj6.Name = "FormatAppearanceObject6";
                obj6.TargetFormattingProperty = "Target formatting property value (font color is Blue)";
                obj6.Priority = Priority.Low;
                obj6.Save();
            }
            ActionAppearanceControlObject obj7 = ObjectSpace.FindObject<ActionAppearanceControlObject>(CriteriaOperator.Parse("Name='ActionAppearanceControlObject1'"));
            if(obj7 == null) {
                obj7 = ObjectSpace.CreateObject<ActionAppearanceControlObject>();
                obj7.Name = "ActionAppearanceControlObject1";
                obj7.Save();
            }
            ActionAppearanceControlObject obj8 = ObjectSpace.FindObject<ActionAppearanceControlObject>(CriteriaOperator.Parse("Name='ActionAppearanceControlObject2'"));
            if(obj8 == null) {
                obj8 = ObjectSpace.CreateObject<ActionAppearanceControlObject>();
                obj8.Name = "ActionAppearanceControlObject2";
                obj8.DisableDeleteAction = true;
                obj8.Save();
            }

            ConditionalAppearanceDisableEnableEditorsObject obj11 = ObjectSpace.FindObject<ConditionalAppearanceDisableEnableEditorsObject>(CriteriaOperator.Parse("Name='DisableEnableEditorsObject1'"));
            if(obj11 == null) {
                obj11 = ObjectSpace.CreateObject<ConditionalAppearanceDisableEnableEditorsObject>();
                obj11.Name = "DisableEnableEditorsObject1";
                obj11.SimpleProperty = "SimpleProperty can be disabled in any View";
                obj11.DisableCollectionProperty1 = false;
                obj11.DisableCollectionProperty2 = false;
                obj11.DisableLookupProperty = false;
                obj11.DisableSimpleProperty = false;
                obj11.LookupProperty = ObjectSpace.CreateObject<ConditionalAppearanceDisableEnableEditorsLookupObject>();
                obj11.LookupProperty.Name = "LookupProperty can be disabled in any View";
                obj11.DisableAggregatedProperty = false;
                obj11.AggregatedProperty = ObjectSpace.CreateObject<ConditionalAppearanceDisableEnableEditorsAggregatedObject>();
                obj11.AggregatedProperty.Name = "DisableEnableEditorsAggregatedObject1";
                obj11.AggregatedProperty.Description = "An aggregated object can be disabled in a Detail View";
                obj11.AggregatedProperty.DisableProperties = false;
                obj11.PropertyDisabledByStaticMethod = "Never can be edited";
                obj11.PropertyDisabledByInstanceMethod = "You can edit me";
                obj11.Save();
            }
            ConditionalAppearanceDisableEnableEditorsObject obj12 = ObjectSpace.FindObject<ConditionalAppearanceDisableEnableEditorsObject>(CriteriaOperator.Parse("Name='DisableEnableEditorsObject2'"));
            if(obj12 == null) {
                obj12 = ObjectSpace.CreateObject<ConditionalAppearanceDisableEnableEditorsObject>();
                obj12.Name = "DisableEnableEditorsObject2";
                obj12.SimpleProperty = "SimpleProperty is disabled in any View";
                obj12.DisableCollectionProperty1 = true;
                obj12.DisableCollectionProperty2 = true;
                obj12.DisableLookupProperty = true;
                obj12.DisableSimpleProperty = true;
                obj12.LookupProperty = ObjectSpace.CreateObject<ConditionalAppearanceDisableEnableEditorsLookupObject>();
                obj12.LookupProperty.Name = "LookupProperty is disabled in any View";
                obj12.DisableAggregatedProperty = true;
                obj12.AggregatedProperty = ObjectSpace.CreateObject<ConditionalAppearanceDisableEnableEditorsAggregatedObject>();
                obj12.AggregatedProperty.Name = "DisableEnableEditorsAggregatedObject2";
                obj12.AggregatedProperty.Description = "An aggregated object is disabled in a Detail View";
                obj12.AggregatedProperty.DisableProperties = true;
                obj12.PropertyDisabledByStaticMethod = "Never can be edited";
                obj12.PropertyDisabledByInstanceMethod = "You cannot edit me";
                obj12.Save();
            }

            ConditionalAppearanceHideShowEditorsObject obj13 = ObjectSpace.FindObject<ConditionalAppearanceHideShowEditorsObject>(CriteriaOperator.Parse("Name='HideShowEditorsObject1'"));
            if(obj13 == null) {
                obj13 = ObjectSpace.CreateObject<ConditionalAppearanceHideShowEditorsObject>();
                obj13.Name = "HideShowEditorsObject1";
                obj13.SimpleProperty = "This property can be hidden in a DetailView";
                obj13.HideLookupProperty = false;
                obj13.HideSimpleProperty = false;
                obj13.LookupProperty = ObjectSpace.CreateObject<ConditionalAppearanceHideShowEditorsLookupObject>();
                obj13.LookupProperty.Name = "This property can be hidden in a Detail View";
                obj13.HideAggregatedProperty = false;
                obj13.AggregatedProperty = ObjectSpace.CreateObject<ConditionalAppearanceHideShowEditorsAggregatedObject>();
                obj13.AggregatedProperty.Name = "HideShowEditorsAggregatedObject1";
                obj13.AggregatedProperty.Description = "An aggregated object can be hidden in a DetailView";
                obj13.AggregatedProperty.HideProperties = false;
                SetPropertyValue(typeof(ConditionalAppearanceHideShowEditorsObject), obj13, "HideSimpleLayoutItem", false);
                SetPropertyValue(typeof(ConditionalAppearanceHideShowEditorsObject), obj13, "HideSimpleLayoutGroup", false);
                SetPropertyValue(typeof(ConditionalAppearanceHideShowEditorsObject), obj13, "HideTabPageGroup", false);
                obj13.Save();
            }
            ConditionalAppearanceHideShowEditorsObject obj14 = ObjectSpace.FindObject<ConditionalAppearanceHideShowEditorsObject>(CriteriaOperator.Parse("Name='HideShowEditorsObject2'"));
            if(obj14 == null) {
                obj14 = ObjectSpace.CreateObject<ConditionalAppearanceHideShowEditorsObject>();
                obj14.Name = "HideShowEditorsObject2";
                obj14.SimpleProperty = "This property can be hidden in a DetailView";
                obj14.HideLookupProperty = true;
                obj14.HideSimpleProperty = true;
                obj14.LookupProperty = ObjectSpace.CreateObject<ConditionalAppearanceHideShowEditorsLookupObject>();
                obj14.LookupProperty.Name = "This property can be hidden in a Detail View";
                obj14.HideAggregatedProperty = true;
                obj14.AggregatedProperty = ObjectSpace.CreateObject<ConditionalAppearanceHideShowEditorsAggregatedObject>();
                obj14.AggregatedProperty.Name = "HideShowEditorsAggregatedObject2";
                obj14.AggregatedProperty.Description = "An aggregated object can be hidden in a DetailView";
                obj14.AggregatedProperty.HideProperties = false;
                SetPropertyValue(typeof(ConditionalAppearanceHideShowEditorsObject), obj14, "HideSimpleLayoutItem", true);
                SetPropertyValue(typeof(ConditionalAppearanceHideShowEditorsObject), obj14, "HideSimpleLayoutGroup", true);
                SetPropertyValue(typeof(ConditionalAppearanceHideShowEditorsObject), obj14, "HideTabPageGroup", true);
                obj14.Save();
            }
            ConditionalAppearanceSelectAllPropertiesObject obj16 = ObjectSpace.FindObject<ConditionalAppearanceSelectAllPropertiesObject>(CriteriaOperator.Parse("Name='SelectAllPropertiesObject1'"));
            if(obj16 == null) {
                obj16 = ObjectSpace.CreateObject<ConditionalAppearanceSelectAllPropertiesObject>();
                obj16.Description = "Description";
                obj16.Name = "SelectAllPropertiesObject1";
                obj16.DisableProperties = false;
                obj16.Save();
            }
            ConditionalAppearanceSelectAllPropertiesObject obj17 = ObjectSpace.FindObject<ConditionalAppearanceSelectAllPropertiesObject>(CriteriaOperator.Parse("Name='SelectAllPropertiesObject2'"));
            if(obj17 == null) {
                obj17 = ObjectSpace.CreateObject<ConditionalAppearanceSelectAllPropertiesObject>();
                obj17.Description = "Description";
                obj17.Name = "SelectAllPropertiesObject2";
                obj17.DisableProperties = true;
                obj17.Save();
            }
            ConditionalAppearanceSuperpositionOfRulesObject obj18 = ObjectSpace.FindObject<ConditionalAppearanceSuperpositionOfRulesObject>(CriteriaOperator.Parse("Name='SuperpositionOfRulesObject1'"));
            if(obj18 == null) {
                obj18 = ObjectSpace.CreateObject<ConditionalAppearanceSuperpositionOfRulesObject>();
                obj18.Name = "SuperpositionOfRulesObject1";
                obj18.AllPropertiesDisabledExcept = ConditionalAppearanceSuperpositionOfRulesAllPropertiesDisabledExcept.Property1;
                obj18.Property1 = "You can edit me";
                obj18.Property2 = "You cannot edit me";
                obj18.Property3 = "Always cannot edit";
                obj18.Save();
            }
            ConditionalAppearanceSuperpositionOfRulesObject obj19 = ObjectSpace.FindObject<ConditionalAppearanceSuperpositionOfRulesObject>(CriteriaOperator.Parse("Name='SuperpositionOfRulesObject2'"));
            if(obj19 == null) {
                obj19 = ObjectSpace.CreateObject<ConditionalAppearanceSuperpositionOfRulesObject>();
                obj19.Name = "SuperpositionOfRulesObject2";
                obj19.AllPropertiesDisabledExcept = ConditionalAppearanceSuperpositionOfRulesAllPropertiesDisabledExcept.Property2;
                obj19.Property1 = "You cannot edit me";
                obj19.Property2 = "You can edit me";
                obj19.Property3 = "Always cannot edit";
                obj19.Save();
            }

            LayoutItemAppearanceObject obj20 = ObjectSpace.FindObject<LayoutItemAppearanceObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject1'"));
            if(obj20 == null) {
                obj20 = ObjectSpace.CreateObject<LayoutItemAppearanceObject>();
                obj20.Name = "FormatAppearanceObject1";
                obj20.TargetFormattingProperty = "Red group caption";
                obj20.Save();
            }
            LayoutItemAppearanceObject obj21 = ObjectSpace.FindObject<LayoutItemAppearanceObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject2'"));
            if(obj21 == null) {
                obj21 = ObjectSpace.CreateObject<LayoutItemAppearanceObject>();
                obj21.Name = "FormatAppearanceObject2";
                obj21.TargetFormattingProperty = "Target formatting property caption (bold)";
                obj21.FontStyle = FontStyle.Bold;
                obj21.Save();
            }
            LayoutItemAppearanceObject obj22 = ObjectSpace.FindObject<LayoutItemAppearanceObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject3'"));
            if(obj22 == null) {
                obj22 = ObjectSpace.CreateObject<LayoutItemAppearanceObject>();
                obj22.Name = "FormatAppearanceObject3";
                obj22.TargetFormattingProperty = "Target formatting property caption (italic)";
                obj22.FontStyle = FontStyle.Italic;
                obj22.Save();
            }
            LayoutItemAppearanceObject obj23 = ObjectSpace.FindObject<LayoutItemAppearanceObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject4'"));
            if(obj23 == null) {
                obj23 = ObjectSpace.CreateObject<LayoutItemAppearanceObject>();
                obj23.Name = "FormatAppearanceObject4";
                obj23.TargetFormattingProperty = "Target formatting property caption (strikeout)";
                obj23.FontStyle = FontStyle.Strikeout;
                obj23.Save();
            }
            LayoutItemAppearanceObject obj24 = ObjectSpace.FindObject<LayoutItemAppearanceObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject5'"));
            if(obj24 == null) {
                obj24 = ObjectSpace.CreateObject<LayoutItemAppearanceObject>();
                obj24.Name = "FormatAppearanceObject5";
                obj24.TargetFormattingProperty = "Target formatting property caption (back color is Red)";
                obj24.Severity = Severity.Severe;
                obj24.Save();
            }
            LayoutItemAppearanceObject obj25 = ObjectSpace.FindObject<LayoutItemAppearanceObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject6'"));
            if(obj25 == null) {
                obj25 = ObjectSpace.CreateObject<LayoutItemAppearanceObject>();
                obj25.Name = "FormatAppearanceObject6";
                obj25.TargetFormattingProperty = "Target formatting property caption (font color is Blue)";
                obj25.Priority = Priority.Low;
                obj25.Save();
            }
            TreeListFormattedObject obj31 = ObjectSpace.FindObject<TreeListFormattedObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject1'"));
            if(obj31 == null) {
                obj31 = ObjectSpace.CreateObject<TreeListFormattedObject>();
                obj31.Name = "FormatAppearanceObject1";
                obj31.Description = "Target formatting property - 'Name'";
                obj31.Save();
            }
            TreeListFormattedObject obj32 = ObjectSpace.FindObject<TreeListFormattedObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject2'"));
            if(obj32 == null) {
                obj32 = ObjectSpace.CreateObject<TreeListFormattedObject>();
                obj32.Name = "FormatAppearanceObject2";
                obj32.Description = "Target formatting property - 'Name' (bold)";
                obj32.FontStyle = FontStyle.Bold;
                obj32.ParentObject = obj31;
                obj32.Save();
            }
            TreeListFormattedObject obj33 = ObjectSpace.FindObject<TreeListFormattedObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject3'"));
            if(obj33 == null) {
                obj33 = ObjectSpace.CreateObject<TreeListFormattedObject>();
                obj33.Name = "FormatAppearanceObject3";
                obj33.Description = "Target formatting property - 'Name' (italic)";
                obj33.FontStyle = FontStyle.Italic;
                obj33.ParentObject = obj31;
                obj33.Save();
            }
            TreeListFormattedObject obj34 = ObjectSpace.FindObject<TreeListFormattedObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject4'"));
            if(obj34 == null) {
                obj34 = ObjectSpace.CreateObject<TreeListFormattedObject>();
                obj34.Name = "FormatAppearanceObject4";
                obj34.Description = "Target formatting property - 'Name' (strikeout)";
                obj34.FontStyle = FontStyle.Strikeout;
                obj34.ParentObject = obj31;
                obj34.Save();
            }
            TreeListFormattedObject obj35 = ObjectSpace.FindObject<TreeListFormattedObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject5'"));
            if(obj35 == null) {
                obj35 = ObjectSpace.CreateObject<TreeListFormattedObject>();
                obj35.Name = "FormatAppearanceObject5";
                obj35.Description = "Target formatting property - 'Name' (back color is Red)";
                obj35.Severity = Severity.Severe;
                obj35.ParentObject = obj31;
                obj35.Save();
            }
            TreeListFormattedObject obj36 = ObjectSpace.FindObject<TreeListFormattedObject>(CriteriaOperator.Parse("Name='FormatAppearanceObject6'"));
            if(obj36 == null) {
                obj36 = ObjectSpace.CreateObject<TreeListFormattedObject>();
                obj36.Name = "FormatAppearanceObject6";
                obj36.Description = "Target formatting property - 'Name' (font color is Blue)";
                obj36.Priority = Priority.Low;
                obj36.ParentObject = obj31;
                obj36.Save();
            }
        }


        private void CreateListEditorsDemoObjects() {
            if(ObjectSpace.FindObject<GridListEditorDemoObject>(null) == null) {
                GridListEditorDemoObject obj = ObjectSpace.CreateObject<GridListEditorDemoObject>();
                obj.Name = "Object 1";
                obj.Index = 1;
                obj.BooleanProperty = false;
                obj.IntegerProperty = 12;
                obj.EnumProperty = SampleEnum.First;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorDemoObject>();
                obj.Name = "Object 2";
                obj.Index = 2;
                obj.BooleanProperty = true;
                obj.IntegerProperty = 45;
                obj.EnumProperty = SampleEnum.Second;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorDemoObject>();
                obj.Name = "Object 3";
                obj.Index = 3;
                obj.BooleanProperty = false;
                obj.IntegerProperty = 100;
                obj.EnumProperty = SampleEnum.Third;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorDemoObject>();
                obj.Name = "Object 4";
                obj.Index = 4;
                obj.BooleanProperty = true;
                obj.IntegerProperty = 156;
                obj.EnumProperty = SampleEnum.First;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorDemoObject>();
                obj.Name = "Object 5";
                obj.Index = 5;
                obj.BooleanProperty = false;
                obj.IntegerProperty = 437;
                obj.EnumProperty = SampleEnum.Second;
                obj.Save();
            }
            if(ObjectSpace.FindObject<GridListEditorFilterDemoObject>(null) == null) {
                GridListEditorFilterDemoObject obj = ObjectSpace.CreateObject<GridListEditorFilterDemoObject>();
                obj.Name = "Object 1";
                obj.BooleanProperty = false;
                obj.IntegerProperty = 12;
                obj.EnumProperty = SampleEnum.First;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorFilterDemoObject>();
                obj.Name = "Object 2";
                obj.BooleanProperty = true;
                obj.IntegerProperty = 45;
                obj.EnumProperty = SampleEnum.Second;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorFilterDemoObject>();
                obj.Name = "Object 3";
                obj.BooleanProperty = false;
                obj.IntegerProperty = 100;
                obj.EnumProperty = SampleEnum.Third;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorFilterDemoObject>();
                obj.Name = "Object 4";
                obj.BooleanProperty = true;
                obj.IntegerProperty = 156;
                obj.EnumProperty = SampleEnum.First;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorFilterDemoObject>();
                obj.Name = "Object 5";
                obj.BooleanProperty = false;
                obj.IntegerProperty = 437;
                obj.EnumProperty = SampleEnum.Second;
                obj.Save();
            }
            if(ObjectSpace.FindObject<GridListEditorAutoFilterDemoObject>(null) == null) {
                GridListEditorAutoFilterDemoObject obj = ObjectSpace.CreateObject<GridListEditorAutoFilterDemoObject>();
                obj.Name = "Object 1";
                obj.BooleanProperty = false;
                obj.IntegerProperty = 12;
                obj.EnumProperty = SampleEnum.First;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorAutoFilterDemoObject>();
                obj.Name = "Object 2";
                obj.BooleanProperty = true;
                obj.IntegerProperty = 45;
                obj.EnumProperty = SampleEnum.Second;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorAutoFilterDemoObject>();
                obj.Name = "Object 3";
                obj.BooleanProperty = false;
                obj.IntegerProperty = 100;
                obj.EnumProperty = SampleEnum.Third;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorAutoFilterDemoObject>();
                obj.Name = "Object 4";
                obj.BooleanProperty = true;
                obj.IntegerProperty = 156;
                obj.EnumProperty = SampleEnum.First;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorAutoFilterDemoObject>();
                obj.Name = "Object 5";
                obj.BooleanProperty = false;
                obj.IntegerProperty = 437;
                obj.EnumProperty = SampleEnum.Second;
                obj.Save();
            }
            if(ObjectSpace.FindObject<GridListEditorNewItemRowDemoObject>(null) == null) {
                GridListEditorNewItemRowDemoObject obj = ObjectSpace.CreateObject<GridListEditorNewItemRowDemoObject>();
                obj.Name = "Object 1";
                obj.BooleanProperty = false;
                obj.IntegerProperty = 12;
                obj.EnumProperty = SampleEnum.First;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorNewItemRowDemoObject>();
                obj.Name = "Object 2";
                obj.BooleanProperty = true;
                obj.IntegerProperty = 45;
                obj.EnumProperty = SampleEnum.Second;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorNewItemRowDemoObject>();
                obj.Name = "Object 3";
                obj.BooleanProperty = false;
                obj.IntegerProperty = 100;
                obj.EnumProperty = SampleEnum.Third;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorNewItemRowDemoObject>();
                obj.Name = "Object 4";
                obj.BooleanProperty = true;
                obj.IntegerProperty = 156;
                obj.EnumProperty = SampleEnum.First;
                obj.Save();
                obj = ObjectSpace.CreateObject<GridListEditorNewItemRowDemoObject>();
                obj.Name = "Object 5";
                obj.BooleanProperty = false;
                obj.IntegerProperty = 437;
                obj.EnumProperty = SampleEnum.Second;
                obj.Save();
            }
            if(ObjectSpace.FindObject<GridListEditorBatchEditDemoObject>(null) == null) {
                GridListEditorBatchEditDemoObject obj = ObjectSpace.CreateObject<GridListEditorBatchEditDemoObject>();
                obj.InitializeObject(0);
                obj = ObjectSpace.CreateObject<GridListEditorBatchEditDemoObject>();
                obj.InitializeObject(1);
                obj = ObjectSpace.CreateObject<GridListEditorBatchEditDemoObject>();
                obj.InitializeObject(2);
                obj = ObjectSpace.CreateObject<GridListEditorBatchEditDemoObject>();
                obj.InitializeObject(3);
                obj = ObjectSpace.CreateObject<GridListEditorBatchEditDemoObject>();
                obj.InitializeObject(4);
            }
            if(ObjectSpace.FindObject<TreeListEditorDemoObject>(null) == null) {
                TreeListEditorDemoObject obj = ObjectSpace.CreateObject<TreeListEditorDemoObject>();
                obj.Caption = "Caption 1";
                obj.Save();
                TreeListEditorDemoObject objChild = ObjectSpace.CreateObject<TreeListEditorDemoObject>();
                objChild.ParentObject = obj;
                objChild.Caption = "Caption 2";
                objChild.Save();
                obj = ObjectSpace.CreateObject<TreeListEditorDemoObject>();
                obj.Caption = "Caption 3";
                obj.Save();
                objChild = ObjectSpace.CreateObject<TreeListEditorDemoObject>();
                objChild.ParentObject = obj;
                objChild.Caption = "Caption 4";
                objChild.Save();
                objChild = ObjectSpace.CreateObject<TreeListEditorDemoObject>();
                objChild.ParentObject = obj;
                objChild.Caption = "Caption 5";
                objChild.Save();
                obj = ObjectSpace.CreateObject<TreeListEditorDemoObject>();
                obj.Caption = "Caption 6";
                obj.Save();
            }
            if(ObjectSpace.FindObject<TreeListEditorFilterDemoObject>(null) == null) {
                TreeListEditorFilterDemoObject obj = ObjectSpace.CreateObject<TreeListEditorFilterDemoObject>();
                obj.Caption = "First object";
                obj.Save();
                TreeListEditorFilterDemoObject objChild = ObjectSpace.CreateObject<TreeListEditorFilterDemoObject>();
                objChild.ParentObject = obj;
                objChild.Caption = "Second object";
                objChild.Save();
                obj = ObjectSpace.CreateObject<TreeListEditorFilterDemoObject>();
                obj.Caption = "Third object";
                obj.Save();
                objChild = ObjectSpace.CreateObject<TreeListEditorFilterDemoObject>();
                objChild.ParentObject = obj;
                objChild.Caption = "Fourth object";
                objChild.Save();
                objChild = ObjectSpace.CreateObject<TreeListEditorFilterDemoObject>();
                objChild.ParentObject = obj;
                objChild.Caption = "Fifth object";
                objChild.Save();
                obj = ObjectSpace.CreateObject<TreeListEditorFilterDemoObject>();
                obj.Caption = "Sixth object";
                obj.Save();
            }
            if(ObjectSpace.FindObject<TreeListEditorNodeImagesDemoObject>(null) == null) {
                TreeListEditorNodeImagesDemoObject obj = ObjectSpace.CreateObject<TreeListEditorNodeImagesDemoObject>();
                obj.Caption = "Object 1";
                obj.Save();
                TreeListEditorNodeImagesDemoObject objChild = ObjectSpace.CreateObject<TreeListEditorNodeImagesDemoObject>();
                objChild.ParentObject = obj;
                objChild.Caption = "Object 2";
                objChild.Save();
                obj = ObjectSpace.CreateObject<TreeListEditorNodeImagesDemoObject>();
                obj.Caption = "Object 3";
                obj.Save();
                objChild = ObjectSpace.CreateObject<TreeListEditorNodeImagesDemoObject>();
                objChild.ParentObject = obj;
                objChild.Caption = "Object 4";
                objChild.Save();
                objChild = ObjectSpace.CreateObject<TreeListEditorNodeImagesDemoObject>();
                objChild.ParentObject = obj;
                objChild.Caption = "Object 5";
                objChild.Save();
                obj = ObjectSpace.CreateObject<TreeListEditorNodeImagesDemoObject>();
                obj.Caption = "Object 6";
                obj.Save();
            }
            if(ObjectSpace.FindObject<TreeListEditorFilterByTextObject>(null) == null) {
                TreeListEditorFilterByTextObject rootObject1 = ObjectSpace.CreateObject<TreeListEditorFilterByTextObject>();
                rootObject1.Caption = "Object 1";
                rootObject1.FriendlyKey = "F001";
                rootObject1.DefaultProperty = "RootDefaultProperty1";
                rootObject1.NonDefaultProperty = "RootNonDefaultProperty1";
                rootObject1.AggregatedObject.DefaultProperty = "Aggregated1.DefaultProperty";
                rootObject1.AggregatedObject.NonDefaultProperty = "Aggregated1.NonDefaultProperty";
                rootObject1.ReferencedObject = ObjectSpace.CreateObject<FilterByTextReferencedObject>();
                rootObject1.ReferencedObject.DefaultProperty = "Referenced1.DefaultProperty";
                rootObject1.ReferencedObject.NonDefaultProperty = "Referenced1.NonDefaultProperty";
                rootObject1.Save();

                TreeListEditorFilterByTextObject childObject1 = ObjectSpace.CreateObject<TreeListEditorFilterByTextObject>();
                childObject1.ParentObject = rootObject1;
                childObject1.Caption = "Child Object 1";
                childObject1.FriendlyKey = "F0011";
                childObject1.DefaultProperty = "ChildDefaultProperty1";
                childObject1.NonDefaultProperty = "Child NonDefaultProperty1";
                childObject1.AggregatedObject.DefaultProperty = "AggregatedChild1.DefaultProperty";
                childObject1.AggregatedObject.NonDefaultProperty = "AggregatedChild1.NonDefaultProperty";
                childObject1.ReferencedObject = ObjectSpace.CreateObject<FilterByTextReferencedObject>();
                childObject1.ReferencedObject.DefaultProperty = "ReferencedChild1.DefaultProperty";
                childObject1.ReferencedObject.NonDefaultProperty = "ReferencedChild1.NonDefaultProperty";
                childObject1.Save();

                TreeListEditorFilterByTextObject rootObject2 = ObjectSpace.CreateObject<TreeListEditorFilterByTextObject>();
                rootObject2.Caption = "Object 2";
                rootObject2.FriendlyKey = "F002";
                rootObject2.DefaultProperty = "RootDefaultProperty2";
                rootObject2.NonDefaultProperty = "RootNonDefaultProperty2";
                rootObject2.AggregatedObject.DefaultProperty = "Aggregated2.DefaultProperty";
                rootObject2.AggregatedObject.NonDefaultProperty = "Aggregated2.NonDefaultProperty";
                rootObject2.ReferencedObject = ObjectSpace.CreateObject<FilterByTextReferencedObject>();
                rootObject2.ReferencedObject.DefaultProperty = "Referenced2.DefaultProperty";
                rootObject2.ReferencedObject.NonDefaultProperty = "Referenced2.NonDefaultProperty";
                rootObject2.Save();

                TreeListEditorFilterByTextObject childObject2 = ObjectSpace.CreateObject<TreeListEditorFilterByTextObject>();
                childObject2.ParentObject = rootObject2;
                childObject2.Caption = "Child Object 2";
                childObject2.FriendlyKey = "F0021";
                childObject2.DefaultProperty = "ChildDefaultProperty2";
                childObject2.NonDefaultProperty = "Child NonDefaultProperty2";
                childObject2.AggregatedObject.DefaultProperty = "AggregatedChild2.DefaultProperty";
                childObject2.AggregatedObject.NonDefaultProperty = "AggregatedChild2.NonDefaultProperty";
                childObject2.ReferencedObject = ObjectSpace.CreateObject<FilterByTextReferencedObject>();
                childObject2.ReferencedObject.DefaultProperty = "ReferencedChild2.DefaultProperty";
                childObject2.ReferencedObject.NonDefaultProperty = "ReferencedChild2.NonDefaultProperty";
                childObject2.Save();

                TreeListEditorFilterByTextObject rootObject3 = ObjectSpace.CreateObject<TreeListEditorFilterByTextObject>();
                rootObject3.Caption = "Object 3";
                rootObject3.FriendlyKey = "F003";
                rootObject3.DefaultProperty = "RootDefaultProperty3";
                rootObject3.NonDefaultProperty = "RootNonDefaultProperty3";
                rootObject3.AggregatedObject.DefaultProperty = "Aggregated3.DefaultProperty";
                rootObject3.AggregatedObject.NonDefaultProperty = "Aggregated3.NonDefaultProperty";
                rootObject3.ReferencedObject = ObjectSpace.CreateObject<FilterByTextReferencedObject>();
                rootObject3.ReferencedObject.DefaultProperty = "Referenced3.DefaultProperty";
                rootObject3.ReferencedObject.NonDefaultProperty = "Referenced3.NonDefaultProperty";
                rootObject3.Save();
            }

            if(ObjectSpace.FindObject<TaskWithNotifications>(null) == null) {
                TaskWithNotifications obj = ObjectSpace.CreateObject<TaskWithNotifications>();
                obj.Subject = "Past Task With Reminder";
                obj.StartDate = DateTime.Now - TimeSpan.FromDays(10);
                obj.DueDate = obj.StartDate - TimeSpan.FromDays(2);
                obj.RemindIn = TimeSpan.FromMinutes(10);
                obj.Save();
                obj = ObjectSpace.CreateObject<TaskWithNotifications>();
                obj.Subject = "Now Task With Reminder";
                obj.StartDate = DateTime.Now.AddMinutes(5);
                obj.DueDate = obj.StartDate.AddHours(2);
                obj.RemindIn = TimeSpan.FromMinutes(5);
                obj.Save();
                obj = ObjectSpace.CreateObject<TaskWithNotifications>();
                obj.Subject = "Future Task With Reminder";
                obj.StartDate = DateTime.Now.AddMinutes(10);
                obj.DueDate = obj.StartDate.AddHours(2);
                obj.RemindIn = TimeSpan.FromMinutes(5);
                obj.Save();
            }

            if(ObjectSpace.FindObject<SchedulerNotifications>(null) == null) {
                SchedulerNotifications obj = ObjectSpace.CreateObject<SchedulerNotifications>();
                obj.Subject = "Past Event With Reminder";
                obj.StartOn = DateTime.Now - TimeSpan.FromDays(1);
                obj.EndOn = obj.StartOn.AddHours(2);
                obj.RemindIn = TimeSpan.FromMinutes(10);
                ((DevExpress.Persistent.Base.General.ISupportNotifications)obj).AlarmTime = obj.StartOn - obj.RemindIn.Value;
                obj.Save();
                obj = ObjectSpace.CreateObject<SchedulerNotifications>();
                obj.Subject = "Now Event With Reminder";
                obj.StartOn = DateTime.Now.AddMinutes(5);
                obj.EndOn = obj.StartOn.AddHours(2);
                obj.RemindIn = TimeSpan.FromMinutes(5);
                ((DevExpress.Persistent.Base.General.ISupportNotifications)obj).AlarmTime = obj.StartOn - obj.RemindIn.Value;
                obj.Save();
                obj = ObjectSpace.CreateObject<SchedulerNotifications>();
                obj.Subject = "Future Event With Reminder";
                obj.StartOn = DateTime.Now.AddMinutes(10);
                obj.EndOn = obj.StartOn.AddHours(2);
                obj.RemindIn = TimeSpan.FromMinutes(5);
                ((DevExpress.Persistent.Base.General.ISupportNotifications)obj).AlarmTime = obj.StartOn - obj.RemindIn.Value;
                obj.Save();
            }

            if(ObjectSpace.FindObject<SchedulerListEditorFilterDemoObject>(null) == null) {
                SchedulerListEditorFilterDemoObject obj = ObjectSpace.CreateObject<SchedulerListEditorFilterDemoObject>();
                obj.Subject = "Event 1";
                obj.StartOn = DateTime.Today.Date.AddHours(9);
                obj.EndOn = obj.StartOn.AddHours(2);
                obj.Save();
                obj = ObjectSpace.CreateObject<SchedulerListEditorFilterDemoObject>();
                obj.Subject = "Another Event";
                obj.StartOn = DateTime.Today.Date.AddHours(12);
                obj.EndOn = obj.StartOn.AddHours(2);
                obj.Save();
            }
            if(ObjectSpace.FindObject<SchedulerListEditorFilterByTextDemoObject>(null) == null) {
                SchedulerListEditorFilterByTextDemoObject obj = ObjectSpace.CreateObject<SchedulerListEditorFilterByTextDemoObject>();
                obj.Subject = "Meeting with customer";
                obj.StartOn = DateTime.Today.Date.AddHours(9);
                obj.EndOn = obj.StartOn.AddHours(2);
                obj.Save();
                obj = ObjectSpace.CreateObject<SchedulerListEditorFilterByTextDemoObject>();
                obj.Subject = "Appointment with Tom";
                obj.StartOn = DateTime.Today.Date.AddHours(12);
                obj.EndOn = obj.StartOn.AddHours(1);
                obj.Save();
                obj = ObjectSpace.CreateObject<SchedulerListEditorFilterByTextDemoObject>();
                obj.Subject = "Lunch time";
                obj.StartOn = DateTime.Today.Date.AddHours(13);
                obj.EndOn = obj.StartOn.AddHours(1);
                obj.Save();
                obj = ObjectSpace.CreateObject<SchedulerListEditorFilterByTextDemoObject>();
                obj.Subject = "Dating with Mary";
                obj.StartOn = DateTime.Today.Date.AddHours(14);
                obj.EndOn = obj.StartOn.AddHours(0.5);
                obj.Save();
                obj = ObjectSpace.CreateObject<SchedulerListEditorFilterByTextDemoObject>();
                obj.Subject = "Appointment with Boss";
                obj.StartOn = DateTime.Today.Date.AddHours(15);
                obj.EndOn = obj.StartOn.AddHours(2);
                obj.Save();
            }
        }
        private NavigationItem CreateNavigationItem(string caption, string imageName, int index, NavigationObject navigationObject) {
            NavigationItem item = ObjectSpace.CreateObject<NavigationItem>();
            item.Name = caption;
            item.ImageName = imageName;
            item.Index = index;
            navigationObject.NavigationItems.Add(item);
            return item;
        }
        private NavigationItem CreateLinearNavigationGroup(NavigationObject navigationObject) {
            NavigationItem group = ObjectSpace.CreateObject<NavigationItem>();
            group.Name = "Linear Group";
            group.Items.Add(CreateNavigationItem("Contacts", "BO_Contact", 0, navigationObject));
            group.Items.Add(CreateNavigationItem("Tasks", "BO_Task", 1, navigationObject));
            group.Index = 0;
            return group;
        }
        private NavigationItem CreateHierarchicalNavigationGroup(NavigationObject navigationObject) {
            NavigationItem group = ObjectSpace.CreateObject<NavigationItem>();
            group.Name = "Hierarchical Group";
            NavigationItem staffItem = CreateNavigationItem("Staff", "BO_Person", 0, navigationObject);
            group.Items.Add(staffItem);
            staffItem.Items.Add(CreateNavigationItem("Labour", "BO_Employee", 0, navigationObject));
            staffItem.Items.Add(CreateNavigationItem("Managers", "BO_Position", 1, navigationObject));
            group.Index = 1;
            return group;
        }
        private void CreateNavigationObjects() {
            if(ObjectSpace.FindObject<NavigationObject>(null) == null) {
                NavigationObject navigationObject = ObjectSpace.CreateObject<NavigationObject>();
                NavigationItem linearGroup = CreateLinearNavigationGroup(navigationObject);
                NavigationItem hierarchicalGroup = CreateHierarchicalNavigationGroup(navigationObject);
                navigationObject.NavigationItems.Add(linearGroup);
                navigationObject.NavigationItems.Add(hierarchicalGroup);
                navigationObject.Save();
            }
        }

        private void CreateFilterByTextObjects() {
            if(ObjectSpace.FindObject<FilterByTextRootObject>(null) == null) {
                FilterByTextRootObject rootObject1 = ObjectSpace.CreateObject<FilterByTextRootObject>();
                rootObject1.FriendlyKey = "F001";
                rootObject1.DefaultProperty = "RootDefaultProperty1";
                rootObject1.NonDefaultProperty = "RootNonDefaultProperty1";
                rootObject1.AggregatedObject.DefaultProperty = "Aggregated.DefaultProperty1";
                rootObject1.AggregatedObject.NonDefaultProperty = "Aggregated.NonDefaultProperty1";
                rootObject1.ReferencedObject = ObjectSpace.CreateObject<FilterByTextReferencedObject>();
                rootObject1.ReferencedObject.DefaultProperty = "Referenced.DefaultProperty1";
                rootObject1.ReferencedObject.NonDefaultProperty = "Referenced.NonDefaultProperty1";
                rootObject1.Save();

                FilterByTextRootObject rootObject2 = ObjectSpace.CreateObject<FilterByTextRootObject>();
                rootObject2.FriendlyKey = "F002";
                rootObject2.DefaultProperty = "RootDefaultProperty2";
                rootObject2.NonDefaultProperty = "RootNonDefaultProperty2";
                rootObject2.AggregatedObject.DefaultProperty = "Aggregated.DefaultProperty2";
                rootObject2.AggregatedObject.NonDefaultProperty = "Aggregated.NonDefaultProperty2";
                rootObject2.Save();

                FilterByTextRootObject rootObject3 = ObjectSpace.CreateObject<FilterByTextRootObject>();
                rootObject3.FriendlyKey = "F003";
                rootObject3.DefaultProperty = "RootDefaultProperty3";
                rootObject3.NonDefaultProperty = "RootNonDefaultProperty3";
                rootObject3.ReferencedObject = ObjectSpace.CreateObject<FilterByTextReferencedObject>();
                rootObject3.ReferencedObject.DefaultProperty = "Referenced.DefaultProperty3";
                rootObject3.ReferencedObject.NonDefaultProperty = "Referenced.NonDefaultProperty3";
                rootObject3.Save();
            }
        }
        private void CreateCustomFieldsObjects() {
            if(ObjectSpace.FindObject<CustomFieldsObject>(null) == null) {
                CustomFieldsObject mainObject = ObjectSpace.CreateObject<CustomFieldsObject>();
                mainObject.Name = "Custom Fields Demo Object";
                mainObject.SetMemberValue("SimpleCustomField", 1);
                CustomFieldsObject complexCustomFieldObject = ObjectSpace.CreateObject<CustomFieldsObject>();
                complexCustomFieldObject.Name = "Complex Data Type Object";
                mainObject.SetMemberValue("ComplexCustomField", complexCustomFieldObject);
                mainObject.Save();

                CustomFieldsObject detailObject1 = ObjectSpace.CreateObject<CustomFieldsObject>();
                detailObject1.Name = "Detail Object 1";
                detailObject1.SetMemberValue("SimpleCustomField", 2);
                detailObject1.Master = mainObject;
                CustomFieldsObject detailObject2 = ObjectSpace.CreateObject<CustomFieldsObject>();
                detailObject2.Name = "Detail Object 2";
                detailObject2.SetMemberValue("SimpleCustomField", 4);
                detailObject2.Master = mainObject;
                CustomFieldsObject detailObject3 = ObjectSpace.CreateObject<CustomFieldsObject>();
                detailObject3.Name = "Detail Object 3";
                detailObject3.SetMemberValue("SimpleCustomField", 8);
                detailObject3.Master = mainObject;
            }
        }
        private void CreateKeyPropetiesObjects() {
            if(ObjectSpace.FindObject<IntegerKeyPropertyObject>(null) == null) {
                IntegerKeyPropertyObject integerKeyPropertyObject = ObjectSpace.CreateObject<IntegerKeyPropertyObject>();
                integerKeyPropertyObject.Name = "Object with an integer key 1";
                integerKeyPropertyObject.Save();
                integerKeyPropertyObject = ObjectSpace.CreateObject<IntegerKeyPropertyObject>();
                integerKeyPropertyObject.Name = "Object with an integer key 2";
                integerKeyPropertyObject.Save();
            }
            if(ObjectSpace.FindObject<GuidKeyPropertyObject>(null) == null) {
                GuidKeyPropertyObject guidKeyPropertyObject = ObjectSpace.CreateObject<GuidKeyPropertyObject>();
                guidKeyPropertyObject.Name = "Object with a Guid key 1";
                guidKeyPropertyObject.Save();
                guidKeyPropertyObject = ObjectSpace.CreateObject<GuidKeyPropertyObject>();
                guidKeyPropertyObject.Name = "Object with a Guid key 2";
                guidKeyPropertyObject.Save();
            }
            if(ObjectSpace.FindObject<StringKeyPropertyObject>(null) == null) {
                StringKeyPropertyObject stringKeyPropertyObject = ObjectSpace.CreateObject<StringKeyPropertyObject>();
                stringKeyPropertyObject.Name = "Object with a string key 1";
                stringKeyPropertyObject.Save();
                stringKeyPropertyObject = ObjectSpace.CreateObject<StringKeyPropertyObject>();
                stringKeyPropertyObject.Name = "Object with a string key 2";
                stringKeyPropertyObject.Save();
            }
        }
        private void CreateCustomizeActionObjects() {
            if(ObjectSpace.FindObject<CustomizeActionControlObject>(null) == null) {
                CustomizeActionControlObject customizeParametrizedAction = ObjectSpace.CreateObject<CustomizeActionControlObject>();
                customizeParametrizedAction.Caption = "Object 1";
                customizeParametrizedAction.Save();
            }
            if(ObjectSpace.FindObject<CustomizeInlineGridActionControl>(null) == null) {
                for(int i = 0; i < 5; i++) {
                    CustomizeInlineGridActionControl customizeGridViewAction = ObjectSpace.CreateObject<CustomizeInlineGridActionControl>();
                    customizeGridViewAction.Caption = "Object " + i;
                    customizeGridViewAction.Save();
                }
            }

        }
        private void CreateCollectionPropertiesObjects() {
            CollectionProperties collectionPropertiesObj = ObjectSpace.FindObject<CollectionProperties>(new BinaryOperator("Name", "Object with Collection Properties"));
            if(collectionPropertiesObj == null) {
                collectionPropertiesObj = ObjectSpace.CreateObject<CollectionProperties>();
                collectionPropertiesObj.Name = "Object with Collection Properties";
                collectionPropertiesObj.Save();
            }
        }

        private void CreateNumericPropertiesObjects() {
            if(ObjectSpace.FindObject<NumericProperties>(null) == null) {
                NumericProperties numericPropertiesObject = ObjectSpace.CreateObject<NumericProperties>();
                numericPropertiesObject.Name = "Object 1";
                numericPropertiesObject.DoubleProperty = 12345.6789;
                numericPropertiesObject.SingleProperty = 1.23F;
                numericPropertiesObject.LongProperty = long.MaxValue / 2;
                numericPropertiesObject.IntegerProperty = 123456;
                numericPropertiesObject.DecimalProperty = 2499.99M;
                numericPropertiesObject.ByteProperty = byte.MaxValue;
                numericPropertiesObject.Save();
            }
        }

        private void CreateStringPropertiesObjects() {
            if(ObjectSpace.FindObject<StringProperties>(null) == null) {
                StringProperties stringPropertiesObject = ObjectSpace.CreateObject<StringProperties>();
                stringPropertiesObject.Name = "Object 1";
                stringPropertiesObject.DefaultSizeStringProperty = "Default Size Property";
                stringPropertiesObject.ShortSizeStringProperty = "123456789012345";
                stringPropertiesObject.UnlimitedSizeStringProperty = "Unlimited Size Property, Line 1\r\nLine 2\r\nLine 3";
                stringPropertiesObject.CompressedUnlimitedStringProperty = "Compressed Unlimited Size Property";
                stringPropertiesObject.StringWithPredefinedValuesProperty = "String Property with Predefined Values";
                stringPropertiesObject.Save();
            }
        }

        private void CreateDateTimePropertiesObjects() {
            if(ObjectSpace.FindObject<DateTimeProperties>(null) == null) {
                DateTimeProperties dateTimePropertiesObject = ObjectSpace.CreateObject<DateTimeProperties>();
                dateTimePropertiesObject.Name = "Object 1";
                dateTimePropertiesObject.DateTimeProperty = DateTime.Today;
                dateTimePropertiesObject.DateTimeNullableProperty = DateTime.Today.AddDays(1);
                dateTimePropertiesObject.TimeSpanProperty = new TimeSpan(12, 0, 0);
                dateTimePropertiesObject.Save();

                DateTimeProperties dateTimePropertiesObject2 = ObjectSpace.CreateObject<DateTimeProperties>();
                dateTimePropertiesObject2.Name = "Object 2";
                dateTimePropertiesObject2.DateTimeProperty = DateTime.Today.AddDays(-7);
                dateTimePropertiesObject2.TimeSpanProperty = new TimeSpan(6, 0, 0);
                dateTimePropertiesObject2.Save();
            }
        }
        private void CreateCustomFormattedPropertiesObjects() {
            if(ObjectSpace.FindObject<CustomFormattedProperties>(null) == null) {
                CustomFormattedProperties obj1 = ObjectSpace.CreateObject<CustomFormattedProperties>();
                obj1.Name = "Object 1";
                obj1.UrlString = "http://www.devexpress.com/xaf";
                obj1.PhoneString = "(123)444-5555";
                //obj1.NumberFromZeroTo999 = 1;
                obj1.DateAndTimeOfDay = new DateTime(1998, 1, 1, 15, 30, 5);
                obj1.LargePrecisionNumber = 0.123456789;
                obj1.Save();

                CustomFormattedProperties obj2 = ObjectSpace.CreateObject<CustomFormattedProperties>();
                obj2.Name = "Object 2";
                obj2.UrlString = "support@devexpress.com";
                obj2.PhoneString = "(999)888-7777";
                //obj2.NumberFromZeroTo999 = 998;
                obj2.DateAndTimeOfDay = new DateTime(2013, 1, 1, 12, 0, 0);
                obj2.LargePrecisionNumber = -12345.4321;
                obj2.Save();
            }
        }
        private void CreateStructPropertiesObjects() {
            if(ObjectSpace.FindObject<StructProperties>(null) == null) {
                StructProperties structPropertiesObject = ObjectSpace.CreateObject<StructProperties>();
                structPropertiesObject.Name = "Object 1";
                structPropertiesObject.Save();
            }
        }
        private void CreateDefaultFocusedItemObjects() {
            if(ObjectSpace.FindObject<DefaultFocusedItem>(null) == null) {
                DefaultFocusedItem DefaultFocusedItemObject = ObjectSpace.CreateObject<DefaultFocusedItem>();
                DefaultFocusedItemObject.Name = "Object 1";
                DefaultFocusedItemObject.Save();
            }
        }
        private void CreateViewVariantsObjects() {
            if(ObjectSpace.FindObject<ViewVariantsObject>(null) == null) {
                ViewVariantsObject viewVariantsObject = ObjectSpace.CreateObject<ViewVariantsObject>();
                viewVariantsObject.Name = "Object 1";
                viewVariantsObject.Property1 = DateTime.Now;
                viewVariantsObject.Property2 = "Property";
                viewVariantsObject.Property3 = 10;
                viewVariantsObject.Save();

                viewVariantsObject = ObjectSpace.CreateObject<ViewVariantsObject>();
                viewVariantsObject.Name = "Object 2";
                viewVariantsObject.Property1 = DateTime.Now;
                viewVariantsObject.Property2 = "Property";
                viewVariantsObject.Property3 = 20;
                viewVariantsObject.Save();
            }
        }
        private void CreateReferencePropertiesObjects() {
            if(ObjectSpace.FindObject<ReferenceProperties>(null) == null) {
                ReferenceProperties referencePropertiesObject = ObjectSpace.CreateObject<ReferenceProperties>();
                referencePropertiesObject.LookupReferencedObject = ObjectSpace.CreateObject<ReferencedObject>();
                referencePropertiesObject.LookupReferencedObject.Name = "Referenced Object 1";
                referencePropertiesObject.LookupReferencedObject.Description = "Description 1";
                referencePropertiesObject.Name = "Object 1";

                ReferencedObject referencedObject2 = ObjectSpace.CreateObject<ReferencedObject>();
                referencedObject2.Name = "Referenced Object 2";
                referencedObject2.Description = "Description 2";
                referencedObject2.Save();

                referencePropertiesObject.GridLookupReferencedObject = referencedObject2;
                referencePropertiesObject.Save();

                ReferencedObject referencedObject3 = ObjectSpace.CreateObject<ReferencedObject>();
                referencedObject3.Name = "Referenced Object 3";
                referencedObject3.Description = "Description 3";
                referencedObject3.Save();
            }
        }

        private void CreateImagePropertiesObjects() {
            if(ObjectSpace.FindObject<ImagePropertiesObject>(null) == null) {
                ImagePropertiesObject imagePropertiesObject = ObjectSpace.CreateObject<ImagePropertiesObject>();
                imagePropertiesObject.ImageProperty = GetByteArrayFromAssembly("FeatureCenter.Module.PropertyEditors.Resources.LargeImage1.png");
                imagePropertiesObject.ImageDelayedProperty = GetByteArrayFromAssembly("FeatureCenter.Module.PropertyEditors.Resources.LargeImage1.png");
                imagePropertiesObject.Name = "Object 1";
                imagePropertiesObject.Save();
            }
        }

        private void CreateFileAttachmentPropertiesObjects() {
            if(ObjectSpace.FindObject<FileAttachmentProperties>(null) == null) {
                FileAttachmentProperties obj = ObjectSpace.CreateObject<FileAttachmentProperties>();
                obj.Picture.LoadFromStream("Image1.png", GetType().Assembly.GetManifestResourceStream("FeatureCenter.Module.PropertyEditors.Resources.Image1.png"));
                obj.Document.LoadFromStream("Document.txt", GetType().Assembly.GetManifestResourceStream("FeatureCenter.Module.PropertyEditors.Resources.Document.txt"));

                FileCollectionItem item = ObjectSpace.CreateObject<FileCollectionItem>();
                item.File.LoadFromStream("Image2.png", GetType().Assembly.GetManifestResourceStream("FeatureCenter.Module.PropertyEditors.Resources.Image2.png"));
                obj.Files.Add(item);
                obj.Name = "Object 1";
                obj.Save();

                FileAttachmentProperties obj2 = ObjectSpace.CreateObject<FileAttachmentProperties>();
                obj2.Picture.LoadFromStream("Image2.png", GetType().Assembly.GetManifestResourceStream("FeatureCenter.Module.PropertyEditors.Resources.Image2.png"));
                obj2.Document.LoadFromStream("Document.txt", GetType().Assembly.GetManifestResourceStream("FeatureCenter.Module.PropertyEditors.Resources.Document.txt"));
                obj2.Name = "Object 2";
                obj2.Save();

                FileAttachmentProperties obj3 = ObjectSpace.CreateObject<FileAttachmentProperties>();
                obj3.Document.LoadFromStream("EmptyFile.txt", GetType().Assembly.GetManifestResourceStream("FeatureCenter.Module.PropertyEditors.Resources.EmptyFile.txt"));
                obj3.Name = "Object 3";
                obj3.Save();
            }
        }

        private void CreateBooleanPropertiesObjects() {
            if(ObjectSpace.FindObject<BooleanProperties>(null) == null) {
                BooleanProperties booleanPropertiesObject = ObjectSpace.CreateObject<BooleanProperties>();
                booleanPropertiesObject.BooleanProperty = true;
                booleanPropertiesObject.BooleanWithCaptions = false;
                booleanPropertiesObject.BooleanWithImages = true;
                booleanPropertiesObject.Name = "Object 1";
                booleanPropertiesObject.Save();
            }
        }

        private void CreateColorPropertiesObjects() {
            if(ObjectSpace.FindObject<ColorPropertiesObject>(null) == null) {
                ColorPropertiesObject colorPropertiesObject1 = ObjectSpace.CreateObject<ColorPropertiesObject>();
                colorPropertiesObject1.Name = "Object 1";
                colorPropertiesObject1.Color = Color.Red;
                colorPropertiesObject1.Save();

                ColorPropertiesObject colorPropertiesObject2 = ObjectSpace.CreateObject<ColorPropertiesObject>();
                colorPropertiesObject2.Name = "Object 2";
                colorPropertiesObject2.Save();
            }
        }

        private void CreateEnumPropertiesObjects() {
            if(ObjectSpace.FindObject<EnumProperties>(null) == null) {
                EnumProperties enumPropertiesObject = ObjectSpace.CreateObject<EnumProperties>();
                enumPropertiesObject.TextAndImageEnumProperty = TextAndImageEnum.High;
                enumPropertiesObject.Name = "Object 1";
                enumPropertiesObject.Save();
            }
        }

        private void CreateRuleRequiredFieldObjects() {
            if(ObjectSpace.FindObject<RuleRequiredFieldObject>(null) == null) {
                RuleRequiredFieldObject ruleRequiredFieldObjectInvalid = ObjectSpace.CreateObject<RuleRequiredFieldObject>();
                ruleRequiredFieldObjectInvalid.Name = "Invalid RuleRequiredFieldObject";
                ruleRequiredFieldObjectInvalid.RequiredDateTimeProperty = null;
                ruleRequiredFieldObjectInvalid.RequiredStringProperty = string.Empty;
                ruleRequiredFieldObjectInvalid.Save();

                RuleRequiredFieldObject ruleRequiredFieldObjectValid = ObjectSpace.CreateObject<RuleRequiredFieldObject>();
                ruleRequiredFieldObjectValid.Name = "Valid RuleRequiredFieldObject";
                ruleRequiredFieldObjectValid.RequiredDateTimeProperty = DateTime.Today;
                ruleRequiredFieldObjectValid.RequiredStringProperty = "Non-empty string";
                ruleRequiredFieldObjectValid.Save();
            }
        }

        private void CreateRuleCriteriaObjects() {
            if(ObjectSpace.FindObject<RuleCriteriaObject>(null) == null) {
                RuleCriteriaObject ruleCriteriaObjectInvalid = ObjectSpace.CreateObject<RuleCriteriaObject>();
                ruleCriteriaObjectInvalid.Name = "Invalid RuleCriteriaObject";
                ruleCriteriaObjectInvalid.GreaterThanTen = 5;
                ruleCriteriaObjectInvalid.RequiredField = string.Empty;
                ruleCriteriaObjectInvalid.StartsWithA = "Some text";
                ruleCriteriaObjectInvalid.Today = DateTime.Today.AddDays(3);
                ruleCriteriaObjectInvalid.MinValue = 10;
                ruleCriteriaObjectInvalid.MaxValue = 5;

                RuleCriteriaCollectionObject invalidCollectionItem1 = ObjectSpace.CreateObject<RuleCriteriaCollectionObject>();
                invalidCollectionItem1.Name = "Invalid RuleCriteriaCollectionObject 1";
                invalidCollectionItem1.BiggerSum = 1;
                invalidCollectionItem1.LessSum = 10;
                RuleCriteriaCollectionObject invalidCollectionItem2 = ObjectSpace.CreateObject<RuleCriteriaCollectionObject>();
                invalidCollectionItem2.Name = "Invalid RuleCriteriaCollectionObject 2";
                invalidCollectionItem2.BiggerSum = 0;
                invalidCollectionItem2.LessSum = -1;
                RuleCriteriaCollectionObject invalidCollectionItem3 = ObjectSpace.CreateObject<RuleCriteriaCollectionObject>();
                invalidCollectionItem3.Name = "Invalid RuleCriteriaCollectionObject 3";
                invalidCollectionItem3.BiggerSum = 5;
                invalidCollectionItem3.LessSum = 5;

                ruleCriteriaObjectInvalid.Collection.Add(invalidCollectionItem1);
                ruleCriteriaObjectInvalid.Collection.Add(invalidCollectionItem2);
                ruleCriteriaObjectInvalid.Collection.Add(invalidCollectionItem3);
                ruleCriteriaObjectInvalid.Save();

                RuleCriteriaObject ruleCriteriaObjectValid = ObjectSpace.CreateObject<RuleCriteriaObject>();
                ruleCriteriaObjectValid.Name = "Valid RuleCriteriaObject";
                ruleCriteriaObjectValid.GreaterThanTen = 25;
                ruleCriteriaObjectValid.RequiredField = "Non-empty string";
                ruleCriteriaObjectValid.StartsWithA = "Ann";
                ruleCriteriaObjectValid.Today = DateTime.Today;
                ruleCriteriaObjectValid.MinValue = -5;
                ruleCriteriaObjectValid.MaxValue = 5;

                RuleCriteriaCollectionObject validCollectionItem1 = ObjectSpace.CreateObject<RuleCriteriaCollectionObject>();
                validCollectionItem1.Name = "Valid RuleCriteriaCollectionObject 1";
                validCollectionItem1.BiggerSum = 10;
                validCollectionItem1.LessSum = 2;
                RuleCriteriaCollectionObject validCollectionItem2 = ObjectSpace.CreateObject<RuleCriteriaCollectionObject>();
                validCollectionItem2.Name = "Valid RuleCriteriaCollectionObject 2";
                validCollectionItem2.BiggerSum = 90;
                validCollectionItem2.LessSum = 90;

                ruleCriteriaObjectValid.Collection.Add(validCollectionItem1);
                ruleCriteriaObjectValid.Collection.Add(validCollectionItem2);
                ruleCriteriaObjectValid.Save();
            }
        }

        private void CreateRuleRangeObjects() {
            if(ObjectSpace.FindObject<RuleRangeObject>(null) == null) {
                RuleRangeObject ruleRangeObjectInvalid = ObjectSpace.CreateObject<RuleRangeObject>();
                ruleRangeObjectInvalid.Name = "Invalid RuleRangeObject";
                ruleRangeObjectInvalid.During2008 = new DateTime(2009, 1, 1);
                ruleRangeObjectInvalid.FromOneToFive = 10;
                ruleRangeObjectInvalid.LastSevenDays = DateTime.Today.AddDays(3);

                RuleRangeCollectionObject invalidCollectionItem1 = ObjectSpace.CreateObject<RuleRangeCollectionObject>();
                invalidCollectionItem1.Name = "Invalid RuleRangeCollectionObject 1";
                invalidCollectionItem1.SumBetween0And50 = 15;
                invalidCollectionItem1.AtLeastOneValueWithinFirstWeekOf2009 = new DateTime(2008, 1, 1);

                RuleRangeCollectionObject invalidCollectionItem2 = ObjectSpace.CreateObject<RuleRangeCollectionObject>();
                invalidCollectionItem2.Name = "Invalid RuleRangeCollectionObject 2";
                invalidCollectionItem2.SumBetween0And50 = 20;
                invalidCollectionItem2.AtLeastOneValueWithinFirstWeekOf2009 = new DateTime(2009, 1, 15);

                RuleRangeCollectionObject invalidCollectionItem3 = ObjectSpace.CreateObject<RuleRangeCollectionObject>();
                invalidCollectionItem3.Name = "Invalid RuleRangeCollectionObject 3";
                invalidCollectionItem3.SumBetween0And50 = 25;
                invalidCollectionItem3.AtLeastOneValueWithinFirstWeekOf2009 = new DateTime(2009, 1, 8);

                ruleRangeObjectInvalid.Collection.Add(invalidCollectionItem1);
                ruleRangeObjectInvalid.Collection.Add(invalidCollectionItem2);
                ruleRangeObjectInvalid.Collection.Add(invalidCollectionItem3);
                ruleRangeObjectInvalid.Save();

                RuleRangeObject ruleRangeObjectValid = ObjectSpace.CreateObject<RuleRangeObject>();
                ruleRangeObjectValid.Name = "Valid RuleRangeObject";
                ruleRangeObjectValid.During2008 = new DateTime(2008, 12, 31);
                ruleRangeObjectValid.FromOneToFive = 3;
                ruleRangeObjectValid.LastSevenDays = DateTime.Today.AddDays(-5);

                RuleRangeCollectionObject validCollectionItem1 = ObjectSpace.CreateObject<RuleRangeCollectionObject>();
                validCollectionItem1.Name = "Valid RuleRangeCollectionObject 1";
                validCollectionItem1.SumBetween0And50 = 0.99m;
                validCollectionItem1.AtLeastOneValueWithinFirstWeekOf2009 = new DateTime(2009, 1, 5);
                RuleRangeCollectionObject validCollectionItem2 = ObjectSpace.CreateObject<RuleRangeCollectionObject>();
                validCollectionItem2.Name = "Valid RuleRangeCollectionObject 2";
                validCollectionItem2.SumBetween0And50 = 49;
                validCollectionItem2.AtLeastOneValueWithinFirstWeekOf2009 = new DateTime(2009, 1, 8);

                ruleRangeObjectValid.Collection.Add(validCollectionItem1);
                ruleRangeObjectValid.Collection.Add(validCollectionItem2);
                ruleRangeObjectValid.Save();
            }
        }

        private void CreateRuleValueComparisonObjects() {
            if(ObjectSpace.FindObject<RuleValueComparisonObject>(null) == null) {
                RuleValueComparisonObject ruleValueComparisonObjectInvalid = ObjectSpace.CreateObject<RuleValueComparisonObject>();
                ruleValueComparisonObjectInvalid.Name = "Invalid RuleValueComparisonObject";
                ruleValueComparisonObjectInvalid.BeforeFebruary2008 = new DateTime(2008, 2, 20);
                ruleValueComparisonObjectInvalid.Equals100 = 500;
                ruleValueComparisonObjectInvalid.GreaterThanZero = -10;
                ruleValueComparisonObjectInvalid.NotEquals1000 = 1000;
                ruleValueComparisonObjectInvalid.NotLessThanOne = 0;
                ruleValueComparisonObjectInvalid.NotMoreThan10 = 11;
                ruleValueComparisonObjectInvalid.BeforeToday = DateTime.Today;

                RuleValueComparisonCollectionObject invalidCollectionItem1 = ObjectSpace.CreateObject<RuleValueComparisonCollectionObject>();
                invalidCollectionItem1.Name = "Invalid RuleValueComparisonCollectionObject 1";
                invalidCollectionItem1.SumIsGreaterThan100 = 10;
                RuleValueComparisonCollectionObject invalidCollectionItem2 = ObjectSpace.CreateObject<RuleValueComparisonCollectionObject>();
                invalidCollectionItem2.Name = "Invalid RuleValueComparisonCollectionObject 2";
                invalidCollectionItem2.SumIsGreaterThan100 = 90;

                ruleValueComparisonObjectInvalid.Collection.Add(invalidCollectionItem1);
                ruleValueComparisonObjectInvalid.Collection.Add(invalidCollectionItem2);
                ruleValueComparisonObjectInvalid.Save();

                RuleValueComparisonObject ruleValueComparisonObjectValid = ObjectSpace.CreateObject<RuleValueComparisonObject>();
                ruleValueComparisonObjectValid.Name = "Valid RuleValueComparisonObject";
                ruleValueComparisonObjectValid.BeforeFebruary2008 = new DateTime(2007, 12, 31);
                ruleValueComparisonObjectValid.Equals100 = 100;
                ruleValueComparisonObjectValid.GreaterThanZero = 10;
                ruleValueComparisonObjectValid.NotEquals1000 = 0;
                ruleValueComparisonObjectValid.NotLessThanOne = 1;
                ruleValueComparisonObjectValid.NotMoreThan10 = -5;
                ruleValueComparisonObjectValid.BeforeToday = DateTime.Today.AddDays(-1);

                RuleValueComparisonCollectionObject validCollectionItem = ObjectSpace.CreateObject<RuleValueComparisonCollectionObject>();
                validCollectionItem.Name = "Valid RuleValueComparisonCollectionObject 1";
                validCollectionItem.SumIsGreaterThan100 = -10;
                RuleValueComparisonCollectionObject validCollectionItem2 = ObjectSpace.CreateObject<RuleValueComparisonCollectionObject>();
                validCollectionItem2.Name = "Valid RuleValueComparisonCollectionObject 2";
                validCollectionItem2.SumIsGreaterThan100 = 100;
                RuleValueComparisonCollectionObject validCollectionItem3 = ObjectSpace.CreateObject<RuleValueComparisonCollectionObject>();
                validCollectionItem3.Name = "Valid RuleValueComparisonCollectionObject 3";
                validCollectionItem3.SumIsGreaterThan100 = 10.99m;

                ruleValueComparisonObjectValid.Collection.Add(validCollectionItem);
                ruleValueComparisonObjectValid.Collection.Add(validCollectionItem2);
                ruleValueComparisonObjectValid.Collection.Add(validCollectionItem3);
                ruleValueComparisonObjectValid.Save();
            }
        }

        private void CreateRuleStringComparisonObjects() {
            if(ObjectSpace.FindObject<RuleStringComparisonObject>(null) == null) {
                RuleStringComparisonObject ruleStringComparisonObjectInvalid = ObjectSpace.CreateObject<RuleStringComparisonObject>();
                ruleStringComparisonObjectInvalid.Name = "Invalid RuleStringComparisonObject";
                ruleStringComparisonObjectInvalid.ContainsXXX = "ABC";
                ruleStringComparisonObjectInvalid.DoesNotEqualInvalid = "Invalid";
                ruleStringComparisonObjectInvalid.EndsWithXyz = "Xyz Abc";
                ruleStringComparisonObjectInvalid.EqualsValid = "Some text";
                ruleStringComparisonObjectInvalid.StartsWithAbc = "Xyz Abc";
                ruleStringComparisonObjectInvalid.Save();

                RuleStringComparisonObject ruleStringComparisonObjectValid = ObjectSpace.CreateObject<RuleStringComparisonObject>();
                ruleStringComparisonObjectValid.Name = "Valid RuleStringComparisonObject";
                ruleStringComparisonObjectValid.ContainsXXX = "AxxxBC";
                ruleStringComparisonObjectValid.DoesNotEqualInvalid = "Invalid or not?";
                ruleStringComparisonObjectValid.EndsWithXyz = "Abc Xyz";
                ruleStringComparisonObjectValid.EqualsValid = "Valid";
                ruleStringComparisonObjectValid.StartsWithAbc = "Abc Xyz";
                ruleStringComparisonObjectValid.Save();
            }
        }

        private void CreateRuleRegularExpressionObjects() {
            if(ObjectSpace.FindObject<RuleRegularExpressionObject>(null) == null) {
                RuleRegularExpressionObject ruleRegularExpressionObjectInvalid = ObjectSpace.CreateObject<RuleRegularExpressionObject>();
                ruleRegularExpressionObjectInvalid.Name = "Invalid RuleRegularExpressionObject";
                ruleRegularExpressionObjectInvalid.Email = "This is not an email.@invalid.email";
                ruleRegularExpressionObjectInvalid.Save();

                RuleRegularExpressionObject ruleRegularExpressionObjectValid = ObjectSpace.CreateObject<RuleRegularExpressionObject>();
                ruleRegularExpressionObjectValid.Name = "Valid RuleRegularExpressionObject";
                ruleRegularExpressionObjectValid.Email = "support@devexpress.com";
                ruleRegularExpressionObjectValid.Save();
            }
        }

        private void CreateRuleFromBoolPropertyObjects() {
            if(ObjectSpace.FindObject<RuleFromBoolPropertyObject>(null) == null) {
                RuleFromBoolPropertyObject ruleFromBoolPropertyObjectInvalid = ObjectSpace.CreateObject<RuleFromBoolPropertyObject>();
                ruleFromBoolPropertyObjectInvalid.Name = "Invalid RuleFromBoolPropertyObject";
                ruleFromBoolPropertyObjectInvalid.ContainsValid = "Some text";
                ruleFromBoolPropertyObjectInvalid.LengthMoreThan10 = "Too short";
                ruleFromBoolPropertyObjectInvalid.MustBeTrue = false;
                ruleFromBoolPropertyObjectInvalid.LeftPart = "Developer ";
                ruleFromBoolPropertyObjectInvalid.MiddlePart = "Express ";
                ruleFromBoolPropertyObjectInvalid.RightPart = "Inc.";
                ruleFromBoolPropertyObjectInvalid.FullString = "Wrong FullString text";
                ruleFromBoolPropertyObjectInvalid.Save();

                RuleFromBoolPropertyObject ruleFromBoolPropertyObjectValid = ObjectSpace.CreateObject<RuleFromBoolPropertyObject>();
                ruleFromBoolPropertyObjectValid.Name = "Valid RuleFromBoolPropertyObject";
                ruleFromBoolPropertyObjectValid.ContainsValid = "Some Valid text";
                ruleFromBoolPropertyObjectValid.LengthMoreThan10 = "This text is longer than 10 characters";
                ruleFromBoolPropertyObjectValid.MustBeTrue = true;
                ruleFromBoolPropertyObjectValid.LeftPart = "Developer ";
                ruleFromBoolPropertyObjectValid.MiddlePart = "Express ";
                ruleFromBoolPropertyObjectValid.RightPart = "Inc.";
                ruleFromBoolPropertyObjectValid.FullString = "Developer Express Inc.";
                ruleFromBoolPropertyObjectValid.Save();
            }
        }

        private void CreateRuleObjectExistsObjects() {
            if(ObjectSpace.FindObject<RuleObjectExistsObject>(null) == null) {
                RuleObjectExistsObject ruleObjectExistsObjectInvalid = ObjectSpace.CreateObject<RuleObjectExistsObject>();
                ruleObjectExistsObjectInvalid.Name = "Invalid RuleObjectExistsObject (Student)";
                ruleObjectExistsObjectInvalid.PersonName = "Sam";
                ruleObjectExistsObjectInvalid.Position = Position.Student;
                ruleObjectExistsObjectInvalid.Subject = Subject.Biology;

                RuleObjectExistsCollectionObject invalidCollectionItem1 = ObjectSpace.CreateObject<RuleObjectExistsCollectionObject>();
                invalidCollectionItem1.Name = "Invalid RuleObjectExistsCollectionObject 1";
                invalidCollectionItem1.ItemSubject = Subject.Physics;
                RuleObjectExistsCollectionObject invalidCollectionItem2 = ObjectSpace.CreateObject<RuleObjectExistsCollectionObject>();
                invalidCollectionItem2.Name = "Invalid RuleObjectExistsCollectionObject 2";
                invalidCollectionItem2.ItemSubject = Subject.Mathemathics;

                ruleObjectExistsObjectInvalid.Collection.Add(invalidCollectionItem1);
                ruleObjectExistsObjectInvalid.Collection.Add(invalidCollectionItem2);
                ruleObjectExistsObjectInvalid.Save();

                RuleObjectExistsObject ruleObjectExistsObjectValid = ObjectSpace.CreateObject<RuleObjectExistsObject>();
                ruleObjectExistsObjectValid.Name = "Valid RuleObjectExistsObject (Student)";
                ruleObjectExistsObjectValid.PersonName = "John";
                ruleObjectExistsObjectValid.Position = Position.Student;
                ruleObjectExistsObjectValid.Subject = Subject.Mathemathics;

                RuleObjectExistsCollectionObject validCollectionItem11 = ObjectSpace.CreateObject<RuleObjectExistsCollectionObject>();
                validCollectionItem11.Name = "Valid RuleObjectExistsCollectionObject 1";
                validCollectionItem11.ItemSubject = Subject.Biology;
                RuleObjectExistsCollectionObject validCollectionItem12 = ObjectSpace.CreateObject<RuleObjectExistsCollectionObject>();
                validCollectionItem12.Name = "Valid RuleObjectExistsCollectionObject 2";
                validCollectionItem12.ItemSubject = Subject.Mathemathics;

                ruleObjectExistsObjectValid.Collection.Add(validCollectionItem11);
                ruleObjectExistsObjectValid.Collection.Add(validCollectionItem12);
                ruleObjectExistsObjectValid.Save();

                RuleObjectExistsObject ruleObjectExistsObjectValidTeacher = ObjectSpace.CreateObject<RuleObjectExistsObject>();
                ruleObjectExistsObjectValidTeacher.Name = "Valid RuleObjectExistsObject (Teacher)";
                ruleObjectExistsObjectValidTeacher.PersonName = "Mr. Smith";
                ruleObjectExistsObjectValidTeacher.Position = Position.Teacher;
                ruleObjectExistsObjectValidTeacher.Subject = Subject.Mathemathics;

                RuleObjectExistsCollectionObject validCollectionItem21 = ObjectSpace.CreateObject<RuleObjectExistsCollectionObject>();
                validCollectionItem21.Name = "Belongs to 'Valid RuleObjectExistsObject (Teacher)' object";
                validCollectionItem21.ItemSubject = Subject.Biology;
                RuleObjectExistsCollectionObject validCollectionItem22 = ObjectSpace.CreateObject<RuleObjectExistsCollectionObject>();
                validCollectionItem22.Name = "Valid RuleObjectExistsCollectionObject 2";
                validCollectionItem22.ItemSubject = Subject.Physics;

                ruleObjectExistsObjectValidTeacher.Collection.Add(validCollectionItem21);
                ruleObjectExistsObjectValidTeacher.Collection.Add(validCollectionItem22);
                ruleObjectExistsObjectValidTeacher.Save();
            }
        }

        private void CreateRuleUniqueValueObjects() {
            if(ObjectSpace.FindObject<RuleUniqueValueObject>(null) == null) {
                RuleUniqueValueObject ruleUniqueValueObjectInvalid1 = ObjectSpace.CreateObject<RuleUniqueValueObject>();
                ruleUniqueValueObjectInvalid1.Name = "Invalid RuleUniqueValueObject 1";
                ruleUniqueValueObjectInvalid1.UniqueValue = "Non-unique string";

                RuleUniqueValueCollectionObject invalidCollectionItem11 = ObjectSpace.CreateObject<RuleUniqueValueCollectionObject>();
                invalidCollectionItem11.Name = "Invalid RuleUniqueValueCollectionObject 1";
                invalidCollectionItem11.ItemUniqueValue = 5;
                RuleUniqueValueCollectionObject invalidCollectionItem12 = ObjectSpace.CreateObject<RuleUniqueValueCollectionObject>();
                invalidCollectionItem12.Name = "Invalid RuleUniqueValueCollectionObject 2";
                invalidCollectionItem12.ItemUniqueValue = 5;
                RuleUniqueValueCollectionObject invalidCollectionItem13 = ObjectSpace.CreateObject<RuleUniqueValueCollectionObject>();
                invalidCollectionItem13.Name = "Invalid RuleUniqueValueCollectionObject 3";
                invalidCollectionItem13.ItemUniqueValue = 10;

                ruleUniqueValueObjectInvalid1.Collection.Add(invalidCollectionItem11);
                ruleUniqueValueObjectInvalid1.Collection.Add(invalidCollectionItem12);
                ruleUniqueValueObjectInvalid1.Collection.Add(invalidCollectionItem13);
                ruleUniqueValueObjectInvalid1.Save();

                RuleUniqueValueObject ruleUniqueValueObjectInvalid2 = ObjectSpace.CreateObject<RuleUniqueValueObject>();
                ruleUniqueValueObjectInvalid2.Name = "Invalid RuleUniqueValueObject 2";
                ruleUniqueValueObjectInvalid2.UniqueValue = "Non-unique string";

                RuleUniqueValueCollectionObject invalidCollectionItem21 = ObjectSpace.CreateObject<RuleUniqueValueCollectionObject>();
                invalidCollectionItem21.Name = "Invalid RuleUniqueValueCollectionObject 1";
                invalidCollectionItem21.ItemUniqueValue = 10;
                RuleUniqueValueCollectionObject invalidCollectionItem22 = ObjectSpace.CreateObject<RuleUniqueValueCollectionObject>();
                invalidCollectionItem22.Name = "Invalid RuleUniqueValueCollectionObject 2";
                invalidCollectionItem22.ItemUniqueValue = 10;
                RuleUniqueValueCollectionObject invalidCollectionItem23 = ObjectSpace.CreateObject<RuleUniqueValueCollectionObject>();
                invalidCollectionItem23.Name = "Invalid RuleUniqueValueCollectionObject 3";
                invalidCollectionItem23.ItemUniqueValue = 5;

                ruleUniqueValueObjectInvalid2.Collection.Add(invalidCollectionItem21);
                ruleUniqueValueObjectInvalid2.Collection.Add(invalidCollectionItem22);
                ruleUniqueValueObjectInvalid2.Collection.Add(invalidCollectionItem23);
                ruleUniqueValueObjectInvalid2.Save();

                RuleUniqueValueObject ruleUniqueValueObjectValid = ObjectSpace.CreateObject<RuleUniqueValueObject>();
                ruleUniqueValueObjectValid.Name = "Valid RuleUniqueValueObject";
                ruleUniqueValueObjectValid.UniqueValue = "This string is unique";

                RuleUniqueValueCollectionObject validCollectionItem1 = ObjectSpace.CreateObject<RuleUniqueValueCollectionObject>();
                validCollectionItem1.Name = "Invalid RuleUniqueValueCollectionObject 1";
                validCollectionItem1.ItemUniqueValue = 10;
                RuleUniqueValueCollectionObject validCollectionItem2 = ObjectSpace.CreateObject<RuleUniqueValueCollectionObject>();
                validCollectionItem2.Name = "Invalid RuleUniqueValueCollectionObject 2";
                validCollectionItem2.ItemUniqueValue = 5;

                ruleUniqueValueObjectValid.Collection.Add(validCollectionItem1);
                ruleUniqueValueObjectValid.Collection.Add(validCollectionItem2);
                ruleUniqueValueObjectValid.Save();
            }
        }

        private void CreateRuleIsReferencedObjects() {
            if(ObjectSpace.FindObject<RuleIsReferencedObject>(null) == null) {
                RuleIsReferencedObject ruleIsReferencedObjectInvalid = ObjectSpace.CreateObject<RuleIsReferencedObject>();
                ruleIsReferencedObjectInvalid.Name = "Invalid RuleIsReferencedObject";
                ruleIsReferencedObjectInvalid.Save();

                RuleIsReferencedObject ruleIsReferencedObjectValid = ObjectSpace.CreateObject<RuleIsReferencedObject>();
                ruleIsReferencedObjectValid.Name = "Valid RuleIsReferencedObject";
                ruleIsReferencedObjectValid.ReferencedObject = ruleIsReferencedObjectInvalid;
                ruleIsReferencedObjectValid.Save();
            }
        }

        private void CreateRuleCombinationOfPropertiesIsUniqueObjects() {
            if(ObjectSpace.FindObject<RuleCombinationOfPropertiesIsUniqueObject>(null) == null) {
                RuleCombinationOfPropertiesIsUniqueObject combinationUniqueObjectInvalid1 = ObjectSpace.CreateObject<RuleCombinationOfPropertiesIsUniqueObject>();
                combinationUniqueObjectInvalid1.Name = "Invalid RuleCombinationOfPropertiesIsUniqueObject 1";
                combinationUniqueObjectInvalid1.Description = "First description";
                combinationUniqueObjectInvalid1.Type = SampleEnum.First;
                combinationUniqueObjectInvalid1.Save();

                RuleCombinationOfPropertiesIsUniqueObject combinationUniqueObjectInvalid2 = ObjectSpace.CreateObject<RuleCombinationOfPropertiesIsUniqueObject>();
                combinationUniqueObjectInvalid2.Name = "Invalid RuleCombinationOfPropertiesIsUniqueObject 2";
                combinationUniqueObjectInvalid2.Description = "First description";
                combinationUniqueObjectInvalid2.Type = SampleEnum.First;
                combinationUniqueObjectInvalid2.Save();

                RuleCombinationOfPropertiesIsUniqueObject combinationUniqueObjectValid1 = ObjectSpace.CreateObject<RuleCombinationOfPropertiesIsUniqueObject>();
                combinationUniqueObjectValid1.Name = "Valid RuleCombinationOfPropertiesIsUniqueObject 1";
                combinationUniqueObjectValid1.Description = "Second description";
                combinationUniqueObjectValid1.Type = SampleEnum.Second;
                combinationUniqueObjectValid1.Save();

                RuleCombinationOfPropertiesIsUniqueObject combinationUniqueObjectValid2 = ObjectSpace.CreateObject<RuleCombinationOfPropertiesIsUniqueObject>();
                combinationUniqueObjectValid2.Name = "Valid RuleCombinationOfPropertiesIsUniqueObject 2";
                combinationUniqueObjectValid2.Description = "First description";
                combinationUniqueObjectValid2.Type = SampleEnum.Third;
                combinationUniqueObjectValid2.Save();
            }
        }

        private void CreateCodeRuleObjects() {
            if(ObjectSpace.FindObject<CodeRuleObject>(null) == null) {
                CodeRuleObject codeRuleObjectInvalid1 = ObjectSpace.CreateObject<CodeRuleObject>();
                codeRuleObjectInvalid1.Name = "Invalid CodeRuleObject 1";
                codeRuleObjectInvalid1.PersonName = string.Empty;
                codeRuleObjectInvalid1.Sex = Sex.Male;
                codeRuleObjectInvalid1.TitleOfCourtesy = TitleOfCourtesy.Mrs;
                codeRuleObjectInvalid1.Save();

                CodeRuleObject codeRuleObjectInvalid2 = ObjectSpace.CreateObject<CodeRuleObject>();
                codeRuleObjectInvalid2.Name = "Invalid CodeRuleObject 2";
                codeRuleObjectInvalid2.PersonName = "Mary";
                codeRuleObjectInvalid2.Sex = Sex.Female;
                codeRuleObjectInvalid2.TitleOfCourtesy = TitleOfCourtesy.Mr;
                codeRuleObjectInvalid2.Save();

                CodeRuleObject codeRuleObjectValid = ObjectSpace.CreateObject<CodeRuleObject>();
                codeRuleObjectValid.Name = "Valid CodeRuleObject";
                codeRuleObjectValid.PersonName = "John";
                codeRuleObjectValid.Sex = Sex.Male;
                codeRuleObjectValid.TitleOfCourtesy = TitleOfCourtesy.Mr;
                codeRuleObjectValid.Save();
            }
        }

        private void CreateCustomRuleObjects() {
            if(ObjectSpace.FindObject<CustomRuleObject>(null) == null) {
                CustomRuleObject customRuleObjectInvalid = ObjectSpace.CreateObject<CustomRuleObject>();
                customRuleObjectInvalid.Name = "Invalid CustomRuleObject";
                customRuleObjectInvalid.NotMoreThanTenSymbols = "This string is too long";
                customRuleObjectInvalid.MoreThan5Symbols = "Short";
                customRuleObjectInvalid.Save();
                CustomRuleObject customRuleObjectValid = ObjectSpace.CreateObject<CustomRuleObject>();
                customRuleObjectValid.Name = "Valid CustomRuleObject";
                customRuleObjectValid.NotMoreThanTenSymbols = "10 symbols";
                customRuleObjectValid.MoreThan5Symbols = "Now the length is enough to pass the rule";
                customRuleObjectValid.Save();
            }
        }

        private void CreateValidationTemplatesObjects() {
            if(ObjectSpace.FindObject<ValidationTemplatesObject>(null) == null) {
                ValidationTemplatesObject validationTemplatesObjectInvalid = ObjectSpace.CreateObject<ValidationTemplatesObject>();
                validationTemplatesObjectInvalid.Name = "Invalid ValidationTemplatesObject";
                validationTemplatesObjectInvalid.ContainsAbc = "Xyz";
                validationTemplatesObjectInvalid.GreaterThanZero = 0;
                validationTemplatesObjectInvalid.LeftPart = "Developer ";
                validationTemplatesObjectInvalid.MiddlePart = "Express ";
                validationTemplatesObjectInvalid.RightPart = "Inc.";
                validationTemplatesObjectInvalid.FullString = "Wrong FullString text";
                validationTemplatesObjectInvalid.DateAndPrice = ObjectSpace.CreateObject<DateAndPrice>();
                validationTemplatesObjectInvalid.DateAndPrice.Price = -150m;
                validationTemplatesObjectInvalid.DateAndPrice.Date = new DateTime(2008, 1, 5);
                validationTemplatesObjectInvalid.Save();

                ValidationTemplatesObject validationTemplatesObjectValid = ObjectSpace.CreateObject<ValidationTemplatesObject>();
                validationTemplatesObjectValid.Name = "Valid ValidationTemplatesObject";
                validationTemplatesObjectValid.ContainsAbc = "XyzAbcXyz";
                validationTemplatesObjectValid.GreaterThanZero = 15;
                validationTemplatesObjectValid.LeftPart = "Developer ";
                validationTemplatesObjectValid.MiddlePart = "Express ";
                validationTemplatesObjectValid.RightPart = "Inc.";
                validationTemplatesObjectValid.FullString = "Developer Express Inc.";
                validationTemplatesObjectValid.DateAndPrice = ObjectSpace.CreateObject<DateAndPrice>();
                validationTemplatesObjectValid.DateAndPrice.Price = 100m;
                validationTemplatesObjectValid.DateAndPrice.Date = DateTime.Today.AddDays(5);
                validationTemplatesObjectValid.Save();
            }
        }

        private void CreateSimpleValidationSettingsObjects() {
            if(ObjectSpace.FindObject<SimpleValidationSettingsObject>(null) == null) {
                SimpleValidationSettingsObject simpleValidationSettingsObjectInvalid = ObjectSpace.CreateObject<SimpleValidationSettingsObject>();
                simpleValidationSettingsObjectInvalid.Name = "Invalid SimpleValidationSettingsObject";
                simpleValidationSettingsObjectInvalid.DoesNotContainABC = "xyAbCXYZ";
                simpleValidationSettingsObjectInvalid.NotFromZeroToTen = 7;
                simpleValidationSettingsObjectInvalid.RequiredField = string.Empty;
                simpleValidationSettingsObjectInvalid.Save();

                SimpleValidationSettingsObject simpleValidationSettingsObjectValid = ObjectSpace.CreateObject<SimpleValidationSettingsObject>();
                simpleValidationSettingsObjectValid.Name = "Valid SimpleValidationSettingsObject";
                simpleValidationSettingsObjectValid.DoesNotContainABC = string.Empty;
                simpleValidationSettingsObjectValid.NotFromZeroToTen = -1;
                simpleValidationSettingsObjectValid.RequiredField = "Non-empty string";
                simpleValidationSettingsObjectValid.Save();
            }
        }

        private void CreateComplexValidationSettingsObjects() {
            if(ObjectSpace.FindObject<ComplexValidationSettingsObject>(null) == null) {
                ComplexValidationSettingsObject complexValidationSettingsObjectInvalid1 = ObjectSpace.CreateObject<ComplexValidationSettingsObject>();
                complexValidationSettingsObjectInvalid1.Name = "Invalid ComplexValidationSettingsObject 1";
                complexValidationSettingsObjectInvalid1.FirstName = "John";
                complexValidationSettingsObjectInvalid1.LastName = "Smith";
                complexValidationSettingsObjectInvalid1.Save();

                ComplexValidationSettingsObject complexValidationSettingsObjectInvalid2 = ObjectSpace.CreateObject<ComplexValidationSettingsObject>();
                complexValidationSettingsObjectInvalid2.Name = "Invalid ComplexValidationSettingsObject 2";
                complexValidationSettingsObjectInvalid2.FirstName = "John";
                complexValidationSettingsObjectInvalid2.LastName = "Smith";
                complexValidationSettingsObjectInvalid2.ReferencedObject = complexValidationSettingsObjectInvalid1;
                complexValidationSettingsObjectInvalid2.Save();

                ComplexValidationSettingsObject complexValidationSettingsObjectValid = ObjectSpace.CreateObject<ComplexValidationSettingsObject>();
                complexValidationSettingsObjectValid.Name = "Valid ComplexValidationSettingsObject";
                complexValidationSettingsObjectValid.FirstName = "Sam";
                complexValidationSettingsObjectValid.LastName = "Smith";
                complexValidationSettingsObjectValid.ReferencedObject = complexValidationSettingsObjectInvalid2;
                complexValidationSettingsObjectValid.Save();
            }
        }

        private void CreateMiscellaneousValidationFeaturesObjects() {
            if(ObjectSpace.FindObject<MiscellaneousValidationFeaturesObject>(null) == null) {
                MiscellaneousValidationFeaturesObject miscellaneousValidationFeaturesObject = ObjectSpace.CreateObject<MiscellaneousValidationFeaturesObject>();
                miscellaneousValidationFeaturesObject.Name = "Invalid MiscellaneousValidationFeaturesObject";
                miscellaneousValidationFeaturesObject.PropertyWithDisplayNameAttribute = "";
                miscellaneousValidationFeaturesObject.PropertyWithLocalizedCaption = 3;
                miscellaneousValidationFeaturesObject.Save();

                MiscellaneousValidationFeaturesObject validMiscellaneousValidationFeaturesObject = ObjectSpace.CreateObject<MiscellaneousValidationFeaturesObject>();
                validMiscellaneousValidationFeaturesObject.Name = "Valid MiscellaneousValidationFeaturesObject";
                validMiscellaneousValidationFeaturesObject.PropertyWithDisplayNameAttribute = "Action execution is allowed";
                validMiscellaneousValidationFeaturesObject.PropertyWithLocalizedCaption = 10;
                validMiscellaneousValidationFeaturesObject.Save();
            }
        }

        private void CreateValidationErrorsAndWarningsFeatureObjects() {
            if(ObjectSpace.FindObject<ValidationErrorsAndWarningsFeatureObject>(null) == null) {
                var ruleObject = ObjectSpace.CreateObject<ValidationErrorsAndWarningsFeatureObject>();
                ruleObject.Name = "Rule with validation error";
                ruleObject.IsError = true;
                ruleObject.Save();

                ruleObject = ObjectSpace.CreateObject<ValidationErrorsAndWarningsFeatureObject>();
                ruleObject.Name = "Rule with validation warning";
                ruleObject.IsWarning = true;
                ruleObject.Save();

                ruleObject = ObjectSpace.CreateObject<ValidationErrorsAndWarningsFeatureObject>();
                ruleObject.Name = "Rule with validation information";
                ruleObject.IsInformation = true;
                ruleObject.Save();

                ruleObject = ObjectSpace.CreateObject<ValidationErrorsAndWarningsFeatureObject>();
                ruleObject.Name = "Rule with validation warning and information";
                ruleObject.IsInformation = true;
                ruleObject.IsWarning = true;
                ruleObject.Save();

                ruleObject = ObjectSpace.CreateObject<ValidationErrorsAndWarningsFeatureObject>();
                ruleObject.Name = "Rule with validation error and warning";
                ruleObject.IsError = true;
                ruleObject.IsWarning = true;
                ruleObject.Save();
            }
        }
        private void CreateClientSideValidationObjects() {
            if(ObjectSpace.FindObject<InplaceValidationObject>(null) == null) {
                InplaceValidationObject invalidClientSideValidationObject = ObjectSpace.CreateObject<InplaceValidationObject>();
                invalidClientSideValidationObject.Name = "Invalid object with client-side validation.";
                invalidClientSideValidationObject.RequiredStringProperty = "";
                invalidClientSideValidationObject.GreaterThanZero = -10;
                invalidClientSideValidationObject.StartsWithAbc = "Xyz Abc";
                invalidClientSideValidationObject.During2008 = new DateTime(2009, 1, 1);
                invalidClientSideValidationObject.Email = "This is not an email.@invalid.email";
                invalidClientSideValidationObject.Save();

                InplaceValidationObject validClientSideValidationObject = ObjectSpace.CreateObject<InplaceValidationObject>();
                validClientSideValidationObject.Name = "Valid object with client-side validation.";
                validClientSideValidationObject.RequiredStringProperty = "Non-empty string";
                validClientSideValidationObject.GreaterThanZero = 10;
                validClientSideValidationObject.StartsWithAbc = "Abc Xyz";
                validClientSideValidationObject.During2008 = new DateTime(2008, 1, 1);
                validClientSideValidationObject.Email = "support@devexpress.com";
                validClientSideValidationObject.RequiredReferencedProperty = invalidClientSideValidationObject;
                validClientSideValidationObject.Save();
            }
        }
        private void CreateSkinDemoObjects() {
            if(ObjectSpace.FindObject<SkinDemoObject>(null) == null) {
                SkinDemoObject skinDemoObject = ObjectSpace.CreateObject<SkinDemoObject>();
                skinDemoObject.Name = "This is a simple object";
                skinDemoObject.Save();
            }
        }

        private void CreateLocalizationDemoObjects() {
            if(ObjectSpace.FindObject<LocalizationObject>(null) == null) {
                LocalizationObject localizationObject1 = ObjectSpace.CreateObject<LocalizationObject>();
                localizationObject1.CurrencyProperty = 150.5m;
                localizationObject1.DecimalProperty = 2550320.25m;
                localizationObject1.EnumerationProperty = SimpleEnumeration.First;
                localizationObject1.DateTimeProperty = new DateTime(2008, 12, 31);
                localizationObject1.Save();

                LocalizationObject localizationObject2 = ObjectSpace.CreateObject<LocalizationObject>();
                localizationObject2.CurrencyProperty = 20.25m;
                localizationObject2.DecimalProperty = -0.5m;
                localizationObject2.EnumerationProperty = SimpleEnumeration.Second;
                localizationObject2.DateTimeProperty = new DateTime(2009, 1, 1);
                localizationObject2.Save();
            }
        }

        private void CreateCriteriaPropertiesObjects() {
            if(ObjectSpace.FindObject<CriteriaProperties>(null) == null) {
                CriteriaReferencedObject criteriaRefObject1 = ObjectSpace.CreateObject<CriteriaReferencedObject>();
                criteriaRefObject1.SetKey(1);
                criteriaRefObject1.Name = "Owner Object 1";
                CriteriaReferencedObject criteriaRefObject2 = ObjectSpace.CreateObject<CriteriaReferencedObject>();
                criteriaRefObject2.Name = "Owner Object 2";
                criteriaRefObject2.SetKey(2);
                CriteriaProperties criteriaProperties = ObjectSpace.CreateObject<CriteriaProperties>();
                criteriaProperties.Name = "Object 1";
                criteriaProperties.DataType = typeof(CriteriaObject);
                criteriaProperties.Criteria = "[EnumProperty] = 'High' And [Owner] = '@ObjectType:" + typeof(CriteriaReferencedObject).FullName + "@ObjectID:" + criteriaRefObject1.Key.ToString() + "'";
                criteriaProperties.CriteriaWithNestedProperties = "[EnumProperty] = 'High' And [Owner.Name] = '" + criteriaRefObject1.Name + "'   And [Collection][StartsWith([Name], 'A')].Count() = 4";
                criteriaProperties.CriteriaInPopupWindow = "[EnumProperty] = 'Low' And StartsWith([Owner.Name], 'K')";
            }
        }
        private void CreateSimplePropertiesAuditedObjects() {
            if(ObjectSpace.FindObject<SimplePropertiesAuditedObject>(null) == null) {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                AuditTrailService.Instance.BeginSessionAudit(session, AuditTrailStrategy.OnObjectChanged);
                SimplePropertiesAuditedObject auditedObject = ObjectSpace.CreateObject<SimplePropertiesAuditedObject>();
                auditedObject.Name = "Simple Properties Audited Object";
                auditedObject.BooleanProperty = true;
                auditedObject.DateTimeProperty = DateTime.Now;
                auditedObject.DecimalProperty = 100.99m;
                auditedObject.DoubleProperty = 3.14;
                auditedObject.EnumProperty = SampleEnum.First;
                auditedObject.IntegerProperty = 50;
                auditedObject.ObjectProperty = ObjectSpace.CreateObject<ReferencedAuditedObject>();
                auditedObject.ObjectProperty.Name = "Referenced Audited Object";
                auditedObject.StringProperty = "String value";
                auditedObject.ImageProperty = Image.FromStream(
                    GetType().Assembly.GetManifestResourceStream("FeatureCenter.Module.PropertyEditors.Resources.LargeImage1.png"));
                auditedObject.Save();
                ObjectSpace.CommitChanges();
                AuditTrailService.Instance.SaveAuditData(session);
                AuditTrailService.Instance.EndSessionAudit(session);
            }
        }
        private void CreateCollectionPropertiesAuditedObjects() {
            if(ObjectSpace.FindObject<CollectionPropertiesAuditedObject>(null) == null) {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                AuditTrailService.Instance.BeginSessionAudit(session, AuditTrailStrategy.OnObjectChanged);
                CollectionPropertiesAuditedObject auditedObject = ObjectSpace.CreateObject<CollectionPropertiesAuditedObject>();
                auditedObject.Name = "Collection Properties Audited Object";
                AggregatedAuditedObject aggregatedAuditedObject = ObjectSpace.CreateObject<AggregatedAuditedObject>();
                aggregatedAuditedObject.Name = "Aggregated item";
                auditedObject.AggregatedCollection.Add(aggregatedAuditedObject);
                AssociatedAuditedObject associatedAuditedObject = ObjectSpace.CreateObject<AssociatedAuditedObject>();
                associatedAuditedObject.Name = "Non-aggregated item";
                auditedObject.NonAggregatedCollection.Add(associatedAuditedObject);
                auditedObject.Save();
                ObjectSpace.CommitChanges();
                AuditTrailService.Instance.SaveAuditData(session);
                AuditTrailService.Instance.EndSessionAudit(session);
            }
        }
        private void CreateAuditSettingsObjects() {
            if(ObjectSpace.FindObject<AuditSettingsObject>(null) == null) {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                AuditTrailService.Instance.BeginSessionAudit(session, AuditTrailStrategy.OnObjectChanged);
                AuditSettingsObject auditSettingsObject = ObjectSpace.CreateObject<AuditSettingsObject>();
                auditSettingsObject.Name = "Audit Settings Object";
                auditSettingsObject.AuditedProperty = "Changes of this property will be audited";
                auditSettingsObject.NonAuditedProperty = "Changes of this property won't be audited";
                auditSettingsObject.Save();
                ObjectSpace.CommitChanges();
                AuditTrailService.Instance.SaveAuditData(session);
                AuditTrailService.Instance.EndSessionAudit(session);
            }
        }
        private void CreateAuditObjectAuditingModesObjects() {
            if(ObjectSpace.FindObject<ObjectAuditingModesObject>(null) == null) {
                Session session = ((XPObjectSpace)ObjectSpace).Session;
                AuditTrailService.Instance.BeginSessionAudit(session, AuditTrailStrategy.OnObjectChanged);
                ObjectAuditingModesObject objectAuditingModesObject = ObjectSpace.CreateObject<ObjectAuditingModesObject>();
                objectAuditingModesObject.Name = "Object Auditing Modes Object";
                objectAuditingModesObject.AuditedProperty1 = "Audited property";
                objectAuditingModesObject.AuditedProperty2 = new DateTime(2010, 1, 1);
                objectAuditingModesObject.Save();
                ObjectSpace.CommitChanges();
                AuditTrailService.Instance.SaveAuditData(session);
                AuditTrailService.Instance.EndSessionAudit(session);
            }
        }
        private void CustomPropertyEditorsObjects() {
            if(ObjectSpace.FindObject<CustomPropertyEditorsObject>(null) == null) {
                CustomPropertyEditorsObject customPropertyEditorsObject = ObjectSpace.CreateObject<CustomPropertyEditorsObject>();
                customPropertyEditorsObject.DateTimeProperty = DateTime.Now;
                customPropertyEditorsObject.StringProperty = "Irish (Ireland)(ga-IE)";
                customPropertyEditorsObject.IntegerProperty = 4;
                customPropertyEditorsObject.Name = "Object 1";
                customPropertyEditorsObject.Save();
            }
        }
        private void CreateMapsListEditorsData() {
            if(ObjectSpace.FindObject<VectorMapsListEditorDemoObject>(null) == null) {
                VectorMapsListEditorDemoObject montana = ObjectSpace.CreateObject<VectorMapsListEditorDemoObject>();
                montana.Title = "Montana";

                VectorMapsListEditorDemoObject colorado = ObjectSpace.CreateObject<VectorMapsListEditorDemoObject>();
                colorado.Title = "Colorado";

                VectorMapsListEditorDemoObject nevada = ObjectSpace.CreateObject<VectorMapsListEditorDemoObject>();
                nevada.Title = "Nevada";

                VectorMapsListEditorDemoObject texas = ObjectSpace.CreateObject<VectorMapsListEditorDemoObject>();
                texas.Title = "Texas";

                VectorMapsListEditorDemoObject washington = ObjectSpace.CreateObject<VectorMapsListEditorDemoObject>();
                washington.Title = "Washington";

                MapsListEditorDemoObject coloradoStore1 = ObjectSpace.CreateObject<MapsListEditorDemoObject>();
                coloradoStore1.Title = "Colorado Store 1";
                coloradoStore1.USAState = colorado;
                coloradoStore1.Latitude = 38.7;
                coloradoStore1.Longitude = -105.886389;

                MapsListEditorDemoObject coloradoStore2 = ObjectSpace.CreateObject<MapsListEditorDemoObject>();
                coloradoStore2.Title = "Colorado Store 2";
                coloradoStore2.USAState = colorado;
                coloradoStore2.Latitude = 39.1;
                coloradoStore2.Longitude = -103.777;

                MapsListEditorDemoObject montanaStore1 = ObjectSpace.CreateObject<MapsListEditorDemoObject>();
                montanaStore1.Title = "Montana Store 1";
                montanaStore1.USAState = montana;
                montanaStore1.Latitude = 46.76;
                montanaStore1.Longitude = -107.886389;

                MapsListEditorDemoObject texasStore1 = ObjectSpace.CreateObject<MapsListEditorDemoObject>();
                texasStore1.Title = "Texas Store 1";
                texasStore1.USAState = texas;
                texasStore1.Latitude = 30.3;
                texasStore1.Longitude = -97.7;

                MapsListEditorDemoObject texasStore2 = ObjectSpace.CreateObject<MapsListEditorDemoObject>();
                texasStore2.Title = "Texas Store 2";
                texasStore2.USAState = texas;
                texasStore2.Latitude = 30.9;
                texasStore2.Longitude = -97.3;

                MapsListEditorDemoObject texasStore3 = ObjectSpace.CreateObject<MapsListEditorDemoObject>();
                texasStore3.Title = "Texas Store 3";
                texasStore3.USAState = texas;
                texasStore3.Latitude = 30.9;
                texasStore3.Longitude = -98.3;

                MapsListEditorDemoObject washingtonStore1 = ObjectSpace.CreateObject<MapsListEditorDemoObject>();
                washingtonStore1.Title = "Washington Store 1";
                washingtonStore1.USAState = washington;
                washingtonStore1.Latitude = 47.6;
                washingtonStore1.Longitude = -122.3;

                MapsListEditorDemoObject nevadaStore1 = ObjectSpace.CreateObject<MapsListEditorDemoObject>();
                nevadaStore1.Title = "Nevada Store 1";
                nevadaStore1.USAState = nevada;
                nevadaStore1.Latitude = 39.15;
                nevadaStore1.Longitude = -119.7;


                VectorMapsListEditorPieMarker parisPie = ObjectSpace.CreateObject<VectorMapsListEditorPieMarker>();
                parisPie.Title = "Paris";
                parisPie.CategoryAPercentage = 30;
                parisPie.CategoryBPercentage = 20;
                parisPie.CategoryCPercentage = 50;
                parisPie.Latitude = 48.83;
                parisPie.Longitude = 2.34;

                VectorMapsListEditorPieMarker londonPie = ObjectSpace.CreateObject<VectorMapsListEditorPieMarker>();
                londonPie.Title = "London";
                londonPie.CategoryAPercentage = 70;
                londonPie.CategoryBPercentage = 20;
                londonPie.CategoryCPercentage = 10;
                londonPie.Latitude = 51.5;
                londonPie.Longitude = -0.1;

                VectorMapsListEditorPieMarker romePie = ObjectSpace.CreateObject<VectorMapsListEditorPieMarker>();
                romePie.Title = "Rome";
                romePie.CategoryAPercentage = 50;
                romePie.CategoryBPercentage = 1;
                romePie.CategoryCPercentage = 49;
                romePie.Latitude = 41.9;
                romePie.Longitude = 12.5;

                VectorMapsListEditorPieMarker praguePie = ObjectSpace.CreateObject<VectorMapsListEditorPieMarker>();
                praguePie.Title = "Prague";
                praguePie.CategoryAPercentage = 10;
                praguePie.CategoryBPercentage = 45;
                praguePie.CategoryCPercentage = 45;
                praguePie.Latitude = 50.8;
                praguePie.Longitude = 14.5;

                VectorMapsListEditorPieMarker warsawPie = ObjectSpace.CreateObject<VectorMapsListEditorPieMarker>();
                warsawPie.Title = "Warsaw";
                warsawPie.CategoryAPercentage = 19;
                warsawPie.CategoryBPercentage = 62;
                warsawPie.CategoryCPercentage = 19;
                warsawPie.Latitude = 52.25;
                warsawPie.Longitude = 21.15;

                VectorMapsListEditorPieMarker madridPie = ObjectSpace.CreateObject<VectorMapsListEditorPieMarker>();
                madridPie.Title = "Madrid";
                madridPie.CategoryAPercentage = 40;
                madridPie.CategoryBPercentage = 35;
                madridPie.CategoryCPercentage = 25;
                madridPie.Latitude = 40.38;
                madridPie.Longitude = -3.6;
            }
        }
        private void CreateMapsPropertyEditorsData() {
            if(ObjectSpace.FindObject<MapsPropertyEditorDemoObject>(null) == null) {
                MapsPropertyEditorDemoObject officeInParis = ObjectSpace.CreateObject<MapsPropertyEditorDemoObject>();
                officeInParis.Title = "Office in Paris";
                officeInParis.Address.Title = "Paris";
                officeInParis.Address.Latitude = 48.83;
                officeInParis.Address.Longitude = 2.34;

                MapsPropertyEditorDemoObject officeInLondon = ObjectSpace.CreateObject<MapsPropertyEditorDemoObject>();
                officeInLondon.Title = "Office in London";
                officeInLondon.Address.Title = "London";
                officeInLondon.Address.Latitude = 51.5;
                officeInLondon.Address.Longitude = -0.1;

                MapsPropertyEditorDemoObject officeInRome = ObjectSpace.CreateObject<MapsPropertyEditorDemoObject>();
                officeInRome.Title = "Office in Rome";
                officeInRome.Address.Title = "Rome";
                officeInRome.Address.Latitude = 41.9;
                officeInRome.Address.Longitude = 12.5;
            }
        }
        private void CreateWebMasterDetailData() {
            if(ObjectSpace.FindObject<MasterObject>(null) == null) {
                MasterObject john = ObjectSpace.CreateObject<MasterObject>();
                john.FirstName = "John";
                john.LastName = "Smith";
                john.Email = "john_smith@md.com";
                john.Position = "CEO";
                john.PhoneNumber = "999-999-888";
                john.Birthday = new DateTime(1970, 1, 1);
                john.HiredDate = new DateTime(2010, 1, 1);

                DetailObject johnTask1 = ObjectSpace.CreateObject<DetailObject>();
                johnTask1.Title = "John's first task";
                johnTask1.Comment = "Some comment";
                johnTask1.BeginDateTime = new DateTime(2010, 1, 1);
                johnTask1.EndDateTime = new DateTime(2015, 1, 1);

                DetailObject johnTask2 = ObjectSpace.CreateObject<DetailObject>();
                johnTask2.Title = "John's second task";
                johnTask2.Comment = "Some comment";
                johnTask2.BeginDateTime = new DateTime(2013, 1, 1);
                johnTask2.EndDateTime = new DateTime(2014, 10, 1);

                john.DetailObjects.Add(johnTask1);
                john.DetailObjects.Add(johnTask2);

                MasterObject mary = ObjectSpace.CreateObject<MasterObject>();
                mary.FirstName = "Mary";
                mary.LastName = "Tellitson";
                mary.Email = "mary_tellitson@md.com";
                mary.Position = "Manager";
                mary.PhoneNumber = "999-999-999";
                mary.Birthday = new DateTime(1980, 1, 1);
                mary.HiredDate = new DateTime(2012, 1, 1);

                DetailObject maryTask1 = ObjectSpace.CreateObject<DetailObject>();
                maryTask1.Title = "Mary's first task";
                maryTask1.Comment = "Some comment";
                maryTask1.BeginDateTime = new DateTime(2012, 2, 1);
                maryTask1.EndDateTime = new DateTime(2013, 1, 1);

                DetailObject maryTask2 = ObjectSpace.CreateObject<DetailObject>();
                maryTask2.Title = "Mary's second task";
                maryTask2.Comment = "Some comment";
                maryTask2.BeginDateTime = new DateTime(2013, 1, 1);
                maryTask2.EndDateTime = new DateTime(2013, 9, 5);

                DetailObject maryTask3 = ObjectSpace.CreateObject<DetailObject>();
                maryTask3.Title = "Mary's third task";
                maryTask3.Comment = "Some comment";
                maryTask3.BeginDateTime = new DateTime(2014, 1, 1);
                maryTask3.EndDateTime = new DateTime(2015, 7, 3);

                mary.DetailObjects.Add(maryTask1);
                mary.DetailObjects.Add(maryTask2);
                mary.DetailObjects.Add(maryTask3);

                MasterObject john2 = ObjectSpace.CreateObject<MasterObject>();
                john2.FirstName = "Peter";
                john2.LastName = "Nilsen";
                john2.Email = "peter_nilsen@md.com";
                john2.Position = "Manager";
                john2.PhoneNumber = "999-999-666";
                john2.Birthday = new DateTime(1981, 10, 3);
                john2.HiredDate = new DateTime(2015, 1, 1);
            }
        }
        private void InitializeDashboards() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            DashboardsModule.AddDashboardDataFromResources<DevExpress.Persistent.BaseImpl.DashboardData>(ObjectSpace, "Sales Overview", assembly, "FeatureCenter.Module.Dashboards.SalesOverview.xml");
        }
    }
}
