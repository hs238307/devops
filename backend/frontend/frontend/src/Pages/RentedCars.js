import { useEffect, useState } from 'react'
import { Link, useNavigate, useLocation } from 'react-router-dom';
import axios from 'axios';
import { authAction } from "../Store/index";
import { useSelector, useDispatch } from "react-redux";
import Header from '../Header/Header';
function RentedCar() {
    const [products, setProducts] = useState([]);
    const [searchInput, setSearchInput] = useState('');
    async function fetchProducts() {
        try {
            const response = await axios.get('https://localhost:44320/api/car/data/rent');
            const allProducts = response.data;
            setProducts(allProducts);
        } catch (error) {
            console.error('Error fetching products:', error);
        }
    }
    useEffect(() => {
        fetchProducts();
    }, [searchInput],[]);






    return (<>
        <Header/>
        <h1 className="text-4xl font-bold text-center text-gray-800 mt-8 mb-4">Rented Car</h1>
        {products.length == 0 && <h1 className="text-4xl font-bold text-center text-gray-800 mt-8 mb-4">There is no rented cars!</h1>}
        <div>
            <div className='w-full h-auto flex justify-start flex-wrap pt-8 px-36'>
                {products.map(product => (
                    <div key={product.id} className="w-80 m-3 bg-slate-100 rounded-xl p-2 dark:bg-slate-800">
                        <img className="w-80 h-56 rounded-md mx-auto" src={"data:image/jpeg;base64," + product.image} alt={product.maker} style={{ objectFit: 'cover' }} />
                        <div className="pt-6 space-y-4">
                            <div className="flex justify-between flex-nowrap flex-row">
                                <Link to={'product/' + product.id}> <p className="text-xl text-blue-500 font-medium">{product.maker}</p></Link>

                            </div>
                            <figcaption className="font-medium">
                                <p className="text-blue-400 mr-1 font-bold">{product.model}</p>
                                <div className="mt-1 justify-center">
                                    <p className="text-red-400 mr-1 font-bold">{product.price}&#8377;/day</p>
                                    <p className="text-red-400 mr-1 font-bold">End Date - {new Date(product.endDate).toLocaleDateString()}</p>

                                </div>
                            </figcaption>
                        </div>
                    </div>
                ))}

            </div>
        </div>
    </>
    );
}

export default RentedCar;