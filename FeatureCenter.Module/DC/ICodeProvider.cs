using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using FeatureCenter.Module.PropertyEditors;

namespace FeatureCenter.Module.DC {
    [DomainComponent]
    [NonPersistentDc]
    public interface ICodeProvider {
        [EditorAlias(FeatureCenterEditorAliases.CSCodePropertyEditor)]
        string Code { get; }
        [Browsable(false)]
        string ResourceName { get; }
    }
    [DomainLogic(typeof(ICodeProvider))]
    public class ICodeProvider_Logic {
        private static Assembly currentAssembly;
        private static string[] resources;
        private static bool TryGetResourceStream(string resourceName, out Stream resourceStream) {
            foreach(string item in resources) {
                if(item.Contains(resourceName)) {
                    resourceStream = currentAssembly.GetManifestResourceStream(item);
                    return true;
                }
            }
            resourceStream = null;
            return false;
        }
        static ICodeProvider_Logic() {
            currentAssembly = typeof(ICodeProvider).Assembly;
            resources = currentAssembly.GetManifestResourceNames();
        }
        public static string Get_Code(ICodeProvider obj) {
            Stream resourceStream;
            if(TryGetResourceStream(obj.ResourceName, out resourceStream)) {
                using(StreamReader reader = new StreamReader(resourceStream, Encoding.UTF8)) {
                    return reader.ReadToEnd();
                }
            }
            return null;
        }
    }

    [NavigationItem(Captions.DCGroup)]
    [AutoCreatableObject(ViewEditMode = ViewEditMode.View)]
    [Hint(Hints.DCPersistentPropertiesHint, ViewType.DetailView)]
    [ImageName("DC.PersistentProperties")]
    [DomainComponent]
    public interface IPersistentPropertiesPresenter : ICodeProvider {
        [EditorAlias(EditorAliases.DetailPropertyEditor)]
        IContact Contact { get; set; }
    }
    [DomainLogic(typeof(IPersistentPropertiesPresenter))]
    public class IPersistentProperties_Logic {
        public static string ResourceName { get { return "PersistentProperties.cs"; } }
    }

    [NavigationItem(Captions.DCGroup)]
    [AutoCreatableObject(ViewEditMode = ViewEditMode.View)]
    [Hint(Hints.DCAssociationsHint, ViewType.DetailView)]
    [ImageName("DC.Associations")]
    [DomainComponent]
    public interface IAssociationsPresenter : ICodeProvider {
        [EditorAlias(EditorAliases.DetailPropertyEditor)]
        ICompany Company { get; set; }
    }
    [DomainLogic(typeof(IAssociationsPresenter))]
    public class IAssociationsPresenter_Logic {
        public static string ResourceName { get { return "Associations.cs"; } }
    }

    [NavigationItem(Captions.DCGroup)]
    [AutoCreatableObject(ViewEditMode = ViewEditMode.View)]
    [Hint(Hints.DCMultipleInheritanceHint, ViewType.DetailView)]
    [ImageName("DC.MultipleInheritance")]
    [DomainComponent]
    public interface IMultipleInheritancePresenter : ICodeProvider {
        [NonPersistentDc]
        IList<IManager> Managers { get; }
        [NonPersistentDc]
        IList<IEvangelist> Evangelists { get; }
        [NonPersistentDc]
        IList<IOfficeManager> OfficeManagers { get; }
        [NonPersistentDc]
        IList<IProductManager> ProductManagers { get; }
    }
    [DomainLogic(typeof(IMultipleInheritancePresenter))]
    public class IMultipleInheritancePresenter_Logic {
        public static string ResourceName { get { return "MultipleInheritance.cs"; } }
        public static IList<IManager> Get_Managers(IMultipleInheritancePresenter presenter, IObjectSpace objectSpace) {
            return objectSpace.GetObjects<IManager>();
        }
        public static IList<IEvangelist> Get_Evangelists(IMultipleInheritancePresenter presenter, IObjectSpace objectSpace) {
            return objectSpace.GetObjects<IEvangelist>();
        }
        public static IList<IOfficeManager> Get_OfficeManagers(IMultipleInheritancePresenter presenter, IObjectSpace objectSpace) {
            return objectSpace.GetObjects<IOfficeManager>();
        }
        public static IList<IProductManager> Get_ProductManagers(IMultipleInheritancePresenter presenter, IObjectSpace objectSpace) {
            return objectSpace.GetObjects<IProductManager>();
        }
    }

    [NavigationItem(Captions.DCGroup)]
    [AutoCreatableObject(ViewEditMode = ViewEditMode.Edit)]
    [Hint(Hints.DCDomainLogicForPropertiesHint, ViewType.DetailView)]
    [ImageName("DC.DomainLogicForProperties")]
    [DomainComponent]
    public interface IDomainLogicForPropertiesPresenter : ICodeProvider {
        [EditorAlias(EditorAliases.DetailPropertyEditor)]
        IProduct Product { get; set; }
    }
    [DomainLogic(typeof(IDomainLogicForPropertiesPresenter))]
    public class IDomainLogicForPropertiesPresenter_Logic {
        public static string ResourceName { get { return "DomainLogicForProperties.cs"; } }
    }

    [NavigationItem(Captions.DCGroup)]
    [AutoCreatableObject(ViewEditMode = ViewEditMode.Edit)]
    [Hint(Hints.DCDomainLogicForMethodsHint, ViewType.DetailView)]
    [ImageName("DC.DomainLogicForMethods")]
    [DomainComponent]
    public interface IDomainLogicForMethodsPresenter : ICodeProvider {
        [EditorAlias(EditorAliases.DetailPropertyEditor)]
        ITask Task { get; set; }
    }
    [DomainLogic(typeof(IDomainLogicForMethodsPresenter))]
    public class IDomainLogicForMethodsPresenter_Logic {
        public static string ResourceName { get { return "DomainLogicForMethods.cs"; } }
    }

    [NavigationItem(Captions.DCGroup)]
    [AutoCreatableObject(ViewEditMode = ViewEditMode.Edit)]
    [Hint(Hints.DCDomainLogicInheritanceHint, ViewType.DetailView)]
    [ImageName("DC.DomainLogicInheritance")]
    [DomainComponent]
    public interface IDomainLogicInheritancePresenter : ICodeProvider {
        [EditorAlias(EditorAliases.DetailPropertyEditor)]
        IPerson Person { get; set; }
        [EditorAlias(EditorAliases.DetailPropertyEditor)]
        IClient Client { get; set; }
    }
    [DomainLogic(typeof(IDomainLogicInheritancePresenter))]
    public class IDomainLogicInheritancePresenter_Logic {
        public static string ResourceName { get { return "DomainLogicInheritance.cs"; } }
    }
}
