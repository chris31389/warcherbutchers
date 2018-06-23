export class ComparisonOperator {
    urlValue: string;
    name: string;

    constructor(data?: any) {
        if (data !== undefined && data !== null) {
            if (data.urlValue !== undefined && data.urlValue !== null) {
                this.urlValue = data.urlValue;
            }
            if (data.name !== undefined && data.name !== null) {
                this.name = data.name;
            }   
        }
    }
}