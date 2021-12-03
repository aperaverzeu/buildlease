import CategoryAttributeInfo from "./CategoryAttributeInfo";

export default interface CategoryInfo {
    categoryId: string,
    categoryName: string,
    categoryImageLink: string,
    categoryAttributes: CategoryAttributeInfo[]
}