import AddressInfo from "../dtos/AddressInfo";

import {Button, Input} from "antd";
import styles from '../gen_page.module.css';
import {ChevronDown, ChevronUp} from "react-bootstrap-icons";

const inputStyle = {
    marginBottom: '4px',
}

interface FieldHeadProps {
    fieldName: string,
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

interface Props {
    AddressInfo: AddressInfo,
}

export default function AddressCard({AddressInfo}: Props) {
    return(
        <div className={`${styles.boxey} d-flex flex-row`} style={{
            padding: '16px',
            margin: '0px',
            marginBottom: '16px',
        }}>
            <div className='d-flex flex-column flex-grow-1'>
                <Input style={inputStyle} addonBefore={<FieldHead fieldName='Postal code'/>} defaultValue={AddressInfo.PostalCode}/>
                <Input style={inputStyle} addonBefore={<FieldHead fieldName='City'/>} defaultValue={AddressInfo.City}/>
                <Input style={inputStyle} addonBefore={<FieldHead fieldName='Street'/>} defaultValue={AddressInfo.Street}/>
                <Input style={inputStyle} addonBefore={<FieldHead fieldName='Building'/>} defaultValue={AddressInfo.Building}/>
                <Input addonBefore={<FieldHead fieldName='Office'/>} defaultValue={AddressInfo.Office}/>
            </div>
            <div className='d-flex align-items-center justify-content-end' style={{
                width: '80px',
            }}>
                <div className='d-flex flex-column'>
                    <Button type='primary' style={{
                        width: '64px',
                        marginBottom: '8px',
                    }}><ChevronUp/></Button>
                    <Button type='primary' style={{
                        width: '64px',
                    }}><ChevronDown/></Button>
                </div>
            </div>
        </div>
    );
}
