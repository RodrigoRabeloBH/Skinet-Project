import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Address } from 'cluster';
import { AccountService } from 'src/app/account/account.service';
import { ViaCepAddress } from 'src/app/shared/Models/ViaCepAddress';
import { CheckoutService } from '../checkout.service';

@Component({
  selector: 'app-checkout-address',
  templateUrl: './checkout-address.component.html',
  styleUrls: ['./checkout-address.component.scss']
})
export class CheckoutAddressComponent implements OnInit {

  @Input() checkoutForm: FormGroup;
  isSame: boolean = true;

  constructor(private checkoutService: CheckoutService, private accountService: AccountService) { }

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


  PaymentAndDeliveryAreSame() {
    this.isSame = !this.isSame;
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

  saveUserAddress() {
    this.accountService.updateUserAddress(this.checkoutForm.get('addressForm').value)
      .subscribe(() => {
        console.log('Address Saved!');
      }, error => {
        console.log(error);
      });
  }

  saveShippingAddress() {
    this.checkoutService.saveShippingAddress(this.checkoutForm.get('addressForm').value)
      .subscribe(() => {
        console.log('Address Saved!');
      }, error => {
        console.log(error);
      });
  }
}
