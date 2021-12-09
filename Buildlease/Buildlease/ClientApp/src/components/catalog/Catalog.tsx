import { Breadcrumb, Pagination, Select, } from "antd";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import API from "../../API";
import PATH from "../../PATH";
import Filters from "./filters/Filters";
import AttributeFilter from "./requests/AttributeFilter";
import GetProductsRequest from "./requests/GetProductsRequest";
import SortRule from "./requests/SortRule";
import CategoryFilterView from "../views/CategoryFilterView";
import ProductView from "../views/ProductView";
import LOGIC from "../../LOGIC";

import ProductCard from "../cards/ProductCard";

import SubHeader from "../layout/SubHeader";
import SideMenu from "../layout/SideMenu";
import MainContent from "../layout/MainContent";
import Globals from "../../Globals";

export default function Catalog() {

  const { stringCategoryId } = useParams<{stringCategoryId?: string | undefined}>();
  const categoryId: number = (stringCategoryId && +stringCategoryId) || LOGIC.GetRootCategoryId();

  const breadcrumb = LOGIC.GetBreadcrumb(categoryId);

  const [products, setProducts] = useState<ProductView[] | undefined>(undefined);
  const [filters, setFilters] = useState<CategoryFilterView[] | undefined>(undefined);

  const [filtration, setFiltration] = useState<AttributeFilter[]>([]);

  const [pageNumber, setPageNumber] = useState<number>(1);
  const [pageSize, setPageSize] = useState<number>(10);
  
  const [sortRule, setSortRule] = useState<SortRule>(SortRule.Default);

  function BuildRequestObject(): GetProductsRequest {
    const obj: GetProductsRequest = {
      CategoryId: categoryId,
      Filters: filtration.length != 0 ? filtration.filter(filter => filter.AttributeId != 0) : filtration,
      MaxPrice: filtration.length != 0 ? filtration.filter(filter => filter.AttributeId == 0)[0].ValueNumberUpperBound : null,
      OrderByRule: sortRule,
      SkipCount: (pageNumber - 1) * pageSize,
      TakeCount: pageSize,
    }
    return obj;
  }

  function LoadProducts() {
    API.GetProducts(BuildRequestObject())
      .then(res => setProducts(res));
  }

  useEffect(() => {
    setPageNumber(1);
    LoadProducts();
  }, [filtration, sortRule, pageSize]);

  useEffect(() => {
    LoadProducts();
  }, [pageNumber]);

  useEffect(() => {
    API.GetCategoryFilters(categoryId)
      .then(res => setFilters(res));
  },[]);
  
  return (
    <>
      <SubHeader>
        <Breadcrumb>
          {breadcrumb.map(cat =>
              <Breadcrumb.Item><a href={PATH.ToCategory(cat.Id)} target="_self">{cat.Name}</a></Breadcrumb.Item>
          )}

        </Breadcrumb>
        <Select defaultValue={sortRule} onChange={(newValue) => setSortRule(newValue)}>
          {Object.values(SortRule).map((item => <Select.Option value={item}>{item}</Select.Option>))}
        </Select>
      </SubHeader>
      
      <div className='d-flex flex-row flex-grow-1'>
        
        <SideMenu>
          {Globals.Categories && 
           Globals.Categories
              .filter(category => category.ParentId === categoryId && category.Id !== categoryId)
              .length > 0 &&
            <div>
              Select subcategory
              {Globals.Categories
                  ?.filter(category => category.ParentId === categoryId && category.Id !== categoryId)
                  .map(
                      category =>
                          <div>
                            <a href={PATH.ToCategory(category.Id)}> {category.Name} </a>
                          </div>
                  )
              }
            </div>
          }
          
            {filters && <Filters filtersInfo={filters} filtration={filtration} setFiltration={setFiltration} />}
        </SideMenu>
        
        <MainContent>
          <div className='d-flex flex-row flex-wrap justify-content-evenly flex-grow-1'
              style={{
                minWidth: 500,
              }}
          >
            {products?.map(prod =>
                <ProductCard
                    key={prod.Id}
                    ProductView={prod}
                />
            )}
          </div>
          <div className='d-flex justify-content-center' style={{marginBottom: 10}}>
            <Pagination
                current={pageNumber}
                total={42}
                pageSize={pageSize}
                onChange={(newValue) => setPageNumber(newValue)}
            />
          </div>
        </MainContent>
        
      </div>
    </>
  );
}
