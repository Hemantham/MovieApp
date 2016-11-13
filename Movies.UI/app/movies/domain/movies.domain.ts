export class MovieInfoDetail {
    constructor(public type: string, public id: string, public title: string, public year: number, public imageUrl: string, public provider: string, public rated: string, public released: string, public runtime: string, public genre: string, public director: string, public writer: string, public actors: string, public plot: string, public language: string, public country: string, public awards: string, public poster: string, public metascore: string, public rating: string, public votes: string, public price: number) {

    }
}

export class MovieInfo {
    constructor(public type: string, public id: string, public title: string, public year: number, public imageUrl: string, public provider: string) {

    }
}

export class SearchCriteria {
    constructor(public priceMin: number, public priceMax: number, public title: string) {

    }
}