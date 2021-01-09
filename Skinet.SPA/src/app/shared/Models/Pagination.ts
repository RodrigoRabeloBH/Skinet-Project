import { Product } from './Product';

export interface Pagination {
    total: number;
    totalPage: number;
    data: Product[];
}
