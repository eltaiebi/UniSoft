import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Application, MenuElement } from '../../../models/application.model';
import { ApplicationService } from '../../../services/application.service';

@Component({
  selector: 'app-main-layout',
  standalone: false,
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss']
})
export class MainLayoutComponent implements OnInit {
  application: Application | null = null;
  menuElements: MenuElement[] = [];
  loading = true;
  error = false;

  constructor(
    private applicationService: ApplicationService,
    public router: Router
  ) {}

  ngOnInit(): void {
    // Load application data with ID 1
    this.applicationService.getApplicationDetails(1).subscribe({
      next: (app) => {
        this.application = app;
        this.menuElements = app.menuElements.filter(m => m.isVisible);
        this.loading = false;
        
        // Sort menu elements by order
        this.menuElements.sort((a, b) => a.order - b.order);
      },
      error: (err) => {
        console.error('Error loading application:', err);
        this.error = true;
        this.loading = false;
      }
    });
  }

  navigateToPage(pageId: number | null): void {
    if (pageId) {
      this.router.navigate(['/page', pageId]);
    }
  }
}