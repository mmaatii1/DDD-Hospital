import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Department } from '../../shared/department/department';
import { DepartmentService } from '../../shared/department/department.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-new-Department',
  templateUrl: './new-Department.component.html',
  styleUrls: ['./new-Department.component.css']
})
export class NewDepartmentComponent implements OnInit, OnDestroy {

  pageTitle = "Add New Department";
  errorMessage: string = "";
  departmentForm: FormGroup;
  department: Department = {} as Department
  private sub: Subscription | undefined;
  displayMessage: any = {};
  confirmation = "Are you sure?";

  departments: Department[] = [];

  public validationMessages = {
    'name': [
      { type: 'required', message: 'Department name is required' },
    ],
    'description': [{ type: 'maxlength', message: 'Description max 150 characters' },]

  }


  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private departmentService: DepartmentService) {

    this.departmentForm = fb.group({
      title: '',
      description: ''
    })


  }

  ngOnInit(): void {
    this.departmentForm = this.fb.group({
      name: ["", [Validators.required,]],
      description: ["", [Validators.required, Validators.maxLength(150)]]
    });

    this.sub = this.route.params.subscribe(
      params => {
        this.getDepartment(params['id']);
      }
    );

    this.departmentService.getDepartments()
      .subscribe({
        next: departments => this.departments = departments,
        error: err => this.errorMessage = err
      });
  }



  getDepartment(id: number): void {
    if (id == 0) {
      this.department.id = 0;
      return;
    }
    this.departmentService.getDepartment(id)
      .subscribe({
        next: (department: Department) => this.displayDepartment(department),
        error: err => this.errorMessage = err
      });
  }

  displayDepartment(department: Department): void {
    if (this.departmentForm) {
      this.departmentForm.reset();
    }
    this.department = department;

    if (this.department.id === 0) {
      this.pageTitle = 'Add Department';
    } else {
      this.pageTitle = `Edit Department: ${this.department.name}  `;

      this.departmentForm?.patchValue({
        name: this.department.name,
        description: this.department.description
      });
    }
  }

  changeDepartment(number: any): void {
    let id = number.target.value;
    this.departmentForm.patchValue({
      departmentId: id
    })
  }

  createSuccessNotification(departmentName: string) {
    Swal.fire('Create', `Successfully created new department named ${departmentName}`, 'success');
  }
  updateSuccessNotification(departmentName: string) {
    Swal.fire('Update', `Successfully update department named ${departmentName}`, 'success');
  }
  alertConfirmation() {
    Swal.fire({
      title: 'Are you sure?',
      text: `This process is irreversible. You will delete ${this.department.name}`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, go ahead.',
      cancelButtonText: 'No, let me think',
    }).then((result) => {
      if (result.value) {
        this.deleteDepartment(this.department.id);
        console.log(this.department.id);
        Swal.fire('Removed!', 'Product removed successfully.', 'success');
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire('Cancelled', 'Product still in our database.', 'error');
      }
    });
  }


  deleteDepartment(departmentId: number): void {
    if (this.department?.id === 0) {
      this.onSaveComplete();
    }
    else {
      {
        this.departmentService.deleteDepartment(departmentId)
          .subscribe({
            next: () => this.onSaveComplete(),
            error: err => this.errorMessage = err
          });
      }
    }
  }

  saveDepartment(): void {
    if (this.departmentForm?.valid) {
      if (this.departmentForm.pristine || this.departmentForm.dirty) {
        const p = { ...this.department, ...this.departmentForm.value };

        if (p.id === 0) {
          this.departmentService.createDepartment(p)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err,
            });
        } else {
          this.departmentService.updateDepartment(p)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err,
              complete: () => this.updateSuccessNotification(this.department.name),
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
    this.createSuccessNotification(this.departmentForm.value.name)
    this.departmentForm?.reset();
    this.router.navigate(['/departments']);
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  closeResult = '';

}
