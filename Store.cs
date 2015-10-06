using System;
using System.Dynamic;
using System.Collections.Generic;

namespace Kasbah.Redux
{
    public struct Action
    {
        public string Type { get; set; }

        public dynamic Data { get; set; }
    }

    public class Store
    {
        dynamic _state = null;

        readonly Func<Action, dynamic, dynamic> _reducer;

        public dynamic State { get { return _state; } }

        public Store(Func<Action, dynamic, dynamic> reducer)
        {
            _reducer = reducer;
        }

        public void Dispatch(Action action)
        {
            dynamic state = (_state ?? new ExpandoObject()).Clone();

            state = _reducer(action, state);

            _state = state;
        }
    }
}
