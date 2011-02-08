using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ExclusiveRangeWithNoUpperbound<T> : Range<T> where T : IComparable<T>
    {
        T start;

        public ExclusiveRangeWithNoUpperbound(T start)
        {
            this.start = start;
        }

        public bool contains(T value)
        {
            return value.CompareTo(start) > 0;
        }
    }
}