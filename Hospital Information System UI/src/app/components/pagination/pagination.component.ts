import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PaginationFilter } from 'src/app/Filters/PaginationFilter';


@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {


  @Input() pagesize :Number = 10;
  pageNumbers : Number[];

  @Input() totalPages: number;
  @Input() currentPage: number;

  @Output() pageChangedEvent = new EventEmitter();

  constructor() {
    
  }

  ngOnChanges(){

    this.pageNumbers = Array(this.totalPages).fill(0).map((x,i)=>i+1);
  }



  ngOnInit(): void {
  }

  next(){
    
    if (this.currentPage +1 <= this.totalPages){
    this.currentPage = this.currentPage +1;

    let paginationFilter = new PaginationFilter(this.currentPage,this.pagesize);
    this.pageChangedEvent.emit(paginationFilter);
    }
  }

  previous(){

    if (this.currentPage - 1 >0){

      this.currentPage = this.currentPage -1;
      
      let paginationFilter = new PaginationFilter(this.currentPage,this.pagesize);
      this.pageChangedEvent.emit(paginationFilter);
    }
  }

  pageChanged(value) {
    this.currentPage = value;
    let paginationFilter = new PaginationFilter(this.currentPage,this.pagesize);
    this.pageChangedEvent.emit(paginationFilter);
  }

  onSelectChange(value) {
    this.pagesize =value;
    this.currentPage = 1;
    let paginationFilter = new PaginationFilter(this.currentPage,this.pagesize);
    this.pageChangedEvent.emit(paginationFilter);
  }
}
