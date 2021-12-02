import {useEffect, useState} from "react";

import OrderView from "../views/OrderView";

import SubHeader from "../layout/SubHeader";
import SideMenu from "../layout/SideMenu";
import MainContent from "../layout/MainContent";

import OrderCard from '../cards/OrderCard';

import API from "../../API";
import {Button} from "antd";

export default function OrderHistory() {
    
    const [orderHistory, setOrderHistory] = useState<OrderView[] | undefined>(undefined);
    
    function LoadOrderHistory() {
        API.GetOrders()
            .then(res => setOrderHistory(res));
    }
    
    useEffect(() => {
        LoadOrderHistory();
    }, []);
    
    return(
        <>
            <SubHeader>
                <h1>Your Order History:</h1>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <SideMenu>
                    <div style={{
                        padding: '24px',
                    }}>
                        <div style={{
                            marginBottom: '24px',
                        }}>
                            <h2 style={{
                                margin: '0px',
                                marginBottom: '16px',
                            }}>Actions:</h2>
                            <Button block>Show details for all</Button>
                        </div>
                        <div>
                            <h2>Options:</h2>
                        </div>
                    </div>
                </SideMenu>
                <MainContent>
                    <div style={{
                        padding: '24px',
                    }}>
                        {orderHistory?.map(orderView => <OrderCard OrderView={orderView} detailsShown={false}/>)}
                    </div>
                </MainContent>
            </div>
        </>
    );
}
