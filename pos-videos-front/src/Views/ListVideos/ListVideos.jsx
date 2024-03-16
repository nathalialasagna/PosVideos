import ButtonStartProcess from "../../Components/buttonStartProcess/ButtonStartProcess";
import Pending from "../../Icons/pending";
import Link from "../../Icons/link";
import Done from "../../Icons/done";
import { ListBase, ListBaseTop_Div,  ListBaseMiddle_Div, List_Table } from "./style";

export default function ListVideos() {
  return (
    <ListBase>
        <ListBaseMiddle_Div>
            <List_Table>
                        <thead>
                    
                            <tr>
                          
                                    <th></th>
                                    <th>Nome</th>
                                    <th>Descricao</th>
                                    <th>Data Criação</th>
                                    <th>Status</th>
                                    <th>Link</th>
                        
                            </tr>
                    
                        </thead>
                
                        <tbody>
                   
                            <tr>
                                <td><Done height={"4vh"}/></td>
                                <td>Golaço</td>
                                <td>FUTEBOL QUARTA SPCF VS CFC</td>
                                <td>24/10/2023</td>
                                <td>Processado</td>
                                <td><Link height={"3vh"}/></td>
                            </tr>
                            <tr>
                                <td><Pending height={"4vh"}/></td>
                                <td>RockInRio</td>
                                <td>Show Ao Vivo - Michael Jackson</td>
                                <td>24/10/2023</td>
                                <td>Em processamento</td>
                                <td></td>
                            </tr>
                        </tbody>
            </List_Table>
        </ListBaseMiddle_Div>
    </ListBase>
  );
}