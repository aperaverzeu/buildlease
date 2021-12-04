import CategoryFullView from "./components/views/CategoryFullView";
import ProductAttributeView from "./components/views/ProductAttributeView";

import Globals from "./Globals";
import OrderStatus from "./components/views/OrderStatus";

function firstLetterToLower(str: string) {
    return str.charAt(0).toLowerCase() + str.slice(1);
}

var orderStatusStrings: { [orderStatus: string]: string } = {
    'WaitingForApproval': 'placed',
    'Approved': 'approved',
    'DocumentPending': 'documents done',
    'InProcess': 'in process',
    'Finished': 'finished',
    'DeclinedByCustomer': 'declined by customer',
    'DeclinedByAdmin': 'declined by admin',
}

const LOGIC = {

    GetRootCategoryId: (): number => {
        const id = Globals.Categories?.find(cat => cat.Id == cat.ParentId)?.Id;
        if (id === undefined)
            throw 'Root category id is undefined.';
        else
            return id;
    },
    
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
    
    GetShortDescription: (pairs: ProductAttributeView[] | undefined): string | undefined => {
        return pairs?.map((pair, index) =>
            `${index == 0 ? pair.Name : firstLetterToLower(pair.Name)}: ${firstLetterToLower(pair.Value)}` + (index != pairs.length-1 ? ', ' : '.')).join('')
    },
    
    GetStatusString: (status: OrderStatus): string => {
        return orderStatusStrings[status];
    },
    
    GetUserFriendlyDateRepr: (date: Date | undefined): string => {
        if (!date)
            return '';
        
        date = new Date(date);
        var mmddyy = (((date.getMonth() > 8) ? (date.getMonth() + 1) : ('0' + (date.getMonth() + 1))) + '/' + ((date.getDate() > 9) ? date.getDate() : ('0' + date.getDate())) + '/' + date.getFullYear());
        
        var hhmm = `${date.getHours()}:${date.getMinutes() < 10 ? '0'+date.getMinutes() : date.getMinutes()}`;
        
        return mmddyy + ', ' + hhmm;
    },

}

export default LOGIC;
