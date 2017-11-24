﻿namespace Aimtec.SDK.Util
{
    using System;

    using Aimtec.SDK.Menu;
    using Aimtec.SDK.Menu.Components;

    public class Hacks
    {
        #region Public Properties

        public static bool EnableDrawing
        {
            get => Feature.Drawing;
            set => Feature.Drawing = value;
        }

        #endregion

        #region Methods

        internal static void Init(Menu root)
        {
            var menu = new Menu("Aimtec.Menu.Hacks", "Hacks");

            var enableDrawing = new MenuKeyBind("EnableDrawing", "Enable Drawing", KeyCode.F11, KeybindType.Toggle, shared: false);
            enableDrawing.SetToolTip("Disables ALL drawings untill the Re-enable key is pressed.");
            enableDrawing.OnValueChanged += (sender, args) => EnableDrawing = args.GetNewValue<MenuKeyBind>().Value;

            // Loads value from config
            menu.Add(enableDrawing);

            root.Add(menu);

            // Sets drawings from config
            EnableDrawing = enableDrawing.Value;
        }

        #endregion
    }
}
