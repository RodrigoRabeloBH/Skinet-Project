import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { BasketService } from './basket/basket.service';
import { IBasket } from './shared/Models/Basket';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  basket: IBasket

  constructor(private basketService: BasketService, private accountService: AccountService) { }

  ngOnInit(): void {

    // this.loadbasketLocalStorage();
    this.loadbasket();
    this.loadCurrentUser();
  }

  loadbasket() {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) {
      this.basketService.getBasketRedis(basketId).subscribe(() => {
      }, error => {
        console.log(error);
      })
    }
  }

  loadbasketLocalStorage() {

    const basket = localStorage.getItem('basket');
    if (basket) {
      this.basketService.getBasketLoacalStorage();
    }
  }

  loadCurrentUser() {

    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token)
      .subscribe(() => {
        console.log('loaded user');
      }, error => {
        console.log(error);
      });
  }
}
