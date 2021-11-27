import AttributeFilter from '../requests/AttributeFilter';
import CategoryFilterView from '../../views_tmp/CategoryFilterView';
import Item from './Item';

interface FiltersProps {
    filtersInfo: CategoryFilterView[],
    filtration: AttributeFilter[],
    setFiltration: (_: AttributeFilter[]) => void,
}

export default function Filters({ filtersInfo, filtration, setFiltration }: FiltersProps) {

    return (
        <div className='d-flex flex-column'>
            {filtersInfo.map(filter => {
                if (filter.Values && (filter.UnitName || filter.MinValue || filter.MaxValue)) throw 'Undefined multi type filter';
                if (!filter.Values && !(filter.UnitName && filter.MinValue && filter.MaxValue)) throw 'Undefined none type filter';
                return <Item
                    key={filter.Id}
                    CategoryFilterView={filter}
                    OnFilterChange={(newFilter) => {
                        setFiltration(filtration.filter(filter => filter.AttributeId != newFilter.AttributeId).concat(newFilter));
                        console.log(filtration);
                    }}
                />;
            })}
        </div>
    );
}
