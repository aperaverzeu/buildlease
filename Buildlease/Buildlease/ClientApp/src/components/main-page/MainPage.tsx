import { useState } from 'react';
import { Container } from 'reactstrap';
import Globals from '../../Globals';

import BigHeader from './BigHeader';
import CategoryBar from "./CategoryBar";
import RecomendationBar from "./RecommendationBar";

const data = ['Aerial Work Platforms', 'Compaction', 'Lightning', 'Concrete & Masonry',
    'Plumbing', 'Rail', 'Pumps', 'Saws',
    'Vehicles', 'Trailers', 'Safety', 'Generators',
    'Traffic Management', 'Heating & Cooling', 'Test & Measure', 'Cleaning'
]

export default function MainPage() {
    
    const [OK, setOK] = useState<boolean>(Globals.Categories !== undefined);
    if (!OK) Globals.OnCategoriesLoadedListeners!.push(() => setOK(true));

    return (
        <>
            <BigHeader />

            <Container className='d-flex flex-column justify-content-center'>
                {OK ?
                    <>
                        <CategoryBar categories={data}/>
                    </>
                :
                    <h1>YOU SHOULD NOT SEE THIS, MORTAL ONE!</h1>
                }
            </Container>
        </>
    );
}
