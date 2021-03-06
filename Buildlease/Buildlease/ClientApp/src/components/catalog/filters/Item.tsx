import { Checkbox, InputNumber, Slider } from 'antd';
import { useEffect, useState } from 'react';
import AttributeFilter from '../requests/AttributeFilter';
import CategoryFilterView from '../../views/CategoryFilterView';

interface ItemProps {
  CategoryFilterView: CategoryFilterView,
  OnFilterChange: (AttributeFilter: AttributeFilter) => void,
}

interface NumberItemProps {
  UnitName: string,
  MinValue: number,
  MaxValue: number,

  OnChange: (MinValue: number, MaxValue: number) => void,
}

interface StringItemProps {
  Values: string[],

  OnChange: (Values: string[]) => void,
}

interface PriceItemProps {
    MaxValue: number,
    
    OnChange: (MaxValue: number) => void,
}

function NumberItem({UnitName, MinValue, MaxValue, OnChange}: NumberItemProps) {
  
  const [valueRange, setValueRange] = useState<[number, number]>([MinValue, MaxValue]);

  useEffect(() => {
    OnChange(...valueRange);
  }, [valueRange]);

  console.log(MinValue, MaxValue, valueRange);

  return (
    <div 
      style={{
        display: 'flex', 
        flexDirection: 'column', 
      }}
    >
      <Slider
        range
        min={MinValue} 
        max={MaxValue} 
        step={(MaxValue - MinValue) / 100}
        defaultValue={valueRange}
        onAfterChange={(value) => setValueRange(value)}
      />
      <div
        style={{
          display: 'flex', 
          flexDirection: 'row', 
          justifyContent: 'space-between',
          flexWrap: 'nowrap',
        }}
      >
        <InputNumber
          min={MinValue} 
          max={MaxValue} 
          value={valueRange[0]} 
          onChange={(newValue) => setValueRange([Math.min(valueRange[1], newValue), valueRange[1]])} />
        <InputNumber
          min={MinValue} 
          max={MaxValue} 
          value={valueRange[1]} 
          onChange={(newValue) => setValueRange([valueRange[0], Math.max(valueRange[0], newValue)])} />
      </div>
    </div>
  );
}

function StringItem({Values, OnChange}: StringItemProps) {

  const [checked, setChecked] = useState<string[]>([]);

  useEffect(() => {
    OnChange(checked);
  }, [checked]);

  return (
    <div>
      <Checkbox.Group
        options={Values}
        value={checked}
        onChange={(list) => setChecked(list.map(item => item.toString()))}
        style={{
          display: 'flex', 
          flexDirection: 'column', 
        }}
      />
    </div>
  );
}

function PriceItem({MaxValue, OnChange}: PriceItemProps) {
    
    const [maxValue, setMaxValue] = useState<number>(MaxValue);
    
    useEffect(() => {
        OnChange(MaxValue);
    }, [maxValue]);
    
    return(
        <div
            style={{
                display: 'flex',
                flexDirection: 'column',
            }}
        >
            <Slider
                max={maxValue}
                step={0.01}
                defaultValue={maxValue}
                onAfterChange={(value) => setMaxValue(value)}
            />
            <InputNumber
                min={0}
                max={MaxValue}
                value={maxValue}
                onChange={(newValue) => setMaxValue(newValue)} />
        </div>
    );
}

export default function Item({CategoryFilterView, OnFilterChange}: ItemProps) {

  return (
    <div
      style={{
        display: 'flex',
        flexDirection: 'row',
        flexWrap: 'nowrap',
        justifyContent: 'space-between',
      }}
    >
      <div>{CategoryFilterView.Name}</div>
      { CategoryFilterView.Values &&
        <StringItem
          Values={CategoryFilterView.Values} 
          OnChange={(Values) => OnFilterChange({
            AttributeId: CategoryFilterView.Id, 
            ValueNumberLowerBound: null,
            ValueNumberUpperBound: null,
            ValueStringAllowed: Values,
          })}
        />
      }
      { (CategoryFilterView.UnitName && typeof CategoryFilterView.MinValue == 'number' && typeof CategoryFilterView.MaxValue == 'number') &&
        <NumberItem 
          UnitName={CategoryFilterView.UnitName} 
          MinValue={CategoryFilterView.MinValue}
          MaxValue={CategoryFilterView.MaxValue}
          OnChange={(MinValue, MaxValue) => OnFilterChange({
            AttributeId: CategoryFilterView.Id, 
            ValueNumberLowerBound: MinValue,
            ValueNumberUpperBound: MaxValue,
            ValueStringAllowed: null,
          })}
        />
      }
      {
          (CategoryFilterView.Id == 0 && typeof CategoryFilterView.MaxValue == 'number') &&
              <PriceItem
                  MaxValue={CategoryFilterView.MaxValue}
                  OnChange={MaxValue => OnFilterChange({
                      AttributeId: CategoryFilterView.Id,
                      ValueNumberLowerBound: null,
                      ValueNumberUpperBound: MaxValue,
                      ValueStringAllowed: null,
                  })}/>
      }
    </div>
  );
}
