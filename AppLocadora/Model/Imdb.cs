using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace AppLocadora.Model
{
    public class Imdb
    {
        /// <summary>
        /// The movie's cast list.
        /// </summary>
        [JsonProperty("actors")]
        public List<string> Actors { get; set; }

        /// <summary>
        /// The movie's other name. Fields(full mode): title country remarks
        /// </summary>
        [JsonProperty("also_known_as")]
        public List<string> AlsoKnownAs { get; set; }

        /// <summary>
        /// The movie's country.
        /// </summary>
        [JsonProperty("country")]
        public List<string> Country { get; set; }

        /// <summary>
        /// The movie's directors.
        /// </summary>
        [JsonProperty("directors")]
        public List<string> Directors { get; set; }

        /// <summary>
        /// The TV series's episodes(only TV series). Fields: date season episode title.
        /// </summary>
        [JsonProperty("episodes")]
        public List<string> Episodes { get; set; }

        /// <summary>
        /// The movie's locations.
        /// </summary>
        [JsonProperty("film_locations")]
        public List<string> FilmLocations { get; set; }

        /// <summary>
        /// The movie's genres.(e.g. Drama, War)
        /// </summary>
        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        /// <summary>
        /// The movie's ID on IMDb.com.
        /// </summary>
        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        /// <summary>
        /// The movie's url on IMDb.com.
        /// </summary>
        [JsonProperty("imdb_url")]
        public string ImdbUrl { get; set; }

        /// <summary>
        /// The movie's audio language.
        /// </summary>
        [JsonProperty("language")]
        public List<string> Language { get; set; }

        /// <summary>
        /// The movie's summary.
        /// </summary>
        [JsonProperty("plot")]
        public string Plot { get; set; }

        /// <summary>
        /// The movie's summary.(short)
        /// </summary>
        [JsonProperty("plot_simple")]
        public string PlotSimple { get; set; }

        /// <summary>
        /// The movie's poster.
        /// </summary>
        [JsonProperty("poster")]
        public string Poster { get; set; }

        /// <summary>
        /// The movie's classification and ratings.
        /// </summary>
        [JsonProperty("rated")]
        public string Rated { get; set; }

        /// <summary>
        /// The score of the movie on IMDb.com.
        /// </summary>
        [JsonProperty("rating")]
        public float Rating { get; set; }

        /// <summary>
        /// The number of voters on IMDb.com.
        /// </summary>
        [JsonProperty("rating_count")]
        public int RatingCount { get; set; }

        /// <summary>
        /// The movie's release date. Fields(full mode): year month day country remarks
        /// </summary>
        [JsonProperty("release_date")]
        public int ReleaseDate { get; set; }

        /// <summary>
        /// The movie's duration.
        /// </summary>
        [JsonProperty("runtime")]
        public List<string> Runtime { get; set; }

        /// <summary>
        /// The movie's name.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// The movie's type. Below are all the type:
        /// M   - Movie
        /// TVS - TV Series
        /// TV  - TV Movie
        /// V   - Video
        /// VG  - Video Game
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The movie's writers.
        /// </summary>
        [JsonProperty("writers")]
        public List<string> Writers { get; set; }

        /// <summary>
        /// The movie's age.
        /// </summary>
        [JsonProperty("year")]
        public int Year { get; set; }

        /// <summary>
        /// The movie's business info. (Budget, Gross, Opening Weekend, Weekend Gross, Admissions, Filming Dates, Producation Dates, Copyright holder etc.)
        /// </summary>
        /// <remarks>
        /// NA DOCUMENTAÇÃO O TIPO É JSON
        /// </remarks>
        [JsonProperty("business")]
        public string Business { get; set; }

        /// <summary>
        /// The movie's technical info. (Camera, Laboratory, Film Length, Film negative format, Cinematographic process, Printed film format, Aspect ratio etc.)
        /// </summary>
        /// <remarks>
        /// NA DOCUMENTAÇÃO O TIPO É JSON
        /// </remarks>
        [JsonProperty("technical")]
        public string Technical { get; set; }

        //public bool Integrated { get; set; }
    }
}
