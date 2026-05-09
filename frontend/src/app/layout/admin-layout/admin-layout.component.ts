import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { FooterComponent } from '../footer/footer.component';
import { HeaderComponent } from '../header/header.component';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { LayoutService } from '../services/layout.service';

@Component({
  selector: 'app-admin-layout',
  standalone: true,
  imports: [RouterOutlet, SidebarComponent, HeaderComponent, FooterComponent],
  template: `
    <aside id="left-panel" class="left-panel" [class.open-menu]="layout.isLeftPanelOpen()">
      <app-sidebar />
    </aside>

    <div id="right-panel" class="right-panel">
      <app-header (toggleMenu)="layout.toggleLeftPanel()" />

      <div class="content">
        <div class="animated fadeIn">
          <router-outlet />
        </div>
      </div>

      <div class="clearfix"></div>
      <app-footer />
    </div>
  `,
})
export class AdminLayoutComponent {
  protected readonly layout = inject(LayoutService);
}

