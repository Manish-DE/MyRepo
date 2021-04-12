import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from './../../shared/payment-detail.service';
import { PaymentDetail } from 'src/app/shared/payment-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-detail-list',
  templateUrl: './payment-detail-list.component.html',
  styles: []
})
export class PaymentDetailListComponent implements OnInit {

  constructor( private service: PaymentDetailService,
  private toaster: ToastrService) { }

  ngOnInit() {
    this.service.refreshList();
  }

 populateForm(pd:PaymentDetail) {
   this.service.formData = pd;
 }
 onDelete(PMId)
 {
   if(confirm('Are you sure to dete this record ?'))
    {
     this.service.deletePaymentDetail(PMId).subscribe(res =>{
        this.service.refreshList();
        this.toaster.warning('Deleted Successfully','Payment Detail Register');
      },
        err=>{
          console.log(err);
        })
      }
    }

 }

