import React from 'react';
import styles from './index.css';
import { formatMessage } from 'umi-plugin-locale';
import { Theme as UWPThemeProvider, getTheme } from "react-uwp/Theme";
import MyComponent from "../components/MyComponent";


export default function () {
    return (
        <div className={styles.normal}>
            <UWPThemeProvider
                theme={getTheme({
                    themeName: "dark", // set custom theme
                    accent: "#0078D7", // set accent color
                    useFluentDesign: true, // sure you want use new fluent design.
                    desktopBackgroundImage: "http://127.0.0.1:8092/staticimages/jennifer-bailey-10753.jpg" // set global desktop background image
                })}>
                <MyComponent />
            </UWPThemeProvider>
        </div>
    );
}
