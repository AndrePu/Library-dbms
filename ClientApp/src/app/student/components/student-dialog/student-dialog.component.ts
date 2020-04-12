import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Student } from '../../student.model';

@Component({
    selector: 'app-student-dialog',
    templateUrl: 'student-dialog.component.html',
  })
  export class StudentDialogComponent {

    constructor(
      public dialogRef: MatDialogRef<StudentDialogComponent>,
      @Inject(MAT_DIALOG_DATA) public data: Student) {}

    public onNoClick(): void {
      this.dialogRef.close();
    }

}
