import { Component, OnInit } from '@angular/core';
import { Patient } from '../patient';
import { PatientService } from '../patient.service';

@Component({
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit {

  pageTitle = 'Patients';
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
    this.filteredPatients = this.listFilter
      ? this.performFilter(this.listFilter) : this.patients;
  }

  filteredPatients: Patient[] = [];
  patients: Patient[] = [];

  constructor(private patientService: PatientService) { }

  performFilter(filterBy: string): Patient[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.patients.filter((patient: Patient) =>
      patient.lastName.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  toggleImage(): void {
    this.showImage = !this.showImage;
  }

  ngOnInit(): void {
    this.patientService.getPatients().subscribe({
      next: patients => {
        this.patients = patients;
        this.filteredPatients = this.patients;
      },
      error: err => this.errorMessage = err
    });
  }
}
