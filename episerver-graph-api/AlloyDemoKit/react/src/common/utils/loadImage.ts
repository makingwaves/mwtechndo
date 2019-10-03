export const loadImage = (image: HTMLImageElement, onComplete: () => void, onError?: () => void): void => {
  image.onload = function() {
    onComplete();
  };
  image.onerror = function() {
    if (typeof onError === 'function') {
      onError();
    }
  };
};
