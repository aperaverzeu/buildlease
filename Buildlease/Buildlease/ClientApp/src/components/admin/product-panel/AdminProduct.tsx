import SubHeader from "../../layout/SubHeader";
import MainContent from "../../layout/MainContent";
import {useParams} from "react-router-dom";
import {useEffect, useState} from "react";
import ProductFullView from "../../views/ProductFullView";
import API from "../../../API";

export default function AdminProduct() {
    
    const { stringProductId } = useParams<{stringProductId: string}>();
    const productId: number = +stringProductId;

    const [oldProductDetails, setOldProductDetails] = useState<ProductFullView | undefined>(undefined);
    const [newProductDetails, setNewProductDetails] = useState<ProductFullView | undefined>(undefined);

    function LoadProductDetails() {
        API.GetProductDetails(productId)
            .then(res => {
                setOldProductDetails(JSON.parse(JSON.stringify(res)));
                setNewProductDetails(JSON.parse(JSON.stringify(res)));
            });
    }

    useEffect(() => {
        LoadProductDetails();
    }, []);
    
    return (
        <>
            <SubHeader>
                <div>
                    *Category TreeSelect to choose new product category*
                </div>
                <div>
                    *"Apply changes" button (disabled if old is the same as new)*
                </div>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <MainContent>
                    
                </MainContent>
            </div>
        </>
    );
}