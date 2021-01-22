import { Route } from '@angular/compiler/src/core';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/shared/Models/Basket';
import { OrderToCreate, OrderToReturn } from 'src/app/shared/Models/Order';
import { CheckoutService } from '../checkout.service';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss']
})
export class CheckoutPaymentComponent implements OnInit {

  @Input() checkoutForm: FormGroup;

  constructor(private basketService: BasketService, private checkoutService: CheckoutService, private router: Router) { }

  ngOnInit() {
  }


  submitOrder() {

    const basket = this.basketService.getCurrentBasketValue();
    const orderToCreate = this.getOrderToCreate(basket);

    this.checkoutService.createOrder(orderToCreate)
      .subscribe((res: OrderToReturn) => {      
        this.basketService.deleteLocalBasket();
        const navigationExtras: NavigationExtras = { state: res }
        this.router.navigate(['checkout/success'], navigationExtras);
      }, error => {
        console.log(error);
      });
  }

  private getOrderToCreate(basket: IBasket): OrderToCreate {
    return {
      basketId: basket.id,
      deliveryMethodId: +this.checkoutForm.get('deliveryForm').get('deliveryMethod').value,
      shippingAddress: this.checkoutForm.get('addressForm').value
    }
  }
}
