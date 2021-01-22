import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { OrderComponent } from './order.component';
import { OrderRoutingModule } from './order-routing.module';



@NgModule({
  declarations: [OrderDetailComponent, OrderComponent],
  imports: [
    CommonModule,
    OrderRoutingModule
  ],
  exports:[

  ]
})
export class OrderModule { }
