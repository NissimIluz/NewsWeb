import { Injectable } from '@angular/core';
import { CommService } from './comm.service';

@Injectable({
  providedIn: 'root'
})
export class NewsService {
  private news:any = null
  selectedReportIndex:number = -1 //no selected report.
  
  constructor(private commService:CommService) { 
    this.SetNews("start") //Gets data only once -when Instance create
  }
  get News(): any {
    return this.news
  }
    
  SetNews(action:string) {
    this.commService.GetNews(action).subscribe((res:any) => {
      if (res.list != null) {
        this.news = res.list
      }
      else {
        window.alert("The server cannot get the RSS news")
        }
      },
      error => window.alert("Unable to connect to server")
    )
  }
}
