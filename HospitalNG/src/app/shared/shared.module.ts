import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ModalComponent } from './modal/modal.component';



@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [
    ModalComponent
  ],
  exports: [
    CommonModule,
    FormsModule,
    ModalComponent
  ]
})
export class SharedModule { }
