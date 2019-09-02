using DevExpress.ExpressApp.Demos;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using FeatureCenter.Module.Navigation;

namespace FeatureCenter.Module.Web.Layout {
    public enum LayoutItemTemplateType { Default, Custom }
    [AutoCreatableObject]
    [NavigationItem(Captions.LayoutGroup)]
    [ImageName("Demo_Layout_ItemTemplates")]
    [Hint(Hints.LayoutDemoItemTemplatesHint, DevExpress.ExpressApp.ViewType.Any)]
    public class ItemTemplates : NamedBaseObject {
        private LayoutItemTemplateType layoutItemTemplate = LayoutItemTemplateType.Default;
        private LayoutItemTemplateType layoutGroupTemplate = LayoutItemTemplateType.Default;
        private LayoutItemTemplateType tabbedGroupTemplate = LayoutItemTemplateType.Default;
        private string layoutItem1;
        private string layoutItem2;
        public ItemTemplates(Session session) : base(session) { }
        [ImmediatePostData]
        public LayoutItemTemplateType LayoutItemTemplate {
            get { return layoutItemTemplate; }
            set { SetPropertyValue<LayoutItemTemplateType>("LayoutItemTemplate", ref layoutItemTemplate, value); }
        }
        [ImmediatePostData]
        public LayoutItemTemplateType LayoutGroupTemplate {
            get { return layoutGroupTemplate; }
            set { SetPropertyValue<LayoutItemTemplateType>("LayoutGroupTemplate", ref layoutGroupTemplate, value); }
        }
        [ImmediatePostData]
        public LayoutItemTemplateType TabbedGroupTemplate {
            get { return tabbedGroupTemplate; }
            set { SetPropertyValue<LayoutItemTemplateType>("TabbedGroupTemplate", ref tabbedGroupTemplate, value); }
        }
        public string LayoutItem1 {
            get { return layoutItem1; }
            set { SetPropertyValue<string>("LayoutItem1", ref layoutItem1, value); }
        }
        public string LayoutItem2 {
            get { return layoutItem2; }
            set { SetPropertyValue<string>("LayoutItem2", ref layoutItem2, value); }
        }
    }
}
