import { Component, OnInit } from '@angular/core';
import { EmployeeDetailService } from './../../shared/employee-detail.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styles: []
})
export class EmployeeDetailComponent implements OnInit {

  constructor(private service:EmployeeDetailService, 
    private toastr:ToastrService) { }

    ngOnInit() {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if(form!=null)
        form.resetForm();
    this.service.formData = { Name : '', ID : 0,  Department : '',  Gender : '',  City : '' }
  }
  onSubmit(form:NgForm)
  {
      if(this.service.formData.ID==0)
      {
          this.insertRecord(form);
      }
      else
      {
          this.updateRecord(form);
      }
  }
  insertRecord(form: NgForm)
  {
    this.service.PostEmployeeDetail().subscribe (
      res=>{
        this.resetForm(form);
        this.toastr.success("Submitted Successfully","Employee Details Register");
        this.service.refreshList();
      },
      err=> {
        console.log(err);
        this.toastr.error("Failed to Save","Employee Details Register");
        this.service.refreshList();
      }
    )
  }
  updateRecord(form: NgForm)
  {
      this.service.PutEmployeeDetail().subscribe (
      res=>{
        this.resetForm(form);
        this.toastr.success("Updated Successfully","Employee Details Register");
        this.service.refreshList();
      },
      err=> {
        console.log(err);
        this.toastr.error("Failed to Update","Employee Details Register");
      }
    )
  }
}


