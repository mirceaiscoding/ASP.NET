import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { DoctorDTO } from 'src/app/interfaces/doctor-dto';
import { SelectedDoctorService } from 'src/app/services/selected-doctor.service';

@Component({
  selector: 'app-doctor-info',
  templateUrl: './doctor-info.component.html',
  styleUrls: ['./doctor-info.component.css']
})
export class DoctorInfoComponent implements OnInit, OnDestroy {

  @Input() doctor: DoctorDTO = {
    id: -1,
    firstName: '',
    lastName: '',
    jobDescription: '',
    phoneNumber: ''
  };

  @Output() onMakeAppointmentDoctor: EventEmitter<DoctorDTO> = new EventEmitter<DoctorDTO>();

  constructor(private selectedDoctorService: SelectedDoctorService) { }

  selectedDoctor: DoctorDTO = this.selectedDoctorService.noDoctor;

  subscription!: Subscription;

  ngOnInit(): void {
   this.subscription = this.selectedDoctorService.currentSelectedDoctor.subscribe((response: DoctorDTO) => {
      this.selectedDoctor = response;
    });
  }

  selectDoctor(doctor: DoctorDTO)
  {
    this.selectedDoctorService.changeDoctor(doctor);
  }

  isSelected(doctor: DoctorDTO) {
    return this.selectedDoctor == doctor;
  }

  getImagePath(doctor: DoctorDTO): string
  {
    return "assets/" + (doctor.lastName + "_" + doctor.firstName + "_Photo").toUpperCase() + ".jpg";
  }

  requestConsultation(doctor: DoctorDTO){
    this.onMakeAppointmentDoctor.emit(doctor);
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
  }
}
