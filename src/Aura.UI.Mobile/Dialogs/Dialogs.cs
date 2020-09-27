using Aura.UI.Mobile.Cupertino;
using Aura.UI.Mobile.Material;
using Aura.UI.Mobile.Primitives;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Aura.UI.Mobile.Dialogs
{

    public struct DialogParameters
    {
        public DialogParameters(object header, object content, object agreebuttoncontent, Action agreeclick)
        {
            Header = header;
            Content = content;
            AgreeContentButton = agreebuttoncontent;
            AgreeClick = agreeclick;
        }
        public object Header { get; set; }
        public object Content { get; set; }
        public object AgreeContentButton { get; set; }

        public Action AgreeClick { get; set; }
    }
    public struct AlertDialogParameters
    {
        public AlertDialogParameters(DialogParameters dialogParameters, object cancelcontentbutton,Action cancelclick, bool isemergency)
        {
            Header = dialogParameters.Header;
            Content = dialogParameters.Content;
            AgreeContentButton = dialogParameters.AgreeContentButton;
            CancelContentButton = cancelcontentbutton;
            IsEmergency = isemergency;
            AgreeClick = dialogParameters.AgreeClick;
            CancelClick = cancelclick;
        }

        public object Header { get; set; }
        public object Content { get; set; }
        public object AgreeContentButton { get; set; }
        public object CancelContentButton { get; set; }
        public bool IsEmergency { get; set; }
        public Action AgreeClick { get; set; }
        public Action CancelClick { get; set; }
    }

    public enum DialogType
    {
        Dialog, AlertDialog
    }
}
