import { Component, OnDestroy, OnInit } from '@angular/core';
import { TuiAlertService } from '@taiga-ui/core';
import { Subject, takeUntil, tap } from 'rxjs';
import { TelegramService } from './services/telegram.service';
import { autoDestroy } from './shared/basic-functions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'dating-chica-senorita';
  private componentDestroy$: Subject<void> = new Subject<void>();
  constructor(private telegramService: TelegramService,
              private tuiAlertService: TuiAlertService) {
  }

  ngOnInit(): void {
    if (this.telegramService.getAuthToken()) {
      this.getDictionary();
    }
  }

  getDictionary(){
    this.telegramService.getDictionary()
      .pipe(
        tap((dic)=> this.telegramService.dictionary = dic),
        takeUntil(this.componentDestroy$))
      .subscribe();
  }

  showNotification(): void {
    this.tuiAlertService
      .open('Basic <strong>HTML</strong>', { label: 'With a heading!' })
      .subscribe();
  }

  ngOnDestroy(): void {
    autoDestroy([this.componentDestroy$])
  }
}
