import AttributeFilter from "./AttributeFilter";
import SortRule from "./SortRule"

export default interface GetProductsRequest {
  CategoryId: number,
  KeyWords: string[],
  Filters: AttributeFilter[] | null,
  MaxPrice: number | null,
  OrderByRule: SortRule | null,
  SkipCount: number,
  TakeCount: number,
}