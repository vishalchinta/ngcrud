import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { EmployeeDetail } from './employee-detail.model';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDetailService {
  url: string = environment.apiBaseUrl + '/EmployeeDetail';
  list: EmployeeDetail[] = [];
  formdata: EmployeeDetail = new EmployeeDetail();
  formSubmitted: boolean = false;
  constructor(private http: HttpClient) { }

  refreshList() {
    this.http.get(this.url).subscribe({
      next: res => {
        console.log(res);
        this.list = res as EmployeeDetail[];
      },
      error: err => { console.log(err); }
    });
  }

  postEmployeeDetail() {
    return this.http.post(this.url, this.formdata)
  }
  putEmployeeDetail() {
    return this.http.put(this.url + '/' + this.formdata.id, this.formdata)
  }

  deleteEmployeeDetail(id: number) {
    return this.http.delete(this.url + '/' + id)
  }

  resetForm(form: NgForm) {
    form.form.reset()
    this.formdata = new EmployeeDetail()
    this.formSubmitted = false
  }
}
