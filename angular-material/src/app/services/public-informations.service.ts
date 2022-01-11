import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { DoctorDTO } from '../interfaces/doctor-dto';
import { ProcedureDTO } from '../interfaces/procedure-dto';


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

  getAllDoctors(): Observable<DoctorDTO[]>
  {
    return this.http.get(this.baseUrl + 'api/doctors/get-all-doctors')
    .pipe(map((response) => <DoctorDTO[]> response));
  }

  getAllProcedures(): Observable<ProcedureDTO[]>
  {
    return this.http.get(this.baseUrl + 'api/procedures/get-all-procedures')
    .pipe(map((response) => <ProcedureDTO[]> response));
  }

  getDoctorById(id: number): Observable<DoctorDTO>
  {
    return this.http.get(this.baseUrl + 'api/doctors/get-doctor-by-id/' + id)
    .pipe(map((response) => <DoctorDTO> response));
  }

}
