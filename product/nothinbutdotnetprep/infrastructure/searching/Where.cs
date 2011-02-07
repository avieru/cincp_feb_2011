using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<T>
    {
        public Criteria<T> has_a(Condition<T> condition)
        {
            return new AnonymousCriteria<T>(condition);
        }
    }

    public delegate object GetProperty()

    public static class CriteriaExtentions
    {
        public static Criteria<T> equal_to<T>(object o)
        {
            return null;
        }
    }
}
