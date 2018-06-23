export class Price {
    major = 0;
    private _minor = 0;

    get minor(): number { return this._minor; }

    set minor(value: number) {
        const newNumber = value + this.minor;
        if (newNumber >= 100) {
            this._minor = newNumber % 100;
            this.major = this.major + Math.floor(newNumber / 100);
        } else {
            this._minor = value;
        }
    }

    constructor(json?: any) {
        this.major = json && json.major ? json.major : 0;
        this.minor = json && json.minor ? json.minor : 0;
    }

    isZero(): boolean {
        return this.major === 0 && this.minor === 0;
    }

    lessThan(price: Price): boolean {
        if (this.major < price.major) return true;
        if (this.major > price.major) return false;
        if (this.minor < price.minor) return true;
        return false;
    }

    greaterThan(price: Price): boolean {
        if (this.major > price.major) return true;
        if (this.major < price.major) return false;
        if (this.minor > price.minor) return true;
        return false;
    }

    lessThanOrEqualTo(price: Price): boolean {
        if (this.major < price.major) return true;
        if (this.major > price.major) return false;
        if (this.minor <= price.minor) return true;
        return false;
    }

    greaterThanOrEqualTo(price: Price): boolean {
        if (this.major > price.major) return true;
        if (this.major < price.major) return false;
        if (this.minor >= price.minor) return true;
        return false;
    }

    add(price: Price): Price {
        const newPrice = new Price();
        newPrice.major = this.major + price.major;
        newPrice.minor = this.minor + price.minor;
        return newPrice;
    }

    multiplyBy(value: number): Price {
        const newPrice = new Price();
        newPrice.major = this.major * value;
        newPrice.minor = this.minor * value;
        return newPrice;
    }
}