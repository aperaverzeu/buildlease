import CategoryAttributeInfo from "./CategoryAttributeInfo";

export default interface CategoryInfo {
    Id: number,
    Name: string,
    ImageLink: string,
    Attributes: CategoryAttributeInfo[]
}