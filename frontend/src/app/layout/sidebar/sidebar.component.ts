import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  template: `
    <nav class="navbar navbar-expand-sm navbar-default">
      <div id="main-menu" class="main-menu collapse navbar-collapse show">
        <ul class="nav navbar-nav">
          <li routerLinkActive="active" [routerLinkActiveOptions]="{ exact: true }">
            <a routerLink="/dashboard"><i class="menu-icon fa fa-laptop"></i>Dashboard</a>
          </li>

          <li class="menu-title">UI elements</li>

          <li class="menu-item-has-children dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true"
              aria-expanded="false">
              <i class="menu-icon fa fa-cogs"></i>Components
            </a>
            <ul class="sub-menu children dropdown-menu">
              <li routerLinkActive="active">
                <i class="fa fa-puzzle-piece"></i><a routerLink="/ui/buttons">Buttons</a>
              </li>
            </ul>
          </li>

          <li class="menu-title">Extras</li>
          <li class="menu-item-has-children dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true"
              aria-expanded="false">
              <i class="menu-icon fa fa-glass"></i>Pages
            </a>
            <ul class="sub-menu children dropdown-menu">
              <li routerLinkActive="active">
                <i class="menu-icon fa fa-sign-in"></i><a routerLink="/auth/login">Login</a>
              </li>
              <li routerLinkActive="active">
                <i class="menu-icon fa fa-sign-in"></i><a routerLink="/auth/register">Register</a>
              </li>
              <li routerLinkActive="active">
                <i class="menu-icon fa fa-paper-plane"></i
                ><a routerLink="/auth/forgot">Forget Pass</a>
              </li>
            </ul>
          </li>
        </ul>
      </div>
    </nav>
  `,
})
export class SidebarComponent {}

