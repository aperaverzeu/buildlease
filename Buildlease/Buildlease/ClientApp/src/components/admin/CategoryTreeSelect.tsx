import { TreeSelect } from "antd";
import Globals from "../../Globals";

interface CategoryTreeNode {
  categoryId: number,
  title: string,
  value: string,
  children: CategoryTreeNode[] | null,
}

interface Props {
  onSelect: (selectedCategoryId: number) => void,
}

export default function CategoryTreeSelect({onSelect}: Props) {

  if (Globals.Categories === undefined) return <></>;

  const root = Globals.Categories[0];

  const categoriesTreeData: CategoryTreeNode[] = [{
    categoryId: root.Id,
    title: root.Name,
    value: '0-' + root.Id,
    children: null,
  }];

  function FillChildren(vertex: CategoryTreeNode): void {
    const children = Globals.Categories!
      .filter(c => c.ParentId === vertex.categoryId)
      .filter(c => c.ParentId !== c.Id);

    vertex.children = children.map(c => {
      const obj: CategoryTreeNode = {
        categoryId: c.Id,
        title: c.Name,
        value: vertex.title + '-' + c.Id,
        children: null,
      };
      FillChildren(obj);
      return obj;
    });
  }

  FillChildren(categoriesTreeData[0])

  return (
    <TreeSelect 
        style={{
          width: "100%"
        }}
      // @ts-ignore
      treeData={categoriesTreeData}
      treeDefaultExpandAll={true}
      onSelect={(value, option) => onSelect(option.categoryId)}
    />
  );
}