import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  email = new FormControl('', [Validators.required, Validators.email]);

  getEmailErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  submitLogin(event) {
    console.log(event);
    // this._currentUser.createFromFirebaseData(this.detailsForm.value);
    // this._db.UpdateUser(this._currentUser)
    // .then( result => {
    //   this.busy = false;
    //   this._popUp.showInfo('Perfil guardado');
    // })
    // .catch( error => {
    //   this.busy = false;
    //   this._popUp.showError(error);
    // });
  }

}
