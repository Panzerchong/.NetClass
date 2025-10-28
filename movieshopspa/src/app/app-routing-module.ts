import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Home } from './home/home';
//不带括号是静态导入，带括号是运行是加载

const routes: Routes = [{path:'', component: Home},//path相当于根路径locahost:4200
  {path:'movies',loadChildren:()=>import('./movies/movies-module').then(mod=>mod.MoviesModule)},
  //当用户访问到http://localhost:4200/movies，Angular 就会调用import,导入模块文件/movies/movies-module，
  //当模块加载完成后，then就会从模块中去除MoviesModule类，交给Angular进行注册和激活，实现lazy-loading
  {path:'account',loadChildren:()=>import('./account/account-module').then(mod=>mod.AccountModule)},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
