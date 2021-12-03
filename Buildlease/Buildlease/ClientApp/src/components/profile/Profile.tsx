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

interface FieldHeadProps {
    fieldName: string
}

export function FieldHead({fieldName}: FieldHeadProps) {
    return(
        <div style={{
            width: '160px',
        }}>
            {fieldName}
        </div>
    );
}

interface ICardProps {
    newData: any, 
    setNewData: any,
    editedFieldName: string,
    imageUrl: string, 
    title: string
}

function Card(props: ICardProps) {
    return(
        <>
            <div className='d-flex flex-row'>
                <div className={`${styles.boxey}`} style={{
                    height: '128px',
                    width: '128px',
                    backgroundImage: `url(${props.imageUrl})`,
                    backgroundSize: 'cover',
                    backgroundPosition: 'center',
                }}/>
                <div style={{marginLeft:10}}>
                    <h3> {props.title} </h3>
                    {
                        props.newData && <Input defaultValue={props.newData?.[props.editedFieldName]}
                                                addonBefore={<FieldHead fieldName={props.editedFieldName}/>}
                                                  onChange={data => {
                                                      if (props.newData) {
                                                          const obj = Object.assign({}, props.newData);
                                                          obj[props.editedFieldName] = data.target.value;
                                                          props.setNewData(obj);
                                                      }
                                                  }}
                                                style={{width: 500}}/>
                    }
                    <div style={{marginTop:10}}>
                        {
                            props.newData && <Input defaultValue={props.newData?.CompanyImagePath}
                                                    addonBefore={<FieldHead fieldName="Image link"/>}
                                                      onChange={data => {
                                                          if (props.newData) {
                                                              const obj = Object.assign({}, props.newData);
                                                              obj.CompanyImagePath = data.target.value;
                                                              props.setNewData(obj);
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
    
    function swap(i: number, j: number) {
        console.log(newCustomerData);
        const obj = Object.assign({}, newCustomerData);
        if (obj) {
            const tmp = obj.DeliveryAddresses[i];
            obj.DeliveryAddresses[i] = obj.DeliveryAddresses[j];
            obj.DeliveryAddresses[j] = tmp;
            obj.DeliveryAddresses = [];
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
                                        newCustomerData && <Card newData={newCustomerData} setNewData={setNewCustomerData}
                                                                 editedFieldName={"CompanyName"}
                                                                 imageUrl={newCustomerData?.CompanyImagePath}
                                                                 title={"Company name:"}
                                        />
                                    }
                                    <div style={{marginTop: 10}}>
                                        {
                                            newCustomerData && <Card newData={newCustomerData} setNewData={setNewCustomerData}
                                                                     editedFieldName={"RepresentativeName"}
                                                                     imageUrl={newCustomerData?.RepresentativeImagePath}
                                                                     title={"Representative name:"}
                                            />
                                        }
                                    </div>

                                    <div style={{marginTop: 30}}>
                                        <h3> Legal information </h3>
                                        
                                        <div className='d-flex flex-row'>
                                            {
                                                // newCustomerData && <Input defaultValue={newCustomerData?.JuridicalAddres}
                                                newCustomerData && <Input defaultValue={"TODO"}
                                                                        addonBefore={<FieldHead fieldName='Registered legal address:'/>}
                                                                        onChange={data => {
                                                                            if (newCustomerData) {
                                                                                const obj = Object.assign({}, newCustomerData);
                                                                                // obj[newCustomerData?.JuridicalAddress = data.target.value;
                                                                                setNewCustomerData(obj);
                                                                            }
                                                                        }}
                                                                        style={{width: 500}}/>
                                            }
                                        </div>
                                        <div className='d-flex flex-row'>
                                            {newCustomerData && <Input defaultValue={newCustomerData?.ContactInfo}
                                                                    addonBefore={<FieldHead fieldName='Contact information'/>}
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
                                            <AddressCard AddressInfo={addressInfo}
                                                         index={index}
                                                         count={newCustomerData?.DeliveryAddresses.length}
                                                         swapper={swap}
                                                         remover={remove}/>)}
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
