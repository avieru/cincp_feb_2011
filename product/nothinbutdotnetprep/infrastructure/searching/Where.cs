namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        public static DefaultFilteringExtensionPoint<ItemToFilter, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            return new DefaultFilteringExtensionPoint<ItemToFilter, PropertyType>(accessor);
        }
    }
}