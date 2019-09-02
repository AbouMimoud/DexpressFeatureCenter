using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.ComponentModel;
using DevExpress.Xpo;

namespace FeatureCenter.Module.ListEditors {
    [ImageName("ListEditors.Demo_ListEditors_VectorMaps_Area")]
    [DefaultProperty("Title")]
    [NavigationItem(false)]
    public class VectorMapsListEditorDemoObject : BaseObject, IAreaInfo {
        public VectorMapsListEditorDemoObject(Session session) : base(session) { }
        public string Title { get; set; }

        [Association("USAState-Stores"), Aggregated]
        public XPCollection<MapsListEditorDemoObject> Stores {
            get { return GetCollection<MapsListEditorDemoObject>("Stores"); }
        }
        string IAreaInfo.Tooltip {
            get {
                string tooltipStr = Title;
                int storesCount = Stores.Count;
                if(storesCount > 0) {
                    tooltipStr += string.Format("<br> {0} store{1}", storesCount, storesCount == 1 ? "" : "s");
                }
                return tooltipStr;
            }
        }
        float IAreaInfo.Value {
            get {
                return Stores.Count;
            }
        }
    }

    [ImageName("ListEditors.Demo_ListEditors_VectorMaps_Pie")]
    [DefaultProperty("Title")]
    [NavigationItem(false)]
    public class VectorMapsListEditorPieMarker : BaseObject, IVectorMapsPieMarker {
        public VectorMapsListEditorPieMarker(Session session) : base(session) { }
        public string Title { get; set; }
        [Browsable(false)]
        public string Tooltip {
            get {
                string valuesStr = "";
                string[] captions = { "Category A", "Category B", "Category C" };
                float[] values = { CategoryAPercentage, CategoryBPercentage, CategoryCPercentage };
                int index = 0;
                foreach(float value in values) {
                    if(index != 0)
                        valuesStr += "<br>";
                    if(index >= captions.Length)
                        index = captions.Length - 1;
                    valuesStr += string.Format("{0}: {1}%", captions[index++], value);
                }
                return string.Format("<b>{0}</b><br>{1}", Title, valuesStr);
            }
        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [Browsable(false)]
        public IList<float> Values {
            get {
                return new List<float> { CategoryAPercentage, CategoryBPercentage, CategoryCPercentage };
            }
        }
        [DevExpress.Xpo.DisplayName("Category A percentage")]
        public float CategoryAPercentage { get; set; }
        [DevExpress.Xpo.DisplayName("Category B percentage")]
        public float CategoryBPercentage { get; set; }
        [DevExpress.Xpo.DisplayName("Category C percentage")]
        public float CategoryCPercentage { get; set; }
    }
}
