import SubHeader from "../../layout/SubHeader";
import MainContent from "../../layout/MainContent";
import SideMenu from "../../layout/SideMenu";
import {Button, Input, Space} from "antd";
import {useEffect, useState} from "react";
import API from "../../../API";
import CategoryFullView from "../../views/CategoryFullView";
import CategoryTreeSelect from "../CategoryTreeSelect";

export default function AdminCategory() {
    const [categoryId, setCategoryIdValue] = useState<number | undefined>(undefined);
    const [productCategories, setProductCategories] = useState<CategoryFullView[] | undefined>(undefined);

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
                    <Space direction="vertical" size={25}>
                        <div>
                            <span>Category:</span>
                            <CategoryTreeSelect onSelect={category => setCategoryIdValue(category)}/>
                        </div>
                        <div>
                            <span>Name:</span>
                            <Input/>
                        </div>
                        <div>
                            <span>ImageLink:</span>
                            <Input/>
                        </div>
                        <Button type="primary" style={{width: "15rem", height: "3rem", fontSize: "17px"}}>
                            Save Category
                        </Button>
                        <Button type="primary" style={{width: "15rem", height: "3rem", fontSize: "17px"}}>
                            Delete Category
                        </Button>
                    </Space>
                </SideMenu>
                <MainContent>
                    <Space direction="vertical" size={25} style={{width: "70%", marginLeft: "10rem"}}>
                        <div>
                            <span>ImageLink:</span>
                            <Input
                                placeholder={`${productCategories?.find(category => category.Id === categoryId)?.ParentId}`}>
                            </Input>
                        </div>
                        <div>
                            <span>ImageLink:</span>
                            <Input
                                placeholder={`${productCategories?.find(category => category.Id === categoryId)?.Name}`}>
                            </Input>
                        </div>
                        <div>
                            <span>ImageLink:</span>
                            <Input
                                placeholder={`${productCategories?.find(category => category.Id === categoryId)?.DefaultImagePath}`}>
                            </Input>
                        </div>
                        <div>
                            <span>ImageLink:</span>
                            <Input
                                placeholder={`${productCategories?.find(category => category.Id === categoryId)?.ProductCount}`}>
                            </Input>
                        </div>
                        <Button type="primary" style={{width: "15rem", height: "3rem", fontSize: "17px"}}>
                            Save attribute
                        </Button>
                    </Space>
                </MainContent>
            </div>
        </>
    );
}