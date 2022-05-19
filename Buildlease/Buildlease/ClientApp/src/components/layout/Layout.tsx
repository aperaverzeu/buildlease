import { Container } from 'reactstrap';
import { Header } from './Header';

export default function Layout(props: any) {
    return (
        <>
            <Header />
            <Container className='d-flex flex-column flex-grow-1'>
                {props.children}
            </Container>
        </>
    );
}
