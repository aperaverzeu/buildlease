import OrderView from "../views/OrderView";

import LOGIC from "../../LOGIC";
import PATH from "../../PATH";

import styles from '../gen_page.module.css';
import {useEffect, useState} from "react";

interface Props {
    OrderView: OrderView,
    detailsShown: boolean,
}

export default function Item({OrderView, detailsShown}: Props) {
    
    const [showDetails, setShowDetails] = useState<boolean>(false);
    
    useEffect(() => {setShowDetails(detailsShown)}, []);
    
    function switchDetails() {
        setShowDetails(!showDetails);
    }
    
    return(
        <div className={`${styles.boxey} d-flex flex-row justify-content-between align-items-center`} style={{
            minHeight: '160px',
            padding: '16px',
            marginBottom: '16px',
        }}>
            <div>
                <a href={PATH.ToOrder(OrderView.Id)}>
                    <h2 className={styles.link} style={{
                        marginBottom: '8px',
                    }}>{`Order #${OrderView.Id}, placed ${LOGIC.GetUserFriendlyDateRepr(OrderView.OrderAcceptDate)}`}</h2>
                </a>
                <p style={{
                    marginBottom: '8px',
                }}>{`${OrderView?.ProductOrders.map(productOrder => productOrder.Count).reduce((a, b) => a+b, 0)} unit(s) of ${OrderView?.ProductOrders.length} product(s) ordered`}</p>
                {
                    showDetails ?
                        <div className='d-flex flex-column' style={{
                            marginBottom: '8px',
                        }}>
                            {
                                OrderView.ProductOrders.map(productOrderView =>
                                    <div className='d-flex flex-row align-items-center' style={{
                                        marginBottom: '8px',
                                    }}>
                                        <a href={PATH.ToHistoricProduct(productOrderView.ProductOrderId)}>
                                            <div className={`${styles.boxey}`} style={{
                                                height: '32px',
                                                width: '32px',
                                                backgroundImage: `url(${productOrderView?.ImagePath})`,
                                                backgroundSize: 'cover',
                                                backgroundPosition: 'center',
                                                marginRight: '8px',
                                            }}/>
                                        </a>
                                        <a href={PATH.ToHistoricProduct(productOrderView.ProductOrderId)}>
                                            <p className={styles.link} style={{
                                                margin: '0px',
                                                fontSize: '14px',
                                            }}>{(productOrderView.Count > 1) && `(x${productOrderView.Count}) `}{productOrderView.Name}</p>
                                        </a>
                                    </div>
                                )
                            }

                            <p style={{
                                margin: '0px',
                                color: '#ff6655',
                                fontStyle: 'italic',
                                cursor: 'pointer',
                            }} onClick={switchDetails}>Hide details</p>
                        </div>
                        :
                        <div className='d-flex flex-row align-items-center' style={{
                            height: '32px',
                            marginBottom: '8px',
                        }}>
                            {
                                OrderView.ProductOrders.map(productOrderView =>
                                    <a href={PATH.ToHistoricProduct(productOrderView.ProductOrderId)}>
                                        <div className={`${styles.boxey}`} style={{
                                            height: '32px',
                                            width: '32px',
                                            backgroundImage: `url(${productOrderView?.ImagePath})`,
                                            backgroundSize: 'cover',
                                            backgroundPosition: 'center',
                                            marginRight: '8px',
                                        }}/>
                                    </a>
                                )
                            }
                            <p style={{
                                margin: '0px',
                                color: '#ff6655',
                                fontStyle: 'italic',
                                cursor: 'pointer',
                            }} onClick={switchDetails}>Show details</p>
                        </div>
                }
                <h3 style={{
                    fontWeight: 'lighter',
                    margin: '0px',
                }}>{`$${OrderView.Price.toFixed(2)} total`}</h3>
            </div>
            <div className='d-flex flex-row'>
                <h3 style={{
                    fontWeight: 600,
                    margin: '0px',
                    marginRight: '4px',
                }}>Status:</h3>
                <h3 style={{
                    fontWeight: 'lighter',
                    fontStyle: 'italic',
                    margin: '0px',
                }}>{LOGIC.GetStatusString(OrderView.Status)}</h3>
            </div>
        </div>    
    );
}
