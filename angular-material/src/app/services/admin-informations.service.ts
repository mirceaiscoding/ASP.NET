import { formatDate } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AppointmentDTO } from '../interfaces/appointment-dto';
import { AppointmentInformationModel } from '../interfaces/appointment-information-model';
import { AppoointmentPostModel } from '../interfaces/appoointment-post-model';
import { PacientDTO } from '../interfaces/pacient-dto';
import { ProcedureDTO } from '../interfaces/procedure-dto';

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

  getUpcomingAppointments(): Observable<AppointmentInformationModel[]>
  {
    return this.http.get(this.baseUrl + 'api/appointments/get-upcoming-appointments')
    .pipe(map((response) => <AppointmentInformationModel[]> response));
  }

  getPreviousAppointments(): Observable<AppointmentInformationModel[]>
  {
    return this.http.get(this.baseUrl + 'api/appointments/get-previous-appointments')
    .pipe(map((response) => <AppointmentInformationModel[]> response));
  }

  getAllPacients(): Observable<PacientDTO[]>
  {
    return this.http.get(this.baseUrl + 'api/pacients/get-all-pacients')
    .pipe(map((response) => <PacientDTO[]> response));
  }

  deleteAppointment(appointment: AppointmentDTO)
  {
    console.log(appointment);
    const options = {
      headers: this.privateHttpHeaders,
      body: appointment,
    };
    return this.http.delete(this.baseUrl + 'api/appointments/delete-appointment', options);
  }

  updateAppointmentTime(appointment: AppointmentDTO, newDate: Date, newTime: String)
  {
    var formattedDate = formatDate(newDate, "yyyy-MM-dd", "en-US");
    var body = {
      "pacientId": appointment.pacientId,
      "doctorId": appointment.doctorId,
      "procedureId": appointment.procedureId,
      "startTime": appointment.startTime,
      "endTime": appointment.endTime,
      "newStartTime": formattedDate + "T" + newTime
    };
    console.log(body);
    return this.http.put(this.baseUrl + 'api/appointments/update-appointment-time', body);
  }

  addAppointment(appointment: AppoointmentPostModel)
  {
    console.log("POST APPOINTMENT", appointment);
    return this.http.post(this.baseUrl + 'api/appointments/insert-appointment', appointment);
  }

  getAppointmentInfo(appointment: AppointmentDTO)
  {
    return this.http.post(this.baseUrl + 'api/appointments/get-appointment-information', appointment);
  }

  addProcedure(procedure: ProcedureDTO)
  {
    return this.http.post(this.baseUrl + 'api/procedures/insert-procedure', procedure);
  }

}
