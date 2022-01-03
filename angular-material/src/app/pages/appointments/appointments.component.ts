import { LiveAnnouncer } from '@angular/cdk/a11y';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { AppointmentDTO } from 'src/app/interfaces/appointment-dto';
import { AppointmentInformationModel } from 'src/app/interfaces/appointment-information-model';
import { AppointmentTableDataModel } from 'src/app/interfaces/appointment-table-data-model';
import { DoctorDTO } from 'src/app/interfaces/doctor-dto';
import { PacientDTO } from 'src/app/interfaces/pacient-dto';
import { ProcedureDTO } from 'src/app/interfaces/procedure-dto';
import { AdminInformationsService } from 'src/app/services/admin-informations.service';
import { PublicInformationsService } from 'src/app/services/public-informations.service';
import { AddAppointmentMatDialogComponent } from './add-appointment-mat-dialog/add-appointment-mat-dialog.component';
import { ChooseTimeIntervalMatDialogComponent } from './choose-time-interval-mat-dialog/choose-time-interval-mat-dialog.component';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {

  constructor(
    private publicInformationsService: PublicInformationsService,
    private adminInformationsServie: AdminInformationsService,
    private liveAnnouncer: LiveAnnouncer,
    public dialog: MatDialog) { }

  displayedColumns: string[] = ['doctorName', 'pacientName', 'procedure', 'startTime', 'endTime', 'delete', 'editStartTime'];

  dataSource: MatTableDataSource<any> = new MatTableDataSource();

  appointmets: AppointmentTableDataModel[] = [];
  pacients: PacientDTO[] = [];
  doctors: DoctorDTO[] = [];
  procedures: ProcedureDTO[] = [];

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
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
    this.openNewTimeDialog(appointment);
  }

  ngOnInit(): void {

    this.adminInformationsServie.getUpcomingAppointments().subscribe(appointments => {
      this.appointmets = appointments.map(function (appointment): AppointmentTableDataModel {
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

    this.adminInformationsServie.getAllPacients().subscribe(pacients => {
      this.pacients = pacients;
    })

    this.publicInformationsService.getAllDoctors().subscribe(doctors => {
      this.doctors = doctors;
    })

    this.publicInformationsService.getAllProcedures().subscribe(procedures => {
      this.procedures = procedures;
    })
  }

  addAppointment() {
    this.openAddAppointmentDialog();
  }

  openAddAppointmentDialog() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.data = {
      doctors: this.doctors,
      pacients: this.pacients,
      procedures: this.procedures
    };

    const dialogRef = this.dialog.open(AddAppointmentMatDialogComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(
      data => {
        if (data) {
          console.log("Dialog output:", data);
          var addedAppointment: AppointmentTableDataModel = 
          {
            doctorName: data.doctorDTO.lastName + " " + data.doctorDTO.firstName,
            doctorId: data.doctorDTO.id,
            pacientName: data.pacientDTO.lastName + " " + data.pacientDTO.firstName,
            pacientId: data.pacientDTO.id,
            procedureName: data.procedureDTO.procedureName,
            procedureId: data.procedureDTO.id,
            startTime: data.startTime,
            endTime: data.endTime,
          }
          this.appointmets.push(addedAppointment);
          this.dataSource.data = this.appointmets;
        }
      }
    );
  }

  openNewTimeDialog(appointment: AppointmentDTO) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.data = {
      appointment: appointment
    };

    const dialogRef = this.dialog.open(ChooseTimeIntervalMatDialogComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(
      data => {
        if (data) {
          console.log("Dialog output:", data);
          var appointmetToUpdate = this.appointmets.filter(a => a == appointment)[0]; // TODO: Write this better!
          console.log(appointmetToUpdate);
          appointmetToUpdate['startTime'] = data['startTime'];
          appointmetToUpdate['endTime'] = data['endTime'];
        }
      }
    );
  }

  isSelectedUpcoming = true;

  showUpcomingAppointmentsOnly() {
    this.isSelectedUpcoming = (!this.isSelectedUpcoming);
    this.isSelectedPrevious = false;
    if (this.isSelectedUpcoming == true) {
      this.adminInformationsServie.getUpcomingAppointments().subscribe(appointments => {
        this.appointmets = appointments.map(function (appointment): AppointmentTableDataModel {
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
    } else {
      this.adminInformationsServie.getAllAppointments().subscribe(appointments => {
        this.appointmets = appointments.map(function (appointment): AppointmentTableDataModel {
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

  isSelectedPrevious = false;

  showPreviousAppointmentsOnly() {
    this.isSelectedPrevious = (!this.isSelectedPrevious);
    this.isSelectedUpcoming = false;
    if (this.isSelectedPrevious == true) {
      this.adminInformationsServie.getPreviousAppointments().subscribe(appointments => {
        this.appointmets = appointments.map(function (appointment): AppointmentTableDataModel {
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
    } else {
      this.adminInformationsServie.getAllAppointments().subscribe(appointments => {
        this.appointmets = appointments.map(function (appointment): AppointmentTableDataModel {
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

  isExpired(row: AppointmentTableDataModel)
  {
    return new Date(row.endTime).getTime() < new Date().getTime();
  }
}
