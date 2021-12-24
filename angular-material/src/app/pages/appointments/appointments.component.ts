import { LiveAnnouncer } from '@angular/cdk/a11y';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { AppointmentDTO } from 'src/app/interfaces/appointment-dto';
import { AppointmentTableDataModel } from 'src/app/interfaces/appointment-table-data-model';
import { AdminInformationsService } from 'src/app/services/admin-informations.service';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {

  constructor(
    private adminInformationsServie: AdminInformationsService,
    private liveAnnouncer: LiveAnnouncer,
    public dialog: MatDialog ) { }
  
  displayedColumns: string[] = ['doctorName', 'pacientName', 'procedure', 'startTime', 'endTime', 'delete', 'editStartTime'];

  dataSource: MatTableDataSource<any> = new MatTableDataSource();
  
  appointmets: AppointmentTableDataModel[] = [];

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  @ViewChild(MatSort) sort!: MatSort;

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }

  announceSortChange(sortState: Sort) {
    if (sortState.direction) {
      this.liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this.liveAnnouncer.announce('Sorting cleared');
    }
  }

  delete(appointment: AppointmentDTO) {
    console.log(appointment);
    this.adminInformationsServie.deleteAppointment(appointment).subscribe(response => {
      console.log(response);
      this.appointmets = this.appointmets.filter(a => a != appointment);
      this.dataSource.data = this.appointmets;
    });
  }

  editTime(appointment: AppointmentDTO) {
    console.log(appointment);
    this.adminInformationsServie.deleteAppointment(appointment).subscribe(response => {
      console.log(response);
      
    });
  }
  
  ngOnInit(): void {

    this.adminInformationsServie.getAllAppointments().subscribe(appointments => {
      this.appointmets = appointments.map(function(appointment): AppointmentTableDataModel {
        return {
          pacientId: appointment.pacientDTO.id,
          doctorId: appointment.doctorDTO.id,
          procedureId: appointment.procedureDTO.id,
          pacientName: appointment.pacientDTO.lastName + " " + appointment.pacientDTO.firstName,
          doctorName: appointment.doctorDTO.lastName + " " + appointment.doctorDTO.firstName,
          procedureName: appointment.procedureDTO.procedureName,
          startTime: appointment.startTime,
          endTime: appointment.endTime,
        }
      });
      this.dataSource.data = this.appointmets;
      console.log(this.appointmets);
      
    });
  }
}
