import { NumberValueAccessor } from "@angular/forms";

export class Patient {

    id: String;
    name: String;
    fileNo: Number;
    citizenId: String;
    birthdate: Date;
    gender: 0 | 1;
    natinality: String;
    phoneNumber: String;
    email: String;
    country: String;
    city: String;
    street: String;
    address1: String;
    address2: String;
    contactPerson: String;
    contactRelation: String;
    contactPhone: String;
    firstVisitDate: Date;
    recordCreationDate: Date;


    constructor(
        name?: String,
        fileNo?: Number
    ) {
        this.name = name;
        this.fileNo = fileNo;
    }


}