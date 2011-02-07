namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface Criteria<ItemToMatch>
    {
        bool matches(ItemToMatch item);
    }
}