import { Component } from '@angular/core';
import { TuiAlertService } from '@taiga-ui/core';
import { TestService } from './services/test.service';
import { tap } from 'rxjs';
import { TelegramService } from './services/telegram.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'dating-chica-senorita';
  constructor(private testService: TestService,
              private telegramService: TelegramService,
              private tuiAlertService: TuiAlertService) {
  }

  ngOnInit(): void {
    console.log(this.telegramService.getAuthToken())
    if (this.telegramService.getAuthToken()) {
      this.testService.getTest()
      .pipe(
        tap((body)=> console.log('123', body)))
      .subscribe();
    }


  }

  protected showNotification(): void {
    this.tuiAlertService
      .open('Basic <strong>HTML</strong>', { label: 'With a heading!' })
      .subscribe();
  }
}
