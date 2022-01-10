import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private authService: AuthService,
    private router: Router) {
      this.role = this.authService.getRole();
      if (this.role == "Pacient") {
        var userId = this.authService.getUserId();
        if (userId) {
          this.router.navigate(["profile/" + userId]);
        }
      }
     }

  role: string = "";

  logout(): void {
    this.authService.logout();
    this.router.navigate([""]);
  }

  ngOnInit(): void {
  }

}
