import { Component } from 'react';
import { Container } from 'reactstrap';
import Globals from '../../Globals';

import BigHeader from './BigHeader';
import SearchBar from "./SearchBar";
import CategoryBar from "./CategoryBar";
import RecomendationBar from "./RecommendationBar";

function Search() {

}

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

                <Container>
                    {Globals.Categories ?
                        <SearchBar OnClick={Search}/>
                        <CategoryBar categories={this.data}/>
                        <RecomendationBar smth={'lalala'}/>
                    :
                        <h1>YOU SHOULD NOT SEE THIS, MORTAL ONE!</h1>
                    }
                </Container>
            </>
        );
    }
}