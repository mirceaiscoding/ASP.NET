import { Pipe, PipeTransform } from '@angular/core';
import { DoctorDTO } from '../interfaces/doctor-dto';
import { PacientDTO } from '../interfaces/pacient-dto';

@Pipe({
  name: 'idFullName'
})
export class IdFullNamePipe implements PipeTransform {

  transform(person: DoctorDTO | PacientDTO): string {
    return "#" + person?.id + ": " + person?.lastName + " " + person?.firstName;
  }

}
