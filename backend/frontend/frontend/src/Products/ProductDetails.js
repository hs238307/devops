import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Header from '../Header/Header';
import { useNavigate, useParams } from 'react-router-dom';
import { authAction } from "../Store/index";
import { useSelector, useDispatch } from "react-redux";
function ProductDetails() {
  const [quantity, setQuantity] = useState(1);
  const [isEmapty, setIsEmapty] = useState("");
  const [product, setProduct] = useState(null);
  const [maxQuantity, setMaxQuantity] = useState(1);
  const [isAdmin, setIsAdmin] = useState(false);
  const { id } = useParams();
  const isLoggedIn = useSelector((state) => state.isLoggedIn);
  const [startDays, setStartDays] = useState(new Date().toLocaleDateString());
  const [endDays, setEndDays] = useState();
  const [days, setDays] = useState();
  const handleInputChange = (e) => {
    setDays(e.target.value)
    console.log(e.target.value);
    const currentDate = new Date();
    const fiveDaysLater = new Date(currentDate);
    fiveDaysLater.setDate(currentDate.getDate() + Number(e.target.value));
    const formattedDate = fiveDaysLater.toLocaleDateString();
    setEndDays(formattedDate);
  }


  const nev = useNavigate();

  const dispatch = useDispatch();
  useEffect(() => {
    const fetchProduct = async () => {
      try {
        const response = await axios.get(`https://localhost:44320/api/car/${id}`);
        const productData = response.data;
        setProduct(productData);
        if (productData.quantity == 0) {
          setIsEmapty("Out of stock!");
        }
        setMaxQuantity(productData.quantity);
      } catch (error) {
        console.error('Error fetching product:', error);
      }
    };
    fetchProduct();

    try {
      if (localStorage.getItem("isAdmin") == "true") {
        setIsAdmin(true);
      }
    } catch (error) {
      console.log(error);
    }
    try {
      if (localStorage.getItem("isLoggedIn") == "true") {
        dispatch(authAction.login());
      }
    } catch (error) {
      console.log(error)
    }

  }, [id]);

  if (!product) {
    return <div>Loading...</div>;
  }

  const handleSubmit = async () => {
    if (days <= 0) {
      alert('Days must be positive number');
      return;
    }
    const userId = Number(localStorage.getItem("userId"));
    const token = String(localStorage.getItem("token"));
    try {
      const response = await axios.post(`https://localhost:44320/api/car/add/rental/car/${id}`, {
        userId: userId,
        token: token,
        days: Number(days)
      });
      const res = response.data;
      alert(res.message);
      window.location.href = '/';
    } catch (error) {
      console.error('Error fetching product:', error);
      alert(error.response.data.message);
    }

  }


  return (
    <>
      <Header />
      <div className="w-full bg-slate-100 rounded-xl p-2 dark:bg-slate-800 ">
        <img
          className="rounded-md mx-auto"
          src={"data:image/jpeg;base64," + product.image}
          alt={product.maker}
          width="500px"
          height="500px"
        />
        <div className="pt-6 space-y-4">
          <div>
            <p className="text-xl flex justify-center text-blue-500 font-medium">{product.maker}</p>
          </div>
          <figcaption className="font-medium p-4">
            <div className="flex justify-center">{product.model}</div>
            <div className="mt-1">
              <div className="mt-1 flex justify-center">
                <p className="text-red-400 mr-1 font-bold">{product.price}&#8377;/day</p>
              </div>
              {
                isLoggedIn && !isAdmin &&
              (<div className="items-center ">
                <h1 className='justify-center items-center mr-1 font-xl font-bold'>Rental Agreements</h1>
                <p className=" mr-1 font-bold">Start date of the rental agreement - {startDays}</p>
                <p className=" mr-1 font-bold">End date of the rental agreement - {endDays ? endDays : ''}</p>
                <p className=" mr-1 font-bold">Total rent - {days * product.price}&#8377;/day</p>

                <label className="block text-sm font-medium">
                  Select days:
                  <input
                    type="number"
                    name="days"
                    value={days}
                    onChange={handleInputChange}
                    required
                    className="mt-1 px-3 py-2 w-full border rounded-md"
                  />
                </label>
                <button type="submit" onClick={handleSubmit} className="px-4 mt-2 py-2 bg-blue-500 text-white rounded-md">
                  Accept Agreements
                </button>
              </div>)
              }
              {
                !isLoggedIn && <div className="mt-1 flex justify-center">
                <p className="text-red-400 mr-1 font-bold">Login in to rent car</p>
              </div>
              }
            </div>
          </figcaption>
        </div>
      </div>
    </>
  );
}

export default ProductDetails;
