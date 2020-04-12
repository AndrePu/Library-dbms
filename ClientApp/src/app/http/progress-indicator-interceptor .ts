import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class ProgressIndicatorInterceptor implements HttpInterceptor {

    public loading = false;

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        this.loading = true;
        const callPipe = next.handle(request).pipe(
            map(event => {
                if (event instanceof HttpResponse) {
                    this.loading = false;
                }
                return event;
            })
        );

        return callPipe;
    }
}
