import axios from 'axios';

const instance = axios.create({
    baseURL: 'https://localhost:7014/api/',
    withCredentials: true,
});

// 🧠 Her istekten önce token varsa header'a ekle
instance.interceptors.request.use((config) => {

    const token = localStorage.getItem('token');
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

export default instance;