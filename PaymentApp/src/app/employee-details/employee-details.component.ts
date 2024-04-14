import { Component } from '@angular/core';
import { EmployeeDetailService } from '../shared/employee-detail.service';
import { ToastrService } from 'ngx-toastr';
import { EmployeeDetail } from '../shared/employee-detail.model';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styles: ``
})
export class EmployeeDetailsComponent {
  constructor(public service: EmployeeDetailService, private toastr: ToastrService) {
  }
  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForn(selectedRecord: EmployeeDetail) {
    this.service.formdata = Object.assign({}, selectedRecord);
  }

  deleteRecord(id: number) {
    if (confirm('Are you sure to delete this record'))
      this.service.deleteEmployeeDetail(id)
        .subscribe({
          next: res => {
            this.service.list = res as EmployeeDetail[]
            this.toastr.error('delete successfully', 'Employee Detail')
          }
        })
  }
}
