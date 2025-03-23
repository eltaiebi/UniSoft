// components/dynamic-form/dynamic-form.component.ts
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ComponentDB, FieldType, FormComponentField } from '../../../models/application.model';

@Component({
  selector: 'app-dynamic-form',
  standalone: false,
  templateUrl: './dynamic-form.component.html',
  styleUrls: ['./dynamic-form.component.scss']
})
export class DynamicFormComponent implements OnInit {
  @Input() component!: ComponentDB;
  
  form!: FormGroup;
  FieldType = FieldType; // Make enum available to template
  
  constructor(private fb: FormBuilder) {}
  
  ngOnInit(): void {
    this.buildForm();
  }
  
  buildForm(): void {
    const formControls: any = {};
    
    // Sort fields by order
    const sortedFields = [...this.component.fields].sort((a, b) => a.order - b.order);
    
    sortedFields.forEach(field => {
      // Get validators
      const validators = [];
      
      // Required for all primary keys
      if (field.column?.isPrimaryKey) {
        validators.push(Validators.required);
      }
      
      // Regex validator if specified
      if (field.regex) {
        validators.push(Validators.pattern(field.regex));
      }
      
      // Set max length if specified
      if (field.length) {
        validators.push(Validators.maxLength(field.length));
      }
      
      // Add control to form with initial value
      formControls[field.name] = [field.value || '', validators];
    });
    
    this.form = this.fb.group(formControls);
  }
  
  onSubmit(): void {
    if (this.form.valid) {
      console.log('Form submitted:', this.form.value);
      // Here you would send the data to your backend
    } else {
      this.markFormGroupTouched(this.form);
    }
  }
  
  // Helper method to mark all controls as touched
  markFormGroupTouched(formGroup: FormGroup) {
    Object.values(formGroup.controls).forEach(control => {
      control.markAsTouched();
      
      if ((control as any).controls) {
        this.markFormGroupTouched(control as FormGroup);
      }
    });
  }
  
  // Helper to check if field should be visible
  isFieldVisible(field: FormComponentField): boolean {
    return true; // You can add logic here based on your requirements
  }
}