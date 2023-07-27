// TODO: Convert this file to TypeScript and use the types from @types/http-proxy-middleware.

const { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:13924';

const context = [
  "/api",
];

/**
 * Handles errors from the proxy middleware. Should be used as a callback for the onError option of the proxy
 * middleware upon setup.
 *
 * @param err - The error that occurred.
 * @param req - The request that caused the error.
 * @param resp - The response that was being sent when the error occurred.
 * @param target - The target of the proxy middleware.
 */
const onError = (err, req, resp, target) => {
  console.error(err.message);
}

/**
 * Setup proxy to the ASP.NET Core backend.
 *
 * @param app - An Express app instance.
 */
module.exports = function (app) {
  const appProxy = createProxyMiddleware(context, {
    changeOrigin: true,
    secure: false,
    target: target,
    headers: { Connection: 'Keep-Alive' },
    // Handle errors to prevent the proxy middleware from crashing when the ASP.NET Core webserver is unavailable.
    onError: onError
  });

  app.use(appProxy);
};
