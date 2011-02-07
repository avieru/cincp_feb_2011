namespace nothinbutdotnetprep.collections
{
    public class IsPublishedBy : MovieCriteria
    {
        ProductionStudio studio;

        public IsPublishedBy(ProductionStudio studio)
        {
            this.studio = studio;
        }

        public bool matches(Movie movie)
        {
            return movie.production_studio == studio;
        }
    }
}