#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>


void signIn(MYSQL *conn ,MYSQL_RES *resultado, MYSQL_ROW row,char respuesta[80],char consulta [80],char consulta1[80], int err,int err1,char nombre [20],char contra [20])
{
	sprintf (consulta,"SELECT JUGADORES.NOMBRE FROM (JUGADORES) WHERE JUGADORES.NOMBRE ='%s' ",nombre); 
	err=mysql_query (conn, consulta); 
	resultado = mysql_store_result (conn);
	// El resultado es una estructura matricial en memoria
	// en la que cada fila contiene los datos de una persona.
	
	// Ahora obtenemos la primera fila que se almacena en una
	// variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);
	
	//err=mysql_query (conn, consulta); 
	if (row==NULL){
		sprintf(consulta1,"INSERT INTO JUGADORES VALUES ('%s','%s',0,0,0,0)",nombre,contra);
		err1=mysql_query (conn, consulta1); 
		if (err1!=0){
			printf("Fallo al insertar\n");
			strcpy(respuesta, "Fallo al insertar");
		}
		else {
			printf("Bienvenido %s al Gran Casino UPC\n",nombre);
			sprintf(respuesta, "Bienvenido %s al Gran Casino UPC",nombre);
		}
	}
	
	else{
		printf("Nombre de usuario ya registrado pruebe otro nombre\n");
		strcpy(respuesta, "Nombre de usuario ya registrado pruebe otro nombre");
	}
	
}

void  LogIn(MYSQL *conn ,MYSQL_RES *resultado, MYSQL_ROW row,char respuesta[80],char consulta [80],char consulta1[80], int err,int err1,char nombre [20],char contra [20])
{
	sprintf (consulta,"SELECT JUGADORES.NOMBRE FROM (JUGADORES) WHERE JUGADORES.NOMBRE ='%s' ",nombre); 
	err=mysql_query (conn, consulta); 
	resultado = mysql_store_result (conn);
	// El resultado es una estructura matricial en memoria
	// en la que cada fila contiene los datos de una persona.
	
	// Ahora obtenemos la primera fila que se almacena en una
	// variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);
	
	//err=mysql_query (conn, consulta); 
	if (row!=NULL){
		sprintf(consulta,"SELECT JUGADORES.PASSWD FROM (JUGADORES) WHERE JUGADORES.PASSWD ='%s' AND JUGADORES.NOMBRE='%s' ",contra,nombre);
		err=mysql_query (conn, consulta);
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row==NULL){
			printf("Password incorrecto");
			strcpy(respuesta, "Password incorrecto");
		}
		else {
			printf("Bienvenido de nuevo %s al Gran Casino UPC\n",nombre);
			sprintf(respuesta, "Bienvenido de nuevo %s al Gran Casino UPC",nombre);
		}
	}
	
	else{
		printf("Nombre de usuario incorrecto\n");
		strcpy(respuesta, "Nombre de usuario incorrecto");
	}
	
}


void Consulta_1 (MYSQL *conn ,MYSQL_RES *resultado, MYSQL_ROW row,char respuesta[1000],char consulta [80],  int err )
{
	//copiamos en consulta la sintaxis necesaria para hacer una consulta mysql	
	
	strcpy (consulta,"SELECT JUGADORES.NOMBRE FROM (JUGADORES, PARTIDAS, ESTADISTICAS) WHERE JUGADORES.TOTAL_POINTS >= 10000 AND JUGADORES.NOMBRE=PARTIDAS.WINNER ORDER BY STR_TO_DATE(PARTIDAS.FECHA, '%d/%m/%Y') DESC LIMIT 1");
	
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	
	row = mysql_fetch_row (resultado);
	
	if (row == NULL){
		printf ("No se han obtenido datos en la consulta\n");
		sprintf(respuesta,"No se han obtenido datos en la consulta\n");
	}
	else
		while (row !=NULL) {
			// la columna 0 contiene el nombre del jugador
			printf("La consulta retorna el jugador con 10000 puntos minimos que ha ganado la partida mas reciente:\n");
			printf ("%s\n", row[0]);
			sprintf(respuesta,"El resultado a la consulta es %s",row[0]);
			// obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);
	}
		
}

void Consulta_2(MYSQL *conn ,MYSQL_RES *resultado, MYSQL_ROW row,char respuesta[1000],char consulta [80],  int err)
{
	strcpy (consulta,"SELECT JUGADORES.NOMBRE FROM (JUGADORES) WHERE JUGADORES.TOTAL_WINS IN (SELECT MIN(TOTAL_WINS) FROM (JUGADORES)) AND JUGADORES.DEPOSITO=(SELECT MAX(JUGADORES.DEPOSITO) FROM (JUGADORES) WHERE JUGADORES.TOTAL_WINS IN (SELECT MIN(TOTAL_WINS) FROM (JUGADORES)));");
	
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	
	row = mysql_fetch_row (resultado);
	
	if (row == NULL){
		printf ("No se han obtenido datos en la consulta\n");
		sprintf(respuesta,"No se han obtenido datos en la consulta\n");
	}
	else
		while (row !=NULL) {
			// la columna 0 contiene el nombre del jugador
			printf("La consulta retorna el jugador con 10000 puntos minimos que ha ganado la partida mas reciente:\n");
			printf ("%s\n", row[0]);
			sprintf(respuesta,"El resultado a la consulta es %s",row[0]);
			// obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);
	}
}

void Consulta_3( MYSQL *conn ,MYSQL_RES *resultado, MYSQL_ROW row,char respuesta[80],char consulta [80],char consulta1[80], int err,int err1 )
{
	MYSQL_RES *resultado1;
	MYSQL_ROW row1;
	int i;
	//copiamos en consulta la sintaxis necesaria para hacer una consulta mysql
	strcpy (consulta,"SELECT JUGADORES.NOMBRE FROM (JUGADORES) WHERE JUGADORES.TOTAL_WINS >=5 AND JUGADORES.NOMBRE IN (SELECT PARTIDAS.WINNER FROM (PARTIDAS) WHERE PARTIDAS.NPLAYERS >=4)"); 
	err=mysql_query (conn, consulta); 
	if (err!=0) {
		printf ("Error 4 al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
	}
	//recogemos el resultado de la consulta 
	resultado = mysql_store_result (conn); 
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		sprintf(respuesta,"No se han obtenido datos en la consulta\n");
	}
	//consulta adicional para saber la ID de la partida que en la que gan￳ el jugador que se busca en la consulta anterior
	strcpy(consulta1,"SELECT ESTADISTICAS.ID_P FROM(ESTADISTICAS) WHERE ESTADISTICAS.ID_P IN (SELECT PARTIDAS.ID FROM (PARTIDAS) WHERE PARTIDAS.NPLAYERS >=4) AND ESTADISTICAS.POSITION=1 AND ESTADISTICAS.NOMBRE IN (SELECT JUGADORES.NOMBRE FROM (JUGADORES) WHERE JUGADORES.TOTAL_WINS >=5);");
	err=mysql_query (conn, consulta1); 
	if (err!=0) {
		printf ("Error 4 al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		sprintf(respuesta,"Error 4 al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
	}
	//recogemos el resultado de la consulta 
	resultado1 = mysql_store_result (conn); 
	row1 = mysql_fetch_row (resultado1);
	if (row1 == NULL)
	{
		printf ("No se han obtenido datos en la consulta\n");
		strcpy(respuesta,"No se han obtenido datos en la consulta\n");
	}
	else
	{
		strcpy(respuesta,"Resultado de la consulta:\n");
		printf("En la consulta de los jugadores que han ganado mas de 5 partidas y ganaron una partida en la que habia mas de 4 jugadores obtenemos:\n");
		i=0;
		char next[1000];
		while (row !=NULL) 
		{
			if (i==0)
			{
				sprintf(respuesta,"Nombre del ganador de la partida con ID %s: %s ", row1[0],row[0]);
			}
			else{
				sprintf(next," Nombre del ganador de la partida con ID %s: %s ", row1[0],row[0]);
				strcat(respuesta,next);
			}
			printf ("Nombre del ganador de la partida con ID %s: %s\n", row1[0],row[0] );
			//sprintf(respuesta," Nombre del ganador de la partida con ID %s: %s ", row1[0],row[0]);
			row = mysql_fetch_row (resultado);
			row1 = mysql_fetch_row (resultado1);
			i=i+1;
		}
		
	}
}




int main(int argc, char *argv[])
{	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creando socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9200);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	
	MYSQL *conn;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	int err1;
	
	// Estructura especial para almacenar resultados de consultas 
	
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error 1 al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Casino",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error 2 al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	else{
		printf("Conexion con la base de datos establecida correctamente\n");
	}
	
	int i;
	// Bucle infinito
	for (;;){
		char consulta [80];
		char consulta1 [80];
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
		int terminar =0;
		// Entramos en un bucle para atender todas las peticiones de este cliente
		//hasta que se desconecte
		while (terminar ==0)
		{
			// Ahora recibimos la petici?n
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibido\n");
			
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';
			
			
			printf ("Peticion: %s\n",peticion);
			
			// vamos a ver que quieren
			char *p = strtok( peticion, "/");
			int codigo =  atoi (p);
			// Ya tenemos el c?digo de la petici?n
			char nombre[20];
			char contra[20];
			
			
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			// Ya tenemos el nombre
			
			p = strtok( NULL, "/");
			strcpy (contra, p);
			// Ya tenemos la contraseￃﾱa
			
			printf ("Codigo: %d Nombre: %s Contrase￱a: %s\n", codigo, nombre,contra);
			
			//iniciamos la conexi￯﾿ﾳn a la base de datos
			
			
			
			if (codigo ==0) {//petici?n de desconexi?n
				terminar=1;
				strcpy(respuesta,"Desconexion OK");
			}
			else if (codigo ==1){ //darse de alta
				signIn (conn,resultado,row,respuesta,consulta,consulta1,err,err1,nombre,contra);				
			}
			
			
			
			else if (codigo ==2){ //iniciar sesion
				LogIn (conn,resultado,row,respuesta,consulta,consulta1,err,err1,nombre,contra);
			}
			else if (codigo ==3){ //consulta 1
				Consulta_1 (conn,resultado,row,respuesta,consulta,err);
			}
			else if (codigo ==4){ //consulta 2
				Consulta_2(conn,resultado,row,respuesta,consulta,err);	
			}
			
			else if (codigo ==5){ //consulta 3
				Consulta_3(conn,resultado,row,respuesta,consulta,consulta1,err,err1);	
			}
			
			printf ("Respuesta: %s\n", respuesta);
			// Enviamos respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		}
	}
	// Se acabo el servicio para este cliente
	close(sock_conn);
	mysql_close (conn);
	exit(0);
}

