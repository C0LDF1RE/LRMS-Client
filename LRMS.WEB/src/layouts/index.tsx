import React from 'react';
import styles from './index.css';

const BasicLayout: React.FC = props => {
    return (
        /* TO DO SOME LAYOUT */
        <div className={styles.normal}>

            {props.children}
        </div>
    );
};

export default BasicLayout;
