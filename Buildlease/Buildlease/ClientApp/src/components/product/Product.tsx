import { useEffect, useState } from "react";
import {useParams} from "react-router-dom";

import {Breadcrumb} from "antd";

// gen layout
import SubHeader from "../layout/SubHeader";
import SideMenu from "../layout/SideMenu";
import MainContent from "../layout/MainContent";

// views
import ProductFullView from "../views/ProductFullView";

// requests
import GetProductDetailsRequest from "./requests/GetProductDetailsRequest";

// Rigorich
import PATH from "../../PATH";
import LOGIC from "../../LOGIC";
import API from "../../API";

export default function Product() {
    
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
    
    console.log(productDetails?.Description);
    
    return(
        <>
            <SubHeader>
                <Breadcrumb>
                    
                </Breadcrumb>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <SideMenu>
                    <img src='https://www.meme-arsenal.com/memes/d076c825ca4c7745b32e6fa9867ff806.jpg'/>
                </SideMenu>
                <MainContent>
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
                                {`$${productDetails?.Price}`}
                            </p>
                        </div>
                        <div>
                            
                        </div>
                        <div>
                            <h3>Description:</h3>
                            <p style={{whiteSpace: 'pre-wrap'}}>{productDetails?.Description}</p>
                        </div>
                        <div>
                            <h3>Parameters:</h3>
                        </div>
                    </div>
                </MainContent>
            </div>
        </>  
    );
    
}
