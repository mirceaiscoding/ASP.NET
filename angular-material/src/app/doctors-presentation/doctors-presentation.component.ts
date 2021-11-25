import { Component, OnInit } from '@angular/core';
import { Doctor } from '../shared/models/doctor.model';

@Component({
  selector: 'app-doctors-presentation',
  templateUrl: './doctors-presentation.component.html',
  styleUrls: ['./doctors-presentation.component.css']
})
export class DoctorsPresentationComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    var doctors = [Doctor];
  }

}
