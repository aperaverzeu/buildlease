import ProductAttributeInfo from "./ProductAttributeInfo";

export default interface ProductInfo {
    productId: string,
    productCategoryId: string,
    productName: string,
    productDescription: string,
    productImageLink: string,
    productTotalCount: string,
    productPrice: string | undefined,
    productAttributes: ProductAttributeInfo[]
}