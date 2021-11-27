import CategoryFullView from "./components/views/CategoryFullView";

interface GlobalsFields {
  Categories: CategoryFullView[] | undefined;
  OnCategoriesLoadedListeners: (() => void)[] | null;
};

const Globals: GlobalsFields = {
  Categories: undefined,
  OnCategoriesLoadedListeners: [],
};

export default Globals;
