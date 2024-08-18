import { Component, OnInit } from '@angular/core';
import { TelegramService } from './services/telegram.service';
import { TuiAlertService } from '@taiga-ui/core';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  title = 'DatingWeb';

  constructor(
    private telegram: TelegramService,
    private tuiAlertService: TuiAlertService
  ) {
    telegram.ready();
  }


  ngOnInit(): void {}

  protected showNotification(): void {
    this.tuiAlertService
      .open('Basic <strong>HTML</strong>', { label: 'With a heading!' })
      .subscribe();
  }
}
