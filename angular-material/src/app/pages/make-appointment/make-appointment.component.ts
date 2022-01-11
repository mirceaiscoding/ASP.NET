import { ResourceLoader } from '@angular/compiler';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { DoctorDTO } from 'src/app/interfaces/doctor-dto';
import { PublicInformationsService } from 'src/app/services/public-informations.service';
import { SelectedDoctorService } from 'src/app/services/selected-doctor.service';

@Component({
  selector: 'app-make-appointment',
  templateUrl: './make-appointment.component.html',
  styleUrls: ['./make-appointment.component.css']
})
export class MakeAppointmentComponent implements OnInit, OnDestroy {

  constructor(
    private selectedDoctorService: SelectedDoctorService, 
    private activatedRoute: ActivatedRoute,
    private publicInformationsService: PublicInformationsService) { }

  doctor: DoctorDTO = this.selectedDoctorService.noDoctor;

  doctorId!: number;

  subscription!: Subscription;

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params: any) => {
      console.log("Route params", params);
      this.doctorId = params['id'];
      this.subscription = this.selectedDoctorService.currentSelectedDoctor.subscribe((response: any) => {
        this.doctor = response;
        if (this.doctor.id != this.doctorId) {
          // selectedDoctorService data was lost due to reloading, getting data from route params
          this.publicInformationsService.getDoctorById(this.doctorId).subscribe((paramsDoctor: any) => {
            this.doctor = paramsDoctor;
            this.selectedDoctorService.changeDoctor(this.doctor);
          })
        }
      });
    });
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
  }

}
