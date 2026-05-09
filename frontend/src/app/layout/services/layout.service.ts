import { Injectable, signal } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class LayoutService {
  private readonly _leftPanelOpen = signal(false);

  isLeftPanelOpen() {
    return this._leftPanelOpen();
  }

  toggleLeftPanel() {
    this._leftPanelOpen.update((v) => !v);
  }
}

