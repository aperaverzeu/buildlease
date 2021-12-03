import {useEffect, useState} from "react";

import SubHeader from "../layout/SubHeader";
import SideMenu from "../layout/SideMenu";
import MainContent from "../layout/MainContent";

import CustomerInfo from "../dtos/CustomerInfo";

import API from "../../API";

import {Input} from "antd";
import styles from '../gen_page.module.css';
import AddressCard from "../cards/AddressCard";

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
        const obj = Object.assign({}, newCustomerData);
        if (obj) {
            const tmp = obj.DeliveryAddresses[i];
            obj.DeliveryAddresses[i] = obj.DeliveryAddresses[j];
            obj.DeliveryAddresses[j] = tmp;
            setNewCustomerData(obj);
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
                                                                                  const obj = Object.assign({}, newCustomerData);
                                                                                  obj.CompanyName = data.target.value;
                                                                                  setNewCustomerData(obj);
                                                                              }
                                                                          }}/> 
                                            }
                                            {
                                                newCustomerData && <Input defaultValue={newCustomerData?.CompanyImagePath} 
                                                                          onChange={data => {
                                                                              if (newCustomerData) {
                                                                                  const obj = Object.assign({}, newCustomerData);
                                                                                  obj.CompanyImagePath = data.target.value;
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
                                        {newCustomerData?.DeliveryAddresses.map((addressInfo, index) =>
                                            <AddressCard key={Math.random()}
                                                         AddressInfo={addressInfo}
                                                         index={index}
                                                         count={newCustomerData?.DeliveryAddresses.length}
                                                         swapper={swap}
                                                         remover={remove}
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
