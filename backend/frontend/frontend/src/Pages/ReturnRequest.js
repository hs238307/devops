import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Header from '../Header/Header';
const ReturnRequest = () => {
  const [requests, setRequests] = useState([]);

  useEffect(() => {
    let userId, token;
    try {
      userId = Number(localStorage.getItem("userId"));
      token = String(localStorage.getItem("token"));
    } catch (error) {
      console.log(error)
    }
    let data = JSON.stringify({
      "userId": userId,
      "token": token
    });

    let config = {
      method: 'post',
      maxBodyLength: Infinity,
      url: 'https://localhost:44320/api/car/data/rent/return',
      headers: {
        'Content-Type': 'application/json'
      },
      data: data
    };

    axios.request(config)
      .then((response) => {
        setRequests(response.data);
        console.log(response.data)
      })
      .catch((error) => {
        console.log(error.data);
      });
  }, [])

  const handleApprove = async (id, user) => {
    const userId = Number(localStorage.getItem("userId"));
    const token = String(localStorage.getItem("token"));
    console.log(id,user)
    try {
        const response = await axios.post(`https://localhost:44320/api/car/data/rent/return/approve/${id}`, {
            userId: userId,
            token: token,
            user:user
        });
        const res = response.data;
        alert(res.message);
        window.location.reload();
    } catch (error) {
        console.error('Error fetching product:', error);
        alert(error.response.data.message);
    }
}


  return (
    <>
      <Header />
      <div className="container mx-auto px-4 py-8">
        <h2 className="text-2xl font-bold mb-4">All Return Request</h2>
        <div className="shadow overflow-hidden border-b border-gray-200 sm:rounded-lg">
          <table className="min-w-full divide-y divide-gray-200">
            <thead className="bg-gray-50">
              <tr>
                <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                  Maker
                </th>
                <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                  Car Image
                </th>
                <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                  Model
                </th>
                <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                  End Date
                </th>
                <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                  Duration
                </th>
                <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                  Cost
                </th>
                <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                  User
                </th>
                <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                  Returned?
                </th>
              </tr>
            </thead>
            <tbody className="bg-white divide-y divide-gray-200">
              {requests.reverse().map((data) => (
                <tr key={data.id}>
                  <td className="px-6 py-4 whitespace-nowrap">
                    <div className="text-sm font-medium text-gray-900">{data.maker}</div>
                  </td>
                  <td className="px-6 py-4 whitespace-nowrap">
                    <img src={`data:image/jpeg;base64,${data.image}`} alt={data.maker} className="w-16 h-16 " />
                  </td>

                  <td className="px-6 py-4 whitespace-nowrap">
                    <div className="text-sm text-gray-500">{data.model}</div>
                  </td>
                  <td className="px-6 py-4 whitespace-nowrap">
                    <div className="text-sm text-gray-500">{new Date(data.endDate).toLocaleDateString()}</div>
                  </td>
                  <td className="px-6 py-4 whitespace-nowrap">
                    <div className="text-sm text-gray-500">{data.duration} days</div>
                  </td>
                  <td className="px-6 py-4 whitespace-nowrap">
                    <div className="text-sm text-gray-500">{data.cost}</div>
                  </td>
                  <td className="px-6 py-4 whitespace-nowrap">
                    <div className="text-sm text-gray-500">{data.username}</div>
                  </td>
                  <td className="px-4 py-4 whitespace-nowrap">
                    <button type="submit" onClick={() => handleApprove(data.id, data.userId)} className="px-2 py-2 bg-blue-500 text-white rounded-md">
                      Confirm Return
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </>
  );
};

export default ReturnRequest;
