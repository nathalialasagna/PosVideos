import { StartProcess_Button, StartProcess_Icon, StartProcess_Text } from "./style";
import  Play  from "../../Icons/play"



export default function ButtonStartProcess(props){
    return(
        <StartProcess_Button height={props.height}>
            <StartProcess_Icon>
                <Play height={"4vh"}/>
            </StartProcess_Icon>
            <StartProcess_Text>Iniciar Processamento</StartProcess_Text>
        </StartProcess_Button>
    )
}