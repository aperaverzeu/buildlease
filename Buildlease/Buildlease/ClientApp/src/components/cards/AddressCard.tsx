import AddressInfo from "../dtos/AddressInfo";

import {Input} from "antd";
import styles from '../gen_page.module.css';

interface Props {
    AddressInfo: AddressInfo,
}

export default function AddressCard({AddressInfo}: Props) {
    return(
        <div className={styles.boxey} style={{
            padding: '16px',
            margin: '0px',
            marginBottom: '16px',
        }}>
            <Input addonBefore='Postal code' value={AddressInfo.PostalCode}/>
            <Input addonBefore='City' value={AddressInfo.City}/>
            <Input addonBefore='Street' value={AddressInfo.Street}/>
            <Input addonBefore='Building' value={AddressInfo.Building}/>
            <Input addonBefore='Office' value={AddressInfo.Office}/>
        </div>
    );
}
