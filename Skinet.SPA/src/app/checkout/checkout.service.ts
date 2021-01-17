import { HttpClient } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { DeliveryMethod } from '../shared/Models/DeliveryMethod';
import { ViaCepAddress } from '../shared/Models/ViaCepAddress';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAddressViaCep(zipcode: string): Observable<ViaCepAddress> {

    return this.http.get<ViaCepAddress>(this.baseUrl + 'order/shippingaddress/' + zipcode );
  }

  getDeliveryMethods() {

    return this.http.get(this.baseUrl + 'order/deliverymethods')
      .pipe(
        map((dm: DeliveryMethod[]) => {
          return dm.sort((a, b) => b.price - a.price);
        })
      );
  }
}
