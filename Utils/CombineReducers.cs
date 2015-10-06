namespace Kasbah.Redux.Utils
{
    public static class CombineReducers
    {
        public static Func<Action, dynamic, dynamic> Combine(IEnumerable<Func<Action, dynamic, dynamic>> reducers)
        {
            return new Func<Action, dynamic, dynamic>((input, state) =>
            {
                var ret = state;

                foreach (var reducer in reducers)
                {
                    ret = reducer(input, ret);
                }

                return ret;
            });
        }
    }
}
