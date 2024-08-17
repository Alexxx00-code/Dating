import {
  CUSTOM_ELEMENTS_SCHEMA,
  NgModule,
  provideZoneChangeDetection,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  BrowserAnimationsModule,
  provideAnimations,
} from '@angular/platform-browser/animations';
import { provideRouter } from '@angular/router';
import { NG_EVENT_PLUGINS } from '@taiga-ui/event-plugins';
import { routes } from './app.routes';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { TAIGA_UI_MODULES } from './all-ui-module.ts/taiga-ui-all-module';
import { AppBarComponent } from './components/app-bar/app-bar.component';
import { MainContainerComponent } from './components/main-container/main-container.component';
import { TabBarComponent } from './components/tab-bar/tab-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    AppBarComponent,
    MainContainerComponent,
    TabBarComponent
  ],
  imports: [
    ...TAIGA_UI_MODULES,
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [
    provideAnimations(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    NG_EVENT_PLUGINS,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent],
})
export class AppModule {}
