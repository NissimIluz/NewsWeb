import { Component, OnInit } from '@angular/core';
import { NewsService } from './services/news.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  news:any= null;
  constructor(private newsService:NewsService) { 
    this.news = newsService.News
  }
  ngOnInit() {} 
  get News(): any {
    return this.newsService.News
  }
  
  SetSelectReport(index:any) {
    this.newsService.selectedReportIndex =index
  }  
  Refresh() {
    this.newsService.SetNews("refresh");
  }
  HasSelected():Boolean {
    return this.newsService.selectedReportIndex != -1
  }
  HasNext():Boolean {
    return this.newsService.selectedReportIndex != this.newsService.News.length-1
  }
  Next() {
    this.newsService.selectedReportIndex += 1
  }
}
