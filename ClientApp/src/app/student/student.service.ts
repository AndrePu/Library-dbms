import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Student } from './student.model';
import { OperationResult } from '../http/operation-result.model';

const url = 'https://localhost:5001/api/student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }


  public getAllStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(url);
  }

  public deleteStudent(studentId: number): Observable<OperationResult<void>> {
    return this.http.delete<OperationResult<void>>(url + `/${studentId}`, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Methods': 'DELETE' })
    });
  }

  public updateStudent(student: Student): Observable<OperationResult<void>> {
    return this.http.post<OperationResult<void>>(url + '/update', student);
  }

  public addStudent(student: Student): Observable<OperationResult<number>> {
    return this.http.post<OperationResult<number>>(url, student);
  }
}
