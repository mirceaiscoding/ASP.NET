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

  ngOnInit(): void {
    this.publicInformationsService.getDoctors().subscribe(doctors => {
      this.doctors = doctors;
      console.log(doctors);
    });
  }

  onSelect(doctor: DoctorInformationModel)
  {
    console.log(doctor);
  }

}
