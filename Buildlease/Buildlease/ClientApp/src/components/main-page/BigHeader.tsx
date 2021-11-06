import { NavMenu } from '../layout/NavMenu';

import styles from './main_page.module.css'

export default function BigHeader() {
    return (
        <div className={styles.bigHeader}>
            <NavMenu/>
        </div>
    );
}
