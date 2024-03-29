import React, { useState } from 'react';
import axios from 'axios';
import Header from '../Header/Header';
import { authAction } from "../Store/index";
import { useSelector, useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
function LoginForm() {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    username: '',
    password: '',
  });
  const dispatch = useDispatch();
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({ ...prevData, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if(formData.username == '' || formData.password == ''){
      alert('Any field can not emapty');
    }
    try {
      const response = await axios.post('https://localhost:44320/api/account/login', formData);
      dispatch(authAction.login());
      const { userId, isAdmin, token, name } = await response.data;
      
      try {
        localStorage.removeItem("userId")
        localStorage.removeItem("isAdmin")
        localStorage.removeItem("token")
        localStorage.removeItem("name")
      } catch (error) {
        console.log(error);
      }

      localStorage.setItem('userId', userId);
      localStorage.setItem('isAdmin', isAdmin);
      localStorage.setItem('token', token);
      localStorage.setItem('name', name)
      navigate('/')
    } catch (error) {
      console.error(error);
      alert(error.response.data.message);
      if(error.response.status==404){
        alert('wrong username or password');
        return;
      }
    }

  };

  return (
    <>
      <Header />
      <div className="flex justify-center items-center h-screen bg-blue-500">
        <form className="bg-white shadow-md rounded w-80 px-8 pt-6 pb-8 mb-4" onSubmit={handleSubmit}>
        <h2 className="text-2xl font-bold text-center mb-6">Log In</h2>
        <div className="mb-4">
          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="email">
          Username
          </label>
          <input
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            type="text"
            name="username"
            id="username"
            placeholder="Enter your username"
            value={formData.username}
            onChange={handleChange}
            />
        </div>
        <div className="mb-6">
          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="password">
            Password
          </label>
          <input
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            type="password"
            name="password"
            id="password"
            placeholder="Enter your password"
            value={formData.password}
            onChange={handleChange}
            />
        </div>
        <div className="flex items-center justify-between">
          
          <button
            className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
            type="submit"
            >
            Log In
          </button>
        </div>
        </form>
      </div>
    </>
  );
}

export default LoginForm;
