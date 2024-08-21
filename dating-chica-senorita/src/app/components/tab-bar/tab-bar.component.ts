import { Component } from '@angular/core';
import { TuiAlertService } from '@taiga-ui/core';

@Component({
  selector: 'app-tab-bar',
  templateUrl: './tab-bar.component.html',
  styleUrl: './tab-bar.component.scss'
})
export class TabBarComponent {
  constructor(private tuiAlertService: TuiAlertService) {}

  protected activeItemIndex = 1;

  protected readonly items = [
    {
      text: 'Favorites',
      icon: '@tui.heart',
      badge: 3,
    },
    {
      text: 'Calls',
      icon: '@tui.phone',
      badge: 1234,
    },
    {
      text: 'Profile',
      icon: '@tui.user',
    },
    {
      text: 'Settings and configuration',
      icon: '@tui.settings',
      badge: 100,
    },
    {
      text: 'More',
      icon: '@tui.ellipsis',
    },
  ];

  protected onClick(item: any): void {
    item.badge = 0;
    this.tuiAlertService
      .open(this.activeItemIndex, { label: item.text })
      .subscribe();
  }
}
