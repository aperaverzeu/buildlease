import CategoryFullView from "./components/views/CategoryFullView";
import Globals from "./Globals";

const LOGIC = {

    GetCategoryById: (categoryId: number): CategoryFullView => {
        if (Globals.Categories === undefined) throw "Categories aren't loaded";
        const result = Globals.Categories.find(cat => cat.Id == categoryId);
        if (result === undefined) throw "There is no category with such id";
        return result;
    },

    GetBreadcrumb: (categoryId: number): CategoryFullView[] => {
        const result: CategoryFullView[] = [];
        let prev = -1;
        let current = LOGIC.GetCategoryById(categoryId);
        do {
            result.push(current);
            prev = current.Id;
            current = LOGIC.GetCategoryById(current.ParentId);
        } while (current.ParentId != prev);
        result.reverse();
        return result;
    },

}

export default LOGIC;
