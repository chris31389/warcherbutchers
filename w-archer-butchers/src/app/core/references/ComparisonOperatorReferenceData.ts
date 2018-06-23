import { ComparisonOperator } from "./ComparisonOperator";

export class ComparisonOperatorReferenceData {
    id: string;
    operator: ComparisonOperator;

    constructor(id, operator) {
        this.id = id;
        this.operator = operator;
    }
}