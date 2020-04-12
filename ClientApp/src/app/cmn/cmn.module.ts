import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { SatPopoverModule } from '@ncstate/sat-popover';
import { InlineEditComponent } from './components/inline-edit/inline-edit.component';

@NgModule({
  declarations: [
    InlineEditComponent,
  ],
  imports: [
    SatPopoverModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  exports: [
      InlineEditComponent
  ]
})
export class CommonModule { }
