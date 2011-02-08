namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DefaultFilteringExtensionPoint<ItemToFilter, PropertyType> :
        FilteringExtensionPoint<ItemToFilter, PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> accessor { get; set; }

        public FilteringExtensionPoint<ItemToFilter, PropertyType> not
        {
            get { return new NegatingFilteringExtensionPoint<ItemToFilter, PropertyType>(this); }
        }

        public DefaultFilteringExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> create_criteria_from(Criteria<PropertyType> raw_criteria)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor, raw_criteria);
        }
    }
}