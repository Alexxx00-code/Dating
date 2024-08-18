
import { Component } from '@angular/core';
import { TelegramService } from './services/telegram.service';
import {TuiAlertService} from '@taiga-ui/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'DatingWeb';

  constructor(private telegram: TelegramService,
    private tuiAlertService: TuiAlertService) {
   telegram.ready();
  }

  protected showNotification(): void {
      this.tuiAlertService
          .open('Basic <strong>HTML</strong>', {label: 'With a heading!'})
          .subscribe();
  }
}
