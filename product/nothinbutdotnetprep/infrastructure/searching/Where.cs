namespace nothinbutdotnetprep.infrastructure.searching
{
    public delegate PropertyType PropertyAccessor<ItemToFilter, PropertyType>(ItemToFilter item);


    public class Where<ItemToFilter>
    {
        public static PropertyAccessor<ItemToFilter, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            return accessor;
        }
    }

}