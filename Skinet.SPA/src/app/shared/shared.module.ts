import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule, PaginationModule } from 'ngx-bootstrap';
import { CarouselModule } from 'ngx-bootstrap';
import { OrderTotalComponent } from './components/order-total/order-total.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './components/text-input/text-input.component';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { StepperComponent } from './components/stepper/stepper.component';
import { BasketSumaryComponent } from './components/basket-sumary/basket-sumary.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [OrderTotalComponent, TextInputComponent, StepperComponent, BasketSumaryComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
    CdkStepperModule,
    RouterModule
  ],
  exports: [
    PaginationModule,
    CarouselModule,
    OrderTotalComponent,
    ReactiveFormsModule,
    BsDropdownModule, 
    TextInputComponent,
    CdkStepperModule,
    StepperComponent,
    BasketSumaryComponent
  ]
})
export class SharedModule { }
