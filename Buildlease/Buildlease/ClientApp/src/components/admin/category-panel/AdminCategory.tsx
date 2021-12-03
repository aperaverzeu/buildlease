import SubHeader from "../../layout/SubHeader";
import MainContent from "../../layout/MainContent";
import SideMenu from "../../layout/SideMenu";
import {Button, Input, TreeSelect} from "antd";
import {useEffect, useState} from "react";
import API from "../../../API";
import CategoryFullView from "../../views/CategoryFullView";

const {TreeNode} = TreeSelect;

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

    function MapProductCategories(productCategories: CategoryFullView[]) {
        let map = new Map<CategoryFullView, CategoryFullView[]>;

        for (let productCategory of productCategories) {
            if (productCategory.Name === "Все") {
                productCategories.reduce(productCategory);
            }
        }

        let currentKeyCategory: CategoryFullView;
        let isKey = true;
        let isValue = true;


        // 0
        // 2 
        // 0
        // 2
        productCategories.forEach(category => {
            if (category.ParentId > 0) {
                isKey = false;
                isValue = true;
            }

            if (isKey) {
                isValue = false;
                currentKeyCategory = category;
            }

        });
    }

    function RenderTreeKey(category: CategoryFullView) {
        if (category.Name === "Все") {
            return (<></>)
        }

        if (category.ParentId > 0) {
            return (
                <TreeNode value={category.Name} title={category.Name}>
                    {RenderTreeKey()}
                </TreeNode>
            )
        }

        return (
            <TreeNode value={category.Name} title={category.Name}>

            </TreeNode>
        )
    }

    return (
        <>
            <SubHeader>
                <h1>Categories</h1>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <SideMenu className="d-flex justify-content-around justify-content-between">
                    <TreeSelect showSearch
                                style={{width: '100%'}}
                                value={undefined}
                                dropdownStyle={{maxHeight: 400, overflow: 'auto'}}
                                placeholder="Please select"
                                allowClear
                                treeDefaultExpandAll
                                onChange={() => onChangeSetCategoryValue()}>
                        {/*{MapProductCategories(productCategories).}*/}


                        {/*<TreeNode value="parent 1" title="parent 1">*/}
                        {/*    <TreeNode value="parent 1-0" title="parent 1-0">*/}
                        {/*        <TreeNode value="leaf1" title="my leaf"/>*/}
                        {/*        <TreeNode value="leaf2" title="your leaf"/>*/}
                        {/*    </TreeNode>*/}
                        {/*    <TreeNode value="parent 1-1" title="parent 1-1">*/}
                        {/*        <TreeNode value="sss" title={<b style={{color: '#08c'}}>sss</b>}/>*/}
                        {/*    </TreeNode>*/}
                        {/*</TreeNode>*/}
                    </TreeSelect>
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