import { AfterViewInit, Component, ElementRef, inject } from '@angular/core';

@Component({
  selector: 'app-dashboard-home-page',
  standalone: true,
  templateUrl: './dashboard-home-page.component.html',
  styleUrls: ['./dashboard-home-page.component.css'],
})
export class DashboardHomePageComponent implements AfterViewInit {
  private readonly host = inject(ElementRef<HTMLElement>);

  ngAfterViewInit(): void {
    this.animateCounts();
  }

  private animateCounts(durationMs = 3000): void {
    const els = Array.from(this.host.nativeElement.querySelectorAll('.count')).filter(
      (el): el is HTMLElement => el instanceof HTMLElement,
    );
    const start = performance.now();

    const targets = els.map((el) => {
      const raw = (el.textContent ?? '').trim().replace(/,/g, '');
      const n = Number(raw);
      return { el, target: Number.isFinite(n) ? n : 0 };
    });

    const tick = (now: number) => {
      const t = Math.min(1, (now - start) / durationMs);
      const eased = 1 - Math.pow(1 - t, 3);
      for (const { el, target } of targets) {
        el.textContent = String(Math.round(target * eased));
      }
      if (t < 1) requestAnimationFrame(tick);
    };

    requestAnimationFrame(tick);
  }
}

