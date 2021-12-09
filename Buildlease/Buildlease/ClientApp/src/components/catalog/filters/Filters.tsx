import AttributeFilter from '../requests/AttributeFilter';
import CategoryFilterView from '../../views/CategoryFilterView';
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
      {filtersInfo
          .filter(filter => filter.Values || (typeof filter.MinValue == "number" && typeof filter.MaxValue == "number") || filter.Id == 0) // the last one for the price filter
          .map(filter => {
        if (filter.Values && (filter.UnitName || typeof filter.MinValue == 'number' || typeof filter.MaxValue == 'number')) throw 'Undefined multi type filter';
        if (!filter.Values && !(filter.UnitName && typeof filter.MinValue == "number" && typeof filter.MaxValue == 'number') && filter.Id != 0) throw 'Undefined none type filter';
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
