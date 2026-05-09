import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [RouterLink],
  template: `
    <div class="bg-dark" style="min-height: 100vh;">
      <div class="sufee-login d-flex align-content-center flex-wrap">
        <div class="container">
          <div class="login-content">
            <div class="login-logo">
              <a routerLink="/dashboard">
                <img class="align-content" src="assets/images/logo.png" alt="" />
              </a>
            </div>
            <div class="login-form">
              <form>
                <div class="form-group">
                  <label>Email address</label>
                  <input type="email" class="form-control" placeholder="Email" />
                </div>
                <div class="form-group">
                  <label>Password</label>
                  <input type="password" class="form-control" placeholder="Password" />
                </div>
                <div class="checkbox">
                  <label> <input type="checkbox" /> Remember Me </label>
                  <label class="pull-right">
                    <a routerLink="/auth/forgot">Forgotten Password?</a>
                  </label>
                </div>
                <button type="submit" class="btn btn-success btn-flat m-b-30 m-t-30">Sign in</button>
                <div class="register-link m-t-15 text-center">
                  <p>Don't have account ? <a routerLink="/auth/register">Sign Up Here</a></p>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  `,
})
export class LoginPageComponent {}

