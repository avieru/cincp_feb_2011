using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return all_movies_matching(x => x.production_studio == ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return all_movies_matching(x => x.production_studio == ProductionStudio.Pixar ||
                x.production_studio == ProductionStudio.Disney);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return all_movies_matching(x => x.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            return all_movies_matching(x => x.date_published.Year >= startingYear &&
                x.date_published.Year <= endingYear);
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return all_movies_published_between_years(year + 1, DateTime.MaxValue.Year);
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return filter_movies_by_genre(Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return filter_movies_by_genre(Genre.action);
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            IList<Movie> sorted_movies = new List<Movie>();
            var movies = all_movies();
            var maxDate = DateTime.MaxValue;
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_matching(Condition<Movie> condition)
        {
            foreach (var movie in all_movies())
            {
                if (condition(movie)) yield return movie;
            }
        }

        IEnumerable<Movie> filter_movies_by_genre(Genre byGenre)
        {
            foreach (var filtered_movie in all_movies())
            {
                if (filtered_movie.genre.Equals(byGenre))
                {
                    yield return filtered_movie;
                }
            }
        }

        IEnumerable<Movie> filter_movies_by_production_studio(ProductionStudio studio)
        {
            foreach (var movie in all_movies())
            {
                if (movie.production_studio.Equals(studio))
                {
                    yield return movie;
                }
            }
        }
    }
}