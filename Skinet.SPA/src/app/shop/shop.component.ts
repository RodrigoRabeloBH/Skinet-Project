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
  search: string;
  total: number;
  totalPage: number;
  currentPage: number;
  brandIdSelected = 0;
  typeIdSelected = 0;
  sortSelected = 'name';
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price Low to High', value: 'priceAsc' },
    { name: 'Price High to Low', value: 'priceDesc' }
  ];

  constructor(private service: ShopService) { }

  ngOnInit() {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  onSortSelected(sort: string) {
    this.sortSelected = sort;
    this.getProducts();
  }

  getProducts() {

    this.service.getProducts(this.index, this.length, this.sortSelected, this.brandIdSelected, this.typeIdSelected)
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

    this.sortSelected = null;
    this.typeIdSelected = id;
    this.getProducts();
  }

  getProductsByBrandId(id: number) {

    this.sortSelected = null;
    this.brandIdSelected = id;
    this.getProducts();
  }

  getProductsByName(name: string) {

    this.service.getProductsBySearch(name, this.index, this.length)
      .subscribe(res => {
        this.products = res.data;
        this.total = res.total;
        this.totalPage = res.totalPage * 10;
      }, error => console.log(error));
  }

  clearSearch() {

    this.search = null;
    this.brandIdSelected = 0;
    this.typeIdSelected = 0;
    this.getProducts();
  }

  clearType() {

    this.typeIdSelected = 0;
    this.getProducts();
  }

  clearBrand() {

    this.brandIdSelected = 0;
    this.getProducts();
  }

  pageChanged(event: any): void {

    this.index = event.page;
    this.getProducts();
  }
}
