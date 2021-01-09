export interface IBasketItem {
    id: number;
    productName: string;
    price: number;
    quantity: number;
    imageUrl: string;
    brand: string;
    type: string;
    tierPriceDescription:string;
    tierPriceId:number;
    percent: number;
}