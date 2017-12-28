export class Price {
    major: number;
    minor: number;

    constructor(json?: any) {
        if (json) {
            this.major = json.major ? json.major : 0;
            this.minor = json.minor ? json.minor : 0;
        }
    }
}