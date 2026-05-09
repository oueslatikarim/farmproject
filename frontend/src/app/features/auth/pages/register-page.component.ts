import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-register-page',
  standalone: true,
  imports: [RouterLink],
  template: `
    <div class="card">
      <div class="card-body">
        <h4 class="box-title">Register</h4>
        <p class="text-muted">Stub page. Next step: port dashboard/page-register.html here.</p>
        <a class="btn btn-link p-0" routerLink="/auth/login">Back to login</a>
      </div>
    </div>
  `,
})
export class RegisterPageComponent {}

