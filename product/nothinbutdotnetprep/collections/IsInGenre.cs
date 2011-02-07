namespace nothinbutdotnetprep.collections
{
    public class IsInGenre : MovieCriteria
    {
        Genre genre;

        public IsInGenre(Genre genre)
        {
            this.genre = genre;
        }

        public bool matches(Movie movie)
        {
            return movie.genre == genre;
        } 
    }
}