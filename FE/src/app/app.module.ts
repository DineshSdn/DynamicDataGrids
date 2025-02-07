import { HttpClientModule } from '@angular/common/http';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './Componand/home/home.component';
import { ViewFieldComponent } from './Componand/view-field/view-field.component';
import { HealthProfileComponent } from './Componand/health-profile/health-profile.component';
import { MatOptionModule } from '@angular/material/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { MatSelectModule, MAT_SELECT_SCROLL_STRATEGY } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Overlay, OverlayModule } from '@angular/cdk/overlay';
import { MultiSelectModule } from 'primeng/multiselect'; // PrimeNG MultiSelect module
import { ButtonModule } from 'primeng/button'; // PrimeNG Button module
import { BrowserModule } from '@angular/platform-browser';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { CheckboxModule } from 'primeng/checkbox';
import { View2Component } from './view2/view2.component';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { AccordionModule } from 'primeng/accordion';
import { CalendarModule } from 'primeng/calendar';
import { TooltipModule } from 'primeng/tooltip';







@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ViewFieldComponent,
    HealthProfileComponent,
   HealthProfileComponent,
   View2Component
   
  ],
  imports: [
    BrowserModule,
    DialogModule,
    DropdownModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatOptionModule,
    MatSelectModule,
    BrowserAnimationsModule,
    CommonModule,
    MatFormFieldModule,
    OverlayModule,
    MultiSelectModule,
    ButtonModule,
    NgMultiSelectDropDownModule,
    CheckboxModule,
    DragDropModule,
    InputTextModule,
    InputTextareaModule,
    DropdownModule,
    MultiSelectModule,
    CalendarModule,
    TooltipModule,
    AccordionModule
  
  ],
  schemas: [NO_ERRORS_SCHEMA],
  providers: [
    {
      provide: MAT_SELECT_SCROLL_STRATEGY,
      useFactory: (overlay: Overlay) => () => overlay.scrollStrategies.block(),
      deps: [Overlay]
    }
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
