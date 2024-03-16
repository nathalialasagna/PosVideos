import styled from "styled-components";
import { Colors } from "../../Colors";

export const SearchBar_Input = styled.input`
	font-size: 1em;
	outline: none;
	width: 100%;
	background: ${Colors.base.InputColor} ;
	color: ${Colors.decorative.blueDark};
	border: 0px;

	&::placeholder {
		color: rgba(0,0,0,0.50);
	}

`

export const SearchBar_Div = styled.div`
	display: flex;
	align-items: center;
	position: relative;
	max-width: 100%;

	font-size: 1em;
	padding: 1.3vh 4vw;
	padding-right: 10px;
	outline: none;
	background: ${Colors.base.InputColor} ;
	color: ${Colors.decorative.blueDark};
	border: 0px;
	border-radius: 90px;
	box-shadow: 3px 3px 2px 0px #E2E2E2;
	transition: .3s ease;
	box-shadow: 3px 3px 2px 0px #E2E2E2;
`
