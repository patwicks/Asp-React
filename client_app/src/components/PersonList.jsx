import React, { useState, useEffect } from "react";
import AddModal from "./AddModal";
import PersonTable from "./PersonTable";
import API from "../api/Api";

const PersonList = () => {
  const [open, setOpen] = useState(false);
  const [listData, setListData] = useState([]);

  //fetch data

  useEffect(() => {
    let unsubscribe = false;

    const fetchData = async () => {
      try {
        const res = await API.get("/person");
        if (res.data !== null) {
          setListData(res.data);
        }
      } catch (error) {
        console.log(error.message);
      }
    };

    if (!unsubscribe) {
      fetchData();
    }

    return () => {
      unsubscribe = true;
    };
  }, []);

  return (
    <div className="w-full h-full min-h-screen p-10">
      <div>
        <button
          className="rounded-sm py-2 px-5 bg-blue-500 text-white text-sm"
          onClick={() => setOpen(!open)}
        >
          Add Data
        </button>
      </div>
      <AddModal toggle={open} onClose={() => setOpen(!open)} />
      <PersonTable data={listData} />
    </div>
  );
};

export default PersonList;
