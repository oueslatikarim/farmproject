import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'auth',
    children: [
      {
        path: 'login',
        loadComponent: () =>
          import('./features/auth/pages/login-page.component').then((m) => m.LoginPageComponent),
      },
      {
        path: 'register',
        loadComponent: () =>
          import('./features/auth/pages/register-page.component').then(
            (m) => m.RegisterPageComponent,
          ),
      },
      {
        path: 'forgot',
        loadComponent: () =>
          import('./features/auth/pages/forgot-password-page.component').then(
            (m) => m.ForgotPasswordPageComponent,
          ),
      },
      { path: '', pathMatch: 'full', redirectTo: 'login' },
    ],
  },
  {
    path: '',
    loadComponent: () =>
      import('./layout/admin-layout/admin-layout.component').then((m) => m.AdminLayoutComponent),
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'dashboard',
      },
      {
        path: 'dashboard',
        loadComponent: () =>
          import('./features/dashboard/pages/dashboard-home-page.component').then(
            (m) => m.DashboardHomePageComponent,
          ),
      },
      {
        path: 'ui/buttons',
        loadComponent: () =>
          import('./features/ui/pages/ui-buttons-page.component').then((m) => m.UiButtonsPageComponent),
      },
      { path: '**', redirectTo: 'dashboard' },
    ],
  },
];
