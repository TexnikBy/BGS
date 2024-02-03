// @ts-nocheck

export function removeEmptyValues(obj: any) {
    if (Array.isArray(obj)) {
        return obj
            .map(v => (v && typeof v === 'object') ? removeEmptyValues(v) : v)
            .filter(v => !(v === ""));
    } else {
        return Object.entries(obj)
            .map(([k, v]) => [k, v && typeof v === 'object' ? removeEmptyValues(v) : v])
            .reduce((a, [k, v]) => (v === "" ? a : (a[k]=v, a)), {});
    }
}