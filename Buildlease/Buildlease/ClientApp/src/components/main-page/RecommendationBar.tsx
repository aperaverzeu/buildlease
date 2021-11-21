import React from "react";

import styles from './main_page.module.css'
import { ChevronRightRounded as Icon} from "@material-ui/icons"
import RecommendationTile from "./RecommendationTile";

interface Props {
    smth:any
}

interface IState {
    option: string
}

export default class RecomendationBar extends React.Component<Props, IState> {
    constructor(props: Props) {
        super(props);

        this.state = {
            option: 'featured'
        };
    }
    
    changeState() {
        if (this.state.option == 'featured') {
            this.setState({option: 'popular'});
        } else {
            this.setState({option: 'featured'});
        }
    }
    
    render () {
        return (
            <div className={styles.recommendationContainer}>
                <RecommendationTile/>
                <RecommendationTile/>
            </div>
        );
    }
}