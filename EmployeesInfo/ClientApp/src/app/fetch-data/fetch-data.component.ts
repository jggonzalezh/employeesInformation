import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {

  public employees: Employee[];
  baseUrl;
  notfound: boolean = false;


   employeesForm = this.fb.group({
    employeeId: [''],
  });

  constructor(private fb: FormBuilder, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  onSubmit() {
    if (this.employeeId.value === '') {
      this.getEmployees()
    } else {
      this.getEmployeById(this.employeeId.value);
    }

  }

    getEmployees() {

      this.http.get<Employee[]>(this.baseUrl + 'api/Employess').subscribe(result => {
        this.employees = result;
        this.employeeId.setValue('');
        this.notfound = false;
      }, error => console.error(error));
  }

  getEmployeById( id: string) {

    this.http.get<Employee[]>(this.baseUrl + 'api/Employess/'+id).subscribe(result => {
      this.employees = result;
      this.employeeId.setValue('');
      this.notfound = false;
    }, error => {
        if (error.status === 404) {
          this.notfound = true;
          this.employees = [];
        }
      console.error(error)
    }
    );
  }




   get employeeId() {
    return this.employeesForm.get('employeeId');
  }


}

interface Employee {

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
