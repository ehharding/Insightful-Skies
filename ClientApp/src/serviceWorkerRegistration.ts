interface Config {
  /** Called after the service worker has been registered. */
  onSuccess?: (registration: ServiceWorkerRegistration) => void;
  /** Called after the service worker has been updated. */
  onUpdate?: (registration: ServiceWorkerRegistration) => void;
}

/**
 * Checks if a new service worker is available and, if so, proceeds with its registration and update. If the service
 * worker can't be found or if the file we receive is not a valid JavaScript file, we reload the page to ensure that
 * the user gets the latest content. In the event that the fetch fails due to a network error, we log that fact to the
 * console and proceed with the default offline experience.
 *
 * @param swUrl - The path to the service worker file.
 * @param config - The configuration object.
 */
function checkValidServiceWorker(swUrl: string, config: Config): void {
  fetch(swUrl, { headers: { 'Service-Worker': 'script' } }).then((response: Response): void => {
    // Ensure the service worker exists, and that we really are getting a JS file.
    const contentType: string | null = response.headers.get('content-type');

    if (response.status === 404 || (contentType != null && contentType.indexOf('javascript') === -1)) {
      // No service worker found. Probably a different app. Reload the page.
      navigator.serviceWorker.ready.then((registration): void => {
        registration.unregister().then((): void => {
          window.location.reload();
        });
      });
    } else {
      // Service worker found - Proceed as normal.
      registerValidSW(swUrl, config);
    }
  }).catch((): void => {
    console.log('No internet connection found. App is running in offline mode.');
  });
}

/**
 * Registers the service worker, and calls the callback functions if they are provided. If an error occurs during the
 * registration process, we log that error to the console.
 *
 * @param swUrl - The path to the service worker file.
 * @param config - The configuration object.
 */
function registerValidSW(swUrl: string, config: Config): void {
  navigator.serviceWorker.register(swUrl).then((registration: ServiceWorkerRegistration): void => {
    registration.onupdatefound = () => {
      const installingWorker: ServiceWorker | null = registration.installing;
      if (installingWorker == null) {
        return;
      }

      installingWorker.onstatechange = (): void => {
        if (installingWorker.state === 'installed') {
          if (navigator.serviceWorker.controller) {
            // At this point, the updated precached content has been fetched, but the previous service worker will still
            // serve the older content until all client tabs are closed.
            console.log(
              'New content is available and will be used when all tabs for this page are closed. See ' +
              'https://cra.link/PWA.'
            );

            // Execute the onUpdate callback.
            if (config && config.onUpdate) {
              config.onUpdate(registration);
            }
          } else {
            // At this point, everything has been precached. It's the perfect time to display a "Content is cached for
            // offline use." message.
            console.log('Content is cached for offline use.');

            // Execute the onSuccess callback.
            if (config && config.onSuccess) {
              config.onSuccess(registration);
            }
          }
        }
      };
    };
  }).catch((error): void => {
    console.error('Error during service worker registration:', error);
  });
}

const isLocalhost: boolean = Boolean(
  window.location.hostname === 'localhost' ||
  // [::1] is the IPv6 localhost address.
  window.location.hostname === '[::1]' ||
  // 127.0.0.0/8 are considered localhost for IPv4.
  window.location.hostname.match(/^127(?:\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$/)
);

/**
 * Registers the service worker with the provided configuration object if the app is running in production mode and the
 * browser supports service workers.
 *
 * @param config - The configuration object.
 */
export function register(config: Config): void {
  if (process.env.NODE_ENV === 'production' && 'serviceWorker' in navigator) {
    // The URL constructor is available in all browsers that support service workers.
    const publicUrl: URL = new URL(process.env.PUBLIC_URL as string, window.location.href);
    if (publicUrl.origin !== window.location.origin) {
      // Our service worker won't work if PUBLIC_URL is on a different origin from what our page is served on. This
      // might happen if a CDN is used to serve assets; see https://github.com/facebook/create-react-app/issues/2374.
      return;
    }

    window.addEventListener('load', (): void => {
      const swUrl: string = `${process.env.PUBLIC_URL}/service-worker.js`;

      if (isLocalhost) {
        // This is running on localhost - Let's check if a service worker still exists or not.
        checkValidServiceWorker(swUrl, config);

        // Add some additional logging to localhost, pointing developers to the service worker/PWA documentation.
        navigator.serviceWorker.ready.then((): void => {
          console.log(
            'This web app is being served cache-first by a service worker. To learn more, visit ' +
            'https://cra.link/PWA.'
          );
        });
      } else {
        // This is not running on localhost - Just register the service worker.
        registerValidSW(swUrl, config);
      }
    });
  }
}

/**
 * Unregisters the service worker if the browser supports service workers.
 */
export function unregister(): void {
  if ('serviceWorker' in navigator) {
    navigator.serviceWorker.ready.then((registration: ServiceWorkerRegistration): void => {
      registration.unregister();
    }).catch((error): void => {
      console.error(error.message);
    });
  }
}
