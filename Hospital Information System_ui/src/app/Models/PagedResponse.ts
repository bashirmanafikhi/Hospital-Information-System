import { from } from "rxjs";
import { Response } from 'src/app/Models/Response'


export class PagedResponse<T> extends Response<T> {


  pageNumber: number;
  pageSize: number;
  totalPages: number;
  totalRecords: number;

  
  constructor(data: T,
    succeeded: boolean,
    errors: string[],
    message: string,
    pageNumber: number,
    pageSize: number,
    totalPages: number,
    totalRecords: number) {


    super(data, succeeded, errors, message);


    this.pageNumber = pageNumber;
    this.pageSize = pageSize;
    this.totalPages = totalPages;
    this.totalRecords = totalRecords;

  }
}