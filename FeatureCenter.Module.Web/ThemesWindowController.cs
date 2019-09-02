using System;

using FeatureCenter.Module.Skins;
using DevExpress.ExpressApp.Web.SystemModule;
using DevExpress.ExpressApp.Actions;
using System.Collections.Generic;

namespace FeatureCenter.Module.Web
{
    public partial class ThemesWindowController : SkinsWindowControllerBase<ChooseThemeController> {
        protected override string SkinsGroupCaption {
            get { return "Themes"; }
        }
        protected override string ChooseSkinActionId {
            get { return "ChooseTheme"; }
        }
    }
}
