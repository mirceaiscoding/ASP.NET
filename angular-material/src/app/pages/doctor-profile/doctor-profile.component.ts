import { Component, OnInit } from '@angular/core';
import { Weekday } from 'src/app/interfaces/weekday';

@Component({
  selector: 'app-doctor-profile',
  templateUrl: './doctor-profile.component.html',
  styleUrls: ['./doctor-profile.component.css']
})
export class DoctorProfileComponent implements OnInit {

  weekdays: Weekday[] = [
    {
      id: 0,
      name: 'Sunday',
    },
    { 
      id: 1,
      name: 'Monday',
    },
    { 
      id: 2,
      name: 'Tuesday',
    },
    { 
      id: 3,
      name: 'Wednesday',
    },
    { 
      id: 4,
      name: 'Thursday',
    },
    { 
      id: 5,
      name: 'Friday',
    },
    { 
      id: 6,
      name: 'Saturday'
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
