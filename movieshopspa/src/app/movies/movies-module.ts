import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovieDetails } from './movie-details/movie-details';
import { CastDetails } from './cast-details/cast-details';
import { MoviesRoutingModule } from './movies-routing-module';
import { Movies } from './movies';
import { RouterOutlet } from "@angular/router";



@NgModule({
  declarations: [
    MovieDetails,
    CastDetails,
    Movies
  ],
  imports: [
    CommonModule,
    MoviesRoutingModule,
    RouterOutlet
]
})
export class MoviesModule { }
