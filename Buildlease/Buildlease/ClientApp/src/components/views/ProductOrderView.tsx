import ProductAttributeView from "./ProductAttributeView";

export default interface ProductOrderView {
  ProductId: number,
  Name: string,
  Attributes: ProductAttributeView[],
  ImagePath: string,
  Count: number,
  Price: number,
}