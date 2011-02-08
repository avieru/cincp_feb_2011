namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NegatingFilteringExtensionPoint<ItemToFilter,PropertyType> : FilteringExtensionPoint<ItemToFilter,PropertyType>
    {
        FilteringExtensionPoint<ItemToFilter, PropertyType> basic;

        public NegatingFilteringExtensionPoint(FilteringExtensionPoint<ItemToFilter, PropertyType> basic)
        {
            this.basic = basic;
        }

        public Criteria<ItemToFilter> create_criteria_from(Criteria<PropertyType> raw_criteria)
        {
            return basic.create_criteria_from(raw_criteria).not();
        }
    }
}