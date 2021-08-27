import { Component, Input, OnInit } from '@angular/core';
import { NewsService } from 'src/app/services/news.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  @Input() index:number = -1
  constructor(private newsService:NewsService) { }

  ngOnInit(): void {
  }
  get Selected():any {
    return  this.newsService.News[this.newsService.selectedReportIndex]
  }

}
