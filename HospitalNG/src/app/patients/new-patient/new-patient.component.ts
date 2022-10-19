import { Gender } from './../gender';
import { PatientService } from './../patient.service';
import { Subscription, Observable, fromEvent, merge, debounceTime } from 'rxjs';
import { AfterViewInit, Component, ElementRef, OnDestroy, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { Patient } from '../patient';
import { GenericValidator } from '../../shared/generic-validator';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-new-patient',
  templateUrl: './new-patient.component.html',
  styleUrls: ['./new-patient.component.css']
})
export class NewPatientComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[] | undefined;

  pageTitle = "Add New Patient";
  errorMessage: string = "";
  patientForm: FormGroup;
  patient: Patient = {} as Patient
  private sub: Subscription | undefined;
  controlBlurs: Observable<any>[] | undefined;
  displayMessage: any = {};
  private validationMessages: { [key: string]: { [key: string]: string } } | undefined;
  private genericValidator: GenericValidator | undefined;

  genders: Gender[] = [
    { value: 0, viewValue: "Male" },
    { value: 1, viewValue: "Female" },
  ];

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private PatientService: PatientService,) {

    this.patientForm = fb.group({
      title: '',
      description: ''
    })

    this.validationMessages = {
      firstName: {
        required: "FirstName is required."
      },
      lastName: {
        required: "LastName is required."
      },
      emailAddress: {
        required: "Email is required.",
        email: "It must be of type email"
      },
      insuranceNumber: {
        required: "Insurance number is required",
        number: "It must be number"
      },
      gender: {
        required: "Gender is required",
        number: "It must be number"
      },
      phoneNumber: {
        required: "Phone number is required",
        number: "It must be number"
      }
    };
    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit(): void {
    this.patientForm = this.fb.group({
      firstName: ["", [Validators.required]],
      lastName: ["", [Validators.required]],
      emailAddress: ["", [Validators.required, Validators.email]],
      insuranceNumber: ["", [Validators.required,]],
      phoneNumber: ["", [Validators.required]]
    });

    this.sub = this.route.params.subscribe(
      params => {
        this.getPatient(params['id']);
      }
    );
  }

  getPatient(id: number): void {
    if (id == 0) {
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
      this.pageTitle = `Edit patient: ${this.patient.lastName} `;

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

  deletePatient(): void {
    if (this.patient?.id === 0) {
      this.onSaveComplete();
    }
    else {
      if (confirm(`Really delete this patient: ${this.patient?.lastName},
       this proccess cannot be undone`)) {
        this.PatientService.deletePatient(this.patient?.id)
          .subscribe({
            next: () => this.onSaveComplete(),
            error: err => this.errorMessage = err
          });
      }
    }
  }
  onSelected(number: number): void {
    this.patient.gender = number;
  }
  savePatient(): void {
    if (this.patientForm?.valid) {
      if (this.patientForm.dirty) {
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
    this.patientForm?.reset();
    this.router.navigate(['/patients']);
  }
  ngAfterViewInit(): void {
    const t = this.formInputElements
      ?.map((formControl: ElementRef) => fromEvent(formControl.nativeElement, "blur"));

    merge(this.patientForm?.valueChanges, ...[this.controlBlurs])
      .pipe(debounceTime(800))
      .subscribe(value => {
        this.displayMessage = this.genericValidator?.processMessages(this.patientForm);
      });
  }
  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }
}
