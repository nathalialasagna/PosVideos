import { SearchBar_Div, SearchBar_Button } from "./style";
import Search from "../../Icons/search"

export default function SearchButton() {
    return (
        <SearchBar_Div>
          Procurar Vídeo
          <Search fill={"#828282"} height={"4vh"}/>
        </SearchBar_Div>
    );
  }
  