import { AuthModel } from "./auth-model";
import { PacientModel } from "./pacient-model";

export interface PacientRegistrationModel {
    registerModel: AuthModel;
    pacientDTO: PacientModel;
}
