/// <reference types="react-scripts" />

interface IEnv {
  API_URL: string;
  GRAPH_API_URL: string;
}

declare global {
  namespace NodeJS {
    interface ProcessEnv extends IEnv {}
  }
}
