import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CommService {
  constructor(private httpClient:HttpClient) { }

  GetNews(action:string): Observable<any> {
    const address:{[key: string]: any} = {
      "start": this.httpClient.get("/api/News/Get"),
      "refresh": this.httpClient.get("/api/News/Refresh")
    }
    return address[action]
  }
}
