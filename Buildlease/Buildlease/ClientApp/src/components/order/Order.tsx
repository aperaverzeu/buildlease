import { useEffect, useState } from "react";
import {useParams} from "react-router-dom";

import {Breadcrumb} from "antd";

// gen layout
import SubHeader from "../layout/SubHeader";
import SideMenu from "../layout/SideMenu";
import MainContent from "../layout/MainContent";

// views
import OrderFullView from "../views/OrderFullView";

// Rigorich
import PATH from "../../PATH";
import LOGIC from "../../LOGIC";
import API from "../../API";


export default function Order() {

    const { stringOrderId } = useParams<{stringOrderId: string}>();
    const productId: number = +stringOrderId;

    const [orderDetails, setOrderDetails] = useState<OrderFullView | undefined>(undefined);

    function LoadOrderDetails() {
        API.GetOrderDetails(productId)
            .then(res => setOrderDetails(res));
    }

    useEffect(() => {
        LoadOrderDetails();
    }, []);
    
    return(
        <>
            <SubHeader>
                <h1>{`Order #${orderDetails?.Id}`}</h1>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <SideMenu>
                    <p>{`Price: ${orderDetails?.Price}`}</p>
                </SideMenu>
                <MainContent>
                    
                </MainContent>
            </div>
        </>
    );
    
}
