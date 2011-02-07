using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        List<Movie> movies = new List<Movie>();

        public MovieLibrary(List<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies;
        }

        public void add(Movie movie)
        {
            foreach (var existingMovie in this.movies)
            {
                if (existingMovie.title== movie.title)
                    return;
            }
            this.movies.Add(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                var results = new List<Movie>();
 
                foreach (var movie in this.movies)
                {
                    if (results.Count==0)
                        results.Add(movie);continue;

                    

                }
                return results;                

            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            var results = new List<Movie>();
            foreach (var movie in this.movies)
            {
                if (movie.date_published > DateTime.Parse("01/01/"+year.ToString()))
                    results.Add(movie);
            }
            return results;
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            var results = new List<Movie>();
            foreach (var movie in this.movies)
            {
                if (movie.date_published > GetYearAsDateTime(startingYear) && movie.date_published < GetYearAsDateTime(endingYear))
                    results.Add(movie);
            }
            return results;
        }

        DateTime GetYearAsDateTime(int endingYear)
        {
            return DateTime.Parse("01/01/"+ endingYear);
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_by(Predicate<Movie> predicate)
        {
            var results = new List<Movie>();
            foreach (var movie in this.movies)
            {
                if (predicate.Invoke(movie))
                    results.Add(movie);
            }
            return results;
        }
    }
}