import { ComparisonOperator } from "./";

export class ComparisonOperatorReferenceData {
    id: string;
    operator: ComparisonOperator;

    constructor(id, operator) {
        this.id = id;
        this.operator = operator;
    }
}