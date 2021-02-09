import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Patient } from 'src/app/Models/Patient';
import { Gender } from 'src/app/Models/Gender';

@Component({
  selector: 'app-patient-add',
  templateUrl: './patient-add.component.html',
  styleUrls: ['./patient-add.component.css']
})
export class PatientAddComponent implements OnInit {

  genderKeys =[0,1];
  genderValues = Gender;
  patient:Patient;
  @Output() addEvent = new EventEmitter();

  constructor() {
  }

  ngOnInit(): void {
    this.patient = new Patient("",1);
  }

  addPatient(){
    this.addEvent.emit(this.patient);
  }

}
