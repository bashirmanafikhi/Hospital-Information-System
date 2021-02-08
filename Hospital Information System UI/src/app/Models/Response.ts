export class Response<T> {

    constructor(public data: T, 
                public succeeded: boolean, 
                public errors: string[], 
                public message: string) {

    }
    
}