using Aura.UI.Services;
using Avalonia;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Primitives
{
    public partial class ContentDialogBase : ContentControl
    {
        public void SetOwner(WindowBase owner)
        {
            if(owner == null)
            {
                throw new ArgumentNullException("The Owner can't be null.");
            }

            this.Owner = owner;
        }

        public void Show()
        {
            ContentDialogService.ShowDialogOn(Owner, this);
        }


        public void Close()
        {
            ContentDialogService.CloseDialogOn(Owner, this);
        }
        private WindowBase Owner
        {
            get;
            set;
        }
    }
}
