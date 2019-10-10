import { AxiosError } from 'axios';

export interface AxiosGraphApiError {
  error: {
    code: string;
    message: string;
  };
}

const GENERAL_ERROR = 'Something bad happened';

export const getAxiosError = (e: AxiosError<AxiosGraphApiError>): string => {
  if (e.response && e.response.data && e.response.data.error) {
    const err = e.response.data.error;
    return err.message ? err.message : GENERAL_ERROR;
  }
  return GENERAL_ERROR;
};
