import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Room } from '../Room';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RoomService } from '../room.service';
@Component({
  selector: 'app-new-Room',
  templateUrl: './new-Room.component.html',
  styleUrls: ['./new-Room.component.css']
})
export class NewRoomComponent implements OnInit, OnDestroy {

  pageTitle = "Add New Room";
  errorMessage: string = "";
  roomForm: FormGroup;
  room: Room = {} as Room
  private sub: Subscription | undefined;
  displayMessage: any = {};
  confirmation = "Are you sure?";

  public validationMessages = {
    'roomNumber': [
      { type: 'required', message: 'Room number is required' },
      { type: 'pattern', message: 'Room number must contain only numbers' },
    ],
    
  }

  lettersPattern = '[A-Za-z]+$'
  numbersPattern = '[0-9]+$'


  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private roomService: RoomService,
    private modalService: NgbModal) {

    this.roomForm = fb.group({
      title: '',
      description: ''
    })


  }

  ngOnInit(): void {
    this.roomForm = this.fb.group({
      roomNumber: ["", [Validators.required, Validators.pattern(this.numbersPattern)]],
    });

    this.sub = this.route.params.subscribe(
      params => {
        this.getRoom(params['id']);
      }
    );
  }

  getRoom(id: number): void {
    if (id == 0) {
      this.room.id = 0;
      return;
    }
    this.roomService.getRoom(id)
      .subscribe({
        next: (room: Room) => this.displayRoom(room),
        error: err => this.errorMessage = err
      });

  }
  displayRoom(room: Room): void {
    if (this.roomForm) {
      this.roomForm.reset();
    }
    this.room = room;

    if (this.room.id === 0) {
      this.pageTitle = 'Add Room';
    } else {
      this.pageTitle = `Edit Room: ${this.room.roomNumber}  `;

      this.roomForm?.patchValue({
        firstName: this.room.roomNumber,
      });
    }
  }

  deleteRoom(): void {
    if (this.room?.id === 0) {
      this.onSaveComplete();
    }
    else {
      {
        this.roomService.deleteRoom(this.room?.id)
          .subscribe({
            next: () => this.onSaveComplete(),
            error: err => this.errorMessage = err
          });
      }
    }
  }
 
  saveRoom(): void {
    if (this.roomForm?.valid) {
      if (this.roomForm.dirty) {
        const p = { ...this.room, ...this.roomForm.value };

        if (p.id === 0) {
          this.roomService.createRoom(p)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err
            });
        } else {
          this.roomService.updateRoom(p)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err
            });
        }
      } else {
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = "Please correct the validation errors";
    }
  }
  onSaveComplete() {
    this.roomForm?.reset();
    this.router.navigate(['/Rooms']);
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  closeResult = '';
  open(content: any) {

    this.modalService.open(content).result;

  }
}
