import { AxiosRequestConfig } from "axios";

import { createApiClient } from "../createApiFactory";

const graphOptions: AxiosRequestConfig = {
  baseURL: process.env.API_URL
}

export const api = createApiClient(graphOptions);