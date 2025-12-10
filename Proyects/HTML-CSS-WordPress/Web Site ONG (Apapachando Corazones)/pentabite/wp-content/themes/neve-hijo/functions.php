<?php

if ( ! function_exists( 'neve_child_load_css' ) ):
	/**
	 * Load CSS file.
	 */
	function neve_child_load_css() {
		wp_enqueue_style( 'neve-child-style', trailingslashit( get_stylesheet_directory_uri() ) . 'style.css', array( 'neve-style' ), NEVE_VERSION );
	}
endif;
add_action( 'wp_enqueue_scripts', 'neve_child_load_css', 20 );



add_action('wp_enqueue_scripts', 'enqueue_icomoon_style'); 
function enqueue_icomoon_style() 
{ 
$ubicacion = get_template_directory_uri() . '/../neve-hijo/fuentes/icomoon/style.css';
wp_enqueue_style( 'icomoon-style', $ubicacion);
}

?>

