import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TypeOfStuffMemberListComponent } from './type-of-stuff-member-list/type-of-stuff-member-list.component';
import { NewTypeOfStuffMemberComponent } from './new-type-of-stuff-member/new-type-of-stuff-member.component';
import { TypeOfStuffMemberDetailComponent } from './type-of-stuff-member-detail/type-of-stuff-member-detail.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    TypeOfStuffMemberListComponent,
    NewTypeOfStuffMemberComponent,
    TypeOfStuffMemberDetailComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([
      {
        path: 'typesOfStuffMembers',
        component: TypeOfStuffMemberListComponent
      },
      {
        path: 'typesOfStuffMembers/:id',
        component: TypeOfStuffMemberDetailComponent
      },
      {
        path: 'typesOfStuffMembers/:id/edit',
        component: NewTypeOfStuffMemberComponent
      }
    ])
  ]
})
export class TypeOfStuffMemberModule { }
