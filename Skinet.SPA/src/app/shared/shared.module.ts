import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule, PaginationModule } from 'ngx-bootstrap';
import { CarouselModule } from 'ngx-bootstrap';
import { OrderTotalComponent } from './components/order-total/order-total.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [OrderTotalComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
  ],
  exports: [
    PaginationModule,
    CarouselModule,
    OrderTotalComponent,
    ReactiveFormsModule,
    BsDropdownModule, 
  ]
})
export class SharedModule { }
