import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Address } from 'cluster';
import { ViaCepAddress } from 'src/app/shared/Models/ViaCepAddress';
import { CheckoutService } from '../checkout.service';

@Component({
  selector: 'app-checkout-address',
  templateUrl: './checkout-address.component.html',
  styleUrls: ['./checkout-address.component.scss']
})
export class CheckoutAddressComponent implements OnInit {

  @Input() checkoutForm: FormGroup;

  constructor(private checkoutService: CheckoutService) { }

  ngOnInit() {


  }

  getAddresViaCep(zipcode: string) {

    zipcode = zipcode.replace('-', '');

    this.checkoutService.getAddressViaCep(zipcode)
      .subscribe((res) => {
        let address = this.mapToShippingAddres(res);
        this.checkoutForm.get('addressForm').patchValue(address);
      }, error => {
        console.log(error);
      });
  }

  mapToShippingAddres(address: ViaCepAddress): any {

    return {
      street: address.logradouro,
      city: address.localidade,
      state: address.uf,
      zipCode: address.cep,
      district: address.bairro
    };
  }
}
