import AttributeFilter from '../requests/AttributeFilter';
import CategoryFilterView from '../../views/CategoryFilterView';
import Item from './Item';
import { Checkbox, InputNumber, Slider } from 'antd';
import { useEffect, useState } from 'react';

interface FiltersProps {
  filtersInfo: CategoryFilterView[],
  filtration: AttributeFilter[],
  setFiltration: (_: AttributeFilter[]) => void,
  setMaxPrice: (_: number | null) => void,
}

export default function Filters({filtersInfo, filtration, setFiltration, setMaxPrice}: FiltersProps) {

  const priceFilter = filtersInfo.find(f => f.Id === 0 && f.Name === 'Price');
  if (priceFilter === undefined) throw 'There is no price filter';

  const usualFilters = filtersInfo.filter(f => f.Id !== priceFilter.Id);

  usualFilters.forEach(filter => {
    if (filter.Values && (filter.UnitName || filter.MinValue || filter.MaxValue)) throw 'Undefined multi type filter';
    if (!filter.Values && !(filter.UnitName && filter.MinValue && filter.MaxValue)) throw 'Undefined none type filter';
  })

  const [onlyWithPrice, setOnlyWithPrice] = useState<boolean>(false);
  const [priceLimit, setPriceLimit] = useState<number | null>(priceFilter.MaxValue);

  useEffect(() => {
    setMaxPrice(onlyWithPrice ? priceLimit : null);
  }, [priceLimit, onlyWithPrice]);
  
  useEffect(() => {
    setOnlyWithPrice(false);
  }, []);

  return (
    <div 
      style={{
        display: 'flex',
        flexDirection: 'column',
      }}
    >
      {priceFilter.MaxValue && priceLimit &&
      <>
        <Checkbox
          checked={onlyWithPrice}
          onChange={(e) => setOnlyWithPrice(e.target.checked)}
        >
          Only products with known price
        </Checkbox>
        <Slider
          disabled={!onlyWithPrice}
          min={0} 
          max={priceFilter.MaxValue} 
          step={0.01} 
          defaultValue={priceLimit} 
          onAfterChange={(value) => setPriceLimit(value)}
        />
        <InputNumber
          disabled={!onlyWithPrice}
          min={0} 
          max={priceFilter.MaxValue} 
          value={priceLimit} 
          onChange={(value) => setPriceLimit(value)} 
        />
      </>}
      {usualFilters.map(filter => {
        if (filter.Values && (filter.UnitName || filter.MinValue || filter.MaxValue)) throw 'Undefined multi type filter';
        if (!filter.Values && !(filter.UnitName && filter.MinValue && filter.MaxValue)) throw 'Undefined none type filter';
        return <Item 
          key={filter.Id}
          CategoryFilterView={filter} 
          OnFilterChange={(newFilter) => {
            setFiltration(filtration.filter(filter => filter.AttributeId !== newFilter.AttributeId).concat(newFilter));
          }}
        />;
      })}
    </div>
  );
}
