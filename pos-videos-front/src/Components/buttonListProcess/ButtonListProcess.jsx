import { ListProcess_Button, ListProcess_Icon, ListProcess_Text } from "./style";
import  List  from "../../Icons/list"



export default function ButtonListProcess(props){
    return(
        <ListProcess_Button height={props.height}>
            <ListProcess_Icon>
                <List width={"4vw"}/>
            </ListProcess_Icon>
            <ListProcess_Text>ver Conteúdos Processados</ListProcess_Text>
        </ListProcess_Button>
    )
}