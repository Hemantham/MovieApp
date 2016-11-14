import { MovieInfoDetail, MovieInfo, SearchCriteria } from "../domain/movies.domain" 
import { Injectable }     from '@angular/core';
import { Http, Response, Request, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class MovieService {
    constructor(private http: Http) {
        this.headers = new Headers();
        this.headers.append('Accept', 'application/json');
    }
    private headers: Headers;
    private headersPost: Headers;

    public search(title: string): Observable<MovieInfo[]> {
        
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Accept', 'application/json');
        let options = new RequestOptions({ headers: headers });

        return (this.http
            .post('/Movies.Rest/api/movies/search', JSON.stringify({ title: title}), options)
            .map(this.extract)
            .catch(this.handleError));
    }       

    public getMovie(id: string, provider: string): Observable<MovieInfoDetail> {

        return this.http
            .get(`/Movies.Rest/api/providers/${provider}/movies/${id}`, { headers: this.headers })
            .map((res: Response) => {
                let body: MovieInfoDetail = res.json();
                return body;
            })
            .catch(this.handleError);

    }

    private extract(res: Response): MovieInfo[] {
        let body: MovieInfo[] = res.json();
        return body;
    }

    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}




