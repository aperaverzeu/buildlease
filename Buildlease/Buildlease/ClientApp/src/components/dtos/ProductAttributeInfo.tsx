export default interface ProductAttributeInfo {
    productAttributeId: string,
    productAttributeCategoryAttributeId: string,
    productAttributeName: string,
    productAttributeValueType: string,
    productAttributeUnitName: string,
    productAttributeExistingStringValues: string[],
    productAttributeValue: string
}