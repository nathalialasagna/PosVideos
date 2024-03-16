import styled from "styled-components";
import { Colors } from "../../Colors";


export const SearchBar_Div = styled.label`
	display: flex;
	flex-direction: row;
	align-items: center;
	position: relative;
	max-width: 60vw;
	min-width: 60vw;
	gap: 2vw;
	font-size: 1em;
	padding: 1.3vh 2vw;
	outline: none;
	background-color: ${Colors.base.InputColor} ;
	color: ${Colors.decorative.blueDark};
	border: 0px;
	border-radius: 90px;
	box-shadow: 3px 3px 2px 0px #2b2b2b53;
	transition: .3s ease;
	cursor: pointer;
	justify-content: center;

	&:hover{
		background-color: ${Colors.decorative.blueDark};
		color: ${Colors.base.fontColor};
	}
`
export const SearchBar_Input = styled.input`
	display:none
`