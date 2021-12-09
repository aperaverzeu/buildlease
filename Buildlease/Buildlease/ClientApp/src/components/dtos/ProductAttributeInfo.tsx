import {AttributeType} from "./CategoryAttributeInfo";

export default interface ProductAttributeInfo {
    AttributeId: string,
    Name: string,
    ValueType: AttributeType,
    UnitName: string,
    ExistingStringValues: string[],
    Value: string
}