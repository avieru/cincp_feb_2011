using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public delegate PropertyType PropertyAccessor<ItemToFilter, PropertyType>(ItemToFilter item);


    public class Where<ItemToFilter>
    {
        public static SomeCriteria<ItemToFilter,PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            return new SomeCriteria<ItemToFilter,PropertyType>(accessor);
        }
    }

    public class SomeCriteria<ItemToFilter,PropertyType> : Criteria<ItemToFilter>
    {
        readonly PropertyAccessor<ItemToFilter, PropertyType> property_accessor;
        PropertyType _itemToCheck;

        public SomeCriteria(PropertyAccessor<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public SomeCriteria<ItemToFilter, PropertyType> equal_to(PropertyType item)
        {
            _itemToCheck = item;
            return this;
        }

        public bool matches(ItemToFilter item)
        {
            return property_accessor.Invoke(item).Equals(_itemToCheck);
        }

        public SomeCriteria<ItemToFilter,PropertyType> equal_to_any(PropertyType item)
        {
            throw new NotImplementedException();
        }
    }
}