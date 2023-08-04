**** Reglas y explicación del juego: ****

-Se trata de un Juego RPG para 1 solo jugador, donde el usuario selecciona una clase de personaje entre (Guerrero, Mago y Asesino), cada clase tiene un total de 60 puntos de atributos iniciales que están distribuidos de forma diferente según la clase elegida y las estadísticas del personaje se calculan según estos atributos.

-Ganas cuando derrotas los 10 enemigos y pierdes cuando pierdes toda la salud. -Puedes abandonar la partida en mitad del juego y continuar donde te quedaste en otro momento. 
-Si ganas o pierdes, al salir del juego se borran los datos de tu personaje, solo quedan guardados si aún no has terminado.

-Al comenzar el juego se empieza en nivel 1 de personaje y se genera aleatoriamente (usando una API) cada parte de tu armadura y armas iniciales según tu clase. 
-(Los objetos de equipo generados o dropeados no aportan nada a las estadísticas, es solo una mecánica de estética).

-Luego se generan 10 enemigos de nivel 1 aleatoriamente con los cuales hay que combatir, cuando un enemigo es abatido, todos los otros suben un nivel y por lo tanto todas sus estadísticas de manera que aumenta la dificultad, además te dropea un objeto nuevo aleatorio y es reemplazado en tu equipo por el del mismo tipo (Ej: si dropea un Casco lo reemplaza por el Casco que ya tenías).

-Cada vez que un enemigo muere ganas experiencia igual a la salud de ese enemigo, al acumular cierta cantidad de experiencia subes de nivel. 
-Cando subes de nivel te curas hasta el máximo de PV, se te regenera todo el PM gastado y obtienes 3 puntos de atributos para distribuir como quieras, cada vez es más difícil subir de nivel.

-Cuenta con un menú de combate con 4 opciones, 1-ataque básico, 2-poder, 3-escapar y 4-curarse, las opciones de curarse y poder tienen un costo de PM 
-Si intentas usar poder o curarte y no tienes suficiente PM, tu acción falla y pierdes el turno, pero el enemigo si te ataca a ti.

-Menú de combate: 
1-Atacar: ataque básico, basado en los atributos y nivel 
2-Poder: ataque más fuerte, basado en ataque, atributos y nivel 
  Costo: 35 % PM_maximo (para Mago el Costo se reduce un 50%) 
3-Escapar: sales del combate 
4-Curarse: te cura una parte de tu salud, basado en la cantidad de PV y cantidad de PM 
  Costo: 25 % PM_maximo (para Mago el Costo se reduce un 50%)

-Cálculo de estadísticas y acciones: 
Salud: Fuerza10 + Destreza5 + Inteligencia3 + nivel200; 
Mana: Inteligencia10 + nivel100; 
Ataque: Destreza10 + Fuerza5 + Inteligencia3 + nivel10; 
Poder: Ataque + Inteligencia10 + Destreza5 + Fuerza 
Defensa: Fuerza10 + Destreza5 + Inteligencia3 + nivel10; 
Curarse: 30 % PV + 30 % PM

Consejos de como jugar para ganar: 
-Elige bien el momento para usar el poder o curarte. 
-Trata de gastar todo tu PM ya sea en el poder o curándote cuando estes a punto de subir de nivel ya que luego se regenera todo. 
-Con enemigos de alto nivel dependiendo de la clase puede ser más útil curarse varias veces en vez de usar el poder.

