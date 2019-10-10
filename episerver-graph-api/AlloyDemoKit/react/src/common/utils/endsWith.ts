export const endsWith = (originalString: string, suffix: string): boolean => {
  return originalString.indexOf(suffix, originalString.length - suffix.length) !== -1;
};
