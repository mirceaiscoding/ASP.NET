import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { DoctorDTO } from '../interfaces/doctor-dto';

@Injectable({
  providedIn: 'root'
})
export class SelectedDoctorService {

  constructor() { }

  public noDoctor: DoctorDTO = {
    id: -1,
    firstName: "",
    lastName: "",
    jobDescription: "",
    phoneNumber: ""
  }

  private selectedDoctorSource = new BehaviorSubject<DoctorDTO>(this.noDoctor);

  public changeDoctor(doctor: DoctorDTO) {
    this.selectedDoctorSource.next(doctor);
  }

  public currentSelectedDoctor: Observable<DoctorDTO> = this.selectedDoctorSource.asObservable();
}
