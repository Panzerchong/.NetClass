import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Home } from './home/home';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from './shared/shared-module';
import { CoreModule } from './core/core-module';

//装饰器，c# attribute
@NgModule({
  declarations: [
    App,
    Home
  ],
  //把其他模块，对应的功能，引入到当前模块
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    CoreModule
  ],
  //配置依赖注入，注册服务
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]//应用从哪里启动
})
export class AppModule { }
