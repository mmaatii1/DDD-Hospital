import { Component, OnInit } from '@angular/core';
import { TypeOfStuffMember } from '../../shared/typeOfStuffMember/typeOfStuffMember';
import { TypeOfStuffMemberService } from '../../shared/typeOfStuffMember/type-of-stuff-member.service';
@Component({
  selector: 'app-type-of-stuff-member-list',
  templateUrl: './type-of-stuff-member-list.component.html',
  styleUrls: ['./type-of-stuff-member-list.component.css']
})
export class TypeOfStuffMemberListComponent implements OnInit {

  pageTitle = 'TypeOfStuffMember List';
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
    this.filteredTypeOfStuffMembers = this.listFilter
      ? this.performFilter(this.listFilter) : this.typeOfStuffMembers;
  }

  filteredTypeOfStuffMembers: TypeOfStuffMember[] = [];
  typeOfStuffMembers: TypeOfStuffMember[] = [];

  constructor(private typeOfStuffMemberService: TypeOfStuffMemberService) { }

  performFilter(filterBy: string): TypeOfStuffMember[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.typeOfStuffMembers.filter((typeOfStuffMember: TypeOfStuffMember) =>
      typeOfStuffMember.name.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  toggleImage(): void {
    this.showImage = !this.showImage;
  }

  ngOnInit(): void {
    this.typeOfStuffMemberService.getTypeOfStuffMembers().subscribe({
      next: typeOfStuffMembers => {
        this.typeOfStuffMembers = typeOfStuffMembers;
        this.filteredTypeOfStuffMembers = this.typeOfStuffMembers;
      },
      error: err => this.errorMessage = err
    });
  }
}
