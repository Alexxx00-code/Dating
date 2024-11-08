import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { catchError, mergeAll, Observable, of, Subject, tap, throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { TuiAlertService } from '@taiga-ui/core';

const MAX_CONCURRENT = 3;
@Injectable({
  providedIn: 'root'
})
export class FormSubmitServiceService {
  createUserForm!: FormGroup;
  userForm!: FormGroup;
  private readonly queue$ = new Subject<Observable<unknown>>();

  constructor(private tuiAlertService: TuiAlertService) {
    this.queue$.pipe(mergeAll(MAX_CONCURRENT), takeUntilDestroyed()).subscribe();
  }

  initCreateUserForm(fb: FormBuilder): void {
    this.createUserForm = fb.group({
      Firstname: [null,[Validators.required]],
      Birthdate: [null,[Validators.required]],
      GenderId: [null,[Validators.required]],
      SexOrientationId: [null,[Validators.required]],
      Latitude: [null,[Validators.required]],
      Longitude: [null,[Validators.required]],
    });
    this.createUserForm.markAllAsTouched();
  }

  mapValuesToUserForm(data: any): void {
    this.userForm.patchValue({
    });
  }


  /**
   * Подтверждение формы обработки лида
   * @param form - форма
   * @param request - запрос на обработку
   * @param messageContent - сообщение при успешной обработке
   */
  submitForm(form: FormGroup,
             request: Observable<void>,
             messageContent: string) {
    this.disableForm(form);
    return this.request(form, request, messageContent);
  }

  /**
   * Выполнение запроса на обработку
   * @param form - форма
   * @param request - запрос на обработку
   * @param messageContent - сообщение при успешной обработке
   */
  private request(form: FormGroup,
                  request: Observable<void>,
                  messageContent: string) {
    return request.pipe(
      tap(() => {
        form.reset();
        this.queue$.next(this.tuiAlertService.open(messageContent),);
        this.enableForm(form);
      //  this.navigationService.backPage();
        return of({});
      }),
      catchError((requestError: HttpErrorResponse) => {
        this.enableForm(form);
        return throwError(() => requestError);
      }));
  }

  /**
   * Разблокировать форму
   */
  private enableForm(form: FormGroup): void {
    form.enable({ emitEvent: false });
  //  this.businessCardService.spinningCard$.next(false);
  }

  /**
   * Заблокировать форму
   */
  private disableForm(form: FormGroup): void {
    form.disable({ emitEvent: false });
  //  this.businessCardService.spinningCard$.next(true);
  }
}
function takeUntilDestroyed(): import("rxjs").OperatorFunction<unknown, unknown> {
  throw new Error('Function not implemented.');
}

