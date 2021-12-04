import ProductAttributeInfo from "./ProductAttributeInfo";

export default interface ProductInfo {
    Id: string,
    CategoryId: string,
    Name: string,
    Description: string,
    ImageLink: string,
    TotalCount: string,
    Price: string | undefined,
    Attributes: ProductAttributeInfo[]
}