import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from '../../Models/Basket';
import { IBasketItem } from '../../Models/BasketItem';

@Component({
  selector: 'app-basket-sumary',
  templateUrl: './basket-sumary.component.html',
  styleUrls: ['./basket-sumary.component.scss']
})
export class BasketSumaryComponent implements OnInit {

  basket$: Observable<IBasket>;

  @Output() decrement: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() increment: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() remove: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() total: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Input() isBasket: boolean = true;

  itemTotal: number


  constructor(private basketService: BasketService) { }

  ngOnInit() {

    this.basket$ = this.basketService.basket$;

  }

  decrementItemQuantity(item: IBasketItem) {

    this.decrement.emit(item);
  }

  incrementItemQuantity(item: IBasketItem) {

    this.increment.emit(item);
  }
  removeBasketItem(item: IBasketItem) {

    this.remove.emit(item);
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
