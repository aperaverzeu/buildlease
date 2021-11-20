import React from "react";
import { NavMenu } from '../layout/NavMenu';

import styles from './main_page.module.css'
import { SearchRounded as SearchIcon} from "@material-ui/icons"

interface Props {
    OnClick: any
}

export default function SearchBar(props: Props) {
    return (
        <div className={styles.searchContainer}>
            <div className={styles.searchView}>
                <SearchIcon className={styles.searchIcon}/>
                <input className={styles.searchInput}
                    placeholder={"I'm looking for..."}
                />
            </div>
            <button className={styles.searchButton} onClick={props.OnClick}>
                <text className={styles.searchButtonText}> Search </text>
            </button>
        </div>
    );
}