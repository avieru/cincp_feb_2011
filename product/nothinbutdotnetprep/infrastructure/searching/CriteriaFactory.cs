namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface CriteriaFactory<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> equal_to(PropertyType value_to_equal);
        Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values_to_equal);
        Criteria<ItemToFilter> create_using(Criteria<PropertyType> value_criteria);
    }
}