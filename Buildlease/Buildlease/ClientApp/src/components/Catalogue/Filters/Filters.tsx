import AttributeFilter from '../Request/AttributeFilter';
import CategoryFilterView from '../../Views/CategoryFilterView';
import Item from './Item';

interface FiltersProps {
  filtersInfo: CategoryFilterView[],
  filtration: AttributeFilter[],
  setFiltration: (_: AttributeFilter[]) => void,
}

export default function Filters({filtersInfo, filtration, setFiltration}: FiltersProps) {

  return (
    <div 
      style={{
        display: 'flex',
        flexDirection: 'column',
      }}
    >
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
