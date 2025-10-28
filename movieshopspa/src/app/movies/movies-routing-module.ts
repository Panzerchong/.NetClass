import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule, Routes } from '@angular/router';
import { Movies } from './movies';
import { MovieDetails } from './movie-details/movie-details';
import { CastDetails } from './cast-details/cast-details';


const routes: Routes=[
  {
    //当用户访问 http://localhost:4200/moveis,Angular就会加载movies模块，同时激活默认路由
    path:'',component: Movies,
    children:[
      {path: ':id',component: MovieDetails},//http://localhost:4200/moveis/1
      {path:'cast/:id',component:CastDetails},//http://localhost:4200/moveis/cast/1
    ]
  }
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,RouterModule.forChild(routes)//把当前路由注册到项目路由中
  ]
})
export class MoviesRoutingModule { }
