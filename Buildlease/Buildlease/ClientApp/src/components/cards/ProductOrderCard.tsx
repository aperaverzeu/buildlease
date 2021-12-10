import ProductOrderView from "../views/ProductOrderView";

import styles from '../gen_page.module.css';
import {Breadcrumb, InputNumber, message} from "antd";

import PATH from "../../PATH";
import LOGIC from "../../LOGIC";
import {Delete} from "@material-ui/icons";
import API from "../../API";
import {useState} from "react";
import CartFullView from "../views/CartFullView";

interface Props {
    ProductOrderView: ProductOrderView,
    isInteractive: boolean,
    setCartState: any
}

export default function ProductOrderCard({ProductOrderView, isInteractive, setCartState}: Props) {
    
    function removeFromCart() {
        message.loading({ content: 'Wait for it...', key: ProductOrderView.ProductId, duration: 0 });

        ProductOrderView.ProductId != null &&
        Promise
            .resolve(API.SetProductOrderCount(ProductOrderView.ProductId, 0))
            .then(() => API.GetCartDetails())
            .then(res => setCartState(res))
            .then(() => {
                message.success({ content: 'Done!', key: ProductOrderView.ProductId });
            });
    }
    
    function countChanged(value: number) {
        message.loading({ content: 'Wait for it...', key: ProductOrderView.ProductId, duration: 0 });

        ProductOrderView.ProductId != null && 
        Promise
            .resolve(API.SetProductOrderCount(ProductOrderView.ProductId, value))
            .then(() => API.GetCartDetails())
            .then(res => setCartState(res))
            .then(() => {
                message.success({ content: 'Done!', key: ProductOrderView.ProductId });
            });
    }
    
    return(
        <div className={`${styles.boxey} d-flex`} style={{
            height: '160px',
            padding: '8px',
            marginBottom: '24px',
        }}>
            <a href={isInteractive ? (ProductOrderView.ProductId ? PATH.ToProduct(ProductOrderView.ProductId) : PATH.ToCategory(0) /* even though it shouldn't ever happen */ ) : PATH.ToHistoricProduct(ProductOrderView.ProductOrderId)}>
                <div className={styles.boxey} style={{
                    width: '144px',
                    height: '144px',
                    border: 'none',
                    backgroundImage: `url(${ProductOrderView?.ImagePath})`,
                    backgroundSize: 'cover',
                    backgroundPosition: 'center',
                }}/>
            </a>
            <div style={{
                borderLeft: '1px solid #000',
                marginLeft: '8px',
                marginRight: '8px',
                marginTop: '-8px',
                marginBottom: '-8px',
            }}/>
            <div className='d-flex flex-grow-1 justify-content-between'>
                <div className='d-flex flex-column justify-content-between'>
                    <div>
                        <Breadcrumb>
                            {
                                ProductOrderView?.CategoryPath?.map(
                                    cat => <Breadcrumb.Item><a href={PATH.ToCategory(cat.Id)} target="_self">{cat.Name}</a></Breadcrumb.Item>
                                )
                            }
                        </Breadcrumb>
                        <a href={isInteractive ? (ProductOrderView.ProductId ? PATH.ToProduct(ProductOrderView.ProductId) : PATH.ToCategory(0) /* even though it shouldn't ever happen */ ) : PATH.ToHistoricProduct(ProductOrderView.ProductOrderId)}>
                            <h3 className={styles.link}>{ProductOrderView.Name}</h3>
                        </a>
                        <p style={{fontSize: '14px'}}>{LOGIC.GetShortDescription(ProductOrderView.Attributes)}</p>
                    </div>
                    {
                        ProductOrderView.Price !== null ? <h3 style={{fontWeight: 'lighter'}}>
                            {`$${ProductOrderView.Price.toFixed(2)}
                            ${ProductOrderView.Count > 1 ? ` × ${ProductOrderView.Count} = $
                            ${(ProductOrderView.Price*ProductOrderView.Count).toFixed(2)}` : ``} per day`}
                        </h3> 
                            :
                            <h3 style={{fontWeight: 'lighter'}}> The price is not specified </h3>
                    }
                </div>
                { isInteractive &&
                    <div className='d-flex align-items-center'>
                        <div className='d-flex align-items-center' style={{
                            paddingRight: '24px'
                        }}>
                            <InputNumber defaultValue={ProductOrderView.Count} min={1} onChange={countChanged} style={{
                                height: '32px',
                                width: '60px',
                                marginRight: '24px',
                            }}/>
                            <Delete onClick={removeFromCart} style={{
                                fontSize: '32px',
                                color: '#ff6655',
                                cursor: 'pointer',
                            }}/>
                        </div>
                    </div>
                }
            </div>
        </div>
    );
}
