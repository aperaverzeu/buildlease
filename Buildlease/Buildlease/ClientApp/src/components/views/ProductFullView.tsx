import CategoryView from "./CategoryView";
import ProductAttributeView from "./ProductAttributeView";
import ProductDescriptionView from "./ProductDescriptionView";

export default interface ProductFullView {
  Id: number,
  CategoryPath: CategoryView[],
  Name: string,
  ImagePath: string,
  TotalCount: number,
  AvailableCount: number,
  Price: number | null,
  Attributes: ProductAttributeView[],
  CountInCart: number,
  Descriptions: ProductDescriptionView[],
}
