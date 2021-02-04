using Aura.UI.Controls.Ribbon;

namespace Aura.UI.UIExtensions
{
    public static class RibbonExtensions
    {
        public static void OpenRibbonRoot(this RibbonItem ribbonItem)
        {
            var ribbonroot = ribbonItem.GetParentTOfLogical<Ribbon>();
            ribbonroot.ExpansionState = ExpansionState.Total;
        }

        public static void CloseRibbonRoot(this RibbonItem ribbonItem)
        {
            var ribbonroot = ribbonItem.GetParentTOfLogical<Ribbon>();
            ribbonroot.ExpansionState = ExpansionState.Hidden;
        }

        public static void ToggleRibbonRootState(this RibbonItem ribbonItem)
        {
            var e_ = ribbonItem.GetParentTOfLogical<Ribbon>().ExpansionState;
            switch (e_)
            {
                case ExpansionState.Hidden:
                    ribbonItem.OpenRibbonRoot();
                    break;

                case ExpansionState.Total:
                    ribbonItem.CloseRibbonRoot();
                    break;
            }
        }
    }
}