<?php
/**
 * The base configuration for WordPress
 *
 * The wp-config.php creation script uses this file during the installation.
 * You don't have to use the web site, you can copy this file to "wp-config.php"
 * and fill in the values.
 *
 * This file contains the following configurations:
 *
 * * Database settings
 * * Secret keys
 * * Database table prefix
 * * ABSPATH
 *
 * @link https://wordpress.org/support/article/editing-wp-config-php/
 *
 * @package WordPress
 */

// ** Database settings - You can get this info from your web host ** //
/** The name of the database for WordPress */
/**define('WP_HOME', 'https://1671-186-122-88-103.ngrok-free.app/portfolio');*/
/**define('WP_SITEURL', 'https://1671-186-122-88-103.ngrok-free.app/portfolio');*/

define( 'DB_NAME', 'portfolio' );

/** Database username */
define( 'DB_USER', 'root' );

/** Database password */
define( 'DB_PASSWORD', '' );

/** Database hostname */
define( 'DB_HOST', '127.0.0.1:3366' );

/** Database charset to use in creating database tables. */
define( 'DB_CHARSET', 'utf8mb4' );

/** The database collate type. Don't change this if in doubt. */
define( 'DB_COLLATE', '' );

/**#@+
 * Authentication unique keys and salts.
 *
 * Change these to different unique phrases! You can generate these using
 * the {@link https://api.wordpress.org/secret-key/1.1/salt/ WordPress.org secret-key service}.
 *
 * You can change these at any point in time to invalidate all existing cookies.
 * This will force all users to have to log in again.
 *
 * @since 2.6.0
 */
define( 'AUTH_KEY',         'jBsWW`y /Gp2kv;BhLkl=rE1n]94tyx;s16(cyM)wjd~YX(8o1+wWJoV{8R8Wzqn' );
define( 'SECURE_AUTH_KEY',  '<TPhvzeJk=>KuhgBVD#r$V*/,Gdr6FWh|~{zXu:0v??2nEkpHBIeB^%>$5iWHpPF' );
define( 'LOGGED_IN_KEY',    'iWMSq0rb$Bd`dRLq0r[yfFo4n4`RAF4wdTK}JK*nI>A]yTvIu>Z$ux}9~KVh~,L~' );
define( 'NONCE_KEY',        'Hy@TWB[i62KPe_b@_6X552Rw--RsC-Sw qu-{ET|acb=qki^gwh=94r5XVzEL%%[' );
define( 'AUTH_SALT',        'mK5lq,LOnK/*wWhK#xSdQ:od3Gr2vJ40^3&g6%>U%ulYNgQ3>/7=9Vm6i0?wPCM+' );
define( 'SECURE_AUTH_SALT', 'y^5G{?m<HW}f=9&, %*<wlb1jqj]#}L3Rx3>S`{V>9K^~w!&N9Lu#!_-F+1}uezJ' );
define( 'LOGGED_IN_SALT',   'a4)K#!PK-bW;L/qu;CLr([l~D1K$+P9ulBc7HES1E)+0GvWVj2fVfRrs)CIPWDdQ' );
define( 'NONCE_SALT',       'g< :9SE8R!(3l#Hqwr&,R#b-E8t e>=seLX;_h8F=#ol4Bt$D$Io==Y@+N^sMNeV' );

/**#@-*/

/**
 * WordPress database table prefix.
 *
 * You can have multiple installations in one database if you give each
 * a unique prefix. Only numbers, letters, and underscores please!
 */
$table_prefix = 'wp_';

/**
 * For developers: WordPress debugging mode.
 *
 * Change this to true to enable the display of notices during development.
 * It is strongly recommended that plugin and theme developers use WP_DEBUG
 * in their development environments.
 *
 * For information on other constants that can be used for debugging,
 * visit the documentation.
 *
 * @link https://wordpress.org/support/article/debugging-in-wordpress/
 */
define( 'WP_DEBUG', false );

/* Add any custom values between this line and the "stop editing" line. */



/* That's all, stop editing! Happy publishing. */

/** Absolute path to the WordPress directory. */
if ( ! defined( 'ABSPATH' ) ) {
	define( 'ABSPATH', __DIR__ . '/' );
}

/** Sets up WordPress vars and included files. */
require_once ABSPATH . 'wp-settings.php';
