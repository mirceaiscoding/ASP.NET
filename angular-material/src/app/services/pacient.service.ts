import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PacientAppoointmentModel } from '../interfaces/pacient-appoointment-model';
import { PacientDTO } from '../interfaces/pacient-dto';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class PacientService {

  constructor(private http: HttpClient, private authService: AuthService) { }

  getPacientData(id: number): Observable<PacientDTO> {
    return this.http.get(environment.baseUrl + "api/pacients/get-user-data/" + id)
    .pipe(map((response) => <PacientDTO>(response)));
  }

  getPacientAppointments(id: number): Observable<any> {
    return this.http.get(environment.baseUrl + "api/appointments/get-pacient-appointments/" + id)
    .pipe(map((response) =>  <PacientAppoointmentModel[]>response))
  }

  updatePacientData(id: number, updatedPacient: PacientDTO): Observable<any> {
    return this.http.put(environment.baseUrl + "api/pacients/update-pacient/" + id, updatedPacient);
  }
}
