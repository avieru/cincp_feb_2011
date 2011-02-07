namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NotCriteria<T> : Criteria<T>
    {
        Criteria<T> to_negate;

        public NotCriteria(Criteria<T> to_negate)
        {
            this.to_negate = to_negate;
        }

        public bool matches(T item)
        {
            return ! to_negate.matches(item);
        }
    }
}