import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/shared/Models/Product';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  
  @Input() product: Product

  constructor(private basketService: BasketService) { }

  ngOnInit() {
  }
  addItemToBasket() {
    this.basketService.addItemToBasket(this.product);
  }
}
