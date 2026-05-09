import { Injectable } from '@angular/core';

const STORAGE_KEY = 'farmtwin.token';

@Injectable({ providedIn: 'root' })
export class AuthTokenService {
  get(): string | null {
    return localStorage.getItem(STORAGE_KEY);
  }

  set(token: string): void {
    localStorage.setItem(STORAGE_KEY, token);
  }

  clear(): void {
    localStorage.removeItem(STORAGE_KEY);
  }
}

