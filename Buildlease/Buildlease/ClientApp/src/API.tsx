import axios from "axios";
import GetProductsRequest from "./components/Catalogue/Request/GetProductsRequest";
import CategoryFilterView from "./components/Views/CategoryFilterView";
import ProductView from "./components/Views/ProductView";
import CategoryFullView from "./components/Views/CategoryFullView";

const MainLink = 'https://localhost:44329/api/';

const API = {

  GetAllCategories: () => {
    return axios
      .post<CategoryFullView[]>(MainLink + 'GetAllCategories')
      .then(res => res.data);
  },
  
  GetProducts: (info: GetProductsRequest) => {
    return axios
      .post<ProductView[]>(MainLink + 'GetProducts', info)
      .then(res => res.data);
  },

  GetCategoryFilters: (categoryId: number) => {
    return axios
      .post<CategoryFilterView[]>(MainLink + `GetCategoryFilters/${categoryId}`)
      .then(res => res.data);
  },

  SetProductOrderCount: (productId: number, count: number) => {
    return axios
      .post<void>(MainLink + `SetProductOrderCount/${productId}/${count}`)
      .then(res => res.data);
  },
  
}

export default API;