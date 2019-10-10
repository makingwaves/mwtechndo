export const loadImage = (image: HTMLImageElement, onComplete: () => void, onError?: () => void): void => {
  image.onload = function(): void {
    onComplete();
  };
  image.onerror = function(): void {
    if (typeof onError === 'function') {
      onError();
    }
  };
};
