import { UpperCasePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DoctorDTO } from 'src/app/interfaces/doctor-dto';
import { PublicInformationsService } from 'src/app/services/public-informations.service';
import { SelectedDoctorService } from 'src/app/services/selected-doctor.service';

@Component({
  selector: 'app-doctors-presentation',
  templateUrl: './doctors-presentation.component.html',
  styleUrls: ['./doctors-presentation.component.css']
})
export class DoctorsPresentationComponent implements OnInit {

  constructor(
    private publicInformationsService:PublicInformationsService,
    private router: Router) { }

  doctors: DoctorDTO[] = [];

  getImagePath(doctor: DoctorDTO): string
  {
    return "assets/" + (doctor.lastName + "_" + doctor.firstName + "_Photo").toUpperCase() + ".jpg";
  }

  ngOnInit(): void {
    this.publicInformationsService.getAllDoctors().subscribe(doctors => {
      this.doctors = doctors;
      console.log("Doctors", doctors);
    });
  }

  goToMakeAppointment(doctor: DoctorDTO) {
    this.router.navigate(["make-appointment", doctor.id]);
  }

}
