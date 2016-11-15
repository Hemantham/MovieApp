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
    public movieDetails: MovieInfoDetail;
    public requesting: boolean;

    constructor(private service: MovieService) {
         
    }

    onSubmit(event: any) {
        this.hasError = false;
        this.movies = [];
        this.movieDetails = null;
        this.requesting = true;
        this.service.search(this.title)
            .subscribe((response: MovieInfo[]) => {
                this.movies = response;
                this.requesting = false;
                if (this.movies.length === 0) {
                    this.hasError = true;
                }
                },
            error => {
                this.hasError = true;
                this.requesting = false;                
            });
    }

    public show(id: string, provider: string) {

        this.hasError = false;
        this.movieDetails = null;
        this.requesting = true;
        this.service.getMovie(id, provider)
            .subscribe((res: MovieInfoDetail) => {

                this.movieDetails = res;
                this.requesting = false;                

            },
            (error:any): void => {
                this.hasError = true;
                this.requesting = false;                

            });

    }
    public hide(element: string) {
        this.movieDetails = null;
    }

    ngOnInit(): void {
       
    }
}
