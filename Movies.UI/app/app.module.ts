import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MoviesComponent } from './movies/movies.component';
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

@NgModule({
    imports: [BrowserModule, HttpModule, FormsModule],
  declarations: [AppComponent, MoviesComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }