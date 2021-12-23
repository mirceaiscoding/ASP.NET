import { Component, OnInit } from '@angular/core';
import { AdminInformationsService } from 'src/app/services/admin-informations.service';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {

  constructor(private adminInformationsServie: AdminInformationsService) { }

  appointments: any[] = [];

  ngOnInit(): void {
    this.adminInformationsServie.getAllAppointments().subscribe(appointments => {
      this.appointments = appointments;
      console.log(appointments);
    });
  }

}
