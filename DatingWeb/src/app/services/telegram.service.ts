import { DOCUMENT } from '@angular/common';
import { Inject, Injectable } from '@angular/core';
import { on } from '@telegram-apps/sdk';


@Injectable({
  providedIn: 'root',
})
export class TelegramService {
  private window;
  tg;
  constructor(@Inject(DOCUMENT) private _document) {
    this.window = this._document.defaultView;
    this.tg = this.window.Telegram.WebApp;
    var user = this.window.Telegram.WebAppUser;
    //console.log(user);
    this.tg.isClosingConfirmationEnabled = true;
    //console.log(this.tg);
    this.ready();
    console.log(this.window.Telegram.WebApp.initData);
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