import axios from "axios";
import qs from "qs";

const api = axios.create({
  baseURL: "http://192.168.2.101",
});

export default api;
