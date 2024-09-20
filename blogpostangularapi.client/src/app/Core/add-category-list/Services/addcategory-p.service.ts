import { Injectable } from '@angular/core';
import { RequestModel } from '../../Model/request-model';
import { environment } from '../../../../environments/environment';

import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';






@Injectable({
  providedIn: 'root'
})
export class AddcategoryPService {
// private postapi = environment.Postapiurl; 
   private urls = 'https://localhost:7112/api/Values';
  

  constructor(private http: HttpClient) {}
  addCategory(category: RequestModel): Observable<RequestModel> {
    debugger
   
    return this.http.post<RequestModel>(this.urls, category);}

}
