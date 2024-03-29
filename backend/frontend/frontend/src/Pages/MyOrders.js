import { useEffect, useState } from "react";
import axios from 'axios'
import Header from "../Header/Header";
import { Link } from "react-router-dom";
function MyOrder() {
    const [products, setProducts] = useState([]);
    async function fetchProducts() {
        let token, userId;
        try {
            token = String(localStorage.getItem('token'));
            userId = Number(localStorage.getItem('userId'));
        } catch (error) {
            console.log(error);
        }
        let data = JSON.stringify({
            "userId": userId,
            "token": token
        });

        let config = {
            method: 'post',
            maxBodyLength: Infinity,
            url: 'https://localhost:44320/api/car/data/rent/user',
            headers: {
                'Content-Type': 'application/json'
            },
            data: data
        };

        axios.request(config)
            .then((response) => {
                setProducts(response.data);
            })
            .catch((error) => {
                console.log(error);
            });

    }

    useEffect(() => {
        fetchProducts()
    }, [])

    const handleReturnRequest = async (id) => {
        const userId = Number(localStorage.getItem("userId"));
        const token = String(localStorage.getItem("token"));
        try {
            const response = await axios.post(`https://localhost:44320/api/car/data/rent/return/${id}`, {
                userId: userId,
                token: token
            });
            const res = response.data;
            alert(res.message);
        } catch (error) {
            console.error('Error fetching product:', error);
            alert(error.response.data.message);
        }
    }

    return (<>
        <Header />
        <div className='w-full h-auto flex justify-start flex-col pt-8 px-36'>
            {products.length == 0 && <h1 className="self-center">There is no rented cars by you!</h1>}
            {products.map(product => (
                <div key={product.id} className="w-full m-3 bg-slate-100 flex justify-around flex-row rounded-xl p-2 dark:bg-slate-800">
                    <img className="rounded-md mx-auto" src={"data:image/jpeg;base64," + product.image} alt={product.maker} />
                    <div className="pt-6 space-y-4">
                        <div className="flex justify-between flex-nowrap flex-row">
                            <Link to={'product/' + product.id}> <p className="text-xl text-blue-500 font-medium">{product.maker}</p></Link>
                        </div>
                        <figcaption className="font-medium">
                            <div>{product.model}</div>
                            <div className="mt-1 flex justify-start">
                                <p className="text-red-400 mr-1 font-bold">Total Cost:- {product.cost}&#8377;</p>
                            </div>
                            <div className="mt-3 flex flex-col justify-between">
                                <span className="px-2">Duration:- {product.duration} days</span>
                                <span className="px-2">Start Date:- {new Date(product.startDate).toLocaleDateString()}</span>
                                <span className="px-2">End Date:- {new Date(product.endDate).toLocaleDateString()}</span>
                            </div>
                        </figcaption>
                        <button type="submit" onClick={()=>handleReturnRequest(product.id)} className="px-4 py-2 bg-blue-500 text-white rounded-md">
                            Request For Return
                        </button>
                    </div>
                </div>
            ))}


        </div>
    </>
    );
}


export default MyOrder;