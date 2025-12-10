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
define( 'DB_NAME', 'pentabite' );

/** Database username */
define( 'DB_USER', 'root' );

/** Database password */
define( 'DB_PASSWORD', '' );

/** Database hostname */
define( 'DB_HOST', 'localhost' );

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
define( 'AUTH_KEY',         'FW:7=oB^=?K}Yoz>M)^O:W|Pw*5pE<H3(NuQxC~.j2Ot/gY rorCTI[peSBt2*V[' );
define( 'SECURE_AUTH_KEY',  'sC2M-9Wnld8XdU2sv8bt C<rw~$t&S,h2_Axw(0YAcy:q}+(ZCFH`8+G]zVG>r,m' );
define( 'LOGGED_IN_KEY',    'agp4rUeZL9c=mD40tV[!f-w+::]]oA?F8>j2rx-e)WS )!7;LHv:p1MCd7l749+F' );
define( 'NONCE_KEY',        'W^V[f,^ 0t{kfX8QUGC@$L8pIA;TiYY}sE.b4{bN@ZgQ11g?g]4`Xk:-!TK_Io (' );
define( 'AUTH_SALT',        'LFmthRi/`rz91BrFv2gaWX0co?8.#J{e(=Brxtyxx!T7PDS,FCCxz&:=|$hUsSb;' );
define( 'SECURE_AUTH_SALT', '>#qMdd s[C; |2Y=K4uvP+q`lij4sf8[vr=.EHWXYF)LthF`6CB+oN9Oy8$YVI6J' );
define( 'LOGGED_IN_SALT',   'z>QaYNPW{HMhk7fTP;9JF8:Csm{};ueA&^DmpnN<q|?O`umr1ogXwT#h%=<`VrMW' );
define( 'NONCE_SALT',       '=|//AD]!5)6mA^nPEk(LM]!|;hvvmOkW*M?yBM.X9B^eIbzCh)U,NE<4q7Hv*UUe' );

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
