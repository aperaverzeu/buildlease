export default interface ProductView {
  Id: number,
  Name: string,
  ShortDescription: string,
  ImagePath: string,
  TotalCount: number,
  AvailableCount: number,  
  Price: number | null,
  AlreadyInCart: boolean,
}
