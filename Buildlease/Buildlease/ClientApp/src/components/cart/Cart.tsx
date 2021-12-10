import {useEffect, useState} from "react";

import SubHeader from "../layout/SubHeader";
import SideMenu from "../layout/SideMenu";
import MainContent from "../layout/MainContent";

import CartFullView from "../views/CartFullView";
import API from "../../API";
import ProductOrderCard from "../cards/ProductOrderCard";
import {Button, DatePicker, message} from "antd";
import MakeOrderFromCartRequest from "./MakeOrderFromCartRequest";
import {duration} from "@material-ui/core";
import {Redirect, useHistory} from "react-router-dom";
import PATH from "../../PATH";

export default function Cart() {

    const history = useHistory();
    
    const [cartDetails, setCartDetails] = useState<CartFullView | undefined>(undefined);
    const [startDate, setStartDate] = useState<Date>(new Date(0));
    const [finishDate, setFinishDate] = useState<Date>(new Date(0));

    function LoadCartDetails() {
        API.GetCartDetails()
            .then(res => setCartDetails(res));
    }

    useEffect(() => {
        LoadCartDetails();
    }, []);
    
    return(
        <>
            <SubHeader>
                <h1 style={{
                    margin: '0px',
                }}>Your Cart:</h1>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <SideMenu>
                    <div  style={{
                        padding: '24px',
                    }}>
                        <div style={{
                            margin: '0px',
                            marginBottom: '16px',
                        }}>
                            <h2 style={{
                                margin: '0px',
                                marginBottom: '16px',
                            }}>Actions:</h2>
                            <Button block onClick={(smth) => {cartDetails?.ProductOrders.map(productOrder1 =>
                                productOrder1.ProductId != null &&
                                API.SetProductOrderCount(productOrder1.ProductId, 0));
                                API.GetCartDetails()
                                    .then(res => setCartDetails(res));
                            }
                            }>
                                Remove all</Button>
                        </div>
                        <div style={{
                            margin: '0px',
                            marginBottom: '16px',
                        }}>
                            <h2 style={{
                                margin: '0px',
                                marginBottom: '16px',
                            }}>Options:</h2>
                            <div className='d-flex flex-row justify-content-between'>
                                <DatePicker placeholder='Start date' onChange={date => {
                                    date !== null ? 
                                        setStartDate(date.toDate())
                                        :
                                        setStartDate(new Date(0))
                                }}/>
                                <DatePicker placeholder='Finish date' onChange={date => {
                                    date !== null ?
                                        setFinishDate(date.toDate())
                                        :
                                        setFinishDate(new Date(0))
                                }}/>
                            </div>
                        </div>
                        <div>
                            <h2>Status:</h2>
                            <div style={{padding: '8px'}}>
                                <p style={{margin: 0}}>{`${cartDetails?.ProductOrders.map(productOrder => productOrder.Count).reduce((a, b) => a+b, 0)} unit(s) of ${cartDetails?.ProductOrders.length} product(s) ordered;`}</p>
                                <p style={{margin: 0}}>{`Total price: $${cartDetails?.ProductOrders.map(productOrder => productOrder.Price*productOrder.Count).reduce((a, b) => a+b, 0).toFixed(2)};`}</p>
                            </div>
                        </div>
                        <Button block type='primary' onClick={() => {
                                if (startDate.getUTCMilliseconds() == 0 && finishDate.getUTCMilliseconds() == 0) {
                                    message.error("Fill in the start & finish date!")
                                } else if (startDate.getUTCMilliseconds() == 0) {
                                    message.error("Fill in the start date!")
                                } else if (finishDate.getUTCMilliseconds() == 0) {
                                    message.error("Fill in the finish date!")
                                }
                                
                                const messageKey = Math.random();
                                message.loading({content: 'Wait for it...', key: messageKey, duration: 0});

                                let obj = { StartDate: startDate, FinishDate: finishDate}
                                Promise
                                    .resolve(
                                        API.MakeOrderFromCart(obj)
                                            .then(() => {
                                                message.success({
                                                    content: "Order is successfully carried out!",
                                                    key: messageKey
                                                });
                                                
                                                history.push("/order-history");
                                            })
                                            .catch(err => message.error({ content: err.response.data, key: messageKey }))
                                    )
                            }
                        }>Make order</Button>
                    </div>
                </SideMenu>
                <MainContent>
                    <div style={{
                        padding: '24px',
                    }}>
                        {
                            cartDetails?.ProductOrders.map(productOrder =>
                                <ProductOrderCard ProductOrderView={productOrder} isInteractive={true} 
                                                  key={productOrder.ProductId} setCartState={setCartDetails}/>)
                        }
                    </div>
                </MainContent>
            </div>
        </>
    );
}
