

export const getLocalStorageItem = (key: string) => {
  const item = window.localStorage.getItem(key);
  return item ? JSON.parse(item) : '';
}

export const setLocalStorageItem= (key : string, value: any) => {
  window.localStorage.setItem(key, JSON.stringify(value));
}

export const removeLocalStorageItem= (key : string) => {
  window.localStorage.removeItem(key);
}

