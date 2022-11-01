import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewDepartmentComponent } from './new-department/new-department.component';
import { DepartmentListComponent } from './department-list/department-list.component';
import { DepartmentDetailComponent } from './department-detail/department-detail.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    NewDepartmentComponent,
    DepartmentListComponent,
    DepartmentDetailComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([
      {
        path: 'departments',
        component: DepartmentListComponent
      },
      {
        path: 'departments/:id',
        component: DepartmentDetailComponent
      },
      {
        path: 'departments/:id/edit',
        component: NewDepartmentComponent
      }
    ])
  ]
})
export class DepartmentModule { }
