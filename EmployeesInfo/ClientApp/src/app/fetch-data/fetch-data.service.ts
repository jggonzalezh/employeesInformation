import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Employee {

  id: number;
  name: string;
  contractTypeName: string;
  roleId: number;
  roleName: string;
  roleDescription: string;
  hourlySalary: number;
  monthlySalary: number;
  annualSalary: number;

}

@Injectable({
  providedIn: 'root'
})
export class FetchDataService {

  baseUrl;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.baseUrl = baseUrl;

   }

   getEmployees(): Observable<Employee[]> {
    return  this.http.get<Employee[]>(this.baseUrl + 'api/Employess');
  }


  getEmployeById( id: string) {

    return this.http.get<Employee[]>(this.baseUrl + 'api/Employess/' + id);
  }

}

