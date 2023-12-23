import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import resourcesToBackend from "i18next-resources-to-backend";

async function importLocales(language: string, ns: string) {
    return import(`./app/assets/locales/${language}/${ns}.json`);
}

i18n.use(initReactI18next)
    .use(resourcesToBackend((language: string, ns: string) => importLocales(language, ns)))
    .init({
        debug: true,
        lng: "en",
        fallbackLng: "en",

        interpolation: {
            escapeValue: false,
        }
    });

export default i18n;