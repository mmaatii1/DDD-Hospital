import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Gender } from './../gender';
import { PatientService } from './../patient.service';
import { Subscription, Observable, fromEvent, merge, debounceTime } from 'rxjs';
import { AfterViewInit, Component, ElementRef, OnDestroy, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { Patient } from '../patient';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-new-patient',
  templateUrl: './new-patient.component.html',
  styleUrls: ['./new-patient.component.css']
})
export class NewPatientComponent implements OnInit, OnDestroy {

  pageTitle = "Add New Patient";
  errorMessage: string = "";
  patientForm: FormGroup;
  patient: Patient = {} as Patient
  private sub: Subscription | undefined;
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
    'insuranceNumber': [
      { type: 'pattern', message: 'Insurance number must contain only numbers' },
    ],
    'emailAddress': [
      { type: 'required', message: 'Email is required' },
      { type: 'email', message: 'Enter a valid email' }
    ],
    'phoneNumber': [
      { type: 'pattern', message: 'Phone number must contain only numbers' }
    ],
    'gender': [
      { type: 'required', message: 'Gender is required' }
    ]
  }

  lettersPattern = '[A-Za-z]+$'
  numbersPattern = '[0-9]+$'

  genders: Gender[] = [
    { value: 0, viewValue: "Male" },
    { value: 1, viewValue: "Female" },
  ];

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private PatientService: PatientService,
    private modalService: NgbModal) {

    this.patientForm = fb.group({
      title: '',
      description: ''
    })


  }

  ngOnInit(): void {
    this.patientForm = this.fb.group({
      firstName: ["", [Validators.required, Validators.pattern(this.lettersPattern)]],
      lastName: ["", [Validators.required, Validators.pattern(this.lettersPattern)]],
      emailAddress: ["", [Validators.required, Validators.email]],
      insuranceNumber: ["", [Validators.required, Validators.pattern(this.numbersPattern)]],
      phoneNumber: ["", [Validators.required, , Validators.pattern(this.numbersPattern)]]
    });

    this.sub = this.route.params.subscribe(
      params => {
        this.getPatient(params['id']);
      }
    );
  }

  getPatient(id: number): void {
    if (id == 0) {
      this.patient.id = 0;
      return;
    }
    this.PatientService.getPatient(id)
      .subscribe({
        next: (patient: Patient) => this.displayPatient(patient),
        error: err => this.errorMessage = err
      });

  }
  displayPatient(patient: Patient): void {
    if (this.patientForm) {
      this.patientForm.reset();
    }
    this.patient = patient;

    if (this.patient.id === 0) {
      this.pageTitle = 'Add patient';
    } else {
      this.pageTitle = `Edit patient: ${this.patient.firstName} ${this.patient.lastName} `;

      this.patientForm?.patchValue({
        firstName: this.patient.firstName,
        lastName: this.patient.lastName,
        insuranceNumber: this.patient.insuranceNumber,
        phoneNumber: this.patient.phoneNumber,
        gender: this.patient.gender,
        emailAddress: this.patient.emailAddress
      });
    }
  }

  deletePatient(patientId: number): void {
    if (patientId === 0) {
      this.onSaveComplete();
    }
    else {
      {
        this.PatientService.deletePatient(patientId)
          .subscribe({
            next: () => this.onSaveComplete(),
            error: err => this.errorMessage = err
          });
      }
    }
  }
  changeGender(number: any): void {
    this.patient.gender = number.target.value;
  }
  savePatient(): void {
    if (this.patientForm?.valid) {
      if (this.patientForm.dirty || this.patientForm.pristine) {
        const p = { ...this.patient, ...this.patientForm.value };

        if (p.id === 0) {
          this.PatientService.createPatient(p)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err
            });
        } else {
          this.PatientService.updatePatient(p)
            .subscribe({
              next: () => this.onSaveComplete(),
              error: err => this.errorMessage = err,
              complete: () => this.updateSuccessNotification(this.patient.firstName),
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
    this.createSuccessNotification(this.patientForm.value.firstName)
    this.patientForm?.reset();
    this.router.navigate(['/patients']);
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  closeResult = '';
  createSuccessNotification(patientName: string) {
    Swal.fire('Create', `Successfully created new patient named ${patientName}`, 'success');
  }
  updateSuccessNotification(patientName: string) {
    Swal.fire('Update', `Successfully update patient named ${patientName}`, 'success');
  }
  alertConfirmation() {
    Swal.fire({
      title: 'Are you sure?',
      text: `This process is irreversible. You will delete ${this.patient.firstName} + ${this.patient.lastName}`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, go ahead.',
      cancelButtonText: 'No, let me think',
    }).then((result) => {
      if (result.value) {
        this.deletePatient(this.patient.id);
        console.log(this.patient.id);
        Swal.fire('Removed!', 'Product removed successfully.', 'success');
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire('Cancelled', 'Product still in our database.', 'error');
      }
    });
  }
}
