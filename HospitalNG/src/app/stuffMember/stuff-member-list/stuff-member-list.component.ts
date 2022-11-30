import { Component, OnInit } from '@angular/core';
import { StuffMember } from '../stuffMember';
import { StuffMemberService } from '../stuff-member.service';
@Component({
  selector: 'app-stuff-member-list',
  templateUrl: './stuff-member-list.component.html',
  styleUrls: ['./stuff-member-list.component.css']
})
export class StuffMemberListComponent implements OnInit {

  pageTitle = 'Stuff Members';
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
    this.filteredStuffMembers = this.listFilter
      ? this.performFilter(this.listFilter) : this.stuffMembers;
  }

  filteredStuffMembers: StuffMember[] = [];
  stuffMembers: StuffMember[] = [];

  constructor(private stuffMemberService: StuffMemberService) { }

  performFilter(filterBy: string): StuffMember[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.stuffMembers.filter((stuffMember: StuffMember) =>
      stuffMember.lastName.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  toggleImage(): void {
    this.showImage = !this.showImage;
  }

  ngOnInit(): void {
    this.stuffMemberService.getStuffMembers().subscribe({
      next: stuffMembers => {
        this.stuffMembers = stuffMembers;
        this.filteredStuffMembers = this.stuffMembers;
      },
      error: err => this.errorMessage = err
    });
  }
}
