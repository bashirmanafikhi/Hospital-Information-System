


export class PaginationFilter {

    pageNumber: Number = 1;
    pageSize: Number = 10;


    
    constructor(pageNumber: Number, 
                pageSize: Number ) {

                    this.pageNumber = pageNumber;
                    this.pageSize = pageSize;
    }
    
}