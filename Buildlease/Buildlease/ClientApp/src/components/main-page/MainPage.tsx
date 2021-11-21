import { Component, useState } from 'react';
import { Container } from 'reactstrap';
import Globals from '../../Globals';

import BigHeader from './BigHeader';
import CategoryBar from "./CategoryBar";
import RecomendationBar from "./RecommendationBar";

export class MainPage extends Component {
    data = ['Aerial Work Platforms', 'Compaction', 'Lightning', 'Concrete & Masonry',
            'Plumbing', 'Rail', 'Pumps', 'Saws',
            'Vehicles', 'Trailers', 'Safety', 'Generators',
            'Traffic Management', 'Heating & Cooling', 'Test & Measure', 'Cleaning' 
    ]

    render() {
        return (
            <>
                <BigHeader />

                <Container className='d-flex flex-column justify-content-center'>
                    {Globals.Categories ?
                        <>
                            <CategoryBar categories={this.data}/>
                        </>
                    :
                        <h1>YOU SHOULD NOT SEE THIS, MORTAL ONE!</h1>
                    }
                </Container>
            </>
        );
    }
}
