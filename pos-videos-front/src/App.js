import { Colors } from "./Colors";
import ButtonListProcess from "./Components/buttonListProcess/ButtonListProcess";
import ButtonStartProcess from "./Components/buttonStartProcess/ButtonStartProcess";
import SearchBar from "./Components/searchbar/SearchBar";
import Logo from "./Icons/logo";


function App() {
  return (
    <div className="App" style={{ backgroundColor: Colors.backgroundColor }}>
      <Logo width={"30vw"}/>
      <SearchBar/>
      <br/>
      <ButtonStartProcess height={"10vh"}/>
      <br />
      <ButtonListProcess height={"6vh"}/>
    </div>
  );
}

export default App;
