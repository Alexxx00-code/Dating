import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TelegramService } from './services/telegram.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [TelegramService]
})
export class AppComponent {
  title = 'DatingWeb';

  telegram = inject(TelegramService);
  constructor() {
    this.telegram.ready();
  }
}
