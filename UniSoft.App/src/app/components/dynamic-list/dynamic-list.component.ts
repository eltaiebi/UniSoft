import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ComponentDB, DynamicData } from '../../../models/application.model';
import { DynamicDataService } from '../../../services/dynamic-data.service';

@Component({
  selector: 'app-dynamic-list',
  standalone: false,
  templateUrl: './dynamic-list.component.html',
  styleUrls: ['./dynamic-list.component.scss']
})
export class DynamicListComponent implements OnInit {
  @Input() component!: ComponentDB;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  dataSource = new MatTableDataSource<any>([]);
  displayedColumns: string[] = [];

  constructor(private dynamicDataService: DynamicDataService) {}

  ngOnInit(): void {
    if (this.component?.tableId) {
      this.loadData(this.component.tableId);
    }
  }

  ngAfterViewInit() {
    if (this.component.hasPagination && this.paginator) {
      this.dataSource.paginator = this.paginator;
    }
  }

  loadData(tableId: number): void {
    this.dynamicDataService.getAllData(tableId).subscribe({
      next: (response: DynamicData) => {
        if (response.data.length > 0) {
          this.displayedColumns = Object.keys(response.data[0]); // Déterminer dynamiquement les colonnes
          this.dataSource.data = response.data;
        }
      },
      error: (error) => {
        console.error('Erreur lors du chargement des données:', error);
      }
    });
  }
}
