namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface FilteringExtensionPoint<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> create_criteria_from(Criteria<PropertyType> raw_criteria);
    }
}