import styled from "styled-components";
import { Colors } from "../../Colors";


export const ListBase = styled.div`
    background-color: ${Colors.base.backgoundColor};
    min-height: 100vh;
    max-height: 100vh;
    max-width: 100vw;
    min-width: 100vw;
    margin: 0;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: top;
`

export const ListBaseMiddle_Div = styled.div`
    margin: 0;
    align-items: end;
    display: flex;
    flex-direction: column;
    gap: 5vw;
    align-items: center;
`

export const List_Table = styled.table`
    border:none;
    border-collapse:collapse;
    max-width: 80vw;
    min-width: 80vw;
    padding:5px;
    gap: 2vw;
    align-items: center;
    align-content: center;

    & th {
        color: ${Colors.base.fontColor};
        border-bottom: 1px solid ${Colors.base.fontColor};
    }


    & tr {
        border:none;
        padding:5px;
        min-width: 5vw;
    }

    & td {
        border:none;
        padding:5px;
        align-content: center;
    }
`


