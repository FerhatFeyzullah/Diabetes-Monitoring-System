import { useSelector } from "react-redux";
import "./App.css";
import Loading from "./components/Loading";
import RouterConfig from "./route/RouterConfig";

function App() {
  return (
    <div>
      <RouterConfig />
    </div>
  );
}

export default App;
