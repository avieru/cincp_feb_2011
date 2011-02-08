namespace nothinbutdotnetprep.infrastructure.searching
{
    public class PropertyCriteria<ItemToFilter, PropertyType> : Criteria<ItemToFilter>
    {
        PropertyAccessor<ItemToFilter, PropertyType> accessor;
        Criteria<PropertyType> value_criteria;

        public PropertyCriteria(PropertyAccessor<ItemToFilter, PropertyType> accessor,
                                Criteria<PropertyType> value_criteria)
        {
            this.accessor = accessor;
            this.value_criteria = value_criteria;
        }

        public bool matches(ItemToFilter item)
        {
            return value_criteria.matches(accessor(item));
        }
    }
}