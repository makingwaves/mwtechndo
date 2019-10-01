import { AxiosRequestConfig } from "axios";

import { createApiClient } from "../createApiFactory";

const graphOptions: AxiosRequestConfig = {
  baseURL: process.env.GRAPH_API_URL
}

export const api = createApiClient(graphOptions);