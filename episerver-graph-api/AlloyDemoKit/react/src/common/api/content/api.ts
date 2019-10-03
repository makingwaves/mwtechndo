import { AxiosRequestConfig } from 'axios';

import { createApiClient } from '../createApiFactory';

const graphOptions: AxiosRequestConfig = {
  baseURL: process.env.REACT_APP_API_URL,
};

export const api = createApiClient(graphOptions);
