import { DEFAULT_CURRENCY_CODE, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtHelperService, JWT_OPTIONS  } from '@auth0/angular-jwt';

import { CdkTreeModule } from '@angular/cdk/tree';
import { OverlayModule } from '@angular/cdk/overlay';
import { PortalModule } from '@angular/cdk/portal';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTreeModule } from '@angular/material/tree';
import { MatBadgeModule } from '@angular/material/badge';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatRadioModule } from '@angular/material/radio';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule } from '@angular/material/dialog';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { AppRoutingModule } from './app-routing.module';
import { DoctorsPresentationComponent } from './pages/doctors-presentation/doctors-presentation.component';
import { LayoutModule } from '@angular/cdk/layout';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { SharedModule } from './shared/shared.module';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { AppointmentsComponent } from './pages/appointments/appointments.component';
import { MatTableModule } from '@angular/material/table';

import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ChooseTimeIntervalMatDialogComponent } from './pages/appointments/choose-time-interval-mat-dialog/choose-time-interval-mat-dialog.component';
import { AddAppointmentMatDialogComponent } from './pages/appointments/add-appointment-mat-dialog/add-appointment-mat-dialog.component';
import { ProceduresComponent } from './pages/procedures/procedures.component';
import { AddProcedureDialogComponent } from './pages/procedures/add-procedure-dialog/add-procedure-dialog.component';
import { CurrencyConversionPipe } from './pipes/currency-conversion.pipe';
import { FullNamePipe } from './pipes/full-name.pipe';
import { IdFullNamePipe } from './pipes/id-full-name.pipe';
import { EditProfileDialogComponent } from './pages/pacient-profile/edit-profile-dialog/edit-profile-dialog.component';
import { PacientProfileComponent } from './pages/pacient-profile/pacient-profile.component';
import { HighlightAppointmentStateDirective } from './directives/highlight-appointment-state.directive';
import { MakeAppointmentComponent } from './pages/make-appointment/make-appointment.component';

const materialModules = [
  CdkTreeModule,
  MatAutocompleteModule,
  MatButtonModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDividerModule,
  MatDialogModule,
  MatExpansionModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatTableModule,
  MatMenuModule,
  MatProgressSpinnerModule,
  MatPaginatorModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSnackBarModule,
  MatSortModule,
  MatTabsModule,
  MatToolbarModule,
  MatFormFieldModule,
  MatButtonToggleModule,
  MatTreeModule,
  OverlayModule,
  PortalModule,
  MatBadgeModule,
  MatGridListModule,
  MatRadioModule,
  MatDatepickerModule,
  MatTooltipModule,
  MatGridListModule,
  MatCardModule,
  MatMenuModule,
  MatIconModule,
  MatButtonModule,
  LayoutModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatSlideToggleModule
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomepageComponent,
    DoctorsPresentationComponent,
    LoginComponent,
    RegisterComponent,
    DashboardComponent,
    AppointmentsComponent,
    ChooseTimeIntervalMatDialogComponent,
    AddAppointmentMatDialogComponent,
    ProceduresComponent,
    AddProcedureDialogComponent,
    CurrencyConversionPipe,
    PacientProfileComponent,
    FullNamePipe,
    IdFullNamePipe,
    HighlightAppointmentStateDirective,
    EditProfileDialogComponent,
    MakeAppointmentComponent,
  ],
  imports: [
    materialModules,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SharedModule
  ],
  exports: [
    materialModules,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true,
    },
    { provide: JWT_OPTIONS,
      useValue: JWT_OPTIONS
    },
    { provide: DEFAULT_CURRENCY_CODE,
      useValue: 'RON'
    },
    JwtHelperService
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
