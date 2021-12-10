import OrderStatus from "./OrderStatus";
import ProductOrderView from "./ProductOrderView";
import StatusChangeView from "./StatusChangeView";

export default interface OrderFullView {
  Id: number,
  StatusHistory: StatusChangeView[],
  StartDate: Date,
  FinishDate: Date,
  Status: OrderStatus,
  Price: number,
  ProductOrders: ProductOrderView[],
}