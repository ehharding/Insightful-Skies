import { useEffect, useState } from 'react';

/**
 * Custom hook to debounce a value (e.g., from an input field). This is useful when you want to wait for the user to
 * stop typing before performing an action.
 *
 * @param value - The value to debounce.
 * @param delay - The delay in milliseconds.
 * @returns The debounced value.
 */
const useDebounce = <T>(value: T, delay: number): T => {
  const [debouncedValue, setDebouncedValue] = useState<T>(value);

  useEffect(() => {
    const timer: NodeJS.Timeout = setTimeout((): void => {
      setDebouncedValue(value);
    }, delay);

    return (): void => {
      clearTimeout(timer);
    }
  }, [value, delay]);

  return debouncedValue;
};

export default useDebounce;
