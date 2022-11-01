import { Component, OnInit } from '@angular/core';
import { Room } from '../Room';
import { RoomService } from '../room.service';

@Component({
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.css']
})
export class RoomListComponent implements OnInit {

  pageTitle = 'Room List';
  imageWidth = 50;
  imageMargin = 2;
  showImage = false;
  errorMessage = '';

  _listFilter = '';
  get listFilter(): string {
    return this._listFilter;
  }
  set listFilter(value: string) {
    this._listFilter = value;
    this.filteredRooms = this.listFilter
      ? this.performFilter(this.listFilter) : this.rooms;
  }

  filteredRooms: Room[] = [];
  rooms: Room[] = [];

  constructor(private roomService: RoomService) { }

  performFilter(filterBy: string): Room[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.rooms.filter((room: Room) =>
      room.departmentName.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  toggleImage(): void {
    this.showImage = !this.showImage;
  }

  ngOnInit(): void {
    this.roomService.getRooms().subscribe({
      next: rooms => {
        this.rooms = rooms;
        this.filteredRooms = this.rooms;
      },
      error: err => this.errorMessage = err
    });
  }
}
