import SubHeader from "../../layout/SubHeader";
import MainContent from "../../layout/MainContent";

import {useParams} from "react-router-dom";
import {useEffect, useState} from "react";

import ProductInfo from "../../dtos/ProductInfo";

import API from "../../../API";
import LOGIC from "../../../LOGIC";

import {Button, Checkbox, Input, InputNumber, message, Space} from "antd";
import CategoryTreeSelect from "../CategoryTreeSelect";
import Globals from "../../../Globals";
import {AttributeType, CategoryAttributeInfo} from "../../dtos/CategoryAttributeInfo";

export default function AdminProduct() {
    
    const { stringProductId } = useParams<{stringProductId?: string | undefined}>();
    const productId: number = (stringProductId && +stringProductId) || 0;

    const [oldProductDetails, setOldProductDetails] = useState<ProductInfo | undefined>(undefined);
    const [newProductDetails, setNewProductDetails] = useState<ProductInfo | undefined>(undefined);

    function LoadProductDetails() {
        if (productId != 0) {
            API.GetProductDetails(productId)
                .then(res => {
                    setOldProductDetails(JSON.parse(JSON.stringify(res)));
                    setNewProductDetails(JSON.parse(JSON.stringify(res)));
                });
        } else {
            const obj: ProductInfo = {
                Id: '0',
                CategoryId: `${LOGIC.GetRootCategoryId()}`,
                Name: 'New product',
                Description: 'No description.',
                ImageLink: 'No image link',
                TotalCount: '0',
                Price: undefined,
                Attributes: [],
            };
            setOldProductDetails(JSON.parse(JSON.stringify(obj)));
            setNewProductDetails(JSON.parse(JSON.stringify(obj)));
        }
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
                        <div style={{
                            width: '320px',
                        }}>
                            <CategoryTreeSelect currentId={newProductDetails.CategoryId==`${LOGIC.GetRootCategoryId()}` ?
                                `${LOGIC.GetRootCategoryId()}`
                                :
                                `${Globals.Categories?.find(c => `${c.Id}` == newProductDetails.CategoryId)?.ParentId}-${newProductDetails.CategoryId}`}
                                                onSelect={newCategoryId => {
                                                    const obj = JSON.parse(JSON.stringify(newProductDetails));
                                                    obj.CategoryId = newCategoryId;
                                                    setNewProductDetails(obj);
                                                }}/>
                        </div>
                        <div>
                            <Button type='primary'
                                    onClick={() => {
                                        // save to api
                                        // if productId == 0, reset info
                                        // else, set old info from the new
                                        const someKey = Math.random();
                                        console.log(newProductDetails);
                                        message.loading({ content: 'Product...', key: someKey, duration: 0 });
                                        Promise
                                            .resolve(API.SaveProductInfo(newProductDetails)
                                                .then(() => {
                                                    message.success({ content: 'Done.', key: someKey });
                                                }));
                                    }}>
                                { productId == 0 ? 'Create product' : 'Apply changes' }
                            </Button>
                        </div>
                    </SubHeader>
                    <div className='d-flex flex-row flex-grow-1'>
                        <MainContent>
                            {
                                newProductDetails &&
                                <Space style={{padding: '16px'}}
                                       direction='vertical'
                                       size={8}>
                                    <Input addonBefore='Name'
                                           defaultValue={newProductDetails.Name}
                                           onChange={(data) => {
                                               const obj = Object.assign({}, newProductDetails);
                                               obj.Name = data.target.value;
                                               setNewProductDetails(obj);
                                           }}/>
                                    <Space direction='horizontal' size={8}>
                                        <Checkbox defaultChecked={false}
                                                  onChange={(data) => {
                                                      const obj = Object.assign({}, newProductDetails);
                                                      if (data.target.checked) {
                                                          obj.Price = '0';
                                                      } else {
                                                          obj.Price = undefined;
                                                      }
                                                      setNewProductDetails(obj);
                                        }}>There's a price</Checkbox>
                                        <InputNumber stringMode
                                                     addonBefore='Price'
                                                     addonAfter='$'
                                                     disabled={newProductDetails.Price == undefined}
                                                     min='0.01'
                                                     max='1000000' // just so that there's a maximum
                                                     step='0.01'
                                                     defaultValue={newProductDetails.Price ? newProductDetails.Price : '1'}
                                                     onChange={(data) => {
                                                         const obj = Object.assign({}, newProductDetails);
                                                         obj.Price = `${Number(data)}`;
                                                         setNewProductDetails(obj);
                                                     }}/>
                                    </Space>
                                    <Input addonBefore='Total count'
                                           defaultValue={newProductDetails.TotalCount}
                                           onChange={(data) => {
                                               const obj = Object.assign({}, newProductDetails);
                                               obj.TotalCount = data.target.value;
                                               setNewProductDetails(obj);
                                           }}/>
                                    <Input addonBefore='Image path'
                                           defaultValue={newProductDetails.ImageLink}
                                           onChange={(data) => {
                                               const obj = Object.assign({}, newProductDetails);
                                               obj.ImageLink = data.target.value;
                                               setNewProductDetails(obj);
                                           }}/>
                                    <h3>Product description:</h3>
                                    <Input.TextArea defaultValue={newProductDetails.Description}
                                                    rows={8}
                                                    onChange={(data) => {
                                                        const obj = Object.assign({}, newProductDetails);
                                                        obj.Description = data.target.value;
                                                        setNewProductDetails(obj);
                                                    }}/>
                                </Space>
                            }
                        </MainContent>
                        <div style={{
                            width: '600px',
                        }}>
                            {
                                // to add attributes
                            }
                        </div>
                    </div>
                </>
            }
        </>
    );
}
