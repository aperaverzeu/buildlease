import SubHeader from "../../layout/SubHeader";
import MainContent from "../../layout/MainContent";

import {useParams} from "react-router-dom";
import {useEffect, useState} from "react";

import ProductFullView from "../../views/ProductFullView";

import API from "../../../API";
import LOGIC from "../../../LOGIC";

import {Button, Input} from "antd";
import CategoryTreeSelect from "../CategoryTreeSelect";

export default function AdminProduct() {
    
    const { stringProductId } = useParams<{stringProductId?: string | undefined}>();
    const productId: number = (stringProductId && +stringProductId) || 0;

    const [oldProductDetails, setOldProductDetails] = useState<ProductFullView | undefined>(undefined);
    const [newProductDetails, setNewProductDetails] = useState<ProductFullView | undefined>(undefined);

    function LoadProductDetails() {
        API.GetProductDetails(productId)
            .then(res => {
                setOldProductDetails(JSON.parse(JSON.stringify(res)));
                setNewProductDetails(JSON.parse(JSON.stringify(res)));
            });
    }

    useEffect(() => {
        LoadProductDetails();
    }, []);
    
    return (
        <>
            {
                newProductDetails &&
                <>
                    <SubHeader>
                        <div>
                            <CategoryTreeSelect currentId={newProductDetails.CategoryPath[-1].Id == LOGIC.GetRootCategoryId() ?
                                `${LOGIC.GetRootCategoryId()}`
                                :
                                `${newProductDetails.CategoryPath[-2].Id}-${newProductDetails.CategoryPath[-1].Id}`}
                                                onSelect={data => {
                                                    // attributes pulled
                                                }}/>
                        </div>
                        <div>
                            <Button type='primary'
                                    onClick={() => {
                                        // save to api
                                        // if productId == 0, pull from api and set as old and new info
                                        // else, set old info from the new
                                    }}>
                                { productId == 0 ? 'Create product' : 'Apply changes' }
                            </Button>
                        </div>
                    </SubHeader>
                    <div className='d-flex flex-row flex-grow-1'>
                        <MainContent>
                            <div style={{
                                padding: '16px',
                            }}>
                                {
                                    newProductDetails &&
                                    <Input addonBefore='Name'
                                           style={{
                                               marginBottom: '16px',
                                           }}
                                           defaultValue={newProductDetails?.Name}
                                           onChange={(data) => {
                                               const obj = Object.assign({}, newProductDetails);
                                               obj.Name = data.target.value;
                                               setNewProductDetails(obj);
                                           }}/>
                                }
                                {
                                    newProductDetails &&
                                    <Input addonBefore='Price'
                                           style={{
                                               marginBottom: '16px',
                                           }}
                                           defaultValue={newProductDetails?.Price ? newProductDetails?.Price : ''}
                                           onChange={(data) => {
                                               const obj = Object.assign({}, newProductDetails);
                                               obj.Price = Number(data.target.value);
                                               setNewProductDetails(obj);
                                    }}/>
                                }
                                {
                                    newProductDetails &&
                                    <Input addonBefore='Total count'
                                           style={{
                                               marginBottom: '16px',
                                           }}
                                           defaultValue={newProductDetails?.TotalCount}
                                           onChange={(data) => {
                                               const obj = Object.assign({}, newProductDetails);
                                               obj.TotalCount = parseInt(data.target.value);
                                               setNewProductDetails(obj);
                                           }}/>
                                }
                                {
                                    newProductDetails &&
                                    <Input addonBefore='Image path'
                                           style={{
                                               marginBottom: '16px',
                                           }}
                                           defaultValue={newProductDetails?.ImagePath}
                                           onChange={(data) => {
                                               const obj = Object.assign({}, newProductDetails);
                                               obj.ImagePath = data.target.value;
                                               setNewProductDetails(obj);
                                           }}/>
                                }
                                <h3>Product description:</h3>
                                {
                                    newProductDetails &&
                                    <Input.TextArea defaultValue={newProductDetails?.Description}
                                                    rows={8}
                                                    onChange={(data) => {
                                                        const obj = Object.assign({}, newProductDetails);
                                                        obj.Description = data.target.value;
                                                        setNewProductDetails(obj);
                                                    }}/>
                                }
                                {
                                    // to add attributes
                                }
                            </div>
                        </MainContent>
                    </div>
                </>
            }
        </>
    );
}