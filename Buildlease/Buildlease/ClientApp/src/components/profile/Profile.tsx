import {useEffect, useState} from "react";

import SubHeader from "../layout/SubHeader";
import SideMenu from "../layout/SideMenu";
import MainContent from "../layout/MainContent";

import CustomerInfo from "../dtos/CustomerInfo";

import API from "../../API";

import {Input} from "antd";
import styles from '../gen_page.module.css';
import AddressCard from "../cards/AddressCard";

interface FieldHeadProps {
    fieldName: string,
    preWidthPx: number,
}

export function FieldHead({fieldName, preWidthPx}: FieldHeadProps) {
    return(
        <div style={{
            width: `${preWidthPx}px`,
        }}>
            {fieldName}
        </div>
    );
}

interface ImageNameLinkProps {
    newData: any,
    setNewData: any,
    nameAttrName: string,
    imagePathAttrName: string,
    imageUrl: string,
    title: string
}

function ImageNameLink({newData, setNewData, nameAttrName, imagePathAttrName, imageUrl, title}: ImageNameLinkProps) {
    return(
        <>
            <div className='d-flex flex-row'>
                <div className={`${styles.boxey}`} style={{
                    height: '128px',
                    width: '128px',
                    backgroundImage: `url(${imageUrl})`,
                    backgroundSize: 'cover',
                    backgroundPosition: 'center',
                }}/>
                <div style={{marginLeft:10}}>
                    <h3> {title} </h3>
                    {
                        newData && <Input defaultValue={newData?.[nameAttrName]}
                                                addonBefore={<FieldHead fieldName='Name' preWidthPx={100}/>}
                                                onChange={data => {
                                                    if (newData) {
                                                        const obj = Object.assign({}, newData);
                                                        obj[nameAttrName] = data.target.value;
                                                        setNewData(obj);
                                                    }
                                                }}
                                                style={{width: 500}}/>
                    }
                    <div style={{marginTop:10}}>
                        {
                            newData && <Input defaultValue={newData?.[imagePathAttrName]}
                                                    addonBefore={<FieldHead fieldName='Image link' preWidthPx={100}/>}
                                                    onChange={data => {
                                                        if (newData) {
                                                            const obj = Object.assign({}, newData);
                                                            obj[imagePathAttrName] = data.target.value;
                                                            setNewData(obj);
                                                        }
                                                    }}
                                                    style={{width: 500}}/>
                        }
                    </div>
                </div>
            </div>
        </>
    )

}

export default function Profile() {
    
    // this is probably not the way to do it but this is a prototype
    const [page, setPage] = useState<string>('general');
    
    const [oldCustomerData, setOldCustomerData] = useState<CustomerInfo | undefined>(undefined);
    const [newCustomerData, setNewCustomerData] = useState<CustomerInfo | undefined>(undefined);
    
    function LoadOldCustomerInfo() {
        API.GetProfileDetails()
            .then(res => {
                setOldCustomerData(JSON.parse(JSON.stringify(res)));
                setNewCustomerData(JSON.parse(JSON.stringify(res)));
            })
    }
    
    useEffect(() => {
        LoadOldCustomerInfo();
    }, []);
    
    function swap(i: number, j: number) {
        console.log(newCustomerData);
        const obj = Object.assign({}, newCustomerData);
        if (obj) {
            const tmp = obj.DeliveryAddresses[i];
            obj.DeliveryAddresses[i] = obj.DeliveryAddresses[j];
            obj.DeliveryAddresses[j] = tmp;
            setNewCustomerData(obj);
            console.log(newCustomerData);
        }
    }
    
    function remove(i: number) {
        const obj = Object.assign({}, newCustomerData);
        if (obj) {
            obj.DeliveryAddresses.splice(i, 1);
            setNewCustomerData(obj);
        }
    }
    
    return(
        <>
            <SubHeader>
                <h1>Your Profile</h1>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <SideMenu>
                    <div style={{
                        padding: '24px',
                    }}>
                        { /* TODO: rewrite the terribleness below to normal markdown */ }
                        <h3 style={{
                            color: page == 'general' ? '#ff6655' : '#000',
                            cursor: 'pointer',
                        }} onClick={() => setPage('general')}>General info</h3>
                        <h3 style={{
                            color: page == 'addresses' ? '#ff6655' : '#000',
                            cursor: 'pointer',
                        }} onClick={() => setPage('addresses')}>Addresses</h3>
                        <h3 style={{
                            color: page == 'payment' ? '#ff6655' : '#000',
                            cursor: 'pointer',
                        }} onClick={() => setPage('payment')}>Payment option</h3>
                    </div>
                </SideMenu>
                <MainContent>
                    <div className='h-100 d-flex flex-column justify-content-between' style={{
                        padding: '24px',
                    }}>
                        <div>
                        {
                            page == 'general' ?
                                // general info
                                <>
                                    {
                                        newCustomerData && <ImageNameLink newData={newCustomerData} setNewData={setNewCustomerData} 
                                                                          nameAttrName={'CompanyName'}
                                                                          imagePathAttrName={'CompanyImagePath'}
                                                                          imageUrl={newCustomerData?.CompanyImagePath} 
                                                                          title={"Company name:"}
                                        />
                                    }
                                    <div style={{marginTop: 10}}>
                                        {
                                            newCustomerData && <ImageNameLink newData={newCustomerData} setNewData={setNewCustomerData}
                                                                              nameAttrName={"RepresentativeName"}
                                                                              imagePathAttrName={'RepresentativeImagePath'}
                                                                              imageUrl={newCustomerData?.RepresentativeImagePath} 
                                                                              title={"Representative name:"}
                                            />
                                        }
                                    </div>
    
                                    <div style={{marginTop: 30}}>
                                        <h3> Legal information </h3>
                                        <div style={{
                                            maxWidth: '600px',
                                        }}>
                                            {
                                                newCustomerData &&
                                                <AddressCard
                                                    AddressInfo={newCustomerData.JuridicalAddress}
                                                    setter={() => {
                                                        const obj = Object.assign({}, newCustomerData);
                                                        setNewCustomerData(obj);
                                                    }}
                                                    isInList={false}/>
                                                                          
                                            }
                                        </div>
                                        <div className='d-flex flex-row'>
                                            {newCustomerData && <Input defaultValue={newCustomerData?.ContactInfo}
                                                                       addonBefore={<FieldHead fieldName='Contact information' preWidthPx={160}/>}
                                                                       onChange={data => {
                                                                           if (newCustomerData) {
                                                                               const obj = Object.assign({}, newCustomerData);
                                                                               obj.ContactInfo = data.target.value;
                                                                               setNewCustomerData(obj);
                                                                           }
                                                                       }}
                                                                       style={{width: 500}}/>
                                            }
                                        </div>
    
                                    </div>
                                </>
                                :
                                page == 'addresses' ?
                                    // addresses
                                    <>
                                        {newCustomerData?.DeliveryAddresses.map((addressInfo, index) =>
                                            <AddressCard key={Math.random()}
                                                         AddressInfo={addressInfo}
                                                         index={index}
                                                         count={newCustomerData?.DeliveryAddresses.length}
                                                         swapper={swap}
                                                         remover={remove}
                                                         isInList={true}
                                                         setter={() => {
                                                             const obj = Object.assign({}, newCustomerData);
                                                             if (obj) {
                                                                 setNewCustomerData(obj);
                                                             }
                                                         }}/>)}
                                    </>
                                    :
                                    // payment info
                                    <>
                                        На payment option, что иронично, бюджет не выделили.
                                    </>
                        }
                        </div>
                        {
                            JSON.stringify(oldCustomerData) !== JSON.stringify(newCustomerData) &&
                            <div>
                                the data is new
                            </div>
                        }
                    </div>
                </MainContent>
            </div>
        </>
    );
}
