import { Component } from '@angular/core';
import { TuiAlertService } from '@taiga-ui/core';

@Component({
  selector: 'app-main-container',
  templateUrl: './main-container.component.html',
  styleUrl: './main-container.component.css',
})
export class MainContainerComponent {
  constructor(private tuiAlertService: TuiAlertService) {}

  protected showNotification(): void {
    this.tuiAlertService
      .open('Basic <strong>HTML</strong>', { label: 'With a heading!' })
      .subscribe();
  }
}
