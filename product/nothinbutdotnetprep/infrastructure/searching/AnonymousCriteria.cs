namespace nothinbutdotnetprep.infrastructure.searching
{
    public class AnonymousCriteria<T> : Criteria<T>
    {
        Condition<T> condition;

        public AnonymousCriteria(Condition<T> condition)
        {
            this.condition = condition;
        }

        public bool matches(T item)
        {
            return condition(item);
        }
    }
}