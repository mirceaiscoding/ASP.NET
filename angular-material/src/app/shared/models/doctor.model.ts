export class Doctor {
    public id?: number;
    public firstName: string = '';
    public lastName: string = '';
    public phoneNumber: string = '';
    public jobDescription: string = '';

    public constructor(iDoctor: IDoctor)
    {
        this.id = iDoctor.id;
        this.firstName = this.firstName;
        this.lastName = this.lastName;
        this.phoneNumber = this.phoneNumber;
        this.jobDescription = this.jobDescription;
    }
}

interface IDoctor {
    id?: number;
    firstName: string;
    lastName: string;
    phoneNumber: string;
    jobDescription: string;
}