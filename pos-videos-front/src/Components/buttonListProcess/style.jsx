import styled from "styled-components";
import { Colors } from "../../Colors";


export const ListProcess_Button = styled.button`
    display: flex;
    direction: row;
    align-items: center;
    justify-content: space-between;
    min-width: 20vw;
    height: ${props => props.height};
    border: 0px;
    margin: 0;
    padding: 0;
    border-radius: 5px;
    overflow: hidden;
    background-color: ${Colors.decorative.orangeLight};
    box-shadow: 3px 3px 2px 0px #E2E2E2;
`

export const ListProcess_Icon = styled.span`
    background-color: ${Colors.decorative.orangeDark};
    min-width: 20vw;
    display: flex;
    justify-content: center;
    align-content: center;
    align-items: center;
    margin: 0;
    padding: 0;
    min-height: 100%;
`

export const ListProcess_Text = styled.span`
    display: flex;
    justify-content: center;
    align-content: center;
    align-items: center;
    max-height: 100%;
    margin: 0;
    padding: 0 5vw;
    font-weight: 600;
    font-size: 1.4em;
    color: ${Colors.base.fontColor}
`