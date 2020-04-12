import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';

import { SatPopoverModule } from '@ncstate/sat-popover';
import { NgxLoadingModule } from 'ngx-loading';
import { CommonModule } from '../cmn/cmn.module';
import { StudentComponent } from './components/student/student.component';
import { StudentDialogComponent } from './components/student-dialog/student-dialog.component';


@NgModule({
  declarations: [
    StudentComponent,
    StudentDialogComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    SatPopoverModule,
    FormsModule,
    MatDialogModule,
    MatFormFieldModule,
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule,
    NgxLoadingModule
  ],
  entryComponents: [
    StudentDialogComponent
  ],
  exports: [StudentComponent]
})
export class StudentModule { }
