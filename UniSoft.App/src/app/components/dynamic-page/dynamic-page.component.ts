// components/dynamic-page/dynamic-page.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Application, Page, MenuElement, ComponentType, ComponentDB } from '../../../models/application.model';
import { ApplicationService } from '../../../services/application.service';

@Component({
  selector: 'app-dynamic-page',
  standalone: false,
  templateUrl: './dynamic-page.component.html',
  styleUrls: ['./dynamic-page.component.scss']
})
export class DynamicPageComponent implements OnInit {
  application: Application | null = null;
  currentPage: Page | null = null;
  currentMenuElement: MenuElement | null = null;
  components: ComponentDB[] = [];
  loading = true;
  error = false;
  ComponentType = ComponentType;  // Make enum available to template

  constructor(
    private route: ActivatedRoute,
    private applicationService: ApplicationService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const pageId = +params['id'];
      this.loadPage(pageId);
    });
  }

  loadPage(pageId: number): void {
    this.loading = true;
    this.applicationService.getApplicationDetails(1).subscribe({
      next: (app) => {
        this.application = app;
        
        // Find the menu element for this page
        this.currentMenuElement = app.menuElements.find(m => m.pageId === pageId) || null;
        
        // Set current page from menu element
        if (this.currentMenuElement && this.currentMenuElement.page) {
          this.currentPage = this.currentMenuElement.page;
          
          // Sort components by order
          this.components = [...this.currentPage.components]
            .filter(c => c.isVisible)
            .sort((a, b) => a.order - b.order);
        }
        
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading page:', err);
        this.error = true;
        this.loading = false;
      }
    });
  }
}