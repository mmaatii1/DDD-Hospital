import { Component, OnInit } from '@angular/core';
import { Department } from '../../shared/department/department';
import { DepartmentService } from '../../shared/department/department.service';

@Component({
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {

  pageTitle = 'Departments';
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
    this.filteredDepartments = this.listFilter
      ? this.performFilter(this.listFilter) : this.departments;
  }

  filteredDepartments: Department[] = [];
  departments: Department[] = [];

  constructor(private departmentService: DepartmentService) { }

  performFilter(filterBy: string): Department[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.departments.filter((department: Department) =>
      department.name.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  toggleImage(): void {
    this.showImage = !this.showImage;
  }

  ngOnInit(): void {
    this.departmentService.getDepartments().subscribe({
      next: departments => {
        this.departments = departments;
        this.filteredDepartments = this.departments;
      },
      error: err => this.errorMessage = err
    });
  }
}
