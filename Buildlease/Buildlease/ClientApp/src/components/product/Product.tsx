import { useEffect, useState } from "react";
import {useParams} from "react-router-dom";

import {Breadcrumb, Button} from "antd";
import { InputNumber } from 'antd';

// gen layout
import SubHeader from "../layout/SubHeader";
import SideMenu from "../layout/SideMenu";
import MainContent from "../layout/MainContent";

// views
import ProductFullView from "../views/ProductFullView";

// Rigorich
import PATH from "../../PATH";
import API from "../../API";

import styles from '../gen_page.module.css';
import LOGIC from "../../LOGIC";

interface Props {
    isHistoric: boolean,
}

export default function Product({isHistoric}: Props) {
    
    const { stringProductId } = useParams<{stringProductId: string}>();
    const productId: number = +stringProductId;
    
    const [productDetails, setProductDetails] = useState<ProductFullView | undefined>(undefined);
    
    function LoadProductDetails() {
        API.GetProductDetails(productId)
            .then(res => setProductDetails(res));
    }
    
    useEffect(() => {
        LoadProductDetails();
    }, []);
    
    return(
        <>
            <SubHeader>
                <Breadcrumb>
                    {productDetails?.CategoryPath.map(cat =>
                        <Breadcrumb.Item><a href={PATH.ToCategory(cat.Id)} target='_self'>{cat.Name}</a></Breadcrumb.Item>
                    )}
                    <Breadcrumb.Item><a href={PATH.ToProduct(productId)} target='_self'>{productDetails?.Name}</a></Breadcrumb.Item>
                </Breadcrumb>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <SideMenu>
                    <div style={{
                        padding: '24px',
                    }}>
                        <div className={styles.boxey} style={{
                            width: '272px',
                            height: '272px',
                            backgroundImage: `url(${productDetails?.ImagePath})`,
                            backgroundSize: 'contain',
                        }}/>
                    </div>
                </SideMenu>
                <MainContent>
                    <div className='d-flex flex-row'>
                        <div style={{padding: '24px'}}>
                            <div className='d-flex justify-content-between'>
                                <h2>{productDetails?.Name}</h2>
                                <p style={{
                                    fontSize: '20px',
                                    fontWeight: 'lighter'
                                }}>
                                    {`${productDetails?.AvailableCount}/${productDetails?.TotalCount} available`}
                                </p>
                            </div>
                            <div>
                                <p style={{
                                    fontSize: '28px',
                                    fontWeight: 'lighter',
                                }}>
                                    {`$${productDetails?.Price?.toFixed(2)} per day`}
                                </p>
                            </div>
                            <div style={{
                                marginBottom: '40px',
                            }}>
                                <p>
                                    {LOGIC.GetShortDescription(productDetails?.Attributes)}
                                </p>
                            </div>
                            <div>
                                <h3>Description:</h3>
                                <p style={{whiteSpace: 'pre-wrap'}}>{productDetails?.Description}</p>
                            </div>
                            <div>
                                <h3>Parameters:</h3>
                                <div className={styles.boxey} style={{
                                    padding: '16px',
                                }}>
                                    {productDetails?.Attributes.map(pair =>
                                        <div className='d-flex flex-row'>
                                            <div className='d-flex' style={{flex: 1}}>
                                                <p>{`${pair.Name}:`}</p>
                                            </div>
                                            <div className='d-flex' style={{flex: 1}}>
                                                <p style={{
                                                    fontWeight: 'lighter',
                                                }}>{pair.Value}</p>
                                            </div>
                                        </div>
                                    )}
                                </div>
                            </div>
                        </div>
                        <SideMenu>
                            { /* TODO: add logic to the form */ }
                            <div style={{
                                padding: '24px',
                            }}>
                                <div className={styles.boxey} style={{
                                    padding: '16px',
                                }}>
                                    <h2>Add to Cart Form:</h2>
                                    {
                                        productDetails?.CountInCart && productDetails?.CountInCart > 0 ?
                                        <p style={{
                                            fontStyle: 'italic',
                                        }}>{`${productDetails.CountInCart} items already in cart.`}</p>
                                        : <></>
                                    }
                                    <div className='d-flex flex-row'>
                                        <p>Quantity:</p>
                                        <InputNumber defaultValue={1}/>
                                        <Button type='primary'>Add to Cart</Button>
                                    </div>
                                </div>
                            </div>
                        </SideMenu>
                    </div>
                </MainContent>
            </div>
        </>  
    );
    
}
