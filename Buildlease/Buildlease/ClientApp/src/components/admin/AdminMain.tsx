import SubHeader from "../layout/SubHeader";
import MainContent from "../layout/MainContent";

import {Button, Col, Row} from "antd";

export default function AdminMain() {

    return (
        <>
            <SubHeader>
                <h1>Admin Panel</h1>
            </SubHeader>
            <div className='d-flex flex-row flex-grow-1'>
                <MainContent>
                    <Row style={{
                        display: "flex",
                        flexDirection: "row",
                        alignItems: "center",
                        textAlign: "center",
                        marginTop: "10rem"
                    }}>
                        <Col span={12}>
                            <Button style={{
                                padding: "8rem",
                                fontSize: 30,
                                display: "flex",
                                justifyContent: "center",
                                textAlign: "center",
                                marginRight: "5rem"
                            }} type="primary" size="large" href={`admin/product`}>
                                Manage products
                            </Button>
                        </Col>
                        <Col span={12}>
                            <Button style={{
                                padding: "8rem",
                                fontSize: 30,
                                display: "flex",
                                justifyContent: "center",
                                textAlign: "center",
                                marginLeft: "5rem"
                            }} type="primary" size="large" href={`admin/categories`}>
                                Manage Categories
                            </Button>
                        </Col>
                    </Row>
                </MainContent>
            </div>
        </>
    )
}