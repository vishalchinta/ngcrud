import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from '../shared/payment-detail.service';
import { PaymentDetail } from '../shared/payment-detail.model';
import { ToastrService } from 'ngx-toastr'


@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styles: ``
})
export class PaymentDetailsComponent implements OnInit {
  constructor(public service: PaymentDetailService, private toatr: ToastrService) {

  }
  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForn(selectedRecord: PaymentDetail) {
    this.service.formdata = Object.assign({}, selectedRecord);
  }

  deleteRecord(id: number) {
    if (confirm('Are you sure to delete this record'))
      this.service.deletePaymentDetail(id)
        .subscribe({
          next: res => {
            this.service.list = res as PaymentDetail[]
            this.toatr.error('delete successfully', 'Payment Detail Register')
          }
        })
  }
}
