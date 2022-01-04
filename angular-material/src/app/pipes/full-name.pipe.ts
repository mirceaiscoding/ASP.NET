import { Pipe, PipeTransform } from '@angular/core';
import { DoctorDTO } from '../interfaces/doctor-dto';
import { PacientDTO } from '../interfaces/pacient-dto';

@Pipe({
  name: 'fullName'
})
export class FullNamePipe implements PipeTransform {

  transform(person: DoctorDTO | PacientDTO): string {
    return person?.lastName + " " + person?.firstName;
  }

}
