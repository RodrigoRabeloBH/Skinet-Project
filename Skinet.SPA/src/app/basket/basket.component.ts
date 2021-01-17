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
}
