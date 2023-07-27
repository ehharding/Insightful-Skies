import { onCLS, onFID, onFCP, onLCP, onTTFB, ReportCallback } from 'web-vitals';

/**
 * Measures the performance of the web application using the Web Vitals library. The function takes an optional callback
 * function that, when provided as a function, the function will use the onCLS, onFID, onFCP, onLCP, and onTTFB
 * functions to measure the Core Web Vitals of the page. These functions measure the Cumulative Layout Shift (CLS),
 * First Input Delay (FID), First Contentful Paint (FCP), Largest Contentful Paint (LCP), and Time to First Byte (FTTB),
 * respectively. The performance data is then passed to the callback function, which can be used to handle the data in
 * any way desired.
 *
 * @param onPerfEntry - The callback function that will be used to handle the performance data.
 * @returns A promise that resolves when all of the performance data has been handled.
 */
const reportWebVitals = async(onPerfEntry?: ReportCallback): Promise<void> => {
  if (onPerfEntry && onPerfEntry instanceof Function) {
    await Promise.all([
      onCLS(onPerfEntry),
      onFID(onPerfEntry),
      onFCP(onPerfEntry),
      onLCP(onPerfEntry),
      onTTFB(onPerfEntry)
    ]);
  }
};

export default reportWebVitals;
