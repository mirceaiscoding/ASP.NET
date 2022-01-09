import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PacientAppoointmentModel } from 'src/app/interfaces/pacient-appoointment-model';
import { PacientDTO } from 'src/app/interfaces/pacient-dto';
import { AuthService } from 'src/app/services/auth.service';
import { PacientService } from 'src/app/services/pacient.service';

@Component({
  selector: 'app-pacient-profile',
  templateUrl: './pacient-profile.component.html',
  styleUrls: ['./pacient-profile.component.css']
})
export class PacientProfileComponent implements OnInit {

  private id!: number;

  public pacientData!: PacientDTO;

  public pacientAppoointments: PacientAppoointmentModel[] = [];

  constructor(
    private activatedRoute: ActivatedRoute, 
    private pacientService: PacientService,
    private authService: AuthService,
    private router: Router) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params: any) => {
      console.log("Route params", params);
      this.id = params['id'];
      this.pacientService.getPacientData(this.id).subscribe((response: any) => {
        console.log("Pacient data", response);
        this.pacientData = response;
        this.pacientService.getPacientAppointments(this.pacientData.id).subscribe((appointments: any) => {
          console.log("Pacinet appointments", appointments);
          this.pacientAppoointments = appointments;
        })
      })

    });
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate([""]);
  }


}
