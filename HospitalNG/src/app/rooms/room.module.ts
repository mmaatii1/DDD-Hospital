import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { NewRoomComponent } from './new-room/new-room.component';
import { RoomListComponent } from './room-list/room-list.component';
import { RoomDetailComponent } from './room-detail/room-detail.component';



@NgModule({
  declarations: [
    NewRoomComponent,
    RoomListComponent,
    RoomDetailComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([
      { path: 'rooms', component: RoomListComponent },
      { path: 'rooms/:id', component: RoomDetailComponent },
      {
        path: 'rooms/:id/edit',
        component: NewRoomComponent
      }
    ])
  ]
})
export class RoomModule { }
