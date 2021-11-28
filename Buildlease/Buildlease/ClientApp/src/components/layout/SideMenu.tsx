export default function SideMenu(props: any) {
    return(
        <div className='h-100' style={{width: '320px', minWidth: '320px'}}>
            {props.children}
        </div>
    );
}
