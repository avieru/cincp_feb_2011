using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface CriteriaFactory<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> equal_to(PropertyType value_to_equal);
        Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values_to_equal);
        Criteria<ItemToFilter> create_using(Criteria<PropertyType> value_criteria);
        NegatingCriteriaFactory<ItemToFilter, PropertyType> not { get; }
    }

    public class NegatingCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        readonly CriteriaFactory<ItemToFilter, PropertyType> basic;

        public NegatingCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> basic)
        {
            this.basic = basic;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return new NotCriteria<ItemToFilter>(basic.equal_to(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values_to_equal)
        {
            return new NotCriteria<ItemToFilter>(basic.equal_to_any(possible_values_to_equal));
        }

        public Criteria<ItemToFilter> create_using(Criteria<PropertyType> value_criteria)
        {
            throw new NotImplementedException();
        }

        public NegatingCriteriaFactory<ItemToFilter, PropertyType> not
        {
            get { return this; }
        }
    }
}