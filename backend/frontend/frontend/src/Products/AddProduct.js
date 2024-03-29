import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Header from '../Header/Header';
import { useNavigate, useParams } from 'react-router-dom';

const AddProduct = (props) => {
  const [productData, setProductData] = useState({
    image: null,
    price: '',
    maker: '',
    carModel: '',
  });
  const { id } = useParams();

  const nav = useNavigate();

  useEffect(() => {
    if (props.isEdit) {
      const fetchProduct = async () => {
        try {
          const response = await axios.get(`https://localhost:44320/api/car/${id}`);
          const res = response.data;
          setProductData({
            price: res.price,
            maker: res.maker,
            carModel: res.model,
            image: res.image,
          });
        } catch (error) {
          console.error('Error fetching product:', error);
        }
      };
      fetchProduct();
    }
  }, []);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setProductData((prevProductData) => ({
      ...prevProductData,
      [name]: value,
    }));
  };

  const handleImageChange = (event) => {
    const file = event.target.files[0];
    setProductData((prevProductData) => ({
      ...prevProductData,
      image: file,
    }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      if (!productData.carModel) {
        alert('Category is required.');
        return;
      }
      if (!productData.maker) {
        alert('Available Quantity is required.');
        return;
      }
      if (!productData.image) {
        alert('Image is required.');
        return;
      }
      if (!productData.price) {
        alert('Price is required.');
        return;
      }

      const formData = new FormData();
      formData.append('image', productData.image);
      formData.append('price', productData.price);
      formData.append('maker', productData.maker);
      formData.append('carModel', productData.carModel);
      let token, userId;
      try {
        token = localStorage.getItem('token');
        userId = localStorage.getItem('userId');
      } catch (error) {
        console.log(error);
      }

      formData.append('userId', userId);
      formData.append('token', token);

      let response;
      if (props.isEdit) {
        response = await axios.put(`https://localhost:44320/api/car/edit/${id}`, formData, {
          headers: {
            'Content-Type': 'multipart/form-data',
          },
        });
      } else {
        response = await axios.post('https://localhost:44320/api/car/add', formData, {
          headers: {
            'Content-Type': 'multipart/form-data',
          },
        });
      }
      alert(response.data.message);
      nav('/');
    } catch (error) {
      console.error('Error adding product:', error);
      alert(error.response.data.message);
    }
  };

  return (
    <>
      <Header />
      <h1 className="text-4xl font-bold text-center text-gray-800 mt-8 mb-4">Add Car</h1>
      <div className="max-w-md mx-auto">
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="block text-sm font-medium">
              Image:
              <input
                type="file"
                accept=".jpg,.png"
                onChange={handleImageChange}
                required
                className="mt-1 px-3 py-2 w-full"
              />
            </label>
          </div>
          <div>
            <label className="block text-sm font-medium">
              Rent Price Per Day:
              <input
                type="number"
                name="price"
                value={productData.price}
                onChange={handleInputChange}
                required
                className="mt-1 px-3 py-2 w-full border rounded-md"
              />
            </label>
          </div>
          <div>
            <label className="block text-sm font-medium">
              Maker:
              <input
                type="text"
                name="maker"
                value={productData.maker}
                onChange={handleInputChange}
                className="mt-1 px-3 py-2 w-full border rounded-md"
              />
            </label>
          </div>
          <div>
            <label className="block text-sm font-medium">
              Model:
              <input
                type="text"
                name="carModel"
                value={productData.carModel}
                onChange={handleInputChange}
                className="mt-1 px-3 py-2 w-full border rounded-md"
              />
            </label>
          </div>
          <div>
            <button type="submit" className="px-4 py-2 bg-blue-500 text-white rounded-md">
              Add Car
            </button>
          </div>
        </form>
      </div>
    </>
  );
};

export default AddProduct;
