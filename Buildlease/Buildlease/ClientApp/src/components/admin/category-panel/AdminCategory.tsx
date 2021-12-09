/*
* Ok, so this code is terrible but it works.
* It is to be revisited to be optimized maybe, but for now this is what we get.
* */

import {useEffect, useState} from "react";

import SubHeader from "../../layout/SubHeader";
import MainContent from "../../layout/MainContent";
import SideMenu from "../../layout/SideMenu";
import CategoryTreeSelect from "../CategoryTreeSelect";

import {Button, Input, message, Select, Space} from "antd";

import CategoryInfo from "../../dtos/CategoryInfo";
import {CategoryAttributeInfo, AttributeType} from "../../dtos/CategoryAttributeInfo";

import API from "../../../API";
import LOGIC from "../../../LOGIC";
import Globals from "../../../Globals";

export default function AdminCategory() {
    
    const [categoryId, setCategoryId] = useState<number | undefined>(undefined);
    const [categoryInfo, setCategoryInfo] = useState<CategoryInfo | undefined>(undefined);

    function CheckoutToNewCategory(newCategoryId: number) {
        API.GetAllCategories()
            .then(res => Globals.Categories = res)
            .then(() => setCategoryId(undefined))
            .then(() => setCategoryId(newCategoryId))
            .then(() => API.GetCategoryInfo(newCategoryId))
            .then(res => setCategoryInfo(res));
    }

    useEffect(() => {
        CheckoutToNewCategory(LOGIC.GetRootCategoryId());
    }, [])

    return (
        <>
            <SubHeader>
                <h1 style={{
                    margin: '0px',
                }}>Category management</h1>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <SideMenu className="d-flex justify-content-around justify-content-between">
                    <Space direction="vertical"
                           size={32}
                           className='w-100'
                           style={{
                               padding: '24px',
                           }}>
                        <Space direction='vertical'
                               className='w-100'
                               size={16}>
                            <div>
                                <h3 style={{
                                    margin: '0px',
                                    marginBottom: '4px',
                                }}>Select category to modify:</h3>
                                {
                                    categoryId &&
                                    <CategoryTreeSelect
                                        currentId={categoryId==LOGIC.GetRootCategoryId() ? `${categoryId}` : `${Globals.Categories?.find(c => c.Id == categoryId)?.ParentId}-${categoryId}`}
                                        onSelect={newCategoryId => {
                                            const someKey = Math.random();
                                            message.loading({ content: 'Pulling selected category info...', key: someKey, duration: 0 });
                                            Promise
                                                .resolve(API.GetCategoryInfo(newCategoryId)
                                                    .then(res => setCategoryInfo(res))
                                                    .then(() => setCategoryId(newCategoryId))
                                                    .then(() => CheckoutToNewCategory(newCategoryId))
                                                    .then(() => {
                                                        message.success({ content: 'The info pulled.', key: someKey });
                                                    }));
                                        }}/>
                                }
                            </div>
                            <Button type="primary"
                                    danger
                                    className='w-100'
                                    onClick={() => {
                                        if (categoryId) {
                                            const someKey = Math.random();
                                            message.loading({ content: 'Wait for it...', key: someKey, duration: 0 });
                                            Promise
                                                .resolve(API.DeleteCategory(categoryId)
                                                    .then(() => API.GetCategoryInfo(LOGIC.GetRootCategoryId()))
                                                    .then(res => setCategoryInfo(res))
                                                    .then(() => setCategoryId(LOGIC.GetRootCategoryId()))
                                                    .then(() => CheckoutToNewCategory(LOGIC.GetRootCategoryId()))
                                                    .then(() => {
                                                        message.success({ content: 'Category removed', key: someKey });
                                                    }));
                                        }
                                    }}>
                                Remove
                            </Button>
                        </Space>
                        <Button type="primary"
                                className='w-100'
                                onClick={() => {
                                    if (categoryId) {
                                        const someKey = Math.random();
                                        message.loading({ content: 'Wait for it...', key: someKey, duration: 0 });
                                        Promise
                                            .resolve(API.CreateSubcategory(categoryId)
                                                .then(() => API.GetCategoryInfo(categoryId))
                                                .then(res => setCategoryInfo(res))
                                                .then(() => setCategoryId(categoryId))
                                                .then(() => CheckoutToNewCategory(categoryId))
                                                .then(() => {
                                                    message.success({ content: 'New category added', key: someKey });
                                                }));
                                    }
                                }}>
                            Add child category
                        </Button>
                    </Space>
                </SideMenu>
                <MainContent>
                    {
                        (categoryInfo && categoryId) &&
                        <Space direction="vertical" size={25} style={{width: "70%", marginLeft: "10rem"}}>
                            <div>
                                <Input addonBefore='Name'
                                       defaultValue={`${categoryInfo.Name}`}
                                       onChange={data => {
                                           const obj = Object.assign({}, categoryInfo);
                                           obj.Name = data.target.value;
                                           setCategoryInfo(obj);
                                       }}>
                                </Input>
                            </div>
                            <div>
                                <Input addonBefore='Default image link'
                                       placeholder={`${categoryInfo.ImageLink}`}
                                       onChange={data => {
                                           const obj = Object.assign({}, categoryInfo);
                                           obj.ImageLink = data.target.value;
                                           setCategoryInfo(obj);
                                       }}>
                                </Input>
                            </div>
                            <Space direction="vertical" size={16}>
                                <Button onClick={() => {
                                    const obj = Object.assign({}, categoryInfo);
                                    const newAttr: CategoryAttributeInfo = {
                                        Id: 0,
                                        Name: 'new attribute',
                                        ValueType: AttributeType.Number,
                                        UnitName: 'unit',
                                    };
                                    obj.Attributes.push(newAttr);
                                    setCategoryInfo(obj);
                                }}>
                                    Add new category attribute
                                </Button>
                                {
                                    categoryInfo.Attributes.map(
                                        (attr, index) =>
                                            <Space direction='horizontal' size={4}>
                                                <Input defaultValue={attr.Name} onChange={data => {
                                                    const obj = Object.assign({}, categoryInfo);
                                                    obj.Attributes[index].Name = data.target.value;
                                                    setCategoryInfo(obj);
                                                }}/>
                                                <Select style={{
                                                    width: '100px',
                                                }}
                                                        defaultValue={`${attr.ValueType}`}
                                                        onChange={data => {
                                                            if (data) {
                                                                const obj = Object.assign({}, categoryInfo);
                                                                // @ts-ignore
                                                                obj.Attributes[index].ValueType = data;
                                                                setCategoryInfo(obj);
                                                            }
                                                }}>
                                                    <Select value={`${AttributeType.Number}`}>Number</Select>
                                                    <Select value={`${AttributeType.String}`}>String</Select>
                                                </Select>
                                                <Input defaultValue={attr.UnitName} onChange={newVal => {
                                                    const obj = Object.assign({}, categoryInfo);
                                                    obj.Attributes[index].UnitName = newVal.target.value;
                                                    setCategoryInfo(obj);
                                                }}/>
                                                <Button danger
                                                        onClick={() => {
                                                            const obj = Object.assign({}, categoryInfo);
                                                            obj.Attributes.splice(index, 1);
                                                            setCategoryInfo(obj);
                                                        }}>
                                                    Remove
                                                </Button>
                                            </Space>
                                    )
                                }
                            </Space>
                            <Button type="primary"
                                    style={{
                                        width: "15rem",
                                        height: "3rem",
                                        fontSize: "17px"}}
                                    onClick={() => {
                                        const someKey = Math.random();
                                        message.loading({ content: 'Pushing new category info...', key: someKey, duration: 0 });
                                        Promise
                                            .resolve(API.SaveCategoryInfo(categoryInfo)
                                                .then(() => CheckoutToNewCategory(categoryInfo.Id))
                                                .then(() => {
                                                    message.success({ content: 'Changes applied', key: someKey });
                                                }));
                                    }}>
                                Save changes
                            </Button>
                        </Space>
                    }
                </MainContent>
            </div>
        </>
    );
}