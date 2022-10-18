import { PatientService } from './../patient.service';
import { Subscription } from 'rxjs';
import { AfterViewInit, Component, ElementRef, OnDestroy, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
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

  pageTitle = "Add new Patient";
  errorMessage: string = "";
  patientForm: FormGroup | undefined;

  patient: Patient | undefined;
  private sub: Subscription | undefined;

  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } } | undefined;
  private genericValidator: GenericValidator | undefined;
  
  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private PatientService: PatientService) 
    {

      this.validationMessages = {
        firstName: {
          required: "FirstName is required."
        },
        lastName: {
          required: "LastName is required."
        },
        emailAddress:{
          required: "Email is required.",
          email: "It must be of type email"
        },
        insuranceNumber:{
          required: "Insurance number is required",
          number: "It must be number"
        },
        gender:{
          required: "Gender is required",
          number: "It must be number"
        },
        phoneNumber:{
          required: "Phone number is required",
          number: "It must be number"
        }
      };
      this.genericValidator = new GenericValidator(this.validationMessages);
    }

  ngOnInit(): void {
    this.patientForm = this.fb.group({
      firstName: ["", [Validators.required]],
      lastName: ["",[Validators.required]],
      emailAddress:["",[Validators.required, Validators.email]],
      insuranceNumber:["",[Validators.required, ]],
      gender:["",[Validators.required]],
      phoneNumber:["",[Validators.required]]
    });

    this.sub = this.route.params.subscribe(
      params => {
        this.getPatient(params['id']);
      }
    );
  }

  getPatient(id: number):void {
    this.PatientService.getPatient(id)
    .subscribe({
      next: (patient: Patient) => this.displayPatient(patient),
      error: err => this.errorMessage = err
    });
    
  }
  displayPatient(patient: Patient): void {
    throw new Error('Method not implemented.');
  }
  ngAfterViewInit(): void {
    throw new Error('Method not implemented.');
  }
  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }
}
