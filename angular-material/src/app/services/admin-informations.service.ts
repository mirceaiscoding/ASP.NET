import { formatDate } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AppointmentDTO } from '../interfaces/appointment-dto';
import { AppointmentInformationModel } from '../interfaces/appointment-information-model';

@Injectable({
  providedIn: 'root'
})
export class AdminInformationsService {

  constructor(private http: HttpClient) { }

  private privateHttpHeaders = new HttpHeaders({
    'content-type': 'application/json'
  });

  private baseUrl: string = environment.baseUrl;

  getAllAppointments(): Observable<AppointmentInformationModel[]>
  {
    return this.http.get(this.baseUrl + 'api/appointments/get-all-appointments')
    .pipe(map((response) => <AppointmentInformationModel[]> response));
  }

  deleteAppointment(appointment: AppointmentDTO)
  {
    console.log(appointment);
    const options = {
      headers: this.privateHttpHeaders,
      body: appointment,
    };
    return this.http.delete(this.baseUrl + 'api/appointments/delete-appointment', options)
  }

  updateAppointmentTime(appointment: AppointmentDTO, newStartTime: Date)
  {
    var body = {
      "pacientId": appointment.pacientId,
      "doctorId": appointment.doctorId,
      "procedureId": appointment.procedureId,
      "startTime": appointment.startTime,
      "endTime": appointment.endTime,
      "newStartTime": formatDate(newStartTime, "yyyy-MM-dd", "en-US")
    }
    console.log(body);
    return this.http.put(this.baseUrl + 'api/appointments/update-appointment-time', body)
  }


}
