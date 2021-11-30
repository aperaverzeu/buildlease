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
import ProductOrderCard from "../cards/ProductOrderCard";


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
                    <div style={{
                        padding: '24px',
                    }}>
                        <div className='d-flex' style={{
                            marginBottom: '16px',
                        }}>
                            <h2 style={{marginRight: '8px'}}>Status:</h2>
                            <h2 style={{
                                fontStyle: 'italic',
                                fontWeight: 'lighter',
                            }}>{orderDetails?.Status.toLowerCase()}</h2>
                        </div>
                        <div>
                            <h2>Information:</h2>
                            <div style={{padding: '8px'}}>
                                <p style={{margin: 0}}>{`${orderDetails?.ProductOrders.length} products ordered;`}</p>
                                <p style={{margin: 0}}>{`Total price: $${orderDetails?.ProductOrders.map(productOrder => productOrder.Price*productOrder.Count).reduce((a, b) => a + b, 0)};`}</p>
                            </div>
                        </div>
                    </div>
                </SideMenu>
                <MainContent>
                    <div style={{
                        padding: '24px',
                    }}>
                        {
                            orderDetails?.ProductOrders.map(productOrder =>
                                <ProductOrderCard ProductOrderView={productOrder} isInteractive={false}/>)
                        }
                    </div>
                </MainContent>
            </div>
        </>
    );
    
}
