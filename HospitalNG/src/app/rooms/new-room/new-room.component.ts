import { DepartmentService } from './../../shared/department/department.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Room } from '../Room';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RoomService } from '../room.service';
import { Department } from '../../shared/department/department';
import Swal from 'sweetalert2';
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

  departments: Department[] = [];

  public validationMessages = {
    'roomNumber': [
      { type: 'required', message: 'Room number is required' },
      { type: 'pattern', message: 'Room number must contain only numbers' },
    ],
    'departmentId': [{ type: 'required', message: 'Department is required' },]

  }

  lettersPattern = '[A-Za-z]+$'
  numbersPattern = '[0-9]+$'


  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private roomService: RoomService,
    private modalService: NgbModal,
    private departmentService: DepartmentService) {

    this.roomForm = fb.group({
      title: '',
      description: ''
    })


  }

  ngOnInit(): void {
    this.roomForm = this.fb.group({
      roomNumber: ["", [Validators.required, Validators.pattern(this.numbersPattern)]],
      departmentId: ["", [Validators.required]]
    });

    this.sub = this.route.params.subscribe(
      params => {
        this.getRoom(params['id']);
      }
    );

    this.departmentService.getDepartments()
      .subscribe({
        next: departments => this.departments = departments,
        error: err => this.errorMessage = err
      });
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
        roomNumber: this.room.roomNumber,
        departmentId: this.room.departmentId
      });
    }
  }

  changeDepartment(number: any): void {
    let id =  number.target.value;
    this.roomForm.patchValue({
      departmentId: id
    })
  }

  deleteRoom(roomNumber: number): void {
    if (roomNumber === 0) {
      this.onSaveComplete();
    }
    else {
      {
        this.roomService.deleteRoom(roomNumber)
          .subscribe({
            next: () => this.onSaveComplete(),
            error: err => this.errorMessage = err
          });
      }
    }
  }

  saveRoom(): void {
    if (this.roomForm?.valid) {
      if (this.roomForm.pristine || this.roomForm.dirty) {
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
              error: err => this.errorMessage = err,
              complete: () => this.updateSuccessNotification(this.room.roomNumber),
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
    this.createSuccessNotification(this.roomForm.value.roomNumber)
    this.roomForm?.reset();
    this.router.navigate(['/rooms']);
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  closeResult = '';

  createSuccessNotification(roomNumber: number) {
    Swal.fire('Create', `Successfully created new room named ${roomNumber}`, 'success');
  }
  updateSuccessNotification(roomNumber: number) {
    Swal.fire('Update', `Successfully update room named ${roomNumber}`, 'success');
  }
  alertConfirmation() {
    Swal.fire({
      title: 'Are you sure?',
      text: `This process is irreversible. You will delete ${this.room.roomNumber}`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, go ahead.',
      cancelButtonText: 'No, let me think',
    }).then((result) => {
      if (result.value) {
        this.deleteRoom(this.room.id);
        console.log(this.room.id);
        Swal.fire('Removed!', 'Product removed successfully.', 'success');
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire('Cancelled', 'Product still in our database.', 'error');
      }
    });
  }
}
