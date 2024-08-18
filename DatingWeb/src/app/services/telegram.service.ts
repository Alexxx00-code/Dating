import { DOCUMENT } from '@angular/common';
import { Inject, Injectable } from '@angular/core';
import { on } from '@telegram-apps/sdk';
import { LaunchParams, retrieveLaunchParams } from '@telegram-apps/sdk';
import { TestService } from './advert.service';
import { tap } from 'rxjs';

export const { initDataRaw } = retrieveLaunchParams();

@Injectable({
  providedIn: 'root',
})
export class TelegramService {

  token: string;
  private window;
  tg;
  constructor(@Inject(DOCUMENT) private _document,
              private testService: TestService) {
    this.window = this._document.defaultView;
    this.tg = this.window.Telegram.WebApp;
    var user = this.window.Telegram.WebAppUser;
    //console.log(user);
    this.tg.isClosingConfirmationEnabled = true;
    //console.log(this.tg);
    this.ready();
    console.log(this.window.Telegram.WebApp.initData);
    console.log(initDataRaw);
    this.token  =  initDataRaw;
    console.log('asssssss', this.token)
    if(this.token.length){
      this.getTest()
    }
  }

  getTest() {
    this.testService.getTest()
    .pipe(
      tap((body)=> console.log('123',body))
    )
    .subscribe();
  }

  removeListener = on('viewport_changed', payload => {
    if(payload.is_expanded){
        this.tg.isVerticalSwipesEnabled = false;
    }
  });

  sendData(data: object) {
    this.tg.sendData(JSON.stringify(data));
  }

  ready() {
    this.tg.ready();
  }
}