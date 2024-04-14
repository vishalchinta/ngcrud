import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr'
import { EmployeeDetail } from '../../shared/employee-detail.model';
import { EmployeeDetailService } from '../../shared/employee-detail.service';

@Component({
  selector: 'app-employee-detail-form',
  templateUrl: './employee-detail-form.component.html',
  styles: ``
})
export class EmployeeDetailFormComponent {
  constructor(public service: EmployeeDetailService, private toastr: ToastrService) {

  }


  onSubmit(form: NgForm) {
    this.service.formSubmitted = true
    if (form.valid) {
      if (this.service.formdata.id == 0) {
        this.insertRecord(form)
      } else {
        this.updateRecord(form);
      }
    }
  }

  insertRecord(form: NgForm) {
    this.service.postEmployeeDetail()
      .subscribe({
        next: res => {
          this.service.list = res as EmployeeDetail[];
          this.service.resetForm(form);
          this.toastr.success('Inserted successfully', 'Employee Detail')
        }, error: err => {
          console.log(err);
        }
      })
  }
  updateRecord(form: NgForm) {
    this.service.putEmployeeDetail()
      .subscribe({
        next: res => {
          this.service.list = res as EmployeeDetail[];
          this.service.resetForm(form);
          this.toastr.info('Updated successfully', 'Employee Detail')
        }, error: err => {
          console.log(err);
        }
      })
  }

}
