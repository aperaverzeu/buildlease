import SubHeader from "../../layout/SubHeader";
import MainContent from "../../layout/MainContent";
import SideMenu from "../../layout/SideMenu";
import {Button, Input, Space} from "antd";
import {useEffect, useState} from "react";
import API from "../../../API";
import CategoryFullView from "../../views/CategoryFullView";
import CategoryTreeSelect from "../CategoryTreeSelect";
import CategoryInfo from "../../dtos/CategoryInfo";
import PATH from "../../../PATH";
import LOGIC from "../../../LOGIC";
import Globals from "../../../Globals";

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
                                <CategoryTreeSelect onSelect={category => setCategoryIdValue(category)}/>
                            </div>
                            <Button type="primary"
                                    danger
                                    className='w-100'>
                                Remove
                            </Button>
                        </Space>
                        <Space direction="vertical"
                               className='w-100'
                               size={16}>
                            <h3 style={{
                                margin: '0px',
                            }}>Add child category:</h3>
                            <div>
                                <Input addonBefore='Name'/>
                            </div>
                            <Button type="primary"
                                    className='w-100'
                                    onClick={() => {
                                        
                                    }}>
                                Add child
                            </Button>
                        </Space>
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