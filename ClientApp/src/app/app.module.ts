import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatTabsModule } from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ConnectionRefusedInterceptor } from './http/connection-refused-interceptor';
import { ToasterModule } from 'angular2-toaster';
import { StudentModule } from './student/student.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatTabsModule,
    ToasterModule.forRoot(),
    StudentModule
  ],
  providers: [
  {
    provide: HTTP_INTERCEPTORS, useClass: ConnectionRefusedInterceptor, multi: true
  },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
