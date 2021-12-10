export enum AttributeType {
    Number = 'Number',
    String = 'String',
}

export interface CategoryAttributeInfo {
    Id: number,
    Name: string
    ValueType: AttributeType,
    UnitName: string | null,
}