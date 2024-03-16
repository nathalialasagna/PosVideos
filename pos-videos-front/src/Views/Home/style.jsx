import styled from "styled-components";
import { Colors } from "../../Colors";


export const HomeBase = styled.div`
    background-color: ${Colors.base.backgoundColor};
    min-height: 100vh;
    max-height: 100vh;
    max-width: 100vw;
    min-width: 100vw;
    margin: 0;
    display: flex;
    align-items: center;
    justify-content: center;
`


export const HomeBase_div = styled.div`
    display: flex;
    flex-direction: column;
    background-color: ${Colors.base.backgoundColor};
    margin: 0;
    justify-content: space-between;
    gap: 10vh;
    max-width: 90vw;
    min-width: 90vw;
`

export const LogoDescription_div = styled.div`
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    gap: 10vw;
    color: ${Colors.base.fontColor};
    font-size: 0.8em;
    text-align: justify; 
    font-weight: 200;
`

export const HomeBaseTop_Div = styled.div`
    align-items: end;
    display: flex;
    justify-content: flex-end;
    margin: 0;
`

export const HomeBaseMiddle_Div = styled.div`
    margin: 0;
    align-items: end;
    display: flex;
    flex-direction: column;
    gap: 5vw;
    align-items: center;
`

export const HomeBaseBottom_Div = styled.div`
    margin: 0;
    display: flex;
    align-items: Center;
    justify-content: center;
`


