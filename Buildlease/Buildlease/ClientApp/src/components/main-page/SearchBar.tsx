import React from "react";
import { NavMenu } from '../layout/NavMenu';

import styles from './main_page.module.css'
import { SearchRounded as SearchIcon} from "@material-ui/icons"

import { Input } from 'antd';

interface Props {
    onSearch: (text_или_query_или_типа_того: string) => void
}

export default function SearchBar(props: Props) {
    return (
        <Input.Search
            style={{width: '50%'}} // todo: to be changed somehow to look fine on different screens
            placeholder="I'm looking for..."
            allowClear
            enterButton="Search"
            size="large" // todo: to be changed to 48px of height somehow
            onSearch={props.onSearch}
        />
    );
}
