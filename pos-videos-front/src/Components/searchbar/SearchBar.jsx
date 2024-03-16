import { SearchBar_Div, SearchBar_Input } from "./style";
import Search from "../../Icons/search"

export default function SearchBar() {
    return (
        <SearchBar_Div>
          <SearchBar_Input type="text" placeholder="Procurar Video" />
          <Search fill={"#828282"} width={"5vw"}/>
        </SearchBar_Div>
    );
  }
  