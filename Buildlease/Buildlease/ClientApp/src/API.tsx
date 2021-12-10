import axios from "axios";

import GetProductsRequest from "./components/catalog/requests/GetProductsRequest";

import CategoryFilterView from "./components/views/CategoryFilterView";
import ProductView from "./components/views/ProductView";
import CategoryFullView from "./components/views/CategoryFullView";
import ProductFullView from "./components/views/ProductFullView";
import CartFullView from "./components/views/CartFullView";
import OrderFullView from "./components/views/OrderFullView";
import OrderView from "./components/views/OrderView";

import authService from "./components/api-authorization/AuthorizeService";

import CustomerInfo from "./components/dtos/CustomerInfo";
import CategoryInfo from "./components/dtos/CategoryInfo";
import ProductInfo from "./components/dtos/ProductInfo";

const MainLink = 'https://localhost:5001/api/';

async function AxiosTokenConfig() {
  const token = await authService.getAccessToken();
  return { headers: {'Authorization': `Bearer ${token}`} } ;
}

const API = {

  // Catalog:
  
  GetAllCategories: async () => {
    return axios
      .post<CategoryFullView[]>(MainLink + 'GetAllCategories', {}, await AxiosTokenConfig())
      .then(res => res.data);
  },
  
  GetCategoryFilters: async (categoryId: number) => {
    return axios
        .post<CategoryFilterView[]>(MainLink + `GetCategoryFilters/${categoryId}`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },
  
  GetProductsCount: async (info: GetProductsRequest) => {
    return axios
      .post<number>(MainLink + 'GetProductsCount', info)
      .then(res => res.data);
  },

  // corresponds to backend's "GetProduct"
  GetProductDetails: async (productId: number) => {
    return axios
        .post<ProductFullView>(MainLink + `GetProduct/${productId}`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },
  
  GetProducts: async (info: GetProductsRequest) => {
    return axios
      .post<ProductView[]>(MainLink + 'GetProducts', info, await AxiosTokenConfig())
      .then(res => res.data);
  },
  
  GetProductsCount: async (info: GetProductsRequest) => {
    return axios
        .post<number>(MainLink + 'GetProductsCount', info, await AxiosTokenConfig())
        .then(res => res.data);
  },

  // CategoryInfo:

  CreateSubcategory: async (parentId: number) => {
    return axios
        .post<void>(MainLink + `CreateSubcategory/${parentId}`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },
  
  DeleteCategory: async (categoryId: number) => {
    return axios
        .post<void>(MainLink + `DeleteCategory/${categoryId}`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },
  
  GetCategoryInfo: async (categoryId: number) => {
    return axios
        .post<CategoryInfo>(MainLink + `GetCategoryInfo/${categoryId}`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },
  
  SaveCategoryInfo: async (newCategoryInfo: CategoryInfo) => {
    return axios
        .post<void>(MainLink + 'SaveCategoryInfo', newCategoryInfo, await AxiosTokenConfig())
        .then(res => res.data);
  },
  
  // CustomerInfo:

  // corresponds to backend's "GetCustomerInfo"
  GetProfileDetails: async () => {
    return axios
        .post<CustomerInfo>(MainLink + `GetCustomerInfo`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },

  SaveCustomerInfo: async (newCustomerInfo: CustomerInfo) => {
    return axios
        .post<void>(MainLink + `SaveCustomerInfo`, newCustomerInfo, await AxiosTokenConfig())
        .then(res => res.data);
  },
  
  // MakingOrder:

  DeclineOrder: async (orderId: number) => {
    return axios
        .post<void>(MainLink + `DeclineOrder/${orderId}`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },

  MakeOrderFromCart: async () => {
    return axios
        .post<void>(MainLink + `MakeOrderFromCart`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },

  SetProductOrderCount: async (productId: number, count: number) => {
    return axios
        .post<void>(MainLink + `SetProductOrderCount/${productId}/${count}`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },
  
  // Order:
  
  // corresponds to backend's "GetHistoryProduct"
  GetHistoricProduct: async (productOrderId: number) => {
    return axios
        .post<ProductFullView>(MainLink + `GetHistoryProduct/${productOrderId}`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },

  // corresponds to backend's "GetMyCart"
  GetCartDetails: async () => {
    return axios
        .post<CartFullView>(MainLink + 'GetMyCart', {}, await AxiosTokenConfig())
        .then(res => res.data);
  },

  // corresponds to backend's "GetMyOrders"
  GetOrders: async () => {
    return axios
        .post<OrderView[]>(MainLink + 'GetMyOrders', {}, await AxiosTokenConfig())
        .then(res => res.data);
  },

  // corresponds to backend's "GetOrder"
  GetOrderDetails: async (orderId: number) => {
    return axios
        .post<OrderFullView>(MainLink + `GetOrder/${orderId}`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },
  
  // ProductInfo:
  
  DeleteProduct: async (productId: number) => {
    return axios
        .post<void>(MainLink + `DeleteProduct/${productId}`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },
  
  GetProductInfo: async (productId: number) => {
    return axios
        .post<ProductInfo>(MainLink + `GetProductInfo/${productId}`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },
  
  SaveProductInfo: async (newProductInfo: ProductInfo) => {
    return axios
        .post<ProductInfo>(MainLink + 'SaveProductInfo', newProductInfo, await AxiosTokenConfig())
        .then(res => res.data);
  }
  
}

export default API;