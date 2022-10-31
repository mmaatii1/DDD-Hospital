import { MatSelectModule } from '@angular/material/select';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  imports: [
    CommonModule,
    MatSelectModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
  ],
  declarations: [
  ],
  exports: [
    CommonModule,
    FormsModule,
    MatSelectModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
  ]
})
export class SharedModule { }
