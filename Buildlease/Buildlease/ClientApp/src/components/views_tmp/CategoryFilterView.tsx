export default interface CategoryFilterView {
  Id: number,
  Name: string,

  UnitName: string | null,
  MinValue: number | null,
  MaxValue: number | null,
  
  Values: string[] | null,
}
