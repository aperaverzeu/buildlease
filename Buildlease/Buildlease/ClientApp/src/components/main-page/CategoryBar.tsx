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
            <p className={styles.categoryContainerTitle}>OUR EQUIPMENT CATEGORIES</p>
            <div className={styles.categoryGridContainer}>
                {/*todo: add links*/}
                {props.categories.map(category => (
                    <div className={styles.categoryGridItem}>
                        <Icon className={styles.chevronStyle}/>{category}
                    </div>
                ))}
            </div>
        </div>
    );
}