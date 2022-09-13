import axios from "axios";

const API = axios.create({
  baseURL: "https://localhost:7225/api",
  headers: {
    Accept: "application/json",
    "Content-type": "application/json; charset=UTF-8",
  },
});

export default API;