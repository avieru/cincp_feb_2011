using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToFilter,PropertyType> where PropertyType : IComparable<PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> accessor;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(x => accessor(x).CompareTo(value) > 0);
        }
    }
}