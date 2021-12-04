import CategoryAttributeInfo from "./CategoryAttributeInfo";

export default interface CategoryInfo {
    Id: string,
    Name: string,
    ImageLink: string,
    Attributes: CategoryAttributeInfo[]
}