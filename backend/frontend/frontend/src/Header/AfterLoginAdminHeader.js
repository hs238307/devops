import { useEffect, useState } from "react";
import { Link } from "react-router-dom";

function AfterLoginAdminHeader(){
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
        <a className='no-underane w-auto p-2 font-semibold'><Link to='/'>{name}</Link></a>
        <a className='no-underane w-auto p-2 font-semibold'><Link to='/product/add' >Add Car</Link></a>
        <a className='no-underane w-auto p-2 font-semibold'><Link to='/all/agreement'>All Agreements</Link></a>
        <a className='no-underane w-auto p-2 font-semibold'><Link to='/placed'>Return requests</Link></a>
        </div> 
    );
}

export default AfterLoginAdminHeader;