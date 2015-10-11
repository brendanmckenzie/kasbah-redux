using System;
using System.Dynamic;

namespace Kasbah.Redux
{
    public class Store
    {
        #region Public Constructors

        public Store(Func<Action, dynamic, dynamic> reducer)
        {
            _reducer = reducer;
        }

        #endregion

        #region Public Events

        public event EventHandler<ActionEventArgs> AfterDispatch;

        public event EventHandler<ActionEventArgs> BeforeDispatch;

        #endregion

        #region Public Properties

        public dynamic State { get { return _state; } }

        #endregion

        #region Public Methods

        public void Dispatch(Action action)
        {
            BeforeDispatch?.Invoke(this, new ActionEventArgs { Action = action, CurrentState = _state });

            dynamic state = (_state ?? new ExpandoObject()).Clone();

            state = _reducer(action, state);

            _state = state;

            AfterDispatch?.Invoke(this, new ActionEventArgs { Action = action, CurrentState = _state });
        }

        #endregion

        #region Private Fields

        readonly Func<Action, dynamic, dynamic> _reducer;
        dynamic _state = null;

        #endregion
    }
}