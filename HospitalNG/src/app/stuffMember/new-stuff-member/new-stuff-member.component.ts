import { TypeOfStuffMemberService } from './../../shared/typeOfStuffMember/type-of-stuff-member.service';
import { Department } from './../../shared/department/department';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { StuffMember } from '../stuffMember';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { StuffMemberService } from '../stuff-member.service';
import { DepartmentService } from '../../shared/department/department.service';
import { TypeOfStuffMember } from '../../shared/typeOfStuffMember/typeOfStuffMember';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-new-stuff-member',
  templateUrl: './new-stuff-member.component.html',
  styleUrls: ['./new-stuff-member.component.css']
})
export class NewStuffMemberComponent implements OnInit, OnDestroy {

  pageTitle = "Add New StuffMember";
  errorMessage: string = "";
  stuffMemberForm: FormGroup;
  stuffMember: StuffMember = {} as StuffMember
  private sub: Subscription | undefined;
   departments: Department[] = [];
   typesOfStuffMember: TypeOfStuffMember[] = [];
  displayMessage: any = {};
  confirmation = "Are you sure?";

  public validationMessages = {
    'firstName': [
      { type: 'required', message: 'First name is required' },
      { type: 'pattern', message: 'First name must contain only letters' },
    ],
    'lastName': [
      { type: 'required', message: 'Last name is required' },
      { type: 'pattern', message: 'First name must contain only letters' },
    ],
    'departmentId': [
      { type: 'required', message: 'Departmemt is required' }    ],
    'typeOfStuffMemberId': [
      { type: 'required', message: 'Type of stuff member is required' },
    ]
  }

  lettersPattern = '[A-Za-z]+$'

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private stuffMemberService: StuffMemberService,
    private departmentService: DepartmentService,
    private typeOfStuffMemberService: TypeOfStuffMemberService,
    private modalService: NgbModal) {

    this.stuffMemberForm = fb.group({
      title: '',
      description: ''
    })
  }

  ngOnInit(): void {
    this.stuffMemberForm = this.fb.group({
      firstName: ["", [Validators.required, Validators.pattern(this.lettersPattern)]],
      lastName: ["", [Validators.required, Validators.pattern(this.lettersPattern)]],
      departmentId: ["", [Validators.required,]],
      typeOfStuffMemberId: ["", [Validators.required, ]],
    });

    this.sub = this.route.params.subscribe(
      params => {
        this.getStuffMember(params['id']);
      }
    );

    this.departmentService.getDepartments()
    .subscribe({
      next: departments => this.departments = departments,
      error: err => this.errorMessage = err
    });

    this.typeOfStuffMemberService.getTypeOfStuffMembers()
    .subscribe({
      next: types => this.typesOfStuffMember = types,
      error: err => this.errorMessage = err
    });
  }

  getStuffMember(id: number): void {
    if (id == 0) {
      this.stuffMember.id = 0;
      return;
    }

    this.stuffMemberService.getStuffMember(id)
      .subscribe({
        next: (stuffMember: StuffMember) => this.displayStuffMember(stuffMember),
        error: err => this.errorMessage = err
      });
  }
  
  displayStuffMember(stuffMember: StuffMember): void {
    if (this.stuffMemberForm) {
      this.stuffMemberForm.reset();
    }
    this.stuffMember = stuffMember;

    if (this.stuffMember.id === 0) {
      this.pageTitle = 'Add StuffMember';
    } else {
      this.pageTitle = `Edit StuffMember: ${this.stuffMember.firstName} ${this.stuffMember.lastName} `;

      this.stuffMemberForm?.patchValue({
        departmentId: this.stuffMember.departmentId,
        typeOfStuffMemberId: this.stuffMember.typeOfStuffMemberId,
        firstName: this.stuffMember.firstName,
        lastName: this.stuffMember.lastName,
      });
    }
  }

  deleteStuffMember(stuffMemberId: number): void {
    if (stuffMemberId === 0) {
      this.onSaveComplete();
    }
    else {
      {
        this.stuffMemberService.deleteStuffMember(stuffMemberId)
          .subscribe({
            next: () => this.onSaveComplete(),
            error: err => this.errorMessage = err
          });
      }
    }
  }

  changeDepartmentId(number: any): void {
    let id = number.target.value;
    this.stuffMemberForm.patchValue({
      departmentId: id
    })
  }

  changeTypeOfStuffMemberId(number: any) : void{
    let id = number.target.value;
    this.stuffMemberForm.patchValue({
      typeOfStuffMemberId: id
    })
  }

  saveStuffMember(): void {
    if (this.stuffMemberForm?.valid) {
      if (this.stuffMemberForm.dirty || this.stuffMemberForm.pristine) {
        const p = { ...this.stuffMember, ...this.stuffMemberForm.value };

        if (p.id === 0) {
          this.stuffMemberService.createStuffMember(p)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err
            });
        } else {
          this.stuffMemberService.updateStuffMember(p)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err,
              complete: () => this.updateSuccessNotification(this.stuffMember.firstName),
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
    this.createSuccessNotification(this.stuffMemberForm.value.firstName)
    this.stuffMemberForm?.reset();
    this.router.navigate(['/stuffMembers']);
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  createSuccessNotification(stuffMember: string) {
    Swal.fire('Create', `Successfully created new stuffMember named ${stuffMember}`, 'success');
  }
  updateSuccessNotification(stuffMember: string) {
    Swal.fire('Update', `Successfully update stuffMember named ${stuffMember}`, 'success');
  }
  alertConfirmation() {
    Swal.fire({
      title: 'Are you sure?',
      text: `This process is irreversible. You will delete ${this.stuffMember.firstName}`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, go ahead.',
      cancelButtonText: 'No, let me think',
    }).then((result) => {
      if (result.value) {
        this.deleteStuffMember(this.stuffMember.id);
        console.log(this.stuffMember.id);
        Swal.fire('Removed!', 'Product removed successfully.', 'success');
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire('Cancelled', 'Product still in our database.', 'error');
      }
    });
  }
}
