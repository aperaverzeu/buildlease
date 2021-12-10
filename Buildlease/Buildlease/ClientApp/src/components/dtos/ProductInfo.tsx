import ProductAttributeInfo from "./ProductAttributeInfo";

export default interface ProductInfo {
    Id: number,
    CategoryId: number,
    Name: string,
    Description: string,
    ImageLink: string,
    TotalCount: number,
    Price: number | null,
    Attributes: ProductAttributeInfo[],
}