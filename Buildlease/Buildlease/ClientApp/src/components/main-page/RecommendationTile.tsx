import React from "react";
import { NavMenu } from '../layout/NavMenu';

import styles from './main_page.module.css'
import { ChevronRightRounded as Icon} from "@material-ui/icons"

interface Props {
    // link: string
}

export default function RecommendationTile(props: Props) {
    return (
        <div className={styles.recommendationTile}>
            * Picture with link there *
        </div>
    );
}