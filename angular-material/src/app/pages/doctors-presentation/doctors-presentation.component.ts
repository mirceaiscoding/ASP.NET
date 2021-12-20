import { UpperCasePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { DoctorInformationModel } from 'src/app/interfaces/doctor-information-model';
import { PublicInformationsService } from 'src/app/services/public-informations.service';

@Component({
  selector: 'app-doctors-presentation',
  templateUrl: './doctors-presentation.component.html',
  styleUrls: ['./doctors-presentation.component.css']
})
export class DoctorsPresentationComponent implements OnInit {

  constructor(private publicInformationsService:PublicInformationsService) { }

  doctors: DoctorInformationModel[] = [];

  getImagePath(doctor: DoctorInformationModel): string
  {
    return "assets/" + (doctor.lastName + "_" + doctor.firstName + "_Photo").toUpperCase() + ".jpg";
  }

  ngOnInit(): void {
    this.publicInformationsService.getDoctors().subscribe(doctors => {
      this.doctors = doctors;
      console.log(doctors);
    });
  }

  selectDoctor(doctor: DoctorInformationModel)
  {
    console.log(doctor);
  }

}
