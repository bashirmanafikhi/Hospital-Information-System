import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PatientAddComponent } from './components/patient-add/patient-add.component';
import { PatientItemComponent } from './components/patient-item/patient-item.component';
import { PatientItemsComponent } from './components/patient-items/patient-items.component';
import { PatientFilterComponent } from './components/patient-filter/patient-filter.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    PatientItemComponent,
    PatientItemsComponent,
    PatientAddComponent,
    PatientFilterComponent,
    PaginationComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
