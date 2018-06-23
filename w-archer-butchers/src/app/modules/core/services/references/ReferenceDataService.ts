import { Injectable, Inject } from "@angular/core";
import { AuthHttp } from "angular2-jwt";
import { Response } from "@angular/http";
import { ErrorService } from "../error";
import { ReferenceData, ComparisonOperatorReferenceData, ComparisonOperator } from "./";

import { Observable } from "rxjs/Rx";

@Injectable()
export class ReferenceDataService {
    private url = "api/v1/references/";

    constructor(
        private readonly authHttp: AuthHttp,
        @Inject("SERVER_URL") private readonly approvalsUrl: string,
        private readonly errorService: ErrorService
    ) {
    }

    getInclusiveLevels = (): Observable<ReferenceData[]> => this.getReferenceData("inclusiveLevels");
    getBooleanLogics = (): Observable<ReferenceData[]> => this.getReferenceData("booleanLogics");
    getDataTypes = (): Observable<ReferenceData[]> => this.getReferenceData("dataTypes");

    getOperatorsForDataTypeId =
        (dataTypeId: number): Observable<ComparisonOperatorReferenceData[]> => {
            return this.authHttp.get(this.approvalsUrl + this.url + `operators/${dataTypeId}`)
                .map((response: Response) => {
                    const json = response.json();
                    const referenceDatas = new Array<ComparisonOperatorReferenceData>();

                    if (json !== null && json !== undefined) {
                        Object.keys(json).forEach((key) => {
                            referenceDatas.push(new ComparisonOperatorReferenceData(Number(key), json[key]));
                        });
                    }

                    return referenceDatas;
                })
                .catch(this.handleError);
        };

    getOperators = (): Observable<{ [id: string]: ComparisonOperatorReferenceData[] }> => {
        return this.authHttp.get(this.approvalsUrl + this.url + "operators")
            .map((response: Response) => {
                const json = response.json();
                const referenceDatas = {};

                if (json !== null && json !== undefined) {
                    Object.keys(json).forEach((key) => {
                        const referenceData = new Array<ComparisonOperatorReferenceData>();
                        const innerJson = json[key];
                        if (innerJson !== null && innerJson !== undefined) {
                            Object.keys(innerJson).forEach((innerKey) => {
                                referenceData.push(new ComparisonOperatorReferenceData(Number(innerKey),
                                    new ComparisonOperator(innerJson[innerKey])));
                            });
                        }
                        referenceDatas[key] = referenceData;
                    });
                }

                return referenceDatas;
            })
            .catch(this.handleError);
    }

    private getReferenceData(urlEndpoint: string): Observable<ReferenceData[]> {
        return this.authHttp.get(this.approvalsUrl + this.url + urlEndpoint)
            .map((response: Response) => {
                const json = response.json();
                const referenceDatas = new Array<ReferenceData>();

                if (json !== null && json !== undefined) {
                    Object.keys(json).forEach((key) => {
                        referenceDatas.push(new ReferenceData(Number(key), json[key]));
                    });
                }

                return referenceDatas;
            })
            .catch(this.handleError);
    }

    private handleError =
        (response: Response) => this.errorService.handleHttpResponseError(response, "Reference Data Error");
}