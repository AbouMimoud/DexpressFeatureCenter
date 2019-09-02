using System;

using DevExpress.ExpressApp.Win.SystemModule;
using FeatureCenter.Module.Skins;
using DevExpress.ExpressApp.Model;

namespace TestSolution.Module.Win
{
    public partial class SkinsWindowController : SkinsWindowControllerBase<ChooseSkinController>
    {
        protected override string SkinsGroupCaption {
            get { return "Skins"; }
        }
        protected override string ChooseSkinActionId {
            get { return "ChooseSkin"; }
        }
        //public override void UpdateModel(IModelApplication applicationModel) {
        //    base.UpdateModel(applicationModel);
        //    string diffs = @"
        //        <Application>
        //            <Options Skin=""Black"" />
        //        </Application>";
        //    new ModelXmlReader().ReadFromString(applicationModel, string.Empty, diffs);
        //}
    }
}
