export default function MainContent(props: any) {
    return(
        <div className='h-100 d-flex flex-grow-1 flex-column' style={{maxWidth: "1000px"}}>
            {props.children}
        </div>
    );
}
