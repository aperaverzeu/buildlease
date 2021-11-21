import { NavMenu } from '../layout/NavMenu';
import SearchBar from './SearchBar';

import styles from './main_page.module.css'

function SearchFunction() {
    alert('wow nothing happened');
}

export default function BigHeader() {
    return (
        <div className={styles.bigHeader}>
            <NavMenu/>
            <div className='d-flex justify-content-center' style={{marginTop: `${80-20}px`}}>
                <SearchBar onSearch={SearchFunction}/>
            </div>
        </div>
    );
}
