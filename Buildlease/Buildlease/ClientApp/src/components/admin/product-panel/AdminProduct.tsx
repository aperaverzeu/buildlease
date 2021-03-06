import SubHeader from "../../layout/SubHeader";
import MainContent from "../../layout/MainContent";

import {Redirect, useParams} from "react-router-dom";
import {useEffect, useState} from "react";

import ProductInfo from "../../dtos/ProductInfo";

import API from "../../../API";
import LOGIC from "../../../LOGIC";

import {AutoComplete, Button, Checkbox, Input, InputNumber, message, Select, Space} from "antd";
import CategoryTreeSelect from "../CategoryTreeSelect";
import Globals from "../../../Globals";
import {AttributeType} from "../../dtos/CategoryAttributeInfo";
import ProductDescriptionInfo from "../../dtos/ProductDescriptionInfo";
import {Display} from "react-bootstrap-icons";

export default function AdminProduct() {
    
    const { stringProductId } = useParams<{stringProductId?: string | undefined}>();
    const productId: number = (stringProductId && +stringProductId) || 0;

    const [oldProductDetails, setOldProductDetails] = useState<ProductInfo | undefined>(undefined);
    const [newProductDetails, setNewProductDetails] = useState<ProductInfo | undefined>(undefined);
    const [redirect, setRedirect] = useState<string | null>(null);

    function LoadProductDetails() {
        if (productId != 0) {
            API.GetProductInfo(productId)
                .then(res => {
                    setOldProductDetails(JSON.parse(JSON.stringify(res)));
                    setNewProductDetails(JSON.parse(JSON.stringify(res)));
                });
        } else {
            const obj: ProductInfo = {
                Id: 0,
                CategoryId: LOGIC.GetRootCategoryId(),
                Name: 'New product',
                Descriptions: [],
                ImageLink: 'No image link',
                TotalCount: 0,
                Price: null,
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
            {redirect && <Redirect to={redirect}/>}
            {
                newProductDetails &&
                <>
                    <SubHeader>
                        <div style={{
                            width: '320px',
                        }}>
                            <CategoryTreeSelect currentId={newProductDetails.CategoryId==LOGIC.GetRootCategoryId() ?
                                `${LOGIC.GetRootCategoryId()}`
                                :
                                `${Globals.Categories?.find(c => c.Id == newProductDetails.CategoryId)?.ParentId}-${newProductDetails.CategoryId}`}
                                                onSelect={newCategoryId => {
                                                    const obj = JSON.parse(JSON.stringify(newProductDetails));
                                                    obj.CategoryId = newCategoryId;
                                                    setNewProductDetails(obj);
                                                }}/>
                        </div>
                        <div style={{display: 'flex', flexDirection: "column", gap: '10px'}}>
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
                                                .then((res) => {
                                                    console.log(res);
                                                })
                                                .then(() => {
                                                    message.success({ content: 'Done.', key: someKey });
                                                }));
                                    }}>
                                { productId === 0 ? 'Create product' : 'Apply changes' }
                            </Button>
                            { productId !== 0 &&
                            <Button type='primary'
                                    danger
                                    onClick={() => {
                                        if (productId) {
                                        const someKey = Math.random();
                                        message.loading({ content: 'Wait for it...', key: someKey, duration: 0 });
                                        Promise
                                            .resolve(API.DeleteProduct(productId)
                                                .then(() => {
                                                    message.success({ content: 'Product removed', key: someKey });
                                                }))
                                                .then(() => setRedirect('admin/product'));
                                    }
                                    }}
                            >
                                Delete product
                            </Button>}
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
                                        <Checkbox defaultChecked={newProductDetails.Price != null}
                                                  onChange={(data) => {
                                                      const obj = Object.assign({}, newProductDetails);
                                                      if (data.target.checked) {
                                                          obj.Price = 0;
                                                      } else {
                                                          obj.Price = null;
                                                      }
                                                      setNewProductDetails(obj);
                                        }}>There's a price</Checkbox>
                                        <InputNumber stringMode
                                                     addonBefore='Price'
                                                     addonAfter='$'
                                                     disabled={newProductDetails.Price == null}
                                                     min={0.01}
                                                     max={1000000} // just so that there's a maximum
                                                     step={0.01}
                                                     defaultValue={newProductDetails.Price ? newProductDetails.Price : 1}
                                                     onChange={(data) => {
                                                         const obj = Object.assign({}, newProductDetails);
                                                         obj.Price = Number(data);
                                                         setNewProductDetails(obj);
                                                     }}/>
                                    </Space>
                                    <InputNumber addonBefore='Total count'
                                                 precision={1} 
                                                 defaultValue={newProductDetails.TotalCount}
                                           onChange={(data) => {
                                               const obj = Object.assign({}, newProductDetails);
                                               obj.TotalCount = data;
                                               setNewProductDetails(obj);
                                           }}/>
                                    <Input addonBefore='Image path'
                                           defaultValue={newProductDetails.ImageLink}
                                           onChange={(data) => {
                                               const obj = Object.assign({}, newProductDetails);
                                               obj.ImageLink = data.target.value;
                                               setNewProductDetails(obj);
                                           }}/>
                                    { productId !== 0 && <>
                                        <h3>Product descriptions:</h3>
                                        { newProductDetails.Descriptions.map(d => <>
                                        <Input addonBefore='Language'
                                            defaultValue={d.Language}
                                            onChange={(data) => {
                                                const obj = Object.assign({}, newProductDetails);
                                                obj.Descriptions.filter(x => x.Language == d.Language)[0].Language = data.target.value;
                                                setNewProductDetails(obj);
                                            }}/>
                                        <Input.TextArea key={d.Language}
                                                        defaultValue={d.Description}
                                                        rows={8}
                                                        onChange={(data) => {
                                                            const obj = Object.assign({}, newProductDetails);
                                                            obj.Descriptions.filter(x => x.Language == d.Language)[0].Description = data.target.value;
                                                            setNewProductDetails(obj);
                                                        }}/>
                                        </>)
                                        }
                                        <Button type='primary'
                                                style={{
                                                    marginBottom: '16px',
                                                }}
                                                onClick={() => {
                                                    let newDescriptionInfo : ProductDescriptionInfo = {
                                                        Language: '',
                                                        Description: '',
                                                    };
                                                    newProductDetails.Descriptions.push(newDescriptionInfo);
                                                    const obj = Object.assign({}, newProductDetails);
                                                    setNewProductDetails(obj);
                                                }}
                                        >Add new description</Button>
                                    </>}
                                </Space>
                            }
                        </MainContent>
                        <div className='d-flex flex-column' style={{
                            width: '600px',
                        }}>
                            {
                                productId !== 0 &&
                                newProductDetails.Attributes.map(attr => (
                                    attr.ValueType === AttributeType.String ?
                                        <div className='w-100 d-flex align-items-center' style={{
                                            marginBottom: '16px',
                                        }}>
                                            <p style={{margin: 0,
                                                marginRight: '8px',
                                            }}>{attr.Name}</p>
                                            <AutoComplete className='d-flex flex-grow-1'
                                                defaultValue={attr.Value ?? ""}
                                                options={
                                                    newProductDetails!.Attributes.find(a => a.AttributeId == attr.AttributeId)!.ExistingStringValues!
                                                        .map(sv => ({ value: sv }))
                                                }
                                                onChange={val => {
                                                    const obj = Object.assign({}, newProductDetails);
                                                    obj!.Attributes.find(a => a.AttributeId == attr.AttributeId)!.Value = val;
                                                    setNewProductDetails(obj);
                                                }}/>
                                        </div>
                                        :
                                        <InputNumber
                                            style={{
                                                marginBottom: '8px',
                                            }}
                                            addonBefore={attr.Name} 
                                            addonAfter={attr.UnitName}
                                            defaultValue={attr.Value ?? ''}
                                            onChange={val => {
                                                const obj = Object.assign({}, newProductDetails);
                                                obj!.Attributes.find(a => a.AttributeId == attr.AttributeId)!.Value = val;
                                                setNewProductDetails(obj);
                                            }}/>
                                ))
                            }
                        </div>
                    </div>
                </>
            }
        </>
    );
}
