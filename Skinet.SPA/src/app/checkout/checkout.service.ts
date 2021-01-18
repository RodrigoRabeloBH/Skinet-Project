import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Address } from 'cluster';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { DeliveryMethod } from '../shared/Models/DeliveryMethod';
import { OrderToCreate, OrderToReturn } from '../shared/Models/Order';
import { ViaCepAddress } from '../shared/Models/ViaCepAddress';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAddressViaCep(zipcode: string): Observable<ViaCepAddress> {

    return this.http.get<ViaCepAddress>(this.baseUrl + 'shippingaddress/' + zipcode);
  }

  getDeliveryMethods() {

    return this.http.get(this.baseUrl + 'order/deliverymethods')
      .pipe(
        map((dm: DeliveryMethod[]) => {
          return dm.sort((a, b) => b.price - a.price);
        })
      );
  }

  saveShippingAddress(address: Address) {
    return this.http.post(this.baseUrl + 'shippingaddress', address);
  }

  createOrder(order: OrderToCreate): Observable<OrderToReturn> {
    return this.http.post<OrderToReturn>(this.baseUrl + 'order', order);
  }
}
