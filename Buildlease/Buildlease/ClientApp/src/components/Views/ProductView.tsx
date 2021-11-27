export default interface ProductView {
  Id: number,
  Name: string,
  Attributes: ProductAttributeView[],
  ImagePath: string,
  TotalCount: number,
  AvailableCount: number,  
  Price: number | null,
  AlreadyInCart: boolean,
}
