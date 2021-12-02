import SubHeader from "../layout/SubHeader";
import SideMenu from "../layout/SideMenu";
import MainContent from "../layout/MainContent";

export default function Profile() {
    return(
        <>
            <SubHeader>
                <h1>Your Profile</h1>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <SideMenu>

                </SideMenu>
                <MainContent>

                </MainContent>
            </div>
        </>
    );
}
