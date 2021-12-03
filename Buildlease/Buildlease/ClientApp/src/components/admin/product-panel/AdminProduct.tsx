import SubHeader from "../../layout/SubHeader";
import MainContent from "../../layout/MainContent";

import {useParams} from "react-router-dom";
import {useEffect, useState} from "react";

import ProductFullView from "../../views/ProductFullView";

import API from "../../../API";

import {Input} from "antd";

export default function AdminProduct() {
    
    const { stringProductId } = useParams<{stringProductId: string}>();
    const productId: number = +stringProductId;

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
    
    function pushChanges() {
        
    }
    
    return (
        <>
            <SubHeader>
                <div>
                    *Category TreeSelect to choose new product category*
                </div>
                <div>
                    *"Apply changes" button*
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
                    </div>
                </MainContent>
            </div>
        </>
    );
}