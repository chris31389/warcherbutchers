export class Error {
    title: string;
    message: string;
    constructor(message?: string, title?: string) {
        if (message) {
            this.message = message;
        }

        if (title) {
            this.title = title;
        }
    }
}