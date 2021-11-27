import OrderStatus from "./OrderStatus";

export default interface StatusChangeView {
  Date: Date,
  NewStatus: OrderStatus,
}