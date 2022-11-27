import { RoomModule } from './rooms/room.module';
import { PatientModule } from './patients/patient.module';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { WelcomeComponent } from './home/welcome.component';
import { DepartmentModule } from './department/department.module';
import { TypeOfStuffMemberModule } from './typeOfStuffMember/type-of-stuff-member.module';
import { StuffMemberModule } from './stuffMember/stuff-member.module'; 

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'welcome', component: WelcomeComponent },
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      { path: '**', redirectTo: 'not-found', pathMatch: 'full' }
    ]),
    PatientModule,
    RoomModule,
    DepartmentModule,
    TypeOfStuffMemberModule,
    StuffMemberModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
