import CategoryFullView from "./components/Views/CategoryFullView";

interface GlobalsFields {
  Categories: CategoryFullView[] | undefined;
};

const Globals: GlobalsFields = {
  Categories: undefined,
};

export default Globals;