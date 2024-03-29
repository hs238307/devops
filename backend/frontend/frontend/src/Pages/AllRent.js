import { useEffect, useState } from "react";
import axios from 'axios'
import Header from "../Header/Header";
import { Link } from "react-router-dom";
function AllRent() {
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
            url: 'https://localhost:44320/api/car/data/rent/all',
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

    const [days, setDays] = useState(products.map(() => ''));
    const handleReturnRequest = async (id, user, index) => {
        const userId = Number(localStorage.getItem("userId"));
        const token = String(localStorage.getItem("token"));
        const daysValue = days[index];
        try {
            const response = await axios.put(`https://localhost:44320/api/car/data/rent/update/${id}`, {
                userId: userId,
                token: token,
                user: user,
                days: Number(daysValue)
            });
            const res = response.data;
            alert(res.message);
            window.location.reload();
        } catch (error) {
            console.error('Error fetching product:', error);
            alert(error.response.data.message);
        }
    }

    const handleDeleteReturnRequest = async (id) => {
        const userId = Number(localStorage.getItem("userId"));
        const token = String(localStorage.getItem("token"));
        try {
            const response = await axios.delete(`https://localhost:44320/api/car/data/rent/delete/${id}`, {
                data: {
                    userId: userId,
                    token: token
                }
            });
            const res = response.data;
            alert(res.message);
            window.location.reload();
        } catch (error) {
            console.error('Error fetching product:', error);
            alert(error.response.data.message);
        }
    }

    const handleInputChange = (e, index) => {
        const newDays = [...days];
        newDays[index] = e.target.value;
        setDays(newDays);
    };
    return (<>
        <Header />
        <div className='w-full h-auto flex justify-start flex-col pt-8 px-36'>
            {products.length == 0 && <h1 className="self-center">There is no rented cars!</h1>}
            {products.map((product, index) => (
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
                                <span className="px-2 mb-2">Duration:-{product.duration} days</span>
                                <input
                                    type="number"
                                    name="days"
                                    value={days[index]}
                                    onChange={(e) => handleInputChange(e, index)}
                                    required
                                    className=" px-2 py-1 w-full border rounded-md"
                                    placeholder="Enter days"
                                />
                                <button type="submit" onClick={() => handleReturnRequest(product.id, product.userId, index)} className="mt-2 py-1 bg-blue-500 text-white rounded-md">
                                    Update Days
                                </button>
                                <span className="px-2">Start Date:- {new Date(product.startDate).toLocaleDateString()}</span>
                                <span className="px-2">End Date:- {new Date(product.endDate).toLocaleDateString()}</span>
                            </div>
                        </figcaption>
                        <button type="submit" onClick={() => handleDeleteReturnRequest(product.id)} className="px-4 py-2 bg-red-500 text-white rounded-md">
                            Delete
                        </button>
                    </div>
                </div>
            ))}


        </div>
    </>
    );
}


export default AllRent;