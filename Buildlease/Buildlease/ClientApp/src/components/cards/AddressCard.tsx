import AddressInfo from "../dtos/AddressInfo";

import {Button, Input} from "antd";
import styles from '../gen_page.module.css';
import {ChevronDown, ChevronUp} from "react-bootstrap-icons";
import {Delete} from "@material-ui/icons";

const inputStyle = {
    marginBottom: '4px',
}

interface FieldHeadProps {
    fieldName: string
}

function FieldHead({fieldName}: FieldHeadProps) {
    return(
        <div style={{
            width: '100px',
        }}>
            {fieldName}
        </div>
    );
}

interface InputSetterProps {
    fieldName: string,
    defValue: string,
    setter: (newValue: string) => void,
}

function InputSetter({fieldName, defValue, setter}: InputSetterProps) {
    return(
        <Input style={inputStyle}
               addonBefore={<FieldHead fieldName={fieldName}/>}
               defaultValue={defValue}
               onChange={(data) => setter(data.target.value)}/>
    )
}

interface Props {
    AddressInfo: AddressInfo,
    index: number,
    count: number,
    swapper: (i: number, j: number) => void,
    remover: (i: number) => void,
    setter: () => void,
}

export default function AddressCard({AddressInfo, index, count, swapper, remover, setter}: Props) {
    return(
        <div className={`${styles.boxey} d-flex flex-row`} style={{
            padding: '16px',
            margin: '0px',
            marginBottom: '16px',
        }}>
            <div className='d-flex flex-column flex-grow-1'>
                <InputSetter fieldName='Postal code' defValue={AddressInfo.PostalCode} setter={(s: string) => { AddressInfo.PostalCode = s }}/>
                <InputSetter fieldName='City' defValue={AddressInfo.City} setter={(s: string) => { AddressInfo.City = s }}/>
                <InputSetter fieldName='Street' defValue={AddressInfo.Street} setter={(s: string) => { AddressInfo.Street = s }}/>
                <InputSetter fieldName='Building' defValue={AddressInfo.Building} setter={(s: string) => { AddressInfo.Building = s }}/>
                <InputSetter fieldName='Office' defValue={AddressInfo.Office} setter={(s: string) => { AddressInfo.Office = s }}/>
                
                <Button type='primary' onClick={() => setter()}>Apply</Button>
            </div>
            <div className='d-flex align-items-center justify-content-end' style={{
                width: '80px',
            }}>
                <div className='h-100 d-flex flex-column justify-content-between'>
                    <Button type='primary' disabled={index == 0} onClick={() => swapper(index, index-1)} style={{
                        width: '64px',
                    }}><ChevronUp/></Button>
                    <Button type='primary'
                            danger
                            className='d-flex justify-content-center align-items-center'
                            onClick={() => remover(index)}>
                        <Delete style={{
                            fontSize: '20px', 
                            color: '#fff',
                        }}/>
                    </Button>
                    <Button type='primary' disabled={index == count-1} onClick={() => swapper(index, index+1)} style={{
                        width: '64px',
                    }}><ChevronDown/></Button>
                </div>
            </div>
        </div>
    );
}
