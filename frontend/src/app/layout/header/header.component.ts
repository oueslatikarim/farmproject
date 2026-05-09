import { Component, EventEmitter, Output } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink],
  template: `
    <header id="header" class="header">
      <div class="top-left">
        <div class="navbar-header">
          <a class="navbar-brand" routerLink="/dashboard"
            ><img src="assets/images/logo.png" alt="Logo"
          /></a>
          <a class="navbar-brand hidden" routerLink="/dashboard"
            ><img src="assets/images/logo2.png" alt="Logo"
          /></a>
          <a id="menuToggle" class="menutoggle" (click)="toggleMenu.emit()"
            ><i class="fa fa-bars"></i
          ></a>
        </div>
      </div>

      <div class="top-right">
        <div class="header-menu">
          <div class="header-left">
            <button class="search-trigger"><i class="fa fa-search"></i></button>
          </div>

          <div class="user-area dropdown float-right">
            <a href="#" class="dropdown-toggle active" data-toggle="dropdown" aria-haspopup="true"
              aria-expanded="false">
              <img class="user-avatar rounded-circle" src="assets/images/admin.jpg" alt="User Avatar" />
            </a>
          </div>
        </div>
      </div>
    </header>
  `,
})
export class HeaderComponent {
  @Output() toggleMenu = new EventEmitter<void>();
}

