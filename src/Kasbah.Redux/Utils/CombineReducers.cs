using System;
using System.Collections.Generic;

namespace Kasbah.Redux.Utils
{
    public static class CombineReducers
    {
        #region Public Methods

        public static Func<Action, dynamic, dynamic> Combine(IEnumerable<Func<Action, dynamic, dynamic>> reducers)
        {
            Func<Action, dynamic, dynamic> func = (input, state) =>
           {
               var ret = state;

               foreach (var reducer in reducers)
               {
                   ret = reducer(input, ret);
               }

               return ret;
           };

            return func;
        }

        #endregion
    }
}