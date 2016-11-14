using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movies.Models;
using Movies.Services;

namespace Movies.API.Test
{
    [TestClass]
    public class WebJetMovieServiceTest
    {
        [TestMethod]
        public void TestSearch()
        {
            var mockFilmworld = new Mock<IMovieProviderService>();
            var mockcinemaworld = new Mock<IMovieProviderService>();

            mockFilmworld.Setup(foo => foo
            .Search(It.IsAny<SearchCriteria>()))
            .Returns(Task.Run(()=> (IEnumerable<MovieInfo>) new List<MovieInfo>()
                {
                    new MovieInfo { }, new MovieInfo { },  new MovieInfo { }
                }));

            mockcinemaworld.Setup(foo => foo
            .Search(It.IsAny<SearchCriteria>()))
            .Returns(Task.Run(() => (IEnumerable<MovieInfo>)new List<MovieInfo>()
                {
                    new MovieInfo { }, new MovieInfo { }
                }));

            var movieService = new MovieService( mockcinemaworld.Object, mockFilmworld.Object);

            Assert.AreEqual(5, movieService.Search(new SearchCriteria()).Result.Count());

        }

        [TestMethod]
        public void TestGet()
        {
            var mockFilmworld = new Mock<IMovieProviderService>();
            var mockcinemaworld = new Mock<IMovieProviderService>();

            mockFilmworld.Setup(foo => foo
            .Get(It.IsAny<string>()))
            .Returns(Task.Run(() => (MovieInfo)new MovieInfoDetail()
                {
                    Id = "12345",
                    Title = "How to train your dragon"
                }));

            mockcinemaworld.Setup(foo => foo
           .Get(It.IsAny<string>()))
           .Returns(Task.Run(() => (MovieInfo)new MovieInfoDetail()
           {
               Id = "23456",
               Title = "Dr Strange"
           }));

            var movieService = new MovieService( mockcinemaworld.Object, mockFilmworld.Object);

            Assert.AreEqual("How to train your dragon", movieService.Get("12345", "FilmWorldService").Result.Title );
            Assert.AreEqual("Dr Strange", movieService.Get("23456", "CinemaWorldService").Result.Title );

        }
    }
}
