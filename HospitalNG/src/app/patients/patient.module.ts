import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { PatientListComponent } from './list/patient-list.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { PatientDetailComponent } from './detail/patient-detail.component';
import { PatientEditComponent } from './edit/patient-edit.component';
import { PatientEditGuard } from './edit/patient-edit.guard';
import { NewPatientComponent } from './new-patient/new-patient.component';



@NgModule({
  imports: [
    SharedModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'patients', component: PatientListComponent },
      { path: 'patients/:id', component: PatientDetailComponent },
      {
        path: 'patients/:id/edit',
        canDeactivate: [PatientEditGuard],
        component: PatientEditComponent
      }
    ])
  ],
  declarations: [
    PatientListComponent,
    PatientDetailComponent,
    PatientEditComponent,
    NewPatientComponent
  ],
  
})
export class PatientModule { }
