import { GlobalErrorHandlerService } from './global-error-handling/global-error-handler.service';
import { BadRequestComponent } from './global-api-handling/error-pages/bad-request.component';
import { MatSelectModule } from '@angular/material/select';
import { NgModule, Component, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { GlobalHttpInterceptorService } from './global-api-handling/global-http-interceptor.service';
import { RouterModule } from '@angular/router';
import { NotFoundComponent } from './global-api-handling/error-pages/not-found/not-found.component';
import { InternalServerErrorComponent } from './internal-server-error/internal-server-error.component';



@NgModule({
  imports: [
    CommonModule,
    MatSelectModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      {
        path: 'bad-request',
        component: BadRequestComponent
      },
      {
        path: 'not-found',
        component: NotFoundComponent
      },
      {
        path: 'server-error',
        component: InternalServerErrorComponent
      }
    ])
  ],
  declarations: [
    BadRequestComponent,
    NotFoundComponent,
    InternalServerErrorComponent
  ],
  exports: [
    CommonModule,
    FormsModule,
    MatSelectModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: GlobalHttpInterceptorService, multi: true },
    { provide: ErrorHandler, useClass: GlobalErrorHandlerService }
  ]
})
export class SharedModule { }
