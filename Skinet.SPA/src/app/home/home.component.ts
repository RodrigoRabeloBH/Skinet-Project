import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from '../basket/basket.service';
import { Product } from '../shared/Models/Product';
import { ShopService } from '../shop/shop.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  
  @Input() product: Product;

  activeSlideIndex = 0;
  products: Product[];
  index = 2;
  length = 4;
  total: number;
  totalPage: number;

  constructor(private service: ShopService, private basketService: BasketService) { }

  ngOnInit() {
    this.getProducts();
  }

  getProducts() {
    this.service.getProducts(this.index, this.length, null)
      .subscribe(res => {
        this.products = res.data;
        this.total = res.total;
        this.totalPage = res.totalPage * 10;
      }, err => {
        console.log(err);
      });
  }
  addItemToBasket(product:Product) {
    this.basketService.addItemToBasket(product);
  }
}
