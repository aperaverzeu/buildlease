import { Breadcrumb, Pagination, Select, } from "antd";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import API from "../../API";
import PATH from "../../PATH";
import Filters from "./Filters/Filters";
import Item from "./Item";
import AttributeFilter from "./Request/AttributeFilter";
import GetProductsRequest from "./Request/GetProductsRequest";
import SortRule from "./Request/SortRule";
import CategoryFilterView from "./Views/CategoryFilterView";
import ProductView from "./Views/ProductView";

export default function Catalogue() {

  const { stringCategoryId } = useParams<{stringCategoryId?: string | undefined}>();
  const id: number = (stringCategoryId && +stringCategoryId) || 0;

  const [products, setProducts] = useState<ProductView[] | undefined>(undefined);
  const [filters, setFilters] = useState<CategoryFilterView[] | undefined>(undefined);

  const [filtration, setFiltration] = useState<AttributeFilter[]>([]);

  const [pageNumber, setPageNumber] = useState<number>(1);
  const [pageSize, setPageSize] = useState<number>(10);
  
  const [sortRule, setSortRule] = useState<SortRule>(SortRule.Default);

  function BuildRequestObject(): GetProductsRequest {
    const obj: GetProductsRequest = {
      CategoryId: id,
      Filters: filtration,
      OrderByRule: sortRule,
      SkipCount: (pageNumber - 1) * pageSize,
      TakeCount: pageSize,
    }
    return obj;
  }

  function LoadProducts() {
    Promise
      .resolve(API.GetProducts(BuildRequestObject()))
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
    Promise
      .resolve(API.GetCategoryFilters(id))
      .then(res => setFilters(res));
  },[]);
  
  return (
    <div
      style={{
        display: 'flex', 
        flexDirection: 'column', 
      }}
    >
      <div  
        style={{
          display: 'flex', 
          flexDirection: 'row', 
          flexWrap: 'nowrap',
          justifyContent: 'space-between',
        }}
      >
        <Breadcrumb>
          <Breadcrumb.Item><a href={PATH.ToCategory(0)} target="_self">Home Sweet Home</a></Breadcrumb.Item>
          <Breadcrumb.Item>Front-End</Breadcrumb.Item>
          <Breadcrumb.Item>React</Breadcrumb.Item>
          <Breadcrumb.Item>Hell</Breadcrumb.Item>
        </Breadcrumb>
        <Select defaultValue={sortRule} onChange={(newValue) => setSortRule(newValue)}>
          {Object.values(SortRule).map((item => <Select.Option value={item}>{item}</Select.Option>))}
        </Select>
      </div>
      <div  
        style={{
          display: 'flex', 
          flexDirection: 'row', 
          flexWrap: 'nowrap',
        }}
      >
        <div 
          style={{
            display: 'flex',
            flexDirection: 'column',
            flexGrow: 0,
            minWidth: 300, 
            width: 300, 
            maxWidth: 300, 
          }}
        >
          {filters && <Filters filtersInfo={filters} filtration={filtration} setFiltration={setFiltration} />}
        </div>
        <div 
          style={{
            display: 'flex', 
            flexDirection: 'row', 
            flexWrap: 'wrap',
            justifyContent: 'space-evenly',
            flexGrow: 1,
            minWidth: 500,
            width: 1200,
          }}
        >
          {products?.map(prod => 
            <Item 
              key={prod.Id}
              ProductView={prod}
            />
          )}
        </div>
      </div>
      <div 
        style={{
          display: 'flex',
          justifyContent: 'center',
        }}
      >
        <Pagination 
          current={pageNumber}
          total={42}
          pageSize={pageSize}
          onChange={(newValue) => setPageNumber(newValue)}
        />
      </div>
    </div>
  );
}
