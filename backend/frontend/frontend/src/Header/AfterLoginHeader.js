import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
function AfterLoginHeader(){
    const [name, setName] = useState('');
    useEffect(()=>{
        try {
            if(localStorage.getItem("name")!=undefined){
                setName(localStorage.getItem("name"));
            }
        } catch (error) {
            console.log(error)
        }
    },[])
    return(
        <div className='flex justify-center self-center'>
        <a className='no-underane w-auto p-2 font-semibold '><Link to='/'>{name}</Link></a>
        <a className='no-underane w-auto p-2 font-semibold'><Link to='/user/rented'>All Rented Cars</Link></a>
        <a className='no-underane w-auto self-center p-2 font-semibold'><Link to='/user/orders'>My Agreements</Link></a>
        {/* <a className='no-underane w-auto p-2 font-semibold'>Help</a> */}
        </div> 
    );
}

export default AfterLoginHeader;