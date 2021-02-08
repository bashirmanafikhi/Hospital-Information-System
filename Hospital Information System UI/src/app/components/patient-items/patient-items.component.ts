import { Component, OnInit } from '@angular/core';
import { PaginationFilter } from 'src/app/Filters/PaginationFilter';
import { PatientFilter } from 'src/app/Filters/PatientFilter';
import { Patient } from 'src/app/Models/Patient';
import { PatientService } from 'src/app/Services/patient.service';

@Component({
  selector: 'app-patient-items',
  templateUrl: './patient-items.component.html',
  styleUrls: ['./patient-items.component.css']
})
export class PatientItemsComponent implements OnInit {

  totalPages : number;
  totalRecords : number;

  patientFilter: PatientFilter = new PatientFilter(1, 10, "", 0, "");
  patients: Patient[];


  constructor(private patientService: PatientService) { }

  // هدول منشان اجيب الباراميتر من الرابط مشان صفحات الباجينايشين
  //   constructor(private activatedRt: ActivatedRoute){
  //     this.activeRt.queryParams.subscribe(param => {
  //     let param = param["my-param"];
  //     let pageRequest = {
  //      pageSize: 5,
  //      pageIndex: param // if this is the page you are pulling from query param
  //     }
  //     this.changePage(pageRequest);
  //   });
  //  }

  ngOnInit(): void {

    this.patientService.getPatients(this.patientFilter).subscribe(response => {
      this.patients = response.data;
      this.totalPages = response.totalPages;
      this.totalRecords = response.totalRecords;
    });

  }

  delete(patient: Patient) {
    this.patientService.deletePatient(patient.id).subscribe(response => {
      if (response.succeeded) {
        alert("patient with id: " + response.data + " has been deleted successfuly.");
        this.ngOnInit();
      }
    })
  }

  add(patient: Patient) {

    this.patientService.addPatient(patient).subscribe(response => {
      if (response.succeeded) {
        //alert("patient " + response.data + " has been added");
        this.ngOnInit();
      }
    })
  }


  filter(patientFilter) {
    this.patientFilter = patientFilter;
    this.ngOnInit();
  }

  clearFilter() {
    this.patientFilter.reset();
    this.ngOnInit();
  }

  pageChanged(filter: PaginationFilter){
    this.patientFilter.pageNumber = filter.pageNumber;
    this.patientFilter.pageSize = filter.pageSize;
    
    //alert("page changed");
    this.ngOnInit();
  }
}
