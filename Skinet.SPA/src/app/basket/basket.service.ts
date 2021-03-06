import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { IBasket, Basket, IBasketTotals } from '../shared/Models/Basket';
import { map } from 'rxjs/operators';
import { IBasketItem } from '../shared/Models/BasketItem';
import { Product } from '../shared/Models/Product';
import { DeliveryMethod } from '../shared/Models/DeliveryMethod';

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
  shipping = 0;
  total = 0;

  constructor(private http: HttpClient) { }

  setShippingPrice(delivery: DeliveryMethod) {
    this.shipping = delivery.price;
    this.calculateTotals();
  }

  getBasketRedis(id: string) {

    return this.http.get(this.baseUrl + 'baskets?id=' + id)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          this.calculateTotals();
        })
      );
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
      basket = this.createBasketRedis();
    }
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasketRedis(basket);
  }

  incrementItemQuantity(item: IBasketItem) {

    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(i => i.id === item.id);
    basket.items[foundItemIndex].quantity++;
    this.setBasketRedis(basket);

  }

  decrementItemQuantity(item: IBasketItem) {

    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(i => i.id === item.id);

    if (basket.items[foundItemIndex].quantity > 1) {
      basket.items[foundItemIndex].quantity--;
      this.setBasketRedis(basket);

    } else {
      this.removeItemFromBasket(item);
    }
  }

  removeItemFromBasket(item: IBasketItem) {

    const basket = this.getCurrentBasketValue();

    if (basket.items.some(i => i.id === item.id)) {

      basket.items = basket.items.filter(i => i.id !== item.id);

      if (basket.items.length > 0) {
        this.setBasketRedis(basket);
      } else {
        this.deleteBasketRedis(basket);
      }
    }
  }

  deleteLocalBasket() {
    this.basketSource.next(null);
    this.basketTotalSource.next(null);
    localStorage.removeItem('basket_id');
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
    let basket = this.getCurrentBasketValue();
    const shipping = this.shipping;
    const subtotal = basket.items.reduce((i, p) => (p.price * p.quantity) + i, 0);
    let total;

    this.http.post(this.baseUrl + 'baskets/basketTotal', basket)
      .subscribe((res: number) => {
        total = res + shipping;
        this.basketTotalSource.next({ shipping, total, subtotal });
      });
  }

  calculateItemTotal(item: IBasketItem) {
    return this.http.post(this.baseUrl + 'baskets/basketItemTotal', item);
  }
}
