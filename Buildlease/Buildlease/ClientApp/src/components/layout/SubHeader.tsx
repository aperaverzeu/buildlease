import styles from './layout.module.css';

export default function SubHeader(props: any) {
    return (
        <div className={`d-flex justify-content-between align-items-center ${styles.wideBar}`} style={{
            paddingLeft: '24px',
            paddingRight: '24px',
        }}>
            {props.children}
        </div>
    );
}
