import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
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

  getProducts(index: number, length: number, sort: string, brandId?: number, typeId?: number): Observable<Pagination> {

    return this.http.get<Pagination>(`${this.baseUrl}products/all?index=${index}&length=${length}&brandId=${brandId}&typeId=${typeId}&sort=${sort}`);
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

  getProductsBySearch(search: string, index: number, length: number): Observable<Pagination> {

    return this.http.get<Pagination>(`${this.baseUrl}products/search?index=${index}&length=${length}&search=${search}`);
  }
}
