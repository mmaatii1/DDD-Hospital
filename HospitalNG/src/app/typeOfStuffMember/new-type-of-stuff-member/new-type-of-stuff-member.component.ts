import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs';
import Swal from 'sweetalert2';
import { TypeOfStuffMemberService } from '../../shared/typeOfStuffMember/type-of-stuff-member.service';
import { TypeOfStuffMember } from '../../shared/typeOfStuffMember/typeOfStuffMember';

@Component({
  selector: 'app-new-type-of-stuff-member',
  templateUrl: './new-type-of-stuff-member.component.html',
  styleUrls: ['./new-type-of-stuff-member.component.css']
})
export class NewTypeOfStuffMemberComponent implements OnInit, OnDestroy {

  pageTitle = "Add New TypeOfStuffMember";
  errorMessage: string = "";
  typeOfStuffMemberForm: FormGroup;
  typeOfStuffMember: TypeOfStuffMember = {} as TypeOfStuffMember
  private sub: Subscription | undefined;
  displayMessage: any = {};
  confirmation = "Are you sure?";

  typeOfStuffMembers: TypeOfStuffMember[] = [];

  public validationMessages = {
    'name': [
      { type: 'required', message: 'TypeOfStuffMember number is required' },
    ],
    'description': [{ type: 'maxlength', message: 'Max 150 characters' },]
  }

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private modalService: NgbModal,
    private typeOfStuffMemberService: TypeOfStuffMemberService) {

    this.typeOfStuffMemberForm = fb.group({
      title: '',
      description: ''
    })
  }

  ngOnInit(): void {
    this.typeOfStuffMemberForm = this.fb.group({
      name: ["", [Validators.required, ]],
      description: ["", [Validators.maxLength(150)]]
    });

    this.sub = this.route.params.subscribe(
      params => {
        this.getTypeOfStuffMember(params['id']);
      }
    );

    this.typeOfStuffMemberService.getTypeOfStuffMembers()
      .subscribe({
        next: typeOfStuffMembers => this.typeOfStuffMembers = typeOfStuffMembers,
        error: err => this.errorMessage = err
      });
  }

  getTypeOfStuffMember(id: number): void {
    if (id == 0) {
      this.typeOfStuffMember.id = 0;
      return;
    }
    this.typeOfStuffMemberService.getTypeOfStuffMember(id)
      .subscribe({
        next: (typeOfStuffMember: TypeOfStuffMember) => this.displayTypeOfStuffMember(typeOfStuffMember),
        error: err => this.errorMessage = err
      });
  }

  displayTypeOfStuffMember(typeOfStuffMember: TypeOfStuffMember): void {
    if (this.typeOfStuffMemberForm) {
      this.typeOfStuffMemberForm.reset();
    }
    this.typeOfStuffMember = typeOfStuffMember;

    if (this.typeOfStuffMember.id === 0) {
      this.pageTitle = 'Add TypeOfStuffMember';
    } else {
      this.pageTitle = `Edit TypeOfStuffMember: ${this.typeOfStuffMember.name}  `;

      this.typeOfStuffMemberForm?.patchValue({
        name: this.typeOfStuffMember.name,
        description: this.typeOfStuffMember.description
      });
    }
  }

  deleteTypeOfStuffMember(typeOfStuffMemberId: number): void {
    if (typeOfStuffMemberId === 0) {
      this.onSaveComplete();
    }
    else {
      {
        this.typeOfStuffMemberService.deleteTypeOfStuffMember(typeOfStuffMemberId)
          .subscribe({
            next: () => this.onSaveComplete(),
            error: err => this.errorMessage = err
          });
      }
    }
  }

  saveTypeOfStuffMember(): void {
    if (this.typeOfStuffMemberForm?.valid) {
      if (this.typeOfStuffMemberForm.pristine || this.typeOfStuffMemberForm.dirty) {
        const p = { ...this.typeOfStuffMember, ...this.typeOfStuffMemberForm.value };

        if (p.id === 0) {
          this.typeOfStuffMemberService.createTypeOfStuffMember(p)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err
            });
        } else {
          this.typeOfStuffMemberService.updateTypeOfStuffMember(p)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err,
              complete: () => this.updateSuccessNotification(this.typeOfStuffMember.name),
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
    this.createSuccessNotification(this.typeOfStuffMemberForm.value.name)
    this.typeOfStuffMemberForm?.reset();
    this.router.navigate(['/typesOfStuffMembers']);
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  createSuccessNotification(typeOfStuffMemberName: string) {
    Swal.fire('Create', `Successfully created new Type Of Stuff Member named ${typeOfStuffMemberName}`, 'success');
  }
  updateSuccessNotification(typeOfStuffMemberName: string) {
    Swal.fire('Update', `Successfully update Type Of Stuff Member named ${typeOfStuffMemberName}`, 'success');
  }
  alertConfirmation() {
    Swal.fire({
      title: 'Are you sure?',
      text: `This process is irreversible. You will delete ${this.typeOfStuffMember.name}`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, go ahead.',
      cancelButtonText: 'No, let me think',
    }).then((result) => {
      if (result.value) {
        this.deleteTypeOfStuffMember(this.typeOfStuffMember.id);
        console.log(this.typeOfStuffMember.id);
        Swal.fire('Removed!', 'Product removed successfully.', 'success');
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire('Cancelled', 'Product still in our database.', 'error');
      }
    });
  }
}