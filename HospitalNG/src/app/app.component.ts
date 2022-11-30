import { Component } from '@angular/core';

@Component({
      selector: 'app-root',
      template: `<nav class='navbar navbar-expand-lg navbar-dark bg-dark'>
  <a class='navbar-brand page-title'>{{pageTitle}}</a>
  <ul class='navbar-nav  align-items-center'>
    <li class='nav-item'><a class='nav-link' routerLinkActive='active'
          [routerLink]="['/welcome']">Home</a>
    </li>
    <li class='nav-item'><a class='nav-link' routerLinkActive='active' [routerLinkActiveOptions]="{exact: true}"
          [routerLink]="['/patients']">Patients</a>
    </li>
    <li class='nav-item'><a class='nav-link' routerLinkActive='active' [routerLinkActiveOptions]="{exact: true}"
          [routerLink]="['/rooms']">Rooms</a>
    </li>
    <li class='nav-item'><a class='nav-link' routerLinkActive='active' [routerLinkActiveOptions]="{exact: true}"
          [routerLink]="['/departments']">Departments</a>
    </li>
    <li class='nav-item'><a class='nav-link' routerLinkActive='active' [routerLinkActiveOptions]="{exact: true}"
          [routerLink]="['/typesOfStuffMembers']">Types of stuff member</a>
    </li>
    <li class='nav-item'><a class='nav-link last-nav-item' routerLinkActive='active' [routerLinkActiveOptions]="{exact: true}"
          [routerLink]="['/stuffMembers']">Stuff member</a>
    </li>
  </ul>
</nav>
<div class='page-container bg-secondary'>
  <router-outlet></router-outlet>
</div>`,
      styleUrls: ['./app.component.css']
})
export class AppComponent {
      pageTitle = 'Hospital management';
}
