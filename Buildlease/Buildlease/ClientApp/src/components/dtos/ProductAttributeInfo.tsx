export default interface ProductAttributeInfo {
    AttributeId: string,
    Name: string,
    ValueType: string,
    UnitName: string,
    ExistingStringValues: string[],
    Value: string
}