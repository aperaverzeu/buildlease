import {useEffect, useState} from "react";

import SubHeader from "../layout/SubHeader";
import SideMenu from "../layout/SideMenu";
import MainContent from "../layout/MainContent";

import CartFullView from "../views/CartFullView";
import API from "../../API";
import ProductOrderCard from "../cards/ProductOrderCard";
import {Button, DatePicker} from "antd";

export default function Cart() {
    
    const [cartDetails, setCartDetails] = useState<CartFullView | undefined>(undefined);

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
                                <DatePicker placeholder='Start date'/>
                                <DatePicker placeholder='End date'/>
                            </div>
                        </div>
                        <div>
                            <h2>Status:</h2>
                            {
                                
                            }
                            <div style={{padding: '8px'}}>
                                <p style={{margin: 0}}>{`${cartDetails?.ProductOrders.map(productOrder => productOrder.Count).reduce((a, b) => a+b, 0)} unit(s) of ${cartDetails?.ProductOrders.length} product(s) ordered;`}</p>
                                <p style={{margin: 0}}>{`Total price: $${cartDetails?.ProductOrders.map(productOrder => productOrder.Price*productOrder.Count).reduce((a, b) => a+b, 0)};`}</p>
                            </div>
                        </div>
                    </div>
                </SideMenu>
                <MainContent>
                    <div style={{
                        padding: '24px',
                    }}>
                        {
                            cartDetails?.ProductOrders.map(productOrder =>
                                <ProductOrderCard ProductOrderView={productOrder} isInteractive={true} 
                                                  setCartState={setCartDetails}/>)
                        }
                    </div>
                </MainContent>
            </div>
        </>
    );
}
