import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BasketService } from 'src/app/basket/basket.service';
import { OrderToReturn } from 'src/app/shared/Models/Order';

@Component({
  selector: 'app-checkout-success',
  templateUrl: './checkout-success.component.html',
  styleUrls: ['./checkout-success.component.scss']
})
export class CheckoutSuccessComponent implements OnInit {

  order: OrderToReturn;

  constructor(private router: Router, private basketService:BasketService) {

    const navigation = this.router.getCurrentNavigation();
    const state = navigation && navigation.extras && navigation.extras.state;


    if (state) {
      this.order = state as OrderToReturn;
      console.log(this.order);
      this.basketService.shipping = 0;
    }

  }

  ngOnInit() {
  }

}
