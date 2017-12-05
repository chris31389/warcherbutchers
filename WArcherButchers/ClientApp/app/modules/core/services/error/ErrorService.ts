import { Error } from "./";
import { Injectable, EventEmitter } from "@angular/core";
import { Response } from "@angular/http";
import { Observable } from "rxjs/Rx";

@Injectable()
export class ErrorService {
    private errorRaised = new EventEmitter<Error>();
    raiseError = (error: Error) => this.errorRaised.emit(error);
    listen = (callback) => this.errorRaised.subscribe(callback);

    handleHttpResponseError = (error: Response, optionaltitle: string) => {
        const errorText = error.text();

        const localError = errorText.length === 0
            ? new Error(`${error.url} (${error.status}, ${error.statusText})`, optionaltitle)
            : new Error(JSON.parse(errorText));
        this.raiseError(localError);
        return Observable.throw(error);
    }
}