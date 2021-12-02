export default function MainContent(props: any) {
    return(
        <div className='h-100 d-flex flex-column flex-grow-1'>
            {props.children}
        </div>
    );
}
