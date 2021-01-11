import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pagination } from '../shared/Models/Pagination';
import { Brand } from '../shared/Models/Brand';
import { ProductType } from '../shared/Models/ProductType';
import { Product } from '../shared/Models/Product';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts(index: number, length: number, sort: string): Observable<Pagination> {

    return this.http.get<Pagination>(this.baseUrl + 'products/' + index + '/' + length + '/' + sort);
  }

  getProductById(id: number): Observable<Product> {

    return this.http.get<Product>(this.baseUrl + 'products/' + id);
  }
  getBrands(): Observable<Brand[]> {

    return this.http.get<Brand[]>(this.baseUrl + 'productbrand');
  }
  getTypes(): Observable<ProductType[]> {

    return this.http.get<ProductType[]>(this.baseUrl + 'producttype');
  }

  getProductsByType(typeId: number, index: number, length: number): Observable<Pagination> {

    return this.http.get<Pagination>(this.baseUrl + `products/producttype/${typeId}/${index}/${length}`);
  }
  getProductsByBrandId(brandId: number, index: number, length: number): Observable<Pagination> {

    return this.http.get<Pagination>(this.baseUrl + `products/productbrand/${brandId}/${index}/${length}`);
  }
  getProductsByName(name: string, index: number, length: number): Observable<Pagination> {
    
    return this.http.get<Pagination>(this.baseUrl + `products/name/${name}/${index}/${length}`);
  }
}
