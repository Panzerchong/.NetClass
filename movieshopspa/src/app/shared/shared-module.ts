import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovieCard } from './components/movie-card/movie-card';



@NgModule({
  declarations: [
    MovieCard
  ],
  imports: [
    CommonModule
  ],
  exports:[MovieCard]//exporting Moviecard component to be used in other modules
})
export class SharedModule { }
