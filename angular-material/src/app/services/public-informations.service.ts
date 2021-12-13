import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { DoctorInformationModel } from '../interfaces/doctor-information-model';


@Injectable({
  providedIn: 'root'
})
export class PublicInformationsService {

  constructor(private http: HttpClient) { }

  private baseUrl: string = environment.baseUrl;

  private privateHttpHeaders = {
    headers: new HttpHeaders({
      observe: 'body',
      responseType: 'json'
    })
  };

  getDoctors(): Observable<DoctorInformationModel[]>
  {
    return this.http.get(this.baseUrl + 'api/doctors/get-all-doctors')
    .pipe(map((response) => <DoctorInformationModel[]> response));
  }
}
