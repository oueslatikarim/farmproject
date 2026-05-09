import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';

import { API_BASE_URL } from '../tokens';

@Injectable({ providedIn: 'root' })
export class ApiClient {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = inject(API_BASE_URL);

  url(path: string): string {
    const p = path.startsWith('/') ? path : `/${path}`;
    return `${this.baseUrl}${p}`;
  }

  get<T>(path: string) {
    return this.http.get<T>(this.url(path));
  }

  post<T>(path: string, body: unknown) {
    return this.http.post<T>(this.url(path), body);
  }
}

