import {AttributeType} from "./CategoryAttributeInfo";

export default interface ProductAttributeInfo {
    AttributeId: number,
    Name: string,
    ValueType: AttributeType,
    UnitName: string | null,
    ExistingStringValues: string[] | null,
    Value: string | null,
}