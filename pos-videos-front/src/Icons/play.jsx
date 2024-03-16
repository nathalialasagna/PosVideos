
export default function Play({width, height, color, ...props}){
    return(
        <div {...props}>
            <svg width={width} height={height} viewBox="0 0 21 22" fill={props} xmlns="http://www.w3.org/2000/svg">
                <path d="M0 21.3967V0L20.1226 10.6983L0 21.3967ZM3.65865 15.8183L13.2626 10.6983L3.65865 5.57842V15.8183Z" fill="black"/>
            </svg>
        </div>
    )
}