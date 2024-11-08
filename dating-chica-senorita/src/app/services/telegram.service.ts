import { Injectable, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { DictionaryService, UserService } from '../api/dating-chica/services';
import { Observable } from 'rxjs';
import { DictionaryModel } from '../api/dating-chica/models';
import { ApiUserPost$Json$Params } from '../api/dating-chica/fn/user/api-user-post-json';

@Injectable({
  providedIn: 'root',
})
export class TelegramService {
  private webApp: any;

  dictionary!: DictionaryModel;

  constructor(@Inject(DOCUMENT) private document: Document,
              private userService: UserService,
              private dictionaryService: DictionaryService) {
                this.init()
              }

  init() {
    const defaultView = this.document.defaultView as any;
    this.webApp = defaultView?.Telegram?.WebApp;
    if (this.webApp) {
      this.setInitParams();
    } else {
      console.error('Веб-приложение Telegram недоступно.');
    }
  }

  create(params: ApiUserPost$Json$Params){
    return this.userService.apiUserPost$Json(params)
  }

  getDictionary(): Observable<DictionaryModel> {
    return this.dictionaryService.apiDictionaryGet$Json();
  }

  getCities() {
    return this.dictionary.cities;
  }

  getEyesColors() {
    return this.dictionary.eyesColors;
  }

  getGenders() {
    return this.dictionary.genders;
  }

  private setInitParams() {
      // Включаем подтверждение закрытия
      this.webApp.isClosingConfirmationEnabled = true;
      this.setTgWebAppDataLocalStorage(this.webApp.initData)
      // Сообщаем Telegram, что приложение готово
      this.webApp.ready();
  }
  // Метод для включения или отключения подтверждения закрытия
  enableClosingConfirmation(enable: boolean): void {
    if (this.webApp) {
      this.webApp.isClosingConfirmationEnabled = enable;
    } else {
      console.warn('Веб-приложение Telegram недоступно.');
    }
  }

  // Метод для получения данных пользователя
  getUser(): any {
    return this.webApp?.initDataUnsafe || null;
  }

  // Метод для получения `токена` авторизации
  getAuthToken(): string {
    const token = this.webApp?.initData;
    if (token && token.trim().length > 0 && token.trim() !== "query_id") {
      return token;
    } else {
      return this.getTgWebAppDataLocalStorage()
    }
  }

  // Метод для изменения текста основной кнопки
  setMainButtonText(text: string): void {
    if (this.webApp) {
      this.webApp.MainButton.setText(text).show();
    } else {
      console.warn('Веб-приложение Telegram недоступно.');
    }
  }

  // Метод для скрытия основной кнопки
  hideMainButton(): void {
    if (this.webApp) {
      this.webApp.MainButton.hide();
    } else {
      console.warn('Веб-приложение Telegram недоступно.');
    }
  }

  private setTgWebAppDataLocalStorage(token: string) {
    // Проверяем, что строка не состоит только из "query_id" и не пуста
    if (token && token.trim().length > 0 && token.trim() !== "query_id") {
      localStorage.removeItem('tgWebAppDataTokenDating')
      localStorage.setItem('tgWebAppDataTokenDating', token)
    }
  }

  private getTgWebAppDataLocalStorage() {
    return localStorage.getItem('tgWebAppDataTokenDating')!;
  }
}
