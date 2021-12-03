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

const MainLink = 'https://localhost:5001/api/';

async function AxiosTokenConfig() {
  const token = await authService.getAccessToken();
  return { headers: {'Authorization': `Bearer ${token}`} } ;
}

const API = {

  // for catalog:
  
  GetAllCategories: async () => {
    return axios
      .post<CategoryFullView[]>(MainLink + 'GetAllCategories')
      .then(res => res.data);
  },

  GetCategoryFilters: async (categoryId: number) => {
    return axios
        .post<CategoryFilterView[]>(MainLink + `GetCategoryFilters/${categoryId}`)
        .then(res => res.data);
  },
  
  GetProducts: async (info: GetProductsRequest) => {
    return axios
      .post<ProductView[]>(MainLink + 'GetProducts', info)
      .then(res => res.data);
  },

  // for product details:
  
  GetProductDetails: async (productId: number) => {
    return axios
        .post<ProductFullView>(MainLink + `GetProduct/${productId}`)
        .then(res => res.data);
  },
  
  GetHistoricProduct: async (productId: number) => {
    return axios
        .post<ProductFullView>(MainLink + `GetHistoryProduct/${productId}`)
        .then(res => res.data);
  },

  // for order history:
  GetOrders: async () => {
    return axios
        .post<OrderView[]>(MainLink + 'GetMyOrders')
        .then(res => res.data);
  },

  // for order details:
  GetOrderDetails: async (orderId: number) => {
    return axios
        .post<OrderFullView>(MainLink + `GetOrder/${orderId}`)
        .then(res => res.data);
  },
  
  // for cart details:
  GetCartDetails: async () => {
    return axios
      .post<CartFullView>(MainLink + 'GetMyCart')
      .then(res => res.data);
  },
  
  // for profile details:
  
  GetProfileDetails: async () => {
    return axios
        .post<CustomerInfo>(MainLink + `GetCustomerInfo`)
        .then(res => res.data);
  },
  
  SaveCustomerInfo: async () => {
    return axios
        .post<void>(MainLink + `SaveCustomerInfo`)
        .then(res => res.data);
  },

  SetProductOrderCount: async (productId: number, count: number) => {
    return axios
        .post<void>(MainLink + `SetProductOrderCount/${productId}/${count}`, {}, await AxiosTokenConfig())
        .then(res => res.data);
  },
  
  MakeOrderFromCart: async () => {
    return axios
        .post<void>(MainLink + `MakeOrderFromCart`)
        .then(res => res.data);
  },
  
  DeclineOrder: async (orderId: number) => {
    return axios
        .post<void>(MainLink + `DeclineOrder/${orderId}`)
        .then(res => res.data);
  },
  
  // ==========ADMIN====================ADMIN====================ADMIN==========
  
  AddCategoryFromAdminPanel: async () => {
    return axios
        .post<CategoryInfo>(MainLink + `AddCategory`)
        .then(res => res.data)
  }
  
  
  
  // ==========ADMIN====================ADMIN====================ADMIN==========
  
}

export default API;