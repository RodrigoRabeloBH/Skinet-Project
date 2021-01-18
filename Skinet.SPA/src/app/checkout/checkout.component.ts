import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../account/account.service';
import { CheckoutService } from './checkout.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  checkoutForm: FormGroup;

  constructor(private fb: FormBuilder, private checkoutService: CheckoutService, private accountService: AccountService) { }

  ngOnInit() {
    this.createCheckouForm();
    this.getAddresFormValues();
  }

  createCheckouForm() {

    this.checkoutForm = this.fb.group({
      addressForm: this.fb.group({
        firstName: [null, Validators.required],
        lastName: [null, Validators.required],
        street: [null, Validators.required],
        number: [null, Validators.required],
        district: [null, Validators.required],
        city: [null, Validators.required],
        state: [null, Validators.required],
        zipCode: [null, Validators.required],
        complement: [null]
      }),
      deliveryForm: this.fb.group({
        deliveryMethod: [null, Validators.required]
      }),
      paymentForm: this.fb.group({
        nameOnCard: [null, Validators.required]
      })
    });
  }

  getAddresFormValues() {
    this.accountService.getUserAddress()
      .subscribe(address => {
        if (address) {       
          this.checkoutForm.get('addressForm').patchValue(address);
        }
      }, error => {
        console.log(error);
      })
  }
}
