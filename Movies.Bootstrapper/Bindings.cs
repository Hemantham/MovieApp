using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Movies.API;
using Movies.Services;

namespace Movies.Bootstrapper
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMovieProviderService>().To<FilmWorldService>().InThreadScope().Named("FilmWorldService");
            Bind<IMovieProviderService>().To<CinemaWorldService>().InThreadScope().Named("CinemaWorldService");
            Bind<IMovieService>().To<MovieService>().InThreadScope();
        }
    }
}
