namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DoesNotMatchAnything<T> : Criteria<T>
    {
        public bool matches(T item)
        {
            return false;
        }
    }
}