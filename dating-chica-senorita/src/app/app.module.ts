import { CUSTOM_ELEMENTS_SCHEMA, NgModule, provideZoneChangeDetection,} from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { TokenInterceptor } from './services/token.interceptor ';
import { TabBarComponent } from './components/tab-bar/tab-bar.component';
import { MainContainerComponent } from './components/main-container/main-container.component';
import { BarComponent } from './components/bar/bar.component';
import { TAIGA_UI_MODULES } from "./all-module-ui/taiga-ui-all-module";
import { NG_EVENT_PLUGINS } from '@taiga-ui/event-plugins';

@NgModule({
  declarations: [
    AppComponent,
    TabBarComponent,
    BarComponent,
    MainContainerComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    ...TAIGA_UI_MODULES,
],
  providers: [
    NG_EVENT_PLUGINS,
    provideAnimations(),
    provideRouter(routes),
    provideHttpClient(withInterceptorsFromDi()),
    provideZoneChangeDetection({ eventCoalescing: true }),
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent],
})
export class AppModule {}
