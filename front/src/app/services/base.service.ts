import { environment } from './../../environments/environment';
import { HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { throwError } from "rxjs";

export abstract class BaseService {

    protected UrlServiceV1: string = environment.apiUrlv1;

    protected obterHeaderJson() {
        return {
            headers: new HttpHeaders({
                'Content-Type' : 'application/json'
            })
        };
    }

    protected extractData(response: Response | any) {
        return response.data || {};
    }

    protected serviceError(response: Response | any) {
        let customError: string[] = [];

        if(response instanceof HttpErrorResponse) {

            if(response.statusText === "Unknown Error") {
                customError.push("Ocorreu um erro desconhecido");
                response.error.errors = customError;
            }

            console.log(response);
            return throwError(response);
        }
    }    
}