using System;
using System.Collections.Generic;

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
            return movies;
        }

        public void add(Movie movie)
        {
            foreach (Movie m in all_movies())
            {
                if (m.title == movie.title)
                    return;
            }
            movies.Add(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return filter_movies_by_production_studio(ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            IList<Movie> disney_movies = filter_movies_by_production_studio(ProductionStudio.Disney);
            IList<Movie> filtered_movies = filter_movies_by_production_studio(ProductionStudio.Pixar);
            foreach (Movie m in disney_movies)
            {
                if (!filtered_movies.Contains(m))
                {
                    filtered_movies.Add(m);
                }
            }
            return filtered_movies;
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
            IList<Movie> filtered_movies = new List<Movie>();
            foreach (Movie m in all_movies())
            {
                if (!m.production_studio.Equals(ProductionStudio.Pixar))
                {
                    filtered_movies.Add(m);
                }
            }
            return filtered_movies;
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return all_movies_published_between_years(year+1, DateTime.MaxValue.Year);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            IList<Movie> filtered_movies = new List<Movie>();
            foreach (Movie m in all_movies())
            {
                if ((m.date_published.Year >= startingYear) && (m.date_published.Year <= endingYear))
                {
                    filtered_movies.Add(m);
                }
            }
            return filtered_movies;
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
            IEnumerable<Movie> movies = all_movies();
            DateTime maxDate = DateTime.MaxValue;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            throw new NotImplementedException();
        }


        // Privates introduced by me.
        private IList<Movie> filter_movies_by_genre(Genre byGenre)
        {
            IList<Movie> filtered_movies = new List<Movie>();
            foreach (Movie filtered_movie in all_movies())
            {
                if (filtered_movie.genre.Equals(byGenre))
                {
                    filtered_movies.Add(filtered_movie);
                }
            }
            return filtered_movies;
        }

        private IList<Movie> filter_movies_by_production_studio(ProductionStudio p)
        {
            IList<Movie> filtered_movies = new List<Movie>();
            foreach (Movie m in all_movies())
            {
                if (m.production_studio.Equals(p))
                {
                    filtered_movies.Add(m);
                }
                
            }
            return filtered_movies;
        }
    }
}           

