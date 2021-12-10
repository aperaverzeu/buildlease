export default function SideMenu(props: any) {
    return(
        <div className='h-100' style={{width: '220px', minWidth: '200px', marginRight: "1.5rem"}}>
            {props.children}
        </div>
    );
}
