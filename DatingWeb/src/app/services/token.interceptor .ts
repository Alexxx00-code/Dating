import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, throwError } from 'rxjs';
import { initDataRaw, TelegramService } from './telegram.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  refresh = false;
  constructor( private telegramService: TelegramService, private router: Router) {}

  intercept(req: HttpRequest<unknown>,next: HttpHandler): Observable<HttpEvent<unknown>> {
    req = req.clone({
      setHeaders: {
        Authorization: 'tma ' + initDataRaw,
      },
    });
    return next.handle(req).pipe(
      catchError((err: HttpErrorResponse) => {
        console.warn(err.error);
        if (err.status === 401) {
          this.telegramService.getTest();
        }
        return throwError(() => err);
      })
    );
  }

  reloadCurrentRoute() {
    const currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
}
