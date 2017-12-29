export class Price {
    major: number;
    minor: number;

    constructor(json?: any) {
        this.major = json && json.major ? json.major : 0;
        this.minor = json && json.minor ? json.minor : 0;
    }
}