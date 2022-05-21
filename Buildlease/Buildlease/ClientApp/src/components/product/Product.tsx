import { useEffect, useState } from "react";
import {useParams} from "react-router-dom";

import {Breadcrumb, Button, message, Select} from "antd";
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
    
    const { stringProductOrderId } = useParams<{stringProductOrderId: string}>();
    const productOrderId: number = +stringProductOrderId;
    
    const [productDetails, setProductDetails] = useState<ProductFullView | undefined>(undefined);
    const [formProductCount, setFormProductCount] = useState<number>(1);

    const [language, setLanguage] = useState<string | undefined>(undefined);
    
    function LoadProductDetails() {
        API.GetProductDetails(productId)
            .then(res => {
                setProductDetails(res);
                setLanguage(res.Descriptions[0]?.Language);
            });
    }
    
    function LoadHistoricProductDetails() {
        return;
    }
    
    useEffect(() => {
        if (isHistoric)
            LoadHistoricProductDetails()
        else
            LoadProductDetails();
    }, []);
    
    function addToCart() {
        if (productDetails) {
            message.loading({content: 'Wait for it...', key: productDetails.Id, duration: 0});
            Promise
                .resolve(API.SetProductOrderCount(productDetails.Id, formProductCount))
                .then(() => {
                    message.success({content: 'Successfully added to cart!', key: productDetails.Id});
                });
        }
    }
    
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
            <div className='d-flex flex-row w-100 flex-grow-1'>
                <SideMenu width={360}>
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
                    <div className='d-flex flex-row w-100'>
                        <div className='d-flex flex-grow-1 flex-column' style={{padding: '24px'}}>
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
                                {language &&
                                <Select bordered={false} defaultValue={language} onChange={(newValue) => setLanguage(newValue)}>
                                    {productDetails?.Descriptions.map((item => <Select.Option value={item.Language}>{item.Language}</Select.Option>))}
                                </Select>}
                                <p style={{whiteSpace: 'pre-wrap'}}>{productDetails?.Descriptions.filter(d => d.Language === language)[0]?.Description}</p>
                            </div>
                            <div>
                                <h3>Parameters:</h3>
                                <div className={styles.boxey} style={{
                                    padding: '16px',
                                    paddingBottom: '4px',
                                }}>
                                    {productDetails?.Attributes.map(pair =>
                                        <div className='d-flex flex-row' style={{
                                            marginBottom: '12px',
                                        }}>
                                            <div className='d-flex' style={{flex: 1}}>
                                                <p style={{
                                                    margin: '0px',
                                                }}>{pair.Name}</p>
                                            </div>
                                            <div className='d-flex' style={{flex: 1}}>
                                                <p style={{
                                                    margin: '0px',
                                                    fontWeight: 'lighter',
                                                }}>{pair.Value}</p>
                                            </div>
                                        </div>
                                    )}
                                </div>
                            </div>
                        </div>
                        <SideMenu width={320}>
                            { /* TODO: add logic to the form */ }
                            <div style={{
                                padding: '24px',
                            }}>
                                {
                                    isHistoric ?
                                        <div className={styles.boxey} style={{
                                            padding: '16px',
                                        }}>
                                            <h2 style={{
                                                fontWeight: 'bolder',
                                                margin: '0px',
                                                marginBottom: '8px',
                                            }}>This page is not up to date</h2>
                                            <p style={{
                                                margin: '0px',
                                                marginBottom: '16px',
                                                fontStyle: 'lighter italic',
                                            }}>{`You are viewing the "..." page state as of ...`}</p>
                                            <a>
                                                <p className={styles.link} style={{
                                                    margin: '0px',
                                                    fontStyle: 'italic',
                                                    color: '#ff6655',
                                                }}>Go to the current product page</p>
                                            </a>
                                        </div>
                                        :
                                        <div className={styles.boxey} style={{
                                            padding: '16px',
                                        }}>
                                            <h2>Add to Cart Form:</h2>
                                            {
                                                (productDetails && productDetails?.CountInCart > 0) &&
                                                <p style={{
                                                    fontStyle: 'italic',
                                                }}>{`${productDetails.CountInCart} items already in cart.`}</p>
                                            }
                                            <div className='d-flex flex-row'>
                                                <p>Quantity:</p>
                                                <InputNumber defaultValue={1} min={1} max={productDetails?.AvailableCount}
                                                             onChange={setFormProductCount}
                                                             className='d-flex align-items-center'
                                                             style={{height: '24px'}}/>
                                                <Button type='primary' className='d-flex align-items-center'
                                                        onClick={addToCart}
                                                        style={{height: '24px'}}>Add to Cart</Button>
                                            </div>
                                        </div>
                                }
                            </div>
                        </SideMenu>
                    </div>
                </MainContent>
            </div>
        </>  
    );
    
}
