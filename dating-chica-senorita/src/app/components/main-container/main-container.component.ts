import { Component } from '@angular/core';
import { TuiAlertService } from '@taiga-ui/core';

@Component({
  selector: 'app-main-container',
  templateUrl: './main-container.component.html',
  styleUrl: './main-container.component.scss'
})
export class MainContainerComponent {
  constructor(private tuiAlertService: TuiAlertService) {}

  protected showNotification(): void {
    this.tuiAlertService
      .open('Basic <strong>HTML</strong>', { label: 'With a heading!' })
      .subscribe();
  }

  expanded = false;
  open = false;
  switch = false;

  drawer = {
      Components: [
          {name: 'Button', icon: 'ICON'},
          {name: 'Input', icon: 'ICON'},
          {name: 'Tooltip', icon: 'ICON'},
      ],
      Essentials: [
          {name: 'Getting started', icon: 'ICON'},
          {name: 'Showcase', icon: 'ICON'},
          {name: 'Typography', icon: 'ICON'},
      ],
  };
}
