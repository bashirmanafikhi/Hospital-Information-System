import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PatientFilter } from 'src/app/Filters/PatientFilter'

@Component({
  selector: 'app-patient-filter',
  templateUrl: './patient-filter.component.html',
  styleUrls: ['./patient-filter.component.css']
})
export class PatientFilterComponent implements OnInit {

  @Input() patientFilter: PatientFilter;
  @Output() filterEvent = new EventEmitter();
  @Output() clearFilterEvent = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
    
  }

  filter() {
    this.filterEvent.emit(this.patientFilter);
  }

  clearFilter() {
    this.clearFilterEvent.emit();
  }

}
