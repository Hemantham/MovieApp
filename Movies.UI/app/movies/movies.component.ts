import { Component, OnInit, Input } from '@angular/core';
import { MovieInfoDetail, MovieInfo , SearchCriteria } from './domain/movies.domain';
import { MovieService } from "./services/movies.services";


@Component({
    selector: 'movie-list',
    templateUrl: 'app/movies/templates/MoviesComponent.html',
    providers: [MovieService],   
})
   
export class MoviesComponent implements OnInit {
    
    public movies: MovieInfo[];
    public hasError: boolean;
    public title: string;
    public movieDetails : MovieInfoDetail;

    constructor(private service: MovieService) {
         
    }

    onSubmit(event: any) {
        this.hasError = false;
        this.movies = [];
        this.movieDetails = null;

        this.service.search(this.title)
            .subscribe((response: MovieInfo[]) => {
                this.movies = response;
                debugger;
                if (this.movies.length === 0) {
                    this.hasError = true;
                }
                },
            error => this.hasError = true);
    }

    public show(id: string, provider: string) {

        this.hasError = false;
        this.movieDetails = null;
        this.service.getMovie(id, provider)
            .subscribe((res: MovieInfoDetail) => {

                this.movieDetails = res;
               
            },
            (error:any): void => {
                this.hasError = true;
            });

    }
    public hide(element: string) {
        this.movieDetails = null;
    }

    ngOnInit(): void {
       
    }
}
