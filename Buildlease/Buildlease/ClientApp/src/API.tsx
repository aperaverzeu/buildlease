import axios from "axios";

import GetProductsRequest from "./components/catalog/requests/GetProductsRequest";

import CategoryFilterView from "./components/views/CategoryFilterView";
import ProductView from "./components/views/ProductView";
import CategoryFullView from "./components/views/CategoryFullView";
import ProductFullView from "./components/views/ProductFullView";
import CartFullView from "./components/views/CartFullView";
import OrderFullView from "./components/views/OrderFullView";
import OrderView from "./components/views/OrderView";

import CustomerInfo from "./components/dtos/CustomerInfo";
import CategoryInfo from "./components/dtos/CategoryInfo";
import ProductInfo from "./components/dtos/ProductInfo";
import MakeOrderFromCartRequest from "./components/cart/MakeOrderFromCartRequest";

function GetHeaders() {
  return {
    headers: {
      'Login': localStorage.getItem('Login') || '',
      'Password': localStorage.getItem('Password') || '',
    }
  };
}

const API = {

  IsAuthorized: () => {
    return localStorage.getItem('Login') != null && localStorage.getItem('Password') != null;
  },

  // Authorization:

  Register: async (Login: string, Password: string) => {
    return axios
        .post<void>(`api/Register`, { Login, Password }, GetHeaders())
        .then(res => res.data);
  },

  Login: async (Login: string, Password: string) => {
    return axios
        .post<void>(`api/Login`, { Login, Password }, GetHeaders())
        .then(res => res.data)
        .then(() => {
          localStorage.setItem('Login', Login);
          localStorage.setItem('Password', Password); 
        });
  },

  SendRestoreCode: async (Login: string) => {
    return axios
        .post<void>(`api/SendRestoreCode`, { Login }, GetHeaders())
        .then(res => res.data);
  },

  ChangePassword: async (Login: string, RestoreCode: string, NewPassword: string) => {
    return axios
        .post<void>(`api/ChangePassword`, { Login, RestoreCode, NewPassword }, GetHeaders())
        .then(res => res.data);
  },

  // Catalog:
  
  GetAllCategories: async () => {
    return axios
      .post<CategoryFullView[]>('api/GetAllCategories', {}, GetHeaders())
      .then(res => res.data);
  },
  
  GetCategoryFilters: async (categoryId: number) => {
    return axios
        .post<CategoryFilterView[]>(`api/GetCategoryFilters/${categoryId}`, {}, GetHeaders())
        .then(res => res.data);
  },

  // corresponds to backend's "GetProduct"
  GetProductDetails: async (productId: number) => {
    return axios
        .post<ProductFullView>(`api/GetProduct/${productId}`, {}, GetHeaders())
        .then(res => res.data);
  },

  GetHistoricProductDetails: async (productOrderId: number) => {
    return axios
        .post<ProductFullView>(`api/GetHistoryProduct/${productOrderId}`, {}, GetHeaders())
        .then(res => res.data);
  },
  
  GetProducts: async (info: GetProductsRequest) => {
    return axios
      .post<ProductView[]>('api/GetProducts', info, GetHeaders())
      .then(res => res.data);
  },
  
  GetProductsCount: async (info: GetProductsRequest) => {
    return axios
        .post<number>('api/GetProductsCount', info, GetHeaders())
        .then(res => res.data);
  },

  // CategoryInfo:

  CreateSubcategory: async (parentId: number) => {
    return axios
        .post<void>(`api/CreateSubcategory/${parentId}`, {}, GetHeaders())
        .then(res => res.data);
  },
  
  DeleteCategory: async (categoryId: number) => {
    return axios
        .post<void>(`api/DeleteCategory/${categoryId}`, {}, GetHeaders())
        .then(res => res.data);
  },
  
  GetCategoryInfo: async (categoryId: number) => {
    return axios
        .post<CategoryInfo>(`api/GetCategoryInfo/${categoryId}`, {}, GetHeaders())
        .then(res => res.data);
  },
  
  SaveCategoryInfo: async (newCategoryInfo: CategoryInfo) => {
    return axios
        .post<void>('api/SaveCategoryInfo', newCategoryInfo, GetHeaders())
        .then(res => res.data);
  },
  
  // CustomerInfo:

  // corresponds to backend's "GetCustomerInfo"
  GetProfileDetails: async () => {
    return axios
        .post<CustomerInfo>(`api/GetCustomerInfo`, {}, GetHeaders())
        .then(res => res.data);
  },

  SaveCustomerInfo: async (newCustomerInfo: CustomerInfo) => {
    return axios
        .post<void>(`api/SaveCustomerInfo`, newCustomerInfo, GetHeaders())
        .then(res => res.data);
  },
  
  // MakingOrder:

  DeclineOrder: async (orderId: number) => {
    return axios
        .post<void>(`api/DeclineOrder/${orderId}`, {}, GetHeaders())
        .then(res => res.data);
  },

  MakeOrderFromCart: async (obj: MakeOrderFromCartRequest) => {
    return axios
        .post<void>(`api/MakeOrderFromCart`, obj, GetHeaders())
        .then(res => res.data);
  },

  SetProductOrderCount: async (productId: number, count: number) => {
    return axios
        .post<void>(`api/SetProductOrderCount/${productId}/${count}`, {}, GetHeaders())
        .then(res => res.data);
  },
  
  // Order:
  
  // corresponds to backend's "GetHistoryProduct"
  GetHistoricProduct: async (productOrderId: number) => {
    return axios
        .post<ProductFullView>(`api/GetHistoryProduct/${productOrderId}`, {}, GetHeaders())
        .then(res => res.data);
  },

  // corresponds to backend's "GetMyCart"
  GetCartDetails: async () => {
    return axios
        .post<CartFullView>('api/GetMyCart', {}, GetHeaders())
        .then(res => res.data);
  },

  // corresponds to backend's "GetMyOrders"
  GetOrders: async () => {
    return axios
        .post<OrderView[]>('api/GetMyOrders', {}, GetHeaders())
        .then(res => res.data);
  },

  // corresponds to backend's "GetOrder"
  GetOrderDetails: async (orderId: number) => {
    return axios
        .post<OrderFullView>(`api/GetOrder/${orderId}`, {}, GetHeaders())
        .then(res => res.data);
  },
  
  // ProductInfo:
  
  DeleteProduct: async (productId: number) => {
    return axios
        .post<void>(`api/DeleteProduct/${productId}`, {}, GetHeaders())
        .then(res => res.data);
  },
  
  GetProductInfo: async (productId: number) => {
    return axios
        .post<ProductInfo>(`api/GetProductInfo/${productId}`, {}, GetHeaders())
        .then(res => res.data);
  },
  
  SaveProductInfo: async (newProductInfo: ProductInfo) => {
    return axios
        .post<ProductInfo>('api/SaveProductInfo', newProductInfo, GetHeaders())
        .then(res => res.data);
  },
  
}

export default API;