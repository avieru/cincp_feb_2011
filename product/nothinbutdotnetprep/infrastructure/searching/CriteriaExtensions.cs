using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class CriteriaExtensions
    {
        public static Criteria<T> or<T>(this Criteria<T> left_side, Criteria<T> right_side)
        {
            return new OrCriteria<T>(left_side, right_side);
        }

        public static Criteria<T> not<T>(this Criteria<T> to_negate)
        {
            return new NotCriteria<T>(to_negate);
        }

        public static Criteria<T> and<T>(this Criteria<T> left_side, Criteria<T> right_side)
        {
            return new AndCriteria<T>(left_side, right_side);
        }
    }

    public class AndCriteria<T> : Criteria<T>
    {
        Criteria<T> left_side;
        Criteria<T> right_side;

        public AndCriteria(Criteria<T> left_side, Criteria<T> right_side)
        {
            this.left_side = left_side;
            this.right_side = right_side;
        }

        public bool matches(T item)
        {
            return left_side.matches(item) && right_side.matches(item);
        }
    }
}