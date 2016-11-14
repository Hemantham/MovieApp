# MovieApp
Movie search

##

Functionality

User can search for movies by title and then see who is the provider. (Cinemaworld Or Filmworld). Then they can click on image tile to view details and price. 

note : If individual movie details are not loaded in the first click and gives the loading failiur message , click it again. (This is due to individual movie requests are not cached) 



Key considerations

Since the 3rd PArty movie provider details  needs to be kept hidden from clients and 
they needs to be abstracted to accomodate more providers in the future MovieWorld are CinemaWorl PAIs are wrapped in my own API.  This way we can add more providers in future without changing the UI.

Web API 2 is used to create the Rest Services with HttpClient async calls to 3rd party API's.

Ninject Is used for DI and all the layers are abstracted to easily maintenance and extensility in Future.

UI is done in Angular2 with TypeScript. RxJs Observables used for Http calls from Client. 

Unit tests written for API Layer.

Simple runtime Caching used to cache the data since the given API's are very unpredictable.
Individual movie details are not cached , and are retrieved allways from third party API. 

UI is responsive with Bootstrap Material design.
![]({{site.baseurl}}//Capture.PNG)



##

ToDos./ Nice to haves..

Implement better Error and Excetion handling to detect Http codes returned from 3rd party.

show a waitig animation for log web calls

Move caching from Runtime Cache to redis or something similar.

Cache individual movie requests as well so that price can be shown in the list view.

Create seperate component to show the detail view.

Add Bootstrap and other dependancies to system.config.js. 




