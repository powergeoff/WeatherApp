
export const mockNavigatorGeolocation = () => {
  const clearWatchMock = jest.fn();
  const getCurrentPositionMock = jest.fn();
  const watchPositionMock = jest.fn();

  const geolocation = {
    clearWatch: clearWatchMock,
    getCurrentPosition: getCurrentPositionMock,
    watchPosition: watchPositionMock
  };

  global.navigator.geolocation ?? Object.defineProperty(global.navigator, 'geolocation', {
    value: geolocation,
  });

  return { clearWatchMock, getCurrentPositionMock, watchPositionMock };
};