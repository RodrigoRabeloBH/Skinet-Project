import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { IBasket, Basket, IBasketTotals } from '../shared/Models/Basket';
import { map } from 'rxjs/operators';
import { IBasketItem } from '../shared/Models/BasketItem';
import { Product } from '../shared/Models/Product';

@Injectable({
  providedIn: 'root'
})

export class BasketService {

  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  private basketTotalSource = new BehaviorSubject<IBasketTotals>(null);
  basket$ = this.basketSource.asObservable();
  basketTotal$ = this.basketTotalSource.asObservable();
  basket: IBasket;

  constructor(private http: HttpClient) { }

  getBasketRedis(id: string) {

    return this.http.get(this.baseUrl + 'baskets?id=' + id)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          this.calculateTotals();
        })
      );
  }

  getBasketLoacalStorage() {

    this.basket = JSON.parse(localStorage.getItem('basket'));
    this.basketSource.next(this.basket);
    return this.basket;
  }

  setBasketLocalStorage(basket: IBasket) {

    localStorage.setItem('basket', JSON.stringify(basket));
    this.basketSource.next(basket);
    this.calculateTotals();
  }

  setBasketRedis(basket: IBasket) {
    return this.http.post(this.baseUrl + 'baskets', basket)
      .subscribe((res: IBasket) => {
        this.basketSource.next(res);
        this.calculateTotals();
      }, error => {
        console.log(error);
      });
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: Product, quantity = 1) {
    const itemToAdd: IBasketItem = this.mapProductItemToBasketItem(item, quantity);
    let basket = this.getCurrentBasketValue();
    if (basket === null) {
      basket = this.createBasket();
    }
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasketLocalStorage(basket);
  }

  incrementItemQuantity(item: IBasketItem) {

    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(i => i.id === item.id);
    basket.items[foundItemIndex].quantity++;
    this.setBasketLocalStorage(basket);

  }

  decrementItemQuantity(item: IBasketItem) {

    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(i => i.id === item.id);

    if (basket.items[foundItemIndex].quantity > 1) {
      basket.items[foundItemIndex].quantity--;
      this.setBasketLocalStorage(basket);

    } else {
      this.removeItemFromBasket(item);
    }
  }

  removeItemFromBasket(item: IBasketItem) {

    const basket = this.getCurrentBasketValue();

    if (basket.items.some(i => i.id === item.id)) {

      basket.items = basket.items.filter(i => i.id !== item.id);

      if (basket.items.length > 0) {
        this.setBasketLocalStorage(basket);
      } else {
        this.deleteBasketLocalStore(basket);
      }
    }
  }

  deleteBasketRedis(basket: IBasket) {

    return this.http.delete(this.baseUrl + 'baskets?id=' + basket.id).subscribe(() => {

      this.basketSource.next(null);
      this.basketTotalSource.next(null);
      localStorage.removeItem('basket_id');
    }, error => {
      console.log(error);
    });
  }

  deleteBasketLocalStore(basket: IBasket) {

    this.basketSource.next(null);
    this.basketTotalSource.next(null);
    localStorage.removeItem('basket');

  }

  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {

    const index = items.findIndex(i => i.id === itemToAdd.id)
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }
    return items;
  }

  private createBasketRedis(): IBasket {

    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private createBasket(): IBasket {

    const basket = new Basket();
    localStorage.setItem('basket', JSON.stringify(basket));
    return basket;
  }

  private mapProductItemToBasketItem(item: Product, quantity: number): IBasketItem {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      imageUrl: item.imageUrl,
      quantity,
      brand: item.productBrand,
      type: item.productType,
      tierPriceDescription: item.tierPriceDescription,
      percent: item.percent,
      tierPriceId: item.tierPriceId
    }
  }
  private calculateTotals() {
    const basket = this.getCurrentBasketValue();
    const shipping = 0;
    const subtotal = basket.items.reduce((i, p) => (p.price * p.quantity) + i, 0);
    let total = 0;

    basket.items.forEach((item) => {
      if (item.tierPriceId === 1 && item.quantity % 2 === 0) {

        total += item.price * item.quantity * item.percent;

      } else if (item.tierPriceId === 2 && item.quantity % 3 === 0) {

        total += 10 * item.quantity * item.percent

      } else {
        total += item.price * item.quantity;
      }
    });

    this.basketTotalSource.next({ shipping, total, subtotal });
  }
}
