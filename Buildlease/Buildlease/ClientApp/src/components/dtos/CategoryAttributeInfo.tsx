enum ValueType {
    Number = 1,
    String = 2,
}

export default interface CategoryAttributeInfo {
    Id: number,
    Name: string
    AttributeType: ValueType,
    UnitName: string
}