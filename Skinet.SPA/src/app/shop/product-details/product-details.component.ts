import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { Product } from 'src/app/shared/Models/Product';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: Product;
  quantity = 1;

  constructor(private service: ShopService,
    private router: ActivatedRoute,
    private basketService: BasketService,
    private bcService: BreadcrumbService) { }

  ngOnInit() {
    this.getProducById();
  }

  getProducById() {
    this.service.getProductById(+this.router.snapshot.paramMap.get('id'))
      .subscribe(res => {
        this.product = res;
        this.bcService.set('@productDetails', this.product.name);
      }, error => {
        console.log(error);
      });
  }

  addItemsToBasket() {
    this.basketService.addItemToBasket(this.product, this.quantity);
  }

  incrementQunatity() {
    this.quantity++;
  }

  decrementQunatity() {
    if (this.quantity > 1) {

      this.quantity--;
    }
  }
}
