import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrderToReturn } from 'src/app/shared/Models/Order';
import { BreadcrumbService } from 'xng-breadcrumb';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss']
})
export class OrderDetailComponent implements OnInit {

  order: OrderToReturn;

  constructor(private orderService: OrderService,
    private route: ActivatedRoute,
    private breadcrumbService: BreadcrumbService) {
    this.breadcrumbService.set('@OrderDetailed', '');
  }

  ngOnInit() {

    this.getOrderDetailed();
  }

  getOrderDetailed() {
    this.orderService.getOrderDetailed(+this.route.snapshot.paramMap.get('id'))
      .subscribe((res: OrderToReturn) => {
        this.order = res;
        this.breadcrumbService.set('@OrderDetailed', `Order# ${res.id} - ${res.status}`);
      }, error => {
        console.log(error);
      });
  }
}
