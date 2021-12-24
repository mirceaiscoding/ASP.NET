import { DoctorDTO } from "./doctor-dto";
import { PacientDTO } from "./pacient-dto";
import { ProcedureDTO } from "./procedure-dto";

export interface AppointmentInformationModel {
    pacientDTO: PacientDTO;
    doctorDTO: DoctorDTO;
    procedureDTO: ProcedureDTO;
    startTime: Date;
    endTime: Date;
}
