import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { error } from 'protractor';
import { DeliveryMethod } from 'src/app/shared/Models/DeliveryMethod';
import { CheckoutService } from '../checkout.service';

@Component({
  selector: 'app-checkout-delivery',
  templateUrl: './checkout-delivery.component.html',
  styleUrls: ['./checkout-delivery.component.scss']
})
export class CheckoutDeliveryComponent implements OnInit {

  @Input() checkoutForm: FormGroup;
  deliveryMethods: DeliveryMethod[];

  constructor(private checkoutService: CheckoutService) { }

  ngOnInit() {

    this.getDeliveryMethods();
  }

  getDeliveryMethods() {

    this.checkoutService.getDeliveryMethods()
      .subscribe((res) => {
        this.deliveryMethods = res;
      }, error => {
        console.log(error);
      })
  }
}
