import {useEffect, useState} from "react";

import SubHeader from "../../layout/SubHeader";
import MainContent from "../../layout/MainContent";
import SideMenu from "../../layout/SideMenu";
import CategoryTreeSelect from "../CategoryTreeSelect";

import {Button, Input, message, Space} from "antd";

import CategoryFullView from "../../views/CategoryFullView";
import CategoryInfo from "../../dtos/CategoryInfo";

import API from "../../../API";
import PATH from "../../../PATH";
import LOGIC from "../../../LOGIC";
import Globals from "../../../Globals";

export default function AdminCategory() {
    
    const [categoryId, setCategoryId] = useState<number | undefined>(undefined);
    const [currentCategory, setCurrentCategory] = useState<CategoryFullView | undefined>(undefined);
    const [categoryInfo, setCategoryInfo] = useState<CategoryInfo | undefined>(undefined);

    function ReloadAndCheckoutCategories(newCategoryId: number) {
        API.GetAllCategories()
            .then(res => Globals.Categories = res)
            .then(() => setCategoryId(0))
            .then(() => setCategoryId(newCategoryId));
    }

    useEffect(() => {
        ReloadAndCheckoutCategories(LOGIC.GetRootCategoryId());
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
                                <CategoryTreeSelect
                                    onSelect={newCategoryId => {
                                        setCategoryId(newCategoryId);
                                        const currentCat = Globals.Categories?.find(category => category.Id === newCategoryId);
                                        setCurrentCategory(currentCat);
                                        if (currentCat) {
                                            const obj: CategoryInfo = {
                                                Id: currentCat.Id,
                                                Name: currentCat.Name,
                                                ImageLink: currentCat.DefaultImagePath,
                                                Attributes: [],
                                            };
                                            setCategoryInfo(obj);
                                    }
                                }}/>
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
                                                    .then(() => ReloadAndCheckoutCategories(LOGIC.GetRootCategoryId()))
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
                                                .then(() => ReloadAndCheckoutCategories(categoryId))
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
                        <Space direction="vertical" size={25} style={{width: "70%", marginLeft: "10rem"}}>
                            <div>
                                <Input addonBefore='Name'
                                       placeholder={`${currentCategory?.Name}`}
                                       onChange={data => {
                                           const obj = Object.assign({}, categoryInfo);
                                           obj.Name = data.target.value;
                                           setCategoryInfo(obj);
                                       }}>
                                </Input>
                            </div>
                            <div>
                                <Input addonBefore='Default image link'
                                       placeholder={`${currentCategory?.DefaultImagePath}`}
                                       onChange={data => {
                                           const obj = Object.assign({}, categoryInfo);
                                           obj.ImageLink = data.target.value;
                                           setCategoryInfo(obj);
                                       }}>
                                </Input>
                            </div>
                            <Button type="primary"
                                    style={{
                                        width: "15rem",
                                        height: "3rem",
                                        fontSize: "17px"}}
                                    onClick={() => {
                                        if (categoryInfo) {
                                            const someKey = Math.random();
                                            message.loading({ content: 'Wait for it...', key: someKey, duration: 0 });
                                            Promise
                                                .resolve(API.SaveCategoryInfo(categoryInfo)
                                                    .then(() => ReloadAndCheckoutCategories(categoryInfo.Id))
                                                    .then(() => {
                                                        message.success({ content: 'Changes applied', key: someKey });
                                                    }));
                                        }
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