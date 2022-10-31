import { MatSelectModule } from '@angular/material/select';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalComponent } from './modal/modal.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  imports: [
    CommonModule,
    MatSelectModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
  ],
  declarations: [
    ModalComponent
  ],
  exports: [
    CommonModule,
    FormsModule,
    ModalComponent,
    MatSelectModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
  ]
})
export class SharedModule { }
