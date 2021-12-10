import {Breadcrumb, Button, Input, Pagination, Select, Space,} from "antd";
import {useEffect, useState} from "react";
import {useParams} from "react-router-dom";
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
import {RightOutlined} from "@ant-design/icons";

export default function Catalog() {

    const {stringCategoryId} = useParams<{ stringCategoryId?: string | undefined }>();
    const categoryId: number = (stringCategoryId && +stringCategoryId) || LOGIC.GetRootCategoryId();
    const childCategories = Globals.Categories!.filter(c => c.ParentId === categoryId && c.ParentId !== c.Id);

    const breadcrumb = LOGIC.GetBreadcrumb(categoryId);

    const [productCount, setProductCount] = useState<number>(0);
    const [products, setProducts] = useState<ProductView[] | undefined>(undefined);
    const [filters, setFilters] = useState<CategoryFilterView[] | undefined>(undefined);

    const [filtration, setFiltration] = useState<AttributeFilter[]>([]);
    const [maxPrice, setMaxPrice] = useState<number | null>(null);
    const [keywords, setKeywords] = useState<string[]>([]);

    const [pageNumber, setPageNumber] = useState<number>(1);
    const [pageSize, setPageSize] = useState<number>(10);

    const [sortRule, setSortRule] = useState<SortRule>(SortRule.Default);

    function BuildRequestObject(): GetProductsRequest {
        const obj: GetProductsRequest = {
            CategoryId: categoryId,
            KeyWords: keywords,
            Filters: filtration,
            MaxPrice: maxPrice,
            OrderByRule: sortRule,
            SkipCount: (pageNumber - 1) * pageSize,
            TakeCount: pageSize,
        }
        return obj;
    }

    function LoadProductsCount() {
        API.GetProductsCount(BuildRequestObject())
            .then(res => setProductCount(res));
    }

    function LoadProducts() {
        API.GetProducts(BuildRequestObject())
            .then(res => setProducts(res));
    }

    function ReloadProducts() {
        LoadProductsCount();
        setPageNumber(1);
        LoadProducts();
    }

    useEffect(() => {
        ReloadProducts();
    }, [sortRule]);

    useEffect(() => {
        LoadProducts();
    }, [pageNumber]);

    useEffect(() => {
        API.GetCategoryFilters(categoryId)
            .then(res => setFilters(res));
    }, []);

    return (
        <>
            <SubHeader>
                <Breadcrumb style={{
                    fontSize: "1.8rem",
                    fontWeight: 600
                }}>
                    {breadcrumb.map(cat =>
                        <Breadcrumb.Item><a href={PATH.ToCategory(cat.Id)}
                                            target="_self">{cat.Name}</a></Breadcrumb.Item>
                    )}

                </Breadcrumb>
                <Select bordered={false} defaultValue={sortRule} onChange={(newValue) => setSortRule(newValue)}>
                    {Object.values(SortRule).map((item => <Select.Option value={item}>{item}</Select.Option>))}
                </Select>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1' style={{
                paddingLeft: '24px',
                paddingRight: '24px',
            }}>
                <SideMenu>
                    <Space direction={"vertical"} size={40}>
                        <div>
                            {(childCategories && childCategories.length > 0)  &&
                            <>
                                <h2 style={{
                                    fontSize: "1.4rem",
                                    fontWeight: 400
                                }}>Subcategories:</h2>
                                <Space direction={"vertical"}>
                                    {childCategories.map(c =>
                                        <div className='d-flex' style={{
                                            alignItems: "center"
                                        }}>
                                            <RightOutlined size={0.5}/>
                                            <a style={{
                                                marginLeft: "10px",
                                                color: "black",
                                                textDecoration: "none",
                                                fontSize: "1rem",
                                                fontWeight: 250
                                            }} href={PATH.ToCategory(c.Id)} target="_self">{c.Name}</a>
                                        </div>
                                    )}
                                </Space>
                            </>}
                        </div>
                        <Input placeholder='Search words'
                               onChange={(value) => setKeywords(value.target.value.split(' '))}/>
                        {filters && <Filters filtersInfo={filters} filtration={filtration} setFiltration={setFiltration}
                                             setMaxPrice={setMaxPrice}/>}
                        <Button type='primary' onClick={() => ReloadProducts()}>Apply filters</Button>
                    </Space>
                </SideMenu>
                <MainContent>
                    <div className='d-flex flex-row flex-wrap justify-content-evenly'
                         style={{
                             minWidth: 700,
                             marginBottom: "2rem"
                         }}
                    >
                        {products?.map(prod =>
                            <ProductCard
                                key={prod.Id}
                                ProductView={prod}
                            />
                        )}
                    </div>
                    <div className='d-flex justify-content-center style={{marginBottom: 10}}' style={{
                        alignItems: "center",
                        marginBottom: "3rem"
                    }}>
                        <Pagination
                            current={pageNumber}
                            total={productCount}
                            pageSize={pageSize}
                            onChange={(newValue) => setPageNumber(newValue)}
                        />
                    </div>
                </MainContent>
            </div>
        </>
    );
}
