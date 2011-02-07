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
    }
}