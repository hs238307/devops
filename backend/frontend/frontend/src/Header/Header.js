import { Link, useNavigate } from "react-router-dom";
import AfterLoginHeader from "./AfterLoginHeader";
import { authAction } from "../Store/index";
import { useSelector, useDispatch } from "react-redux";
import { useEffect, useState } from "react";
import AfterLoginAdminHeader from "./AfterLoginAdminHeader";
import axios from "axios";

function Header() {
    const dispatch = useDispatch();
    const [isLoggedIn, setIsLoggedIn] = useState(false)
    const nav = useNavigate();
    const [admin, setAdmin] = useState(false)
    const handleLogout = async () => {
        const userId = Number(localStorage.getItem("userId"));
        const token = String(localStorage.getItem("token"));
        try {
            const response = await axios.post('https://localhost:44320/api/account/signout', {
                data: {
                    userId: userId,
                    token: token
                }
            });
            const res = response.data;
            alert(res.message);
        } catch (error) {
            console.error('Error fetching product:', error);
        }

        dispatch(authAction.logout());
        window.location.href = '/';
    }
    const t = useSelector((state) => state.isLoggedIn);
    useEffect(() => {
        console.log(t);
        try {
            if (localStorage.getItem("isLoggedIn") == "true") {
                setIsLoggedIn(true);
            }
        } catch (error) {

        }
        let a = undefined;
        try {
            a = localStorage.getItem("isAdmin");
        } catch (error) {
            console.log(error)
        }
        if (a != undefined) {
            if (a == "true") {
                setAdmin(true)
            }
        }
    }, [])


    return (
        <div className='w-full h-14 text-center align-middle box-border border-2 border-gray-200  flex justify-between'>
            <div className='self-center text-orange-300 text-3xl ml-4 md:ml font-bold' >
                <Link to='/'>
                𝔊𝔢𝔱 ℭ𝔞𝔯 𝔚𝔦𝔱𝔥𝔬𝔲𝔱 ℌ𝔢𝔞𝔡𝔞𝔠𝔥𝔢🏎️🏎️🏎️
                </Link>
            </div>
            {
                isLoggedIn && (admin ? <AfterLoginAdminHeader /> : <AfterLoginHeader />)
            }
            {
                isLoggedIn ? <button onClick={() => handleLogout()} className='px-4 mr-3 font-semibold rounded-lg shadow-md text-white bg-yellow-500 hover:bg-blue-700'>Logout</button>
                    : <div className='align-center self-center'>
                        <Link to='/login'>  <button className='py-2 px-4 mr-3 font-semibold rounded-lg shadow-md text-white bg-yellow-500 hover:bg-blue-700'>Login</button></Link>
                    </div>
            }


        </div>
    );

}

export default Header;