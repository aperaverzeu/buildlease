import SubHeader from "../../layout/SubHeader";
import MainContent from "../../layout/MainContent";
import SideMenu from "../../layout/SideMenu";
import {Button, Input} from "antd";
import {useEffect, useState} from "react";
import API from "../../../API";
import CategoryFullView from "../../views/CategoryFullView";
import CategoryTreeSelect from "../CategoryTreeSelect";

export default function AdminCategory() {
    const [category, setCategoryValue] = useState<CategoryFullView | undefined>(undefined);
    const [productCategories, setProductCategories] = useState<CategoryFullView[] | undefined>(undefined);

    function onChangeSetCategoryValue() {
        setCategoryValue(category);
    }


    function LoadProductCategories() {
        API.GetAllCategories()
            .then(res => setProductCategories(res))
    }

    useEffect(() => {
        LoadProductCategories();
    }, [])

    return (
        <>
            <SubHeader>
                <h1>Categories</h1>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <SideMenu className="d-flex justify-content-around justify-content-between">

                    <CategoryTreeSelect onSelect={() => category?.Id}/>

                    <div>
                        {category?.Name}
                        <span>Name:</span>
                    </div>
                    <Input/>
                    <div>
                        <span>ImageLink:</span>
                    </div>
                    <Input/>
                    <Button type="primary" size="large">
                        Save Categories
                    </Button>
                </SideMenu>
                <MainContent>
                    {productCategories?.map(category => <div>{`${category?.Name}`}</div>)}
                    {productCategories?.map(category => <div>{`${category?.ProductCount}`}</div>)}
                    {productCategories?.map(category => <div>{`${category?.DefaultImagePath}`}</div>)}
                    {productCategories?.map(category => <div>{`${category?.ParentId}`}</div>)}
                </MainContent>
            </div>
        </>
    );
}