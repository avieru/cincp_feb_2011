namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NegatingCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> basic;

        public NegatingCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> basic)
        {
            this.basic = basic;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return negate(basic.equal_to(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values_to_equal)
        {
            return negate(basic.equal_to_any(possible_values_to_equal));
        }

        public Criteria<ItemToFilter> create_using(Criteria<PropertyType> value_criteria)
        {
            return basic.create_using(value_criteria);
        }

        Criteria<ItemToFilter> negate(Criteria<ItemToFilter> original)
        {
            return original.not();
        }

        public NegatingCriteriaFactory<ItemToFilter, PropertyType> not
        {
            get { return this; }
        }
    }
}