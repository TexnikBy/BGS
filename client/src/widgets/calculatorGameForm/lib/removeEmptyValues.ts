// @ts-nocheck

export function removeEmptyValues(obj: any) {
    if (Array.isArray(obj)) {
        return obj
            .map(v => (v && typeof v === 'object') ? removeEmptyValues(v) : v)
            .filter(v => (!(v === "") && !(v != null)));
    } else {
        return Object.entries(obj)
            .map(([k, v]) => [k, v && typeof v === 'object' ? removeEmptyValues(v) : v])
            .reduce((a, [k, v]) => (v == null && v === "" ? a : (a[k]=v, a)), {});
    }
}