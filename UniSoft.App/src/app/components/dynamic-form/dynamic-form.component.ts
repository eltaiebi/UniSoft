import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ComponentDB, DynamicCol, DynamicLine, FieldType, FormComponentField } from '../../../models/application.model';
import { DynamicDataService } from '../../../services/dynamic-data.service'; // Import du service

@Component({
  selector: 'app-dynamic-form',
  standalone: false,
  templateUrl: './dynamic-form.component.html',
  styleUrls: ['./dynamic-form.component.scss']
})
export class DynamicFormComponent implements OnInit {
  @Input() component!: ComponentDB; // Structure des champs
  @Input() initialData: any = null; // Données existantes pour modification
  @Output() formSubmit = new EventEmitter<any>(); // Émission des données au parent (modal)

  form!: FormGroup;
  FieldType = FieldType; // Permet l'utilisation de l'énumération dans le template
  isLoading = false; // Indicateur de chargement pour le bouton

  constructor(
    private fb: FormBuilder,
    private dynamicDataService: DynamicDataService // Injection du service
  ) {}

  ngOnInit(): void {
    this.buildForm();
  }

  buildForm(): void {
    const formControls: any = {};
    
    // Trier les champs selon leur ordre
    const sortedFields = [...this.component.fields].sort((a, b) => a.order - b.order);
    
    sortedFields.forEach(field => {
      const validators = [];

      // Champs requis
      if (field.column?.isPrimaryKey) {
        validators.push(Validators.required);
      }
      
      if (field.regex) {
        validators.push(Validators.pattern(field.regex));
      }
      
      if (field.length) {
        validators.push(Validators.maxLength(field.length));
      }

      // Définir la valeur initiale : si on est en mode édition, prendre `initialData`
      const initialValue = this.initialData ? this.initialData[field.name] || '' : '';

      formControls[field.name] = [initialValue, validators];
    });
    
    this.form = this.fb.group(formControls);
  }

  onSubmit(): void {
    if (this.form.valid) {
      this.isLoading = true;
      const formData = this.form.value;
      let cols: DynamicCol[] = Object.entries(formData).map(([key, value]) => ({
        columnName: key,
        value: value === null || value === undefined ? "" : 
               typeof value === "object" ? JSON.stringify(value) : String(value),
        typesql: "SomeType"
      }));
      
      let line : DynamicLine = {rows: cols}
      // Si on est en mode ajout (pas de données initiales)
      if (!this.initialData) {
        this.dynamicDataService.addData(this.component.tableId, line).subscribe(
          (response) => {
            console.log('Ajout effectué:', response);
            this.isLoading = false;
            this.handleFormSubmitSuccess(); // Réussite, on émet l'événement pour fermer le modal
          },
          (error) => {
            console.error('Erreur lors de l\'ajout:', error);
            this.isLoading = false;
            this.handleFormSubmitError(error); // Erreur, on affiche le message d'erreur
          }
        );
      } else {
        // Si on est en mode modification (on a des données initiales)
        this.dynamicDataService.updateData(this.component.tableId, this.initialData.id, line).subscribe(
          (response) => {
            console.log('Modification effectuée:', response);
            this.isLoading = false;
            this.handleFormSubmitSuccess(); // Réussite, on émet l'événement pour fermer le modal
          },
          (error) => {
            console.error('Erreur lors de la modification:', error);
            this.isLoading = false;
            this.handleFormSubmitError(error); // Erreur, on affiche le message d'erreur
          }
        );
      }
    } else {
      this.markFormGroupTouched(this.form);
    }
  }

  handleFormSubmitSuccess(): void {
    this.formSubmit.emit({ success: true }); // Émet success pour fermer le modal
  }

  handleFormSubmitError(error: any): void {
    this.formSubmit.emit({ success: false, error: error.message }); // Émet error pour afficher un message d'erreur dans le modal
  }

  markFormGroupTouched(formGroup: FormGroup) {
    Object.values(formGroup.controls).forEach(control => {
      control.markAsTouched();
      
      if ((control as any).controls) {
        this.markFormGroupTouched(control as FormGroup);
      }
    });
  }

  isFieldVisible(field: FormComponentField): boolean {
    return true; // Ajoute une logique si besoin
  }
}




