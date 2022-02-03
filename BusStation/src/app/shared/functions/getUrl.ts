export function getUrl<T>(pathBase: string, params: T): string {
    let url = `${pathBase}?`;
    for (let key in params) {
        if (params[key as keyof T]) {
            url = `${url}${key}=${params[key as keyof T]}&`;
        }
    }
    return url;
}
