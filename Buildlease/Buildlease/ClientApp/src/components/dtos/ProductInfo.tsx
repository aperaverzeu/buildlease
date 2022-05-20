import ProductAttributeInfo from "./ProductAttributeInfo";
import ProductDescriptionInfo from "./ProductDescriptionInfo";

export default interface ProductInfo {
    Id: number,
    CategoryId: number,
    Name: string,
    ImageLink: string,
    TotalCount: number,
    Price: number | null,
    Attributes: ProductAttributeInfo[],
    Descriptions: ProductDescriptionInfo[],
}