import { Component, OnInit } from '@angular/core';
import { OrderToReturn } from '../shared/Models/Order';
import { OrderService } from './order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  orders: OrderToReturn[];

  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.getOrders();
  }

  getOrders() {
    this.orderService.getOrdersForUser()
      .subscribe((res: OrderToReturn[]) => {
        this.orders = res;
      }, error => {
        console.log(error);
      })
  }

}
