import styles from '../gen_page.module.css';
import mainStyles from './main_page.module.css'
import { ChevronRightRounded as Icon} from "@material-ui/icons"
import CategoryFullView from "../views/CategoryFullView";
import PATH from "../../PATH";
import {Redirect} from "react-router-dom";

interface Props {
    categories: CategoryFullView[] | undefined
}

export default function CategoryBar(props: Props) {
    return (
        <div className={mainStyles.categoryContainer}>
            <div style={{marginTop: '40px', marginBottom: '20px'}}>
                <h1>OUR EQUIPMENT CATEGORIES</h1>
            </div>
            <div className={mainStyles.categoryGridContainer}>
                {/*todo: add links*/}
                {props.categories?.filter(c => c.ParentId === 0 && c.Id !== 0).map(category => (
                    <div className={'d-flex flex-row align-items-center'}>
                        <Icon className={mainStyles.chevronStyle}/>
                        <a href={PATH.ToCategory(category.Id)}>
                            <h5 className={styles.link} style={{margin: '0px'}}>
                                {category.Name} 
                            </h5>
                        </a>
                    </div>
                ))}
            </div>
        </div>
    );
}
