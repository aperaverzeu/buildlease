import axios from "axios";
import GetProductsRequest from "./components/Catalogue/Request/GetProductsRequest";
import CategoryFilterView from "./components/views_tmp/CategoryFilterView";
import ProductView from "./components/views_tmp/ProductView";
import CategoryFullView from "./components/views_tmp/CategoryFullView";
import authService from "./components/api-authorization/AuthorizeService";

const MainLink = 'https://localhost:5001/api/';

async function AxiosTokenConfig() {
  const token = await authService.getAccessToken();
  return { headers: {'Authorization': `Bearer ${token}`} } ;
}

const API = {

  GetAllCategories: async () => {
    return axios
      .post<CategoryFullView[]>(MainLink + 'GetAllCategories')
      .then(res => res.data);
  },
  
  GetProducts: async (info: GetProductsRequest) => {
    return axios
      .post<ProductView[]>(MainLink + 'GetProducts', info)
      .then(res => res.data);
  },

  GetCategoryFilters: async (categoryId: number) => {
    return axios
      .post<CategoryFilterView[]>(MainLink + `GetCategoryFilters/${categoryId}`)
      .then(res => res.data);
  },

  SetProductOrderCount: async (productId: number, count: number) => {
    return axios
      .post<void>(MainLink + `SetProductOrderCount/${productId}/${count}`, {}, await AxiosTokenConfig())
      .then(res => res.data);
  },
  
}

export default API;