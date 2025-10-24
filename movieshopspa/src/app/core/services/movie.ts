import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MovieCardModel } from '../../shared/models/MovieCardModel';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'//服务注入到全局root
})
export class Movie {
  //Angular DI容器自动注入实例
  constructor(private http:HttpClient){

  }

  //
  getTopGrossingMovies():Observable<MovieCardModel[]> {
    return this.http.get<MovieCardModel[]>('https://localhost:7067/api/Movie/Top-grossing');
  }
  getMovieDetails(id: number){

  }

  getMovieByGenre(genreId:number){

  }

}

//getTopGrossingMovies()

//getMovieDetails(movieId: number)