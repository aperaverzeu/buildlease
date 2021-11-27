import OrderStatus from "./OrderStatus";
import ProductOrderView from "./ProductOrderView";

export default interface OrderView {
    Id: number,
    OrderAcceptDate: Date,
    Status: OrderStatus,
    ProductCount: number,
    Price: number,
    ProductOrders: ProductOrderView[],
}