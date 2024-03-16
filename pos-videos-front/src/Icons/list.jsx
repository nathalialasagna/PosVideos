
export default function List({width, height, color, ...props}){
    return(
        <div {...props}>
            <svg width={width} height={height} viewBox="0 0 36 36" fill={props} xmlns="http://www.w3.org/2000/svg">
                <path d="M4.5 28.5V25.5H31.5V28.5H4.5ZM4.5 22.5V19.5H31.5V22.5H4.5ZM4.5 16.5V13.5H31.5V16.5H4.5ZM4.5 10.5V7.5H31.5V10.5H4.5Z" fill="black"/>
            </svg>
        </div>
    )
}