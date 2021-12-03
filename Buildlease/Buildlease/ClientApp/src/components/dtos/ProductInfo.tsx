import ProductAttributeInfo from "./ProductAttributeInfo";

export default interface ProductInfo {
    productId: string,
    productCategoryId: string,
    productName: string,
    productDescription: string,
    productImageLink: string,
    productAttributes: ProductAttributeInfo[]
}