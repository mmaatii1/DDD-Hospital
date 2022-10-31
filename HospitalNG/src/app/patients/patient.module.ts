import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { PatientListComponent } from './list/patient-list.component';
import { SharedModule } from '../shared/shared.module';
import { PatientDetailComponent } from './detail/patient-detail.component';
import { NewPatientComponent } from './new-patient/new-patient.component';


@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild([
      { path: 'patients', component: PatientListComponent },
      { path: 'patients/:id', component: PatientDetailComponent },
      {
        path: 'patients/:id/edit',
        component: NewPatientComponent
      }
    ])
  ],
  declarations: [
    PatientListComponent,
    PatientDetailComponent,
    NewPatientComponent,
  ],

})
export class PatientModule { }
