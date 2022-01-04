import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PacientDTO } from '../interfaces/pacient-dto';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class PacientService {

  private pacientsApiUrl: string = environment.baseUrl + "api/pacients/";

  constructor(private http: HttpClient, private authService: AuthService) { }

  getPacientData(id: number): Observable<PacientDTO> {
    return this.http.get(this.pacientsApiUrl + "get-user-data/" + id)
    .pipe(map((response) => <PacientDTO>(response)));
  }
}
