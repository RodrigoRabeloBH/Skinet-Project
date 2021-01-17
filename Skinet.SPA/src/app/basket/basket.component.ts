import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasket } from '../shared/Models/Basket';
import { IBasketItem } from '../shared/Models/BasketItem';
import { BasketService } from './basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  basket$: Observable<IBasket>;


  constructor(private basketService: BasketService) { }

  ngOnInit() {
    this.basket$ = this.basketService.basket$;
  }

  removeBasketItem(item: IBasketItem) {
    this.basketService.removeItemFromBasket(item);
  }

  incrementItemQuantity(item: IBasketItem) {
    this.basketService.incrementItemQuantity(item);
  }
  decrementItemQuantity(item: IBasketItem) {
    this.basketService.decrementItemQuantity(item);
  }

  totalItem(item: IBasketItem) {
    if (item.tierPriceId === 2 && item.quantity % 2 === 0) {

      return item.price * item.quantity * item.percent;

    } else if (item.tierPriceId === 1 && item.quantity % 3 === 0) {

      return 10 * item.quantity * item.percent

    } else {
      return item.price * item.quantity;
    }
  }
}
