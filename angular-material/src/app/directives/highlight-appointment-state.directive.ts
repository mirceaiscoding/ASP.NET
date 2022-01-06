import { Directive, ElementRef, Input, OnInit } from '@angular/core';
import { AppointmentDTO } from '../interfaces/appointment-dto';
import { AppointmentTableDataModel } from '../interfaces/appointment-table-data-model';

@Directive({
  selector: 'my-highlight-appointment[appointment]'
})
export class HighlightAppointmentStateDirective implements OnInit{

  @Input() appointment!: AppointmentDTO | AppointmentTableDataModel;

  pastAppointmentColor = "rgb(228, 227, 227)";
  presentAppointmentColor = "#006064";
  futureAppointmentColor = "white";

  constructor(
    private elr:ElementRef) { }

    ngOnInit() {
      console.log("Highlinghting appointment", this.appointment);
      var currentTime = new Date().getTime();
      var startTime = new Date(this.appointment.startTime).getTime();
      var endTime = new Date(this.appointment.endTime).getTime();
      
      if (endTime < currentTime) {
        this.elr.nativeElement.style.background = this.pastAppointmentColor;
        console.log("pastAppointmentColor");
        return;
      }
      if (startTime > currentTime) {
        this.elr.nativeElement.style.background = this.futureAppointmentColor;
        console.log("futureAppointmentColor");
        return;
      }
      console.log("presentAppointmentColor");
      this.elr.nativeElement.style.background = this.presentAppointmentColor;
    }

}
