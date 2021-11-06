import { Component } from 'react';

import BigHeader from './BigHeader';

export class MainPage extends Component {
    // static displayName = MainPage.name;

    render() {
        return (
            <div>
                <BigHeader />

                <h1>Hello, world!</h1>
                <p>This is to be the content of the main page, i.e. "our categories", "popular", and "featured"</p>
            </div>
        );
    }
}
