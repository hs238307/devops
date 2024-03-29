import { useEffect, useState } from 'react'
import { Link, useNavigate, useLocation } from 'react-router-dom';
import axios from 'axios';
import { authAction } from "../Store/index";
import { useSelector, useDispatch } from "react-redux";
function Products() {
    const dispatch = useDispatch();
    const [categoryVisiblity, setCategoryVisiblity] = useState('none');
    const [products, setProducts] = useState([]);
    const [productLength, setProductLength] = useState(0);
    const [currentPage, setCurrentPage] = useState(1);
    const [searchInput, setSearchInput] = useState('');
    const [categories, setCategories] = useState([]);
    const isLoggedIn = useSelector((state) => state.isLoggedIn);
    const [admin, setAdmin] = useState(false);
    const productsPerPage = 12;

    const [filteredProducts, setFilteredProducts] = useState([]);
    const [makers, setMakers] = useState([]);
    const [models, setModels] = useState([]);
    const [prices, setPrices] = useState([]);
    const [selectedMaker, setSelectedMaker] = useState('');
    const [selectedModel, setSelectedModel] = useState('');
    const [selectedPrice, setSelectedPrice] = useState('');


    async function fetchProducts() {
        try {
            const response = await axios.get('https://localhost:44320/api/car');
            const allProducts = response.data;
            setProductLength(allProducts.length)
            let filteredProducts = allProducts;
            const uniqueMakers = [...new Set(allProducts.map((product) => product.maker))];
            const uniqueModels = [...new Set(allProducts.map((product) => product.model))];
            const uniquePrices = [...new Set(allProducts.map((product) => product.price))];

            setMakers(uniqueMakers);
            setModels(uniqueModels);
            setPrices(uniquePrices);

            setProducts(filteredProducts);
        } catch (error) {
            console.error('Error fetching products:', error);
        }
    }
    useEffect(() => {
        fetchProducts();
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
    }, [searchInput]);


    useEffect(() => {
        fetchProducts();
    }, []);

    useEffect(() => {
        let filtered = products;

        if (selectedMaker) {
            filtered = filtered.filter((product) => product.maker === selectedMaker);
        }

        if (selectedModel) {
            filtered = filtered.filter((product) => product.model === selectedModel);
        }

        if (selectedPrice) {
            filtered = filtered.filter((product) => product.price <= parseInt(selectedPrice));
        }

        setFilteredProducts(filtered);
    }, [selectedMaker, selectedModel, selectedPrice, products]);


    const handelClearFilter = () =>{
        setSelectedMaker("");
        setSelectedModel("");
        setSelectedPrice("");
    }


    const handleDelete = async (id) => {
        const userId = Number(localStorage.getItem("userId"));
        const token = String(localStorage.getItem("token"));
        console.log(userId, id, token)
        try {
            const response = await axios.delete(`https://localhost:44320/api/car/delete/${id}`, {
                data: {
                    userId: userId,
                    token: token
                }
            });
            const res = response.data;
            alert(res.message);
            window.location.reload();
        } catch (error) {
            console.error('Error fetching products:', error);
            alert(error.response.data.message);
        }
    }


    const indexOfLastProduct = currentPage * productsPerPage;
    const indexOfFirstProduct = indexOfLastProduct - productsPerPage;
    const currentProducts = filteredProducts.slice(indexOfFirstProduct, indexOfLastProduct);
    const paginate = (pageNumber) => {
        setCurrentPage(pageNumber);
    };



    return (
        <div>
            <div className="flex justify-center py-5">

                <select
                    value={selectedMaker}
                    onChange={(e) => setSelectedMaker(e.target.value)}
                    className="block mr-2 w-auto mt-1 p-2 border border-gray-300 bg-white rounded-md shadow-sm focus:ring focus:ring-blue-200 focus:ring-opacity-50 focus:outline-none"
                >
                    <option value="">Filter Maker</option>
                    {makers.map((maker) => (
                        <option key={maker} value={maker}>
                            {maker}
                        </option>
                    ))}
                </select>

                <select
                    value={selectedModel}
                    onChange={(e) => setSelectedModel(e.target.value)}
                    className="block mr-2 w-auto mt-1 p-2 border border-gray-300 bg-white rounded-md shadow-sm focus:ring focus:ring-blue-200 focus:ring-opacity-50 focus:outline-none"
                >
                    <option value="">Filter Model</option>
                    {models.map((model) => (
                        <option key={model} value={model}>
                            {model}
                        </option>
                    ))}
                </select>

                <select
                    value={selectedPrice}
                    onChange={(e) => setSelectedPrice(e.target.value)}
                    className="block w-auto mt-1 p-2 border border-gray-300 bg-white rounded-md shadow-sm focus:ring focus:ring-blue-200 focus:ring-opacity-50 focus:outline-none"
                >
                    <option value="">Filter Price</option>
                    {prices.map((price) => (
                        <option key={price} value={price}>
                            &lt;{price}
                        </option>
                    ))}
                </select>
                {
                    (selectedMaker != "" || selectedModel != "" || selectedPrice != "") &&
                    <button onClick={handelClearFilter} className=" p-2 ml-3 font-semibold rounded-lg shadow-md text-white bg-red-500 hover:bg-red-700">
                        Clear All Filter
                    </button>
                }

            </div>
            {productLength.length == 0 && <h1 className="text-4xl font-bold text-center text-gray-800 mt-8 mb-4">There is no cars available!</h1>}
            <div className='w-full h-auto flex justify-start flex-wrap pt-8 px-36'>
                {currentProducts.map(product => (
                    <div key={product.id} className="w-80 m-3 bg-slate-100 rounded-xl p-2 dark:bg-slate-800">
                        <img className="w-80 h-56 rounded-md mx-auto" src={"data:image/jpeg;base64," + product.image} alt={product.maker} style={{ objectFit: 'cover' }} />
                        <div className="pt-6 space-y-4">
                            <div className="flex justify-between flex-nowrap flex-row">
                                <Link to={'product/' + product.id}> <p className="text-xl text-blue-500 font-medium">{product.maker}</p></Link>

                            </div>
                            <figcaption className="font-medium">
                                <p className="text-blue-400 mr-1 font-bold">{product.model}</p>
                                <div className="mt-1 flex justify-center">
                                    <p className="text-red-400 mr-1 font-bold">{product.price}&#8377;/day</p>
                                </div>
                                <div className="mt-3 flex justify-center">
                                    {
                                        admin ? <><Link to={`/product/edit/${product.id}`}>
                                            <button className="py-2 px-4 mr-3 font-semibold rounded-lg shadow-md text-white bg-blue-500 hover:bg-blue-700">
                                                Edit
                                            </button>
                                        </Link>

                                            <button onClick={() => handleDelete(product.id)} className="py-2 px-4 mr-3 font-semibold rounded-lg shadow-md text-white bg-red-300 hover:bg-red-700">
                                                Delete
                                            </button>
                                        </>
                                            : <Link to={`/product/${product.id}`}>
                                                <button className="py-2 px-4 mr-3 font-semibold rounded-lg shadow-md text-white bg-blue-500 hover:bg-blue-700">
                                                    See Details
                                                </button>
                                            </Link>
                                    }

                                </div>
                            </figcaption>
                        </div>
                    </div>
                ))}

            </div>
            <div className="py-10 flex flex-row justify-center">
                <ul className="inline-flex -space-x-px">
                    <li>
                        <a
                            href="#"
                            className="px-3 py-2 ml-0 leading-tight text-gray-500 bg-white border border-gray-300 rounded-l-lg hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white"
                            onClick={() => paginate(currentPage - 1)}
                            disabled={currentPage === 1}
                        >
                            Previous
                        </a>
                    </li>
                    {Array.from({ length: Math.ceil(products.length / productsPerPage) }, (_, index) => (
                        <li key={index}>
                            <a
                                href="#"
                                className={`px-3 py-2 leading-tight text-gray-500 bg-white border border-gray-300 ${index + 1 === currentPage ? 'bg-blue-50 text-blue-600' : 'hover:bg-gray-100 hover:text-gray-700'
                                    } dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white`}
                                onClick={() => paginate(index + 1)}
                            >
                                {index + 1}
                            </a>
                        </li>
                    ))}
                    <li>
                        <a
                            href="#"
                            className="px-3 py-2 leading-tight text-gray-500 bg-white border border-gray-300 rounded-r-lg hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white"
                            onClick={() => paginate(currentPage + 1)}
                            disabled={currentPage === Math.ceil(products.length / productsPerPage)}
                        >
                            Next
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    );
}

export default Products;