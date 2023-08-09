import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthInterceptor } from 'src/services/auth.interceptor';
import { LayoutModule } from './layouts/layout.module';
import { RouterModule, Routes } from '@angular/router';
import { MainModule } from './main/main.module';
import { LoginModule } from './login/login.module';
import { SignupModule } from './signup/signup.module';
import { ChartsModule } from './charts/charts.module';
import { CalendarModule } from './calendar/calendar.module';
import { AddjournalModule } from './addjournal/addjournal.module';
import { ViewjournalModule } from './viewjournal/viewjournal.module';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/main',
    pathMatch: 'full',
  },
];

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    LayoutModule,
    MainModule,
    LoginModule,
    SignupModule,
    ChartsModule,
    CalendarModule,
    AddjournalModule,
    ViewjournalModule,
    RouterModule.forRoot(routes),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
