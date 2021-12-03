import SubHeader from "../../layout/SubHeader";
import MainContent from "../../layout/MainContent";

export default function AdminProduct() {
    return (
        <>
            <SubHeader>
                <h1>Your Admin Product</h1>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <MainContent>
                    // will be button links to the panels
                </MainContent>
            </div>
        </>
    );
}