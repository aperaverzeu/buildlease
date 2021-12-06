import { TreeSelect } from "antd";
import CategoryFullView from "../views/CategoryFullView";
import Globals from "../../Globals";

interface CategoryTreeNode {
  categoryId: number,
  //key: number,
  title: string,
  value: string,
  children: CategoryTreeNode[] | undefined,
}

interface Props {
  currentId: number,
  onSelect: (selectedCategoryId: number) => void,
}

export default function CategoryTreeSelect({currentId, onSelect}: Props) {

  if (Globals.Categories === undefined) return <></>;

  const root = Globals.Categories[0];

  const categoriesTreeData: CategoryTreeNode[] = [{
    categoryId: root.Id,
    //key: root.Id,
    title: root.Name,
    value: root.Name,
    children: undefined,
  }];

  function FillChildren(vertex: CategoryTreeNode): void {
    
    const children = Globals.Categories!
      .filter(c => c.ParentId === vertex.categoryId)
      .filter(c => c.ParentId !== c.Id);

    vertex.children = children.map(c => {
      const obj: CategoryTreeNode = {
        categoryId: c.Id,
        //key: c.Id,
        title: c.Name,
        value: c.ParentId+'-'+c.Id,
        children: undefined,
      };
      
      FillChildren(obj);
      
      return obj;
    });
  }

  FillChildren(categoriesTreeData[0])

  return (
    <TreeSelect className='w-100'
                defaultValue={currentId} 
                treeData={categoriesTreeData} 
                treeDefaultExpandAll={true} 
                onSelect={(value, option) => onSelect(option.categoryId)}
    />
  );
}
