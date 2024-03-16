import { SearchBar_Div, SearchBar_Button, SearchBar_Input } from "./style";
import Search from "../../Icons/search"

export default function SearchButton(props) {
    return (
        <SearchBar_Div htmlFor="img">
            Procurar Vídeo
            <Search fill={"#828282"} height={"4vh"} />
            <SearchBar_Input type="file" accept="video/*" id="img" onChange={props.clickAction}/>
        </SearchBar_Div>
    );
  }
  