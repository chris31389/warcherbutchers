import { Injectable, } from "@angular/core";
// import { AuthHttp } from "angular2-jwt";
import { ResponseContentType, Response } from "@angular/http";
import { HttpClient } from "@angular/common/http";
// import * as FileSaver from "file-saver";

@Injectable()
export class DownloadService {
    constructor(
        private readonly authHttp: HttpClient,
    ) {
    }

    downloadFile(url: string) {
/*         this.authHttp.get(url, { responseType: ResponseContentType.Blob })
            .subscribe((response: Response) => {
                var headers = response.headers;
                var contentDisposition = headers.get("content-disposition");
                var fileName = this.getFileName(contentDisposition);
                //                    FileSaver.saveAs(response.blob(), fileName);
            },
                this.handleError);
 */    }

    private getFileName(contentDisposition: string): string {
        if (contentDisposition && contentDisposition.indexOf('attachment') !== -1) {
            const filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
            const matches = filenameRegex.exec(contentDisposition);
            if (matches != null && matches[1]) {
                const fileName = matches[1].replace(/['"]/g, '');
                return fileName;
            }
        }
        return "not-known-file-name";
    }

    private handleError = (response: Response) => {} // this.errorService.handleHttpResponseError(response, "Download Error");
}