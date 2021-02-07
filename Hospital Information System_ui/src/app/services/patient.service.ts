import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedResponse } from 'src/app/Models/PagedResponse';
import { Response } from 'src/app/Models/Response';
import { Patient } from 'src/app/Models/Patient';
import { PatientFilter } from '../Filters/PatientFilter';


@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private http: HttpClient) { }

  getPatients(patientFilter: PatientFilter): Observable<PagedResponse<Patient[]>>{
    return this.http.get<PagedResponse<Patient[]>>("https://localhost:44385/patients?"+
                                                    "PageNumber="+patientFilter.pageNumber+
                                                    "&PageSize="+patientFilter.pageSize+
                                                    "&Name="+patientFilter.name+
                                                    "&FileNo="+patientFilter.fileNo+
                                                    "&PhoneNumber"+patientFilter.phoneNumber);
  }

  addPatient(patient: Patient) : Observable<Response<string>> {
    return this.http.post<Response<string>>("https://localhost:44385/patients", patient);
  }

  deletePatient(id: String) : Observable<Response<string>>{
    return this.http.delete<Response<string>>("https://localhost:44385/patients/"+id);
  }


}

