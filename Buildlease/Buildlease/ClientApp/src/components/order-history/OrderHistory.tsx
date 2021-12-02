import {useEffect, useState} from "react";

import OrderView from "../views/OrderView";

import SubHeader from "../layout/SubHeader";
import SideMenu from "../layout/SideMenu";
import MainContent from "../layout/MainContent";

import OrderCard from '../cards/OrderCard';

import API from "../../API";

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
                    
                </SideMenu>
                <MainContent>
                    {orderHistory?.map(orderView => <OrderCard OrderView={orderView} detailsShown={false}/>)}
                </MainContent>
            </div>
        </>
    );
}
