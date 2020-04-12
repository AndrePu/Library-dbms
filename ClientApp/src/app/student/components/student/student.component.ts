import { Component, OnInit, ViewChild } from '@angular/core';
import { StudentService } from '../../student.service';
import { Student } from '../../student.model';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { StudentDialogComponent } from '../student-dialog/student-dialog.component';
import { ToasterService, Toast, BodyOutputType } from 'angular2-toaster';
import { OperationResult } from '../../../http/operation-result.model';
import { OperationStatus } from '../../../http/operation-status.model';


@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {
  public displayedColumns = ['firstname', 'lastname', 'libraryCardId', 'groupId', 'action'];
  public students: Student[];
  public loadedInfo = false;
  public dataSource: MatTableDataSource<Student>;

  constructor(private studentService: StudentService, public dialog: MatDialog, private toastService: ToasterService) { }

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  public ngOnInit(): void {
    this.studentService.getAllStudents().subscribe(students => {
      this.students = students;
      this.dataSource = new MatTableDataSource<Student>(students);
      this.dataSource.paginator = this.paginator;
      this.loadedInfo = true;
    });
  }

  public onDeleteClick(studentId: number): void {
    this.studentService.deleteStudent(studentId).subscribe((result: OperationResult<void>) => {
      if (result && result.status === OperationStatus.Ok) {
        this.deleteStudentFromArray(studentId);
        const toast: Toast = {
          type: 'success',
          body: 'Record was successfully deleted',
          bodyOutputType: BodyOutputType.Default
        };
        this.toastService.pop(toast);
      } else {
        const toast: Toast = {
        type: 'error',
        body: result.message,
        bodyOutputType: BodyOutputType.Default
        };
        this.toastService.pop(toast);
      }
    });
  }

  public updateStudent(studentId: number, field: string, value: string): void {

    if (!value) {
      return;
    }

    const studentIndex = this.findStudentIndexInArray(studentId);

    this.students[studentIndex][field] = value;

    this.studentService.updateStudent(this.students[studentIndex]).subscribe((res: OperationResult<void>) => {
      if (res && res.status === OperationStatus.Ok) {
        const toast: Toast = {
          type: 'success',
          body: 'Record successfully updated!',
          bodyOutputType: BodyOutputType.Default
        };
        this.toastService.pop(toast);
      } else {
        const toast: Toast = {
          type: 'error',
          body: res.message,
          bodyOutputType: BodyOutputType.Default
        };
        this.toastService.pop(toast);
      }
    });
  }

  private findStudentIndexInArray(studentId: number): number {
    for (let i = 0; i < this.students.length; i++) {
      if (this.students[i].id === studentId) {
        return i;
      }
    }

    return null;
  }

  private deleteStudentFromArray(studentId: number): void {
    for (let i = 0; i  < this.students.length; i++) {
      if (this.students[i].id === studentId) {
        this.students.splice(i, 1);
        this.dataSource.data = this.students;
        return;
      }
    }
  }

  public onAddStudentClick(): void {

    const dialogRef = this.dialog.open(StudentDialogComponent, {
      data: Object.assign(new Student(), {firstname: '', secondname: '', studentgroupId: ''}),
    });

    dialogRef.afterClosed().subscribe(result => {

      if (result) {
        this.studentService.addStudent(result).subscribe((res: OperationResult<number>) => {
          if (res) {

            if (res.status === OperationStatus.Ok) {

              result.id = res.result;
              console.log(res.result);
              this.students.push(result);
              this.dataSource.data  = this.students;

              const toast: Toast = {
                type: 'success',
                body: 'Record was successfully added',
                bodyOutputType: BodyOutputType.Default
              };
              this.toastService.pop(toast);

            } else {
              const toast: Toast = {
                type: 'error',
                body: res.message,
                bodyOutputType: BodyOutputType.Default
              };
              this.toastService.pop(toast);
            }

          }
        });
      }
    });
  }
}
