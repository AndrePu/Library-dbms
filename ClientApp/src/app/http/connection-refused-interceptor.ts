import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToasterService, Toast, BodyOutputType } from 'angular2-toaster';

@Injectable()
export class ConnectionRefusedInterceptor implements HttpInterceptor {

    constructor(private toastService: ToasterService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const callPipe = next.handle(request).pipe(
            catchError((err: any) => {
                const toast: Toast = {
                    type: 'error',
                    body: 'Huston, we have some problems with server',
                    bodyOutputType: BodyOutputType.Default
                };

                this.toastService.pop(toast);
                return throwError(err);
            })
        );

        return callPipe;
    }
}
