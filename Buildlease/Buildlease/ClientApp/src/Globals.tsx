import CategoryFullView from "./components/views_tmp/CategoryFullView";

interface GlobalsFields {
  Categories: CategoryFullView[] | undefined;
  OnCategoriesLoadedListeners: (() => void)[] | null;
};

const Globals: GlobalsFields = {
  Categories: undefined,
  OnCategoriesLoadedListeners: [],
};

export default Globals;
