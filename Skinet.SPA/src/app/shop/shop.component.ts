import { Component, OnInit } from '@angular/core';
import { Product } from '../shared/Models/Product';
import { ShopService } from './shop.service';
import { Brand } from '../shared/Models/Brand';
import { ProductType } from '../shared/Models/ProductType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: Product[];
  brands: Brand[];
  productTypes: ProductType[];
  index = 1;
  length = 8;
  name: string;
  total: number;
  totalPage: number;
  currentPage: number;
  brandIdSelected = 0;
  typeIdSelected = 0;

  constructor(private service: ShopService) { }

  ngOnInit() {
    this.getProducts();
    this.getBrands();
    this.getTypes();
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

  getBrands() {
    this.service.getBrands()
      .subscribe(res => {
        this.brands = res;
      }, err => console.log(err));
  }
  getTypes() {
    this.service.getTypes()
      .subscribe(res => {
        this.productTypes = res;
      }, err => console.log(err));
  }
  getProductsByTypeId(id: number) {
    this.service.getProductsByType(id, this.index, this.length)
      .subscribe(res => {
        this.products = res.data;
        this.total = res.total;
        this.totalPage = res.totalPage * 10;
        this.typeIdSelected = id;
        this.brandIdSelected = 0;
      }, error => console.log(error));
  }
  getProductsByBrandId(id: number) {
    this.service.getProductsByBrandId(id, this.index, this.length)
      .subscribe(res => {
        this.products = res.data;
        this.total = res.total;
        this.totalPage = res.totalPage * 10;
        this.brandIdSelected = id;
        this.typeIdSelected = 0;

      }, error => console.log(error));
  }
  getProductsByName(name: string) {
    this.service.getProductsByName(name, this.index, this.length)
      .subscribe(res => {
        this.products = res.data;
        this.total = res.total;
        this.totalPage = res.totalPage * 10;
      }, error => console.log(error));
  }

  clearSearch() {
    this.getProducts();
    this.brandIdSelected = 0;
    this.typeIdSelected = 0;  
  }
  onclick() {
    this.getProducts();
    this.brandIdSelected = 0;
    this.typeIdSelected = 0;
  }

  pageChanged(event: any): void {
    this.index = event.page;
    this.getProducts();
  }
}
