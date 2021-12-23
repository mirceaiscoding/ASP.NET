import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AppointmentInformationModel } from '../interfaces/appointment-information-model';

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

  getAllAppointments(): Observable<AppointmentInformationModel[]>
  {
    return this.http.get(this.baseUrl + 'api/appointments/get-all-appointments')
    .pipe(map((response) => <AppointmentInformationModel[]> response));
  }

}
