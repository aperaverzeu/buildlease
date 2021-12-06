export enum AttributeType {
    Number = 1,
    String = 2,
}

export interface CategoryAttributeInfo {
    Id: number,
    Name: string
    ValueType: AttributeType,
    UnitName: string
}