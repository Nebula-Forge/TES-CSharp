import React from 'react';
import ReactDOM from 'react-dom/client';
import { GlobalStyle } from './style/GlobalStyle';
import AppRoutes from './routes';

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <AppRoutes />
    <GlobalStyle />
  </React.StrictMode>
)
