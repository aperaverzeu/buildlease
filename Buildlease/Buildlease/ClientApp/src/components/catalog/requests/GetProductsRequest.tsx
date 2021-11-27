import AttributeFilter from "./AttributeFilter";
import SortRule from "./SortRule"

export default interface GetProductsRequest {
    CategoryId: number,
    Keywords: string[] | null,
    Filters: AttributeFilter[] | null,
    OrderByRule: SortRule | null,
    SkipCount: number,
    TakeCount: number,
}
