import { Injectable } from '@angular/core';
import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../environments/environment';
import { ResponseModel } from './Core/Model/response-model';


@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  // private apiUrl: string = environment.apiUrls; 
  
  private url = 'https://localhost:7112/api/Values';
 
  
 


    constructor(private http: HttpClient) {}
  
   
    

   
   
   
  public getSuperHeroes(): Observable<ResponseModel[]> {
    return this.http.get<ResponseModel[]>(this.url);
  }
  }
