import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
//组件的本质是带有逻辑的HTML容器，整个前端页面的最基本构建单位
export class App {
  protected readonly title = 'movieshopspa';
}
//signal 响应式组件