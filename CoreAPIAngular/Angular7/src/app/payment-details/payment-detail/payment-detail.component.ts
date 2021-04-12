import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from './../../shared/payment-detail.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.component.html',
  styles: []
})
export class PaymentDetailComponent implements OnInit {

  constructor(private service:PaymentDetailService,
    private toaster: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if(form!=null)
      form.resetForm();
    this.service.formData = {
      PMId : 0,
      CardOwnerName : '',
      CardNumber : '',
      ExpirationDate : '',
      CVV : ''
    }
  }
  
  onSubmit(form:NgForm)
  {
    if(this.service.formData.PMId==0)
    {
      this.insertRecord(form);
      
    }
    else
    this.updateRecord(form);
  }
     
updateRecord(form:NgForm)
  {
    this.service.putPaymentDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toaster.success('Submitted Successfully','Payment Detail Register');
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    
    )
  }
insertRecord(form:NgForm)
{
  this.service.postPaymentDetail().subscribe(
    res => {
      this.resetForm(form);
      this.toaster.success('Submitted Successfully','Payment Detail Register');
      this.service.refreshList();
    },
    err => {
      console.log(err);
    }
  
  )
}

}
