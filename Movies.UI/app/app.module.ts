import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MoviesComponent } from './movies/movies.component';
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '@angular/material'

@NgModule({
  imports: [BrowserModule, HttpModule, FormsModule, MaterialModule.forRoot()],
  declarations: [AppComponent, MoviesComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
