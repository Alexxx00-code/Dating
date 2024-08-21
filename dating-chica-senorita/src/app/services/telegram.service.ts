import { Injectable, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';

@Injectable({
  providedIn: 'root',
})
export class TelegramService {
  private webApp: any;

  constructor(@Inject(DOCUMENT) private document: Document) {
    const defaultView = this.document.defaultView as any;
    this.webApp = defaultView?.Telegram?.WebApp;
    console.log(this.webApp);
    if (this.webApp) {
      this.setInitParams();
    } else {
      console.warn('Веб-приложение Telegram недоступно.');
    }
  }

  private setInitParams(){
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

  // Метод для получения токена авторизации
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
