import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { Root, createRoot } from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import reportWebVitals from './reportWebVitals';

const baseUrl: string | undefined = document.getElementsByTagName('base')[0].getAttribute('href') ?? undefined;
const rootElement: HTMLElement | null = document.getElementById('root');
const root: Root = createRoot(rootElement as HTMLElement);

root.render(
  <BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>
);

serviceWorkerRegistration.register({
  onSuccess: (registration: ServiceWorkerRegistration): void => {
    console.log('Service worker registration successful:', registration);
  },
  onUpdate: (registration: ServiceWorkerRegistration): void => {
    console.log('Service worker update:', registration);
  }
});

// Learn more at https://bit.ly/CRA-vitals.
reportWebVitals(console.log);
