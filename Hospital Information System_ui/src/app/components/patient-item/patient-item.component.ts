import { Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { Patient } from 'src/app/Models/Patient';


@Component({
  selector: 'app-patient-item',
  templateUrl: './patient-item.component.html',
  styleUrls: ['./patient-item.component.css']
})
export class PatientItemComponent implements OnInit {

  @Input() patient: Patient;
  @Output() deleteEvent = new EventEmitter();


  constructor() { }

  ngOnInit(): void {

  }

  details() {
    alert("details patient with id = \n" + this.patient.id);
  }

  edit() {
    alert("edit patient with id = \n" + this.patient.id);
  }

  delete() {
    this.deleteEvent.emit(this.patient);
  }

}
