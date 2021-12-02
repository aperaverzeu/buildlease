import ProductAttributeView from "./ProductAttributeView";
import CategoryView from "./CategoryView";

export default interface ProductOrderView {
  ProductOrderId: number,
  ProductId: number | null,
  Name: string,
  Attributes: ProductAttributeView[],
  ImagePath: string,
  Count: number,
  Price: number,
  CategoryPath: CategoryView[],
}
