using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class HasPrecision :Criteria<Decimal>
    {
        public bool matches(decimal item)
        {
            throw new NotImplementedException();
        }
    }
}