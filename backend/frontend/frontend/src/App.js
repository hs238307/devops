import ProductDetails from './Products/ProductDetails';
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import Home from "./Home/Home";
import LoginForm from "./Forms/LoginForm";
import { Buffer } from "buffer";
import { useEffect, useState } from 'react';
import axios from 'axios'
import AddProduct from './Products/AddProduct';
import AllRent from './Pages/AllRent';
import MyOrder from './Pages/MyOrders';
import ReturnRequest from './Pages/ReturnRequest';
import RentedCar from './Pages/RentedCars';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false)
  const [admin, setAdmin] = useState(false)
  useEffect(() => {
    try {
        if (localStorage.getItem("isLoggedIn") == "true") {
            setIsLoggedIn(true);
        }
    } catch (error) {
      console.log(error);
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
    <Router>
      <Routes>
        <Route exact path='/' Component={Home}/>
        <Route exact path='/login' Component={LoginForm}/>
        <Route exact path='/product/:id' Component={ProductDetails}/>
        <Route exact path='user/orders' Component={MyOrder}/>
        <Route exact path='user/rented' Component={RentedCar}/>
        <Route exact path='product/add' Component={AddProduct}/>
        <Route exact path='product/edit/:id' element={<AddProduct isEdit = {true}/>} />
        <Route exact path='all/agreement' Component={AllRent}/>
        <Route exact path='placed' Component={ReturnRequest}/>
      </Routes>
    </Router>
  );
}

export default App;
