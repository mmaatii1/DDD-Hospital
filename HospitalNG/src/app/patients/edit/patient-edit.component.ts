import { AfterViewInit, Component, ElementRef, inject, OnDestroy, OnInit, ViewChildren } from '@angular/core';
import { FormControlName, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Patient } from '../patient';

@Component({
  selector: 'app-patient-edit',
  templateUrl: './patient-edit.component.html',
  styleUrls: ['./patient-edit.component.css']
})
export class PatientEditComponent implements OnInit,AfterViewInit, OnDestroy {
  
  pageTitle="Patient edit";
  private patientForm: FormGroup
  private sub: Subscription;
  constructor(sub: Subscription, patientForm: FormGroup) { 
    this.sub = sub;
    this.patientForm = patientForm
  }
 

  ngOnInit(): void {
    
  }
  ngAfterViewInit(): void {
    throw new Error('Method not implemented.');
  }
  ngOnDestroy(): void {
    throw new Error('Method not implemented.');
  }

}
