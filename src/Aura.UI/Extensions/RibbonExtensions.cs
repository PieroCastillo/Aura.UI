using Aura.UI.Controls.Ribbon;

namespace Aura.UI.Extensions
{
    public static class RibbonExtensions
    {
        public static void OpenRibbonRoot(this RibbonItem ribbonItem)
        {
            var ribbonroot = ribbonItem.GetParentTOfLogical<Ribbon>();
            
            if(ribbonroot == null)
                return;
            
            ribbonroot.ExpansionState = ExpansionState.Total;
        }

        public static void CloseRibbonRoot(this RibbonItem ribbonItem)
        {
            var ribbonroot = ribbonItem.GetParentTOfLogical<Ribbon>();
            if(ribbonroot == null)
                return;
            ribbonroot.ExpansionState = ExpansionState.Hidden;
        }

        public static void ToggleRibbonRootState(this RibbonItem ribbonItem)
        {

            var item = ribbonItem.GetParentTOfLogical<Ribbon>();
            if (item == null)
                return;
            
            var e_ = item.ExpansionState;
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