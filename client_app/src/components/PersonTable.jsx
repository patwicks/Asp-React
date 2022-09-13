import React, { useState } from "react";
import API from "../api/Api";
import UpdateModal from "./UpdateModal";

const PersonTable = ({ data: persons }) => {
  const [open, setOpen] = useState(false);

  const deleteData = async (id) => {
    try {
      
      const res = await API.delete(`https://localhost:7225/api/person/1`);

      if (res) {
        console.log(res.data);
      }
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <>
      <table className="w-1/2 mx-auto mt-5">
        <thead>
          <tr>
            <th className="p-2 text-center uppercase bg-blue-400 text-white">
              Id
            </th>
            <th className="p-2 text-center uppercase bg-blue-400 text-white">
              Firstname
            </th>
            <th className="p-2 text-center uppercase bg-blue-400 text-white">
              Middlename
            </th>
            <th className="p-2 text-center uppercase bg-blue-400 text-white">
              Lastname
            </th>
            <th className="p-2 text-center uppercase bg-blue-400 text-white">
              Age
            </th>
            <th className="p-2 text-center uppercase bg-blue-400 text-white">
              Gender
            </th>
            <th className="p-2 text-center uppercase bg-blue-400 text-white">
              Email
            </th>
            <th className="p-2 text-center uppercase bg-blue-400 text-white"></th>
            <th className="p-2 text-center uppercase bg-blue-400 text-white"></th>
          </tr>
        </thead>
        <tbody>
          {persons?.map((data) => (
            <tr key={data.id}>
              <td className="p-2">{data.id}</td>
              <td className="p-2">{data.firstName}</td>
              <td className="p-2">{data.middleName}</td>
              <td className="p-2">{data.lastName}</td>
              <td className="p-2">{data.age}</td>
              <td className="p-2">{data.gender}</td>
              <td className="p-2">{data.email}</td>
              <td className="p-2">
                <button
                  className="text-red-400 hover:opacity-80"
                  onClick={() => {
                    deleteData(data.id);
                  }}
                >
                  Delete
                </button>
              </td>
              <td>
                <button
                  className="text-blue-400 hover:opacity-80"
                  onClick={() => {
                    setOpen(!open);
                  }}
                >
                  Update
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <UpdateModal toggleUpdate={open} onCloseUpdate={() => setOpen(!open)} />
    </>
  );
};

export default PersonTable;
