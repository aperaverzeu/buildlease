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
                <h1 style={{
                    margin: '0px',
                }}>{`Order #${orderDetails?.Id}, placed ${LOGIC.GetUserFriendlyDateRepr(orderDetails?.StatusHistory[0].Date)}`}</h1>
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
                                <p style={{margin: 0}}>{`${orderDetails?.ProductOrders.map(productOrder => productOrder.Count).reduce((a, b) => a+b, 0)} unit(s) of ${orderDetails?.ProductOrders.length} product(s) ordered;`}</p>
                                <p style={{margin: 0}}>{`Total price: $${orderDetails?.Price.toFixed(2)};`}</p>
                                {orderDetails?.StatusHistory.map(status => <p style={{margin: 0}}>{`${LOGIC.GetStatusString(status.NewStatus)[0].toUpperCase() + LOGIC.GetStatusString(status.NewStatus).slice(1)} ${LOGIC.GetUserFriendlyDateRepr(status.Date)};`}</p>)}
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
                                <ProductOrderCard ProductOrderView={productOrder} isInteractive={false}
                                                  setCartState={undefined}/>)
                        }
                    </div>
                </MainContent>
            </div>
        </>
    );
    
}
