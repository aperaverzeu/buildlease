import CategoryView from "./CategoryView";
import ProductAttributeView from "./ProductAttributeView";

export default interface ProductFullView {
  Id: number,
  CategoryPath: CategoryView[],
  Name: string,
  Description: string,
  ImagePath: string,
  TotalCount: number,
  AvailableCount: number,
  Price: number | null,
  Attributes: ProductAttributeView[],
  CountInCart: number,
}
