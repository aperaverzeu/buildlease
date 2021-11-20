import React from "react";
import { NavMenu } from '../layout/NavMenu';

import styles from './main_page.module.css'
import { ChevronRightRounded as Icon} from "@material-ui/icons"

interface Props {
    categories: Array<String>
}

export default function CategoryBar(props: Props) {
    return (
        <div className={styles.categoryContainer}>
            <div style={{marginTop: '40px', marginBottom: '20px'}}>
                <h1>OUR EQUIPMENT CATEGORIES</h1>
            </div>
            <div className={styles.categoryGridContainer}>
                {/*todo: add links*/}
                {props.categories.map(category => (
                    <div className={'d-flex'}>
                        <Icon className={styles.chevronStyle}/>
                        <h5>{category}</h5>
                    </div>
                ))}
            </div>
        </div>
    );
}
