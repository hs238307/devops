import Header from "../Header/Header";
import Products from "../Products/Products";
import { useSelector} from "react-redux";
import { useState } from "react";
function Home(){
    return(
        <>
        <Header/>
       <Products/>
       </>
    );
}

export default Home;
