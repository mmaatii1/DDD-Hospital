import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StuffMemberDetailComponent } from './stuff-member-detail/stuff-member-detail.component';
import { StuffMemberListComponent } from './stuff-member-list/stuff-member-list.component';
import { NewStuffMemberComponent } from './new-stuff-member/new-stuff-member.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    StuffMemberDetailComponent,
    StuffMemberListComponent,
    NewStuffMemberComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([
      {
        path: 'stuffMembers',
        component: StuffMemberListComponent
      },
      {
        path: 'stuffMembers/:id',
        component: StuffMemberDetailComponent
      },
      {
        path: 'stuffMembers/:id/edit',
        component: NewStuffMemberComponent
      }
    ])
  ]
})
export class StuffMemberModule { }
