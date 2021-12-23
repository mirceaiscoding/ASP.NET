import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DoctorInformationModel } from '../interfaces/doctor-information-model';

@Injectable({
  providedIn: 'root'
})
export class AdminInformationsService {

  constructor(private http: HttpClient) { }

  private privateHttpHeaders = {
    headers: new HttpHeaders({
      observe: 'body',
      responseType: 'json'
    })
  };

  private baseUrl: string = environment.baseUrl;

  getDoctors(): Observable<DoctorInformationModel[]>
  {
    return this.http.get(this.baseUrl + 'api/doctors/get-all-doctors')
    .pipe(map((response) => <DoctorInformationModel[]> response));
  }

}
