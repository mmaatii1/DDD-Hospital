import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-stuff-member-list',
  templateUrl: './stuff-member-list.component.html',
  styleUrls: ['./stuff-member-list.component.css']
})
export class StuffMemberListComponent implements OnInit {

  pageTitle = 'StuffMember List';
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
      ? this.performFilter(this.listFilter) : this.StuffMembers;
  }

  filteredStuffMembers: StuffMember[] = [];
  StuffMembers: StuffMember[] = [];

  constructor(private StuffMemberService: StuffMemberService) { }

  performFilter(filterBy: string): StuffMember[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.StuffMembers.filter((StuffMember: StuffMember) =>
      StuffMember.name.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  toggleImage(): void {
    this.showImage = !this.showImage;
  }

  ngOnInit(): void {
    this.StuffMemberService.getStuffMembers().subscribe({
      next: StuffMembers => {
        this.StuffMembers = StuffMembers;
        this.filteredStuffMembers = this.StuffMembers;
      },
      error: err => this.errorMessage = err
    });
  }
}
