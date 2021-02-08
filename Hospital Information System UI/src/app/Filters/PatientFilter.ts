import { PaginationFilter } from '../Filters/PaginationFilter'


export class PatientFilter extends PaginationFilter {


    name: string;
    fileNo: number;
    phoneNumber: string;


    
    constructor(pageNumber: Number,
        pageSize: Number,
        name: string,
        fileNo: number,
        phoneNumber: string) {

        super(pageNumber, pageSize);

        this.name = name;
        this.fileNo = fileNo;
        this.phoneNumber = phoneNumber;
    }

    reset(){
        this.pageNumber = 1;
        this.pageSize = 10;
        this.name = "";
        this.fileNo = 0;
        this.phoneNumber = "";
    }

}