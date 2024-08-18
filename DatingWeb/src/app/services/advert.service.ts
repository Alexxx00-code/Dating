import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';


const urlCampaign: string = 'advert/GetAdvertSearch';

@Injectable({ providedIn: 'root' })
export class TestService {
  constructor(private http: HttpClient) {}

  getTest(): Observable<any> {
    return this.http.get<any>(environment.api + 'Test/Test');
  }
}
