import ButtonStartProcess from "../../Components/buttonStartProcess/ButtonStartProcess";
import ButtonListProcess from "../../Components/buttonListProcess/ButtonListProcess"
import Logo from "../../Icons/logo";
import { HomeBase, HomeBaseBottom_Div, HomeBaseMiddle_Div, HomeBaseTop_Div, HomeBase_div, LogoDescription_div } from "./style";
import { Colors } from "../../Colors";
import SearchButton from "../../Components/searchButton/SearchButton";
import { useState } from "react";



export default function Home() {

  const [videoFile, setVideoFile] = useState(null);

  const handleVideoChange = (event) => {
    const file = event.target.files[0];
    setVideoFile(file);
    console.log("o nome do vídeo é: " + file.name);
  };

  return (
    <HomeBase>
      <HomeBase_div>
        
        <HomeBaseMiddle_Div>
          <LogoDescription_div>
            <Logo width={"20vw"} fill={Colors.decorative.blueDark}/>
            <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut in posuere diam, mattis volutpat elit. Etiam risus tellus, tincidunt eu suscipit quis, ultricies non felis. Suspendisse ac feugiat eros, ac sodales dui. Nam feugiat sem non dolor faucibus vestibulum. Integer tincidunt orci ipsum, ac feugiat erat dictum in. Pellentesque vehicula pellentesque lacus, ut eleifend lacus iaculis placerat. Nunc ac accumsan ligula. Sed at scelerisque risus. Vestibulum vestibulum at nunc a lobortis. Ut et leo nisi. In rhoncus suscipit est, in eleifend nulla porttitor ac. Duis porttitor sem nec turpis sodales, ac lacinia neque pellentesque. Fusce iaculis enim ut sapien scelerisque mollis. Vivamus posuere congue orci, sed convallis nisl tincidunt eu.
            </p>
          </LogoDescription_div>
          <SearchButton clickAction={handleVideoChange}/>
        </HomeBaseMiddle_Div>

        <HomeBaseBottom_Div>
          <ButtonStartProcess height={"8vh"}/>
        </HomeBaseBottom_Div>    
      </HomeBase_div>
    </HomeBase>
  );
}