using System;

namespace Kasbah.Redux
{
    public class ActionEventArgs : EventArgs
    {
        #region Public Properties

        public Action Action { get; set; }

        public dynamic CurrentState { get; set; }

        #endregion
    }
}