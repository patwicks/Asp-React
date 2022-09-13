import React, { useState } from "react";
import API from "../api/Api";
const AddModal = ({ toggle, onClose }) => {
  const initial = {
    id: 0,
    firstname: "",
    middlename: "",
    lastname: "",
    age: 0,
    gender: "",
    email: "",
  };
  const [data, setData] = useState(initial);

  const handleChange = (event) => {
    const { name, value } = event.target;
    setData({ ...data, [name]: value });
  };

  const handleOnSubmit = async (e) => {
    e.preventDefault();
    try {
      const res = await API.post("/person", data);
      if (res !== null) {
        setData(initial);
      }
    } catch (error) {
      console.error(error.message);
    }
  };
  return (
    <div
      className={`w-full h-full inset-0 justify-center items-center absolute z-50 ${
        toggle === true ? `flex` : "hidden"
      }`}
    >
      <form
        className="flex flex-col bg-[#e6e6e6] p-5 w-96 rounded-md"
        onSubmit={handleOnSubmit}
      >
        <button className="text-xl font-bold" type="button" onClick={onClose}>
          x
        </button>
        <input
          className="form--input"
          type="number"
          name="id"
          placeholder="Id"
          value={data?.id}
          onChange={handleChange}
          required
        />
        <input
          className="form--input"
          type="text"
          name="firstname"
          placeholder="Firstname"
          value={data?.firstname}
          onChange={handleChange}
          required
        />
        <input
          className="form--input"
          type="text"
          name="middlename"
          placeholder="Middlename"
          value={data?.middlename}
          onChange={handleChange}
          required
        />
        <input
          className="form--input"
          type="text"
          name="lastname"
          placeholder="Lastname"
          value={data?.lastname}
          onChange={handleChange}
          required
        />
        <input
          className="form--input"
          type="number"
          name="age"
          placeholder="Age"
          value={data?.age}
          onChange={handleChange}
          required
        />
        <input
          className="form--input"
          type="text"
          name="gender"
          placeholder="Gender"
          value={data?.gender}
          onChange={handleChange}
          required
        />
        <input
          className="form--input"
          type="email"
          name="email"
          placeholder="email"
          value={data?.email}
          onChange={handleChange}
          required
        />
        <button
          className="w-full rounded-md bg-blue-400 py-2 text-white uppercase mt-10"
          type="submit"
        >
          Add
        </button>
      </form>
    </div>
  );
};

export default AddModal;
