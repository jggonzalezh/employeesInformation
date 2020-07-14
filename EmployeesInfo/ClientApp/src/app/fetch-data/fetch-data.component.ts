import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
import { FetchDataService , Employee } from './fetch-data.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {

  public employees: Employee[];
  baseUrl;
  notfound = false;
  showloading = false;

   employeesForm = this.fb.group({
    employeeId: [''],
  });

  constructor(
               private fb: FormBuilder, private fetchDataService: FetchDataService
              ) {
  }

  onSubmit() {
    if (this.employeeId.value === '') {
      this.getEmployees()
    } else {
      this.getEmployeById(this.employeeId.value);
    }

  }

    getEmployees() {
      this.showloading = true;
      this.fetchDataService.getEmployees().subscribe(result => {
        this.employees = result;
        this.showloading = false;
        this.employeeId.setValue('');
        this.notfound = false;
      }, error => console.error(error));
  }

  getEmployeById( id: string) {
    this.showloading = true;
    this.fetchDataService.getEmployeById(id).subscribe(result => {
      this.employees = result;
      this.showloading = false;
      this.employeeId.setValue('');
      this.notfound = false;
    }, error => {
        if (error.status === 404) {
          this.notfound = true;
          this.employees = [];
        }
      console.error(error);
    }
    );
  }




   get employeeId() {
    return this.employeesForm.get('employeeId');
  }


}
