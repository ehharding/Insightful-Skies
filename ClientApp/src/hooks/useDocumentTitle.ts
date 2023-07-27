import { useEffect } from 'react';

/**
 * Custom hook to set the document title to a given string.
 *
 * @param title - The title to set.
 */
const useDocumentTitle = (title: string): void => {
  useEffect((): void => {
    document.title = title || "Insightful Skies";
  }, [title]);
}

export default useDocumentTitle;
