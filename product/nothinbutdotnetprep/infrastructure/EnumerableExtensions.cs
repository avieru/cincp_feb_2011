using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }

        static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Condition<T> condition)
        {
            foreach (var item in items)
            {
                if (condition(item)) yield return item;
            }
        }

        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Criteria<T> criteria)
        {
            return all_items_matching(items, criteria.matches);
        }

        public static EnumerableCriteriaFactory<ItemToFilter,PropertyType> where<ItemToFilter,PropertyType>(this IEnumerable<ItemToFilter> enumerable,PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            return new EnumerableCriteriaFactory<ItemToFilter, PropertyType>(enumerable, accessor);
        }
    }

    public class EnumerableCriteriaFactory<ItemToFilter, PropertyType> 
    {
        readonly IEnumerable<ItemToFilter> enumerable;
        readonly PropertyAccessor<ItemToFilter, PropertyType> accessor;

        public EnumerableCriteriaFactory(IEnumerable<ItemToFilter> enumerable, PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            this.enumerable = enumerable;
            this.accessor = accessor;
        }

        public IEnumerable<ItemToFilter> equal_to(PropertyType value_to_check_against)
        {
            return enumerable.all_items_matching(Where<ItemToFilter>.has_a(accessor).equal_to(value_to_check_against));
        }
    }
}