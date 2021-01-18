import { Address } from "cluster";
import { DeliveryMethod } from "./DeliveryMethod";

export interface OrderToCreate {
    basketId: string;
    deliveryMethodId: number;
    shippingAddress: Address;
  }

  export interface OrderToReturn {
    id: number;
    buyerEmail: string;
    orderDate: string;
    subtotal: number;
    total: number;
    status: string;
    paymentIntentId: string;
    customerId: string;
    orderItems: OrderItem[];
    deliveryMethod: DeliveryMethod;
    shippingAddress: Address;
  }
    
  export interface OrderItem {
    id: number;
    price: number;
    quantity: number;
    productItemId: number;
    productName: string;
    productImageUrl: string;
    orderId: number;
  }