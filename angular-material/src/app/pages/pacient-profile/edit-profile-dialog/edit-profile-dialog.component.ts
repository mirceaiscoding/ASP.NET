import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PacientDTO } from 'src/app/interfaces/pacient-dto';
import { PacientService } from 'src/app/services/pacient.service';

@Component({
  selector: 'app-edit-profile-dialog',
  templateUrl: './edit-profile-dialog.component.html',
  styleUrls: ['./edit-profile-dialog.component.css']
})
export class EditProfileDialogComponent implements OnInit {

  public pacientData!: PacientDTO;

  form = new FormGroup({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    phoneNumber: new FormControl('', []),
    dateOfBirth: new FormControl('', [Validators.required]),
  }, {});


  constructor(
    private dialogRef: MatDialogRef<EditProfileDialogComponent>,
    private pacientService: PacientService,
    @Inject(MAT_DIALOG_DATA) data) {
      this.pacientData = data.pacientData;
  }

  ngOnInit(): void {
    this.form.setValue({
      'firstName': this.pacientData.firstName,
      'lastName': this.pacientData.lastName,
      'phoneNumber': this.pacientData.phoneNumber,
      'dateOfBirth': this.pacientData.dateOfBirth,
    })
  }

  save() {
    if (this.form.valid) {
      var updatedPacient: PacientDTO = {
        id: this.pacientData.id,
        firstName: this.form.controls['firstName'].value,
        lastName: this.form.controls['lastName'].value,
        phoneNumber: this.form.controls['phoneNumber'].value,
        dateOfBirth: this.form.controls['dateOfBirth'].value,
        userId: this.pacientData.userId
      };
      this.pacientService.updatePacientData(this.pacientData.id, updatedPacient).subscribe((response: any) => {
        this.dialogRef.close(response);
      })
    }
  }

  close() {
    this.dialogRef.close();
  }

}
