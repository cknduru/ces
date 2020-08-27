import React from 'react';
import { Row, Col } from 'antd';
import Header from './Header';

const App: React.FC = () => {
    return (
        <Row gutter={[16, 16]}>
            <Col span={12}>
                <Row>
                    <Header />
                </Row>
            </Col>
        </Row >
    )
}

export default App;