import axios, { AxiosRequestConfig, AxiosInstance, AxiosError } from 'axios';

const getApiOptions = (): AxiosRequestConfig => {
  return {
    headers: {
      Accept: 'application/json',
      'Content-Type': 'application/json',
    },
  };
};

export const createApiClient = (options: AxiosRequestConfig = {}): AxiosInstance => {
  const api = axios.create({ ...getApiOptions(), ...options });

  api.interceptors.response.use(
    response => response.data,
    (error: AxiosError) => {
      return error;
    },
  );

  return api;
};
