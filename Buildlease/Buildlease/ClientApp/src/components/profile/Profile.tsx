import {useEffect, useState} from "react";

import SubHeader from "../layout/SubHeader";
import SideMenu from "../layout/SideMenu";
import MainContent from "../layout/MainContent";

import CustomerInfo from "../dtos/CustomerInfo";

import API from "../../API";

import {Input} from "antd";
import styles from '../gen_page.module.css';
import AddressCard from "../cards/AddressCard";

// this is probably not the way to do it but this is a prototype
const subpages = [
    'general',
    'addresses',
    'payment',
];

export default function Profile() {
    
    const [page, setPage] = useState<string>('general');
    
    const [oldCustomerData, setOldCustomerData] = useState<CustomerInfo | undefined>(undefined);
    const [newCustomerData, setNewCustomerData] = useState<CustomerInfo | undefined>(undefined);
    
    function LoadOldCustomerInfo() {
        API.GetProfileDetails()
            .then(res => {
                setOldCustomerData(res);
                setNewCustomerData(res);
            })
    }
    
    useEffect(() => {
        LoadOldCustomerInfo();
    }, []);
    
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
                                    <div className='d-flex flex-row'>
                                        <div className={`${styles.boxey}`} style={{
                                            height: '128px',
                                            width: '128px',
                                            backgroundImage: `url(${newCustomerData?.CompanyImagePath})`,
                                            backgroundSize: 'cover',
                                            backgroundPosition: 'center',
                                        }}/>
                                        <div style={{marginLeft:10}}>
                                            <h3> Company name: </h3>
                                            {
                                                newCustomerData && <Input defaultValue={newCustomerData?.CompanyName} 
                                                                          onChange={data => {
                                                                              if (newCustomerData) {
                                                                                  newCustomerData.CompanyName = data.target.value;
                                                                                  console.log(newCustomerData.CompanyName)}
                                                                          }}/> 
                                            }
                                            {
                                                newCustomerData && <Input defaultValue={newCustomerData?.CompanyImagePath} 
                                                                          onChange={data => {
                                                                              if (newCustomerData) {
                                                                                  const obj = Object.assign({}, newCustomerData);
                                                                                  obj.CompanyImagePath = data.target.value;
                                                                                  console.log(obj.CompanyImagePath);
                                                                                  setNewCustomerData(obj);
                                                                              }
                                                                          }}/>
                                            }
                                        </div>
                                    </div>
                                </>
                                :
                                page == 'addresses' ?
                                    // addresses
                                    <>
                                        {newCustomerData?.DeliveryAddresses.map(addressInfo => <AddressCard AddressInfo={addressInfo}/>)}
                                    </>
                                    :
                                    // payment info
                                    <>
                                        На payment option, что иронично, бюджет не выделили.
                                    </>
                        }
                        </div>
                        {
                            oldCustomerData != newCustomerData &&
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
