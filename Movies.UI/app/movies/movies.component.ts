import { Component, OnInit, Input } from '@angular/core';
import { MovieInfoDetail, MovieInfo , SearchCriteria } from './domain/movies.domain';
import { MovieService } from "./services/movies.services";


@Component({
    selector: 'movie-list',
    templateUrl: 'app/movies/templates/MoviesComponent.html',
    providers: [MovieService],   
})
   
export class MoviesComponent implements OnInit {
    
    public movies: any[];
    public errorMessage: any;
    public title: string;

    constructor(private service: MovieService) {
         
    }

    ngOnInit(): void {

        //alert(1)
        this.service.search("")
            .subscribe((response: MovieInfo[]) => {

              //  alert(response[0].Title)
                this.movies = response;
                 },
            error => this.errorMessage = <any>error
        );
    }
}
