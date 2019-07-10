import { AuthenticationContext, adalFetch, withAdalLogin } from 'react-adal';
 
export const adalConfig = {
  tenant: '882c3105-af5d-4b6c-8ab1-d0271766eb79',
  clientId: '40124df0-e831-453c-b2ce-03ce6efd3c55',
  endpoints: {
    api: 'bce0a0c8-cfd0-4f28-9cde-fa39c6c8b776',
  },
  cacheLocation: 'localStorage', 
  scope: 'openid', 
  extraQueryParameter: 'prompt=consent'
};
 
export const authContext = new AuthenticationContext(adalConfig);
 
export const adalApiFetch = (fetch, url, options) =>
  adalFetch(authContext, adalConfig.endpoints.api, fetch, url, options);
 
export const withAdalLoginApi = withAdalLogin(authContext, adalConfig.endpoints.api);