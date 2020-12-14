#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>
#define MAX 100

typedef struct {
	char nombre [20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados [100];
	int num;
} ListaConectados;


typedef struct{
	Conectado conectados[5];
	int num;
	int juego;
	int ID;
	int answer;
	int num_invitados;
}Partida;

int PonJugadorPartida (Partida *partida,char nombre[20],int socket){ //retorna -1 si la partida ya esta llena (contiene 5 jugadores) rotorna 0 si el jugador se puede a￯﾿ﾱadir a la partida y retorna -2 si no encuentra el jugador en la lista de conectados
	int encontrado=0;
	int i=0;
	if (partida->num==5)
		return -1;
	else
	{
		while (i<partida->num && encontrado==0 )
		{
			if (strcmp(partida->conectados[i].nombre,nombre)==0)
			{
				encontrado=1;
				break;
			}
			i=i+1;
		}
		
		if (encontrado==0) {
			printf("%s anadido correctamente en la partida %d en la posicion %d\n",nombre,partida->ID,partida->num);
			strcpy(partida->conectados[partida->num].nombre,nombre);
			partida->conectados[partida->num].socket=socket;
			partida->num=partida->num+1;
			printf("numero de jugadores en la partida %d = %d\n",partida->ID,partida->num);
			return 0;
		}
		else
			return -2;
	}
}

int DamePosicionJugadorPartida (Partida partida,char nombre[20])
{//retorna la posici￳n del jugador en la partida,retorna -1 si el jugador no se encuentra en la partida
	int i=0;
	int encontrado=0;
	while ((i<partida.num) && !encontrado)
	{
		if (strcmp(partida.conectados[i].nombre,nombre)==0)
			encontrado=1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return i;
	else
		return -1;
}

int DameSocketJugadorPartida (Partida partida, char nombre[20]){
	//Devuelve el socket o -1 si no esta en la lista
	int i=0;
	int encontrado=0;
	while ((i< partida.num) && !encontrado)
	{
		if (strcmp(partida.conectados[i].nombre,nombre)==0)
			encontrado =1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return partida.conectados [i].socket;
	else
		return -1;
}


int EliminarJugadorPartida (Partida partida,char nombre[20]) //esta funcion retorna -1 si no encuentra el nombre que se debe eliminar de la lista y 0 si se ha eliminado correctamente
{
	int pos = DamePosicionJugadorPartida (partida,nombre);
	if (pos==-1)
		return -1;
	else{
		int i;
		for (i=pos;i<partida.num -1;i++)
		{
			partida.conectados[i]=partida.conectados[i+1];
		}
		partida.num--;
		return 0;
	}
}
void DameJugadores (Partida partida,char conectados[300]) //retorna una lista de jugadores que estan dentro de la partida que se pasa como parametro
{
	sprintf(conectados,"%d",partida.num);
	int i;
	for (i=0;i<partida.num;i++)
		sprintf(conectados,"%s/%s",conectados,partida.conectados[i].nombre);
}

typedef Partida partidas[MAX];
void Inicializar_Tabla_Partidas(partidas Tabla)
{
	printf("Tabla inicializada correctamente\n");
	int i;
	for (i=0;i<100;i++)
	{
		Tabla[i].num=0;
		
	}
}
int PonPartida(partidas Tabla,Partida partida) //funcion para insertar una partida en la tabla de partidas; retorna 0 si la partida se puede a￯﾿ﾱadir correctamente, retorna -1 si no ha podido a￯﾿ﾱadir el 
{
	int encontrado;
	int i=0;
	while ((i<100) && !encontrado)
	{
		if (Tabla[i].num==0)
		{
			encontrado=1;
		}
		if (!encontrado)
		{
			i=i+1;
		}
	}
	if (encontrado)
	{
		printf("Partida %d anadida correctamente en la tabla\n",partida.ID);
		Tabla[i]=partida;
		return 0;
	}
	else
		return -1;
}
void DamePartidas(partidas tabla,char partidas[1000],char usuario[20])// funcion para retornar las partidas disponibles de un jugador
	//funcion necesaria para escribir la notificacion 11/num partidas/id partida_1/juego_partida1/id_partida2/juego_partida_2
{
	int i;
	int contador=0;
	char partidas_variables[800];
	for(i=0;i<100;i++)
	{
		int indice_jugadores;
		for(indice_jugadores=0;indice_jugadores<5;indice_jugadores++)
		{
			if(strcmp(tabla[i].conectados[indice_jugadores].nombre,usuario)==0)
			{
				if(contador==0)
				{
					sprintf(partidas_variables,"%d/%d",tabla[i].ID,tabla[i].juego);
				}
				else
				   sprintf(partidas_variables,"%s/%d/%d",partidas_variables,tabla[i].ID,tabla[i].juego);
				contador=contador+1;
			}
		}
		
	}
	sprintf(partidas,"%d/%s",contador,partidas_variables);
	
}
int DamePosicionPartida(partidas Tabla,Partida partida) //retorna la posicion si la partida esta en la tabla, retorna -1 si no esta en la lista
{
	int i=0;
	int encontrado;
	while (i<100)
	{
		if (Tabla[i].ID==partida.ID)
		{
			encontrado=1;
			break;
		}
		i=i+1;
	}
	if (encontrado)
	{
		return i;
	}
	else
		return -1;
	
} 
int EliminarPartida(partidas Tabla,Partida partida) // retorna 0 si ha podido eliminar la partida y retorna -1 si no ha podido eliminarla
{
	int pos=DamePosicionPartida(Tabla,partida);
	if (pos!=-1)
	{
		Tabla[pos].num=0;
		//Tabla[pos].ID=0;
		return 0;
	}
	else
	{
		return -1;
	}
}
int DamePosicionPartidaID(partidas Tabla,int ID) // esta funcion busca una partida, DENTRO DE LA TABLA DE PARTIDAS, a partir de su ID QUE SE PASA COMO PARAMETRO
{//retorna la posici￳n o si no encuentra la partida retorna -1
	int i=0;
	int encontrado;
	while (i<100)
	{
		if (Tabla[i].ID==ID)
		{
			encontrado=1;
			break;
		}
		i=i+1;
	}
	if (encontrado)
	{
		return i;
	}
	else
		return -1;
	
}
int EliminarPartidaID(partidas Tabla, int ID) //retrona 0 si ha podido eliminar la partida de la tabla, en caso contrario retorna -1
{
	int pos=DamePosicionPartidaID(Tabla,ID);
	if (pos!=-1)
	{
		Tabla[pos].num=0;
		printf("Partida con ID %d eliminada correctamente de la posicion %d\n",Tabla[pos].ID,pos);
		//Tabla[pos].ID=0;
		return 0;
	}
	else
	{
		return -1;
	}
}

int i;
ListaConectados miLista;
partidas miPartidas;


pthread_mutex_t mutex= PTHREAD_MUTEX_INITIALIZER;
int Pon (ListaConectados *lista,char nombre[20],int socket){ //funcion para introducir a un usuario a la lista de usuarios conectados
	//retorna -1 si la lista esta llena,retorna 0 si ha introducido correctamente al usuario, retorna -2 si el usuario ya se encuentra en la lista
	int encontrado=0;
	int i=0;
	if (lista->num==100)
		return -1;
	else
	{
		while (i<lista->num && encontrado==0 )
		{
			if (strcmp(lista->conectados[i].nombre,nombre)==0)
			{
				encontrado=1;
				break;
			}
			i=i+1;
		}
		
		if (encontrado==0) {
			strcpy(lista->conectados[lista->num].nombre,nombre);
			lista->conectados[lista->num].socket=socket;
			lista->num++;
			return 0;
		}
		else
			return -2;
	}
}

int DamePosicion (ListaConectados *lista,char nombre[20]) //retorna la posicion del jugador en la lista, retorna -1 si no encuentra al jugador en la lista
{
	int i=0;
	int encontrado=0;
	while ((i<lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre,nombre)==0)
			encontrado=1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return i;
	else
		return -1;
}

int DameSocket (ListaConectados *lista, char nombre[20]){
	//Devuelve el socket o -1 si no esta en la lista
	int i=0;
	int encontrado=0;
	while ((i< lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre,nombre)==0)
			encontrado =1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return lista->conectados [i].socket;
	else
		return -1;
}


int Eliminar (ListaConectados *lista,char nombre[20]) //esta funcion retorna -1 si no encuentra el nombre que se debe eliminar de la lista y 0 si se ha eliminado correctamente
{
	int pos = DamePosicion (lista,nombre);
	if (pos==-1)
		return -1;
	else{
		int i;
		for (i=pos;i<lista->num -1;i++)
		{
			lista->conectados[i]=lista->conectados[i+1];
		}
		lista->num--;
		return 0;
	}
}
void DameConectados (ListaConectados *lista,char conectados[300])
{
	sprintf(conectados,"%d",lista->num);
	int i;
	for (i=0;i<lista->num;i++)
		sprintf(conectados,"%s/%s",conectados,lista->conectados[i].nombre);
}
int DamePosicionSocket (ListaConectados *lista,int socket) //retorna la posicion del socket en la lista o -1  si no encuentra el socket en la lista
{
	int i=0;
	int encontrado=0;
	while ((i<lista->num) && !encontrado)
	{
		if (lista->conectados[i].socket==socket)
			encontrado=1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return i;
	else
		return -1;
}
void EliminarPosicion(ListaConectados *lista,int posicion) //elimina lo que hay en una posicion de la lista de  conectados
	//funcion para eliminar el usuario inicial que se inserta para provar la correcta conexi￳n del socket y no depender de una lista de sockets antes de insertar al usuario real
{
	if(lista->num>posicion)
	{
		int i;
		for (i=posicion;i<lista->num -1;i++)
		{
			lista->conectados[i]=lista->conectados[i+1];
		}
		lista->num--;
	}
}





int signIn(MYSQL *conn ,char respuesta[1000],char nombre [20],char contra [20]) //funcion para dar de alta a un usuario
{//retorna -1 si no se ha podido registrar al usuario o 1 si se ha registrado correctamente, retorna 0 si el nombre que se intenta registrar no este registrado ya
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	int err1;
	char consulta [512];
	char consulta1[512];
	sprintf (consulta,"SELECT JUGADORES.NOMBRE FROM (JUGADORES) WHERE JUGADORES.NOMBRE = BINARY '%s' ",nombre); //comprovamos que no haya ningun usuario ya registrado con el nombre que se quiere registrar
	err=mysql_query (conn, consulta); 
	resultado = mysql_store_result (conn);
	// El resultado es una estructura matricial en memoria
	// en la que cada fila contiene los datos de una persona.
	
	// Ahora obtenemos la primera fila que se almacena en una
	// variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);
	
	//err=mysql_query (conn, consulta); 
	if (row==NULL){
		sprintf(consulta1,"INSERT INTO JUGADORES VALUES ('%s','%s',0,0,0,0)",nombre,contra); //insertamos al nuevo usuario en la base de datos
		err1=mysql_query (conn, consulta1); 
		if (err1!=0){
			printf("Fallo al insertar\n");
			strcpy(respuesta, "1/0/Fallo al insertar");
			return -1;
		}
		else {
			printf("Bienvenido %s al Gran Casino UPC\n",nombre);
			sprintf(respuesta, "1/1/Bienvenido %s al Gran Casino UPC",nombre);
			return 1;
		}
	}
	
	else{
		printf("Nombre de usuario ya registrado pruebe otro nombre\n");
		strcpy(respuesta, "1/0/Nombre de usuario ya registrado pruebe otro nombre");
		return 0;
	}
	
}

int  LogIn(MYSQL *conn ,char respuesta[1000],char nombre [20],char contra [20],ListaConectados *miLista, int sock_conn,char notificacion[100] ) 
	//retorna 0 si no ha podido iniciar sesion o retorna 1 si ha podido iniciar sesion
{
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	int err1;
	char consulta [512];
	char consulta1[512];
	sprintf (consulta,"SELECT JUGADORES.NOMBRE FROM (JUGADORES) WHERE JUGADORES.NOMBRE = BINARY '%s' ",nombre); //comprovamos que el nombre de usuario se encuentra en la base de datos
	//la sentencia BINARY es para distinguir entre mayusculas y minusculas
	err=mysql_query (conn, consulta); 
	resultado = mysql_store_result (conn);
	// El resultado es una estructura matricial en memoria
	// en la que cada fila contiene los datos de una persona.
	
	// Ahora obtenemos la primera fila que se almacena en una
	// variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);
	if (row!=NULL){
		sprintf(consulta,"SELECT JUGADORES.PASSWD FROM (JUGADORES) WHERE JUGADORES.PASSWD = BINARY '%s' AND JUGADORES.NOMBRE= BINARY '%s' ",contra,nombre);//si el nombre es correcto comprovamos ahora que el password es correcto 
		err=mysql_query (conn, consulta);
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row==NULL){
			printf("Respuesta en el proceso de Log In: Password incorrecto\n");
			strcpy(respuesta, "2/1/Password incorrecto");
			int eliminar=DamePosicionSocket(miLista,sock_conn);
			EliminarPosicion(miLista,eliminar);
			return 0; //password incorrecto
		}
		else {
			int already_in=DamePosicion(miLista,nombre);
			if(already_in==-1)
			{
				int socket_jugador=DamePosicionSocket(miLista,sock_conn);
				strcpy(miLista->conectados[socket_jugador].nombre,nombre);				
				printf("Respuesta en el proceso de Log In: Bienvenido de nuevo %s al Gran Casino UPC\n",nombre);
				sprintf(respuesta, "2/0/Bienvenido de nuevo %s al Gran Casino UPC",nombre);
				char conectados[1000];
				DameConectados(miLista,conectados);
				sprintf(notificacion,"6/%s/",conectados);
				printf("Notificacion: %s\n",notificacion);
				return 1;//log in correcto
			}
			else
			{
				printf("Respuesta en el proceso de Log In: Usuario %s ya conectado des de otro terminal\n",nombre);
				sprintf(respuesta, "2/1/Usuario %s ya conectado des de otro terminal",nombre);
				int eliminar=DamePosicionSocket(miLista,sock_conn);
				EliminarPosicion(miLista,eliminar);
				return 0;//el usuario ya ha iniciado sesion des de otro terminal
			}
		}
	}
	
	else{
		printf("Respuesta en el proceso de Log In: Nombre de usuario incorrecto\n");
		strcpy(respuesta, "2/1/Nombre de usuario incorrecto");
		int eliminar=DamePosicionSocket(miLista,sock_conn);
		EliminarPosicion(miLista,eliminar);
		return 0;//nombre de usuario correcto
	}
	
}


void Consulta_1 (MYSQL *conn,char respuesta[1000])
{
	//copiamos en consulta la sintaxis necesaria para hacer una consulta mysql	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	char consulta [512];
	
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
		sprintf(respuesta,"3/No se han obtenido datos en la consulta\n");
	}
	else
		while (row !=NULL) {
			// la columna 0 contiene el nombre del jugador
			printf("La consulta retorna el jugador con 10000 puntos minimos que ha ganado la partida mas reciente:\n");
			printf ("%s\n", row[0]);
			sprintf(respuesta,"3/El resultado a la consulta es %s",row[0]);
			// obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);
	}
		
}

void Consulta_2(MYSQL *conn ,char respuesta[1000])
{
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	
	char consulta [512];
	
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
		sprintf(respuesta,"4/No se han obtenido datos en la consulta\n");
	}
	else
		printf("La consulta retorna el jugador o los jugadores con el mayor dep￯﾿ﾯ￯ﾾ﾿￯ﾾﾳsito y el menor n￯﾿ﾯ￯ﾾ﾿￯ﾾﾺmero de partidas ganadas:\n");
	while (row !=NULL) {
		// la columna 0 contiene el nombre del jugador
		
		printf ("%s\n", row[0]);
		sprintf(respuesta,"4/El resultado a la consulta es %s",row[0]);
		// obtenemos la siguiente fila
		row = mysql_fetch_row (resultado);
	}
}

void Consulta_3( MYSQL *conn, char respuesta[1000])
{
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	char consulta [512];
	char respP[512];
	int i;
	//copiamos en consulta la sintaxis necesaria para hacer una consulta mysql
	strcpy (consulta,"SELECT JUGADORES.NOMBRE,PARTIDAS.ID FROM (JUGADORES,PARTIDAS) WHERE JUGADORES.TOTAL_WINS >=5 AND JUGADORES.NOMBRE = PARTIDAS.WINNER AND PARTIDAS.NPLAYERS >=4"); 
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
		sprintf(respuesta,"5/No se han obtenido datos en la consulta\n");
	}
	//consulta adicional para saber la ID de la partida que en la que gan￯﾿ﾯ￯ﾾ﾿￯ﾾﾯ￯﾿ﾯ￯ﾾﾾ￯ﾾ﾿￯﾿ﾯ￯ﾾﾾ￯ﾾﾯ￯﾿ﾯ￯ﾾ﾿￯ﾾﾯ￯﾿ﾯ￯ﾾﾾ￯ﾾﾾ￯﾿ﾯ￯ﾾﾾ￯ﾾ﾿￯﾿ﾯ￯ﾾ﾿￯ﾾﾯ￯﾿ﾯ￯ﾾﾾ￯ﾾﾾ￯﾿ﾯ￯ﾾﾾ￯ﾾﾯ￯﾿ﾯ￯ﾾ﾿￯ﾾﾯ￯﾿ﾯ￯ﾾﾾ￯ﾾ﾿￯﾿ﾯ￯ﾾﾾ￯ﾾﾯ￯﾿ﾯ￯ﾾ﾿￯ﾾﾯ￯﾿ﾯ￯ﾾﾾ￯ﾾﾾ￯﾿ﾯ￯ﾾﾾ￯ﾾﾾ￯﾿ﾯ￯ﾾ﾿￯ﾾﾯ￯﾿ﾯ￯ﾾﾾ￯ﾾﾾ￯﾿ﾯ￯ﾾﾾ￯ﾾ﾿￯﾿ﾯ￯ﾾ﾿￯ﾾﾯ￯﾿ﾯ￯ﾾﾾ￯ﾾ﾿￯﾿ﾯ￯ﾾﾾ￯ﾾﾯ￯﾿ﾯ￯ﾾ﾿￯ﾾﾯ￯﾿ﾯ￯ﾾﾾ￯ﾾﾾ￯﾿ﾯ￯ﾾﾾ￯ﾾﾾ￯﾿ﾯ￯ﾾ﾿￯ﾾﾯ￯﾿ﾯ￯ﾾﾾ￯ﾾﾾ￯﾿ﾯ￯ﾾﾾ￯ﾾﾳ el jugador que se busca en la consulta anterior
	else
	{
		strcpy(respuesta,"5/");
		printf("En la consulta de los jugadores que han ganado mas de 5 partidas y ganaron una partida en la que habia mas de 4 jugadores obtenemos:\n");
		i=0;
		char next[1000];
		while (row !=NULL) 
		{
			if (i==0)
			{
				sprintf(respP,"Nombre del ganador de la partida con ID %s: %s ", row[0],row[1]);
				strcat(respuesta,respP);
			}
			else{
				sprintf(next," Nombre del ganador de la partida con ID %s: %s ", row[0],row[1]);
				strcat(respuesta,next);
			}
			printf ("Nombre del ganador de la partida con ID %s: %s\n", row[0],row[1] );
			//sprintf(respuesta," Nombre del ganador de la partida con ID %s: %s ", row1[0],row[0]);
			row = mysql_fetch_row (resultado);
			i=i+1;
		}
		
	}
}

void *AtenderCliente(void *socket) //funcion que ejecuta el thread
{
	int sock_conn;
	int*s;
	s=(int*)socket;
	sock_conn=*s;
	char peticion[1000];
	char respuesta[1000];
	int ret;
	char notificacion[1000];
	MYSQL *conn;
	
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
	//sock_conn es el socket que usaremos para este cliente
	
	int terminar =0;
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar ==0)
	{
		// Ahora recibimos la petici?n
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';// Tenemos que anadirle la marca de fin de string 
		char copia[1000];
		strcpy(copia,peticion);
		printf ("Peticion que recibe el servidor: %s\n",peticion);		
		// vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		// Ya tenemos el codigo de la petici?n
		char nombre[20];
		char contra[20];
		int introC=0;
		char anfitrion [20];
		char invitado[20];
		char invitacion[100];
		int juego;
		int IDpartida;

		if ((codigo==1)||(codigo==2)||(codigo==3)||(codigo==4)||(codigo==5)) //se excluye a los otros codigos porque el patron es distinto
		{
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			// Ya tenemos el nombre			
			p = strtok( NULL, "/");
			strcpy (contra, p);
			// Ya tenemos la contra			
			printf ("Codigo: %d Nombre: %s Contra: %s\n", codigo, nombre,contra);
		}
		
		if (codigo ==0) {//peticion de desconexion
			terminar=1;//se debe salir del bucle en esta peticion
			printf("Desconectando\n");
			pthread_mutex_lock( &mutex);
			int eliminado=Eliminar (&miLista,nombre); //eliminar de la lista de conectados
			if (eliminado==-1)
				strcpy(respuesta,"0/1/Error en la desconexion");
			else
				strcpy(respuesta,"0/2/Desconexion OK");
			char conectados[1000];
			DameConectados(&miLista,conectados);
			sprintf(notificacion,"6/%s/",conectados);
			printf("Notificacion: %s\n",notificacion);
			pthread_mutex_unlock( &mutex);
		}
		else if (codigo ==1){ //darse de alta
			printf("Registrando\n");
			pthread_mutex_lock( &mutex);
			int sign=signIn (conn,respuesta,nombre,contra);  
			pthread_mutex_unlock( &mutex);
			if (sign==1)
			{
				pthread_mutex_lock (&mutex);
				introC =LogIn (conn,respuesta,nombre,contra,&miLista,sock_conn,notificacion);//si se ha podidio dar de alta al jugador correctamente ya se inicia sesion automaatica
				pthread_mutex_unlock (&mutex);
			}
			else
			{
				int eliminar=DamePosicionSocket(&miLista,sock_conn);
				EliminarPosicion(&miLista,eliminar);
				terminar=1;
			}
		}
		
		else if (codigo ==2){ //iniciar sesion
			printf("Iniciando sesion\n");
			pthread_mutex_lock (&mutex);
			int log =LogIn (conn,respuesta,nombre,contra,&miLista,sock_conn,notificacion);
			pthread_mutex_unlock (&mutex);
			
			if (log==0)
			{
				terminar=1; //si no se ha podido registrar correctamente el jugador se debe terminar la conexion
			}
			
			
		}
		else if (codigo ==3){ //consulta 1
			Consulta_1 (conn,respuesta);
		}
		else if (codigo ==4){ //consulta 2
			Consulta_2(conn,respuesta);	
		}
		
		else if (codigo ==5){ //consulta 3
			Consulta_3(conn,respuesta);	
		}
		
		else if (codigo==7) //peticion de enviar invitacion
		{
			//llega una peticion de invitar a uno o varios jugadores del tipo codigo del juego/codigo de la partida/anfitrion/jugador invitado/jugador invitado ...
			p = strtok( NULL, "/");
			juego= atoi(p); //0 poker 1 black jack 2 ruleta
			p = strtok( NULL, "/");
			IDpartida= atoi(p);
			
			p = strtok( NULL, "/");
			strcpy (anfitrion, p);
			int pos=DamePosicion(&miLista,anfitrion);
			// Ya tenemos el nombre
			Partida partidA; //creamos una nueva partida
			partidA.ID=IDpartida;
			partidA.juego=juego;
			char partidas_actuales[1000];					
			int sockk=DameSocket(&miLista,anfitrion);
			int anadir_anfitrion= PonJugadorPartida(&partidA,anfitrion,sockk);			
			PonPartida(miPartidas,partidA);
			DamePartidas(miPartidas,partidas_actuales,nombre);
			sprintf(notificacion,"11/%s",partidas_actuales);
			write (sockk,notificacion, strlen(notificacion));
			printf("Notificacion que se envia al jugador %s : %s\n",anfitrion,notificacion);
			int Pos= DamePosicionPartidaID(miPartidas,IDpartida);
			printf("Anfitrion %s en la partida %d en posicion %d\n",partidA.conectados[0].nombre,partidA.ID,partidA.num);
			printf("numero de jugadores en la partida %d = %d\n",partidA.ID,partidA.num);
			
			p = strtok( NULL, "/");
			sprintf(respuesta,"7/0/%d/%d",juego,IDpartida);
			int nInvitadosConectados=0;
			char invitadosConectados[100];
			char invC[100];
			while (p!=NULL)
			{//enviamos las invitaciones
				strcpy (invitado, p);
				
				int j=DameSocket(&miLista,invitado); 
				if (j==-1)
				{//el jugador invitado ya no esta en la lista 
					printf("El jugador %s se ha desconectado\n",invitado);
				}
				else
				{
					sprintf(invitacion,"7/1/%d/%d/%s",juego,IDpartida,anfitrion); //mensaje de invitacion que se envia a cada invitado
					printf("invitacion : %s al jugador %s\n",invitacion,invitado);
					nInvitadosConectados=nInvitadosConectados+1;
					sprintf(invC,"%s/",invitado);
					if (nInvitadosConectados==1)
					{
						sprintf(invitadosConectados,"%s",invC);
						
					}
					else
					{
						strcat(invitadosConectados,invC);
					}
					write (j,invitacion, strlen(invitacion));
					//envio de la invitacion a cada invitado
					
				}
				p = strtok( NULL, "/");
			}
			
			sprintf(respuesta,"%s/%d",respuesta,nInvitadosConectados);
			strcat(respuesta,"/");
			strcat(respuesta,invitadosConectados);
			printf("Respuesta que se envia al anfitrion:%s\n",respuesta);
			miPartidas[Pos].num_invitados=miPartidas[Pos].num_invitados+nInvitadosConectados;
			//enviamos una respuesta al anfitrion para que sepa a quien se ha enviado una invitacion
		}
		else if (codigo==8) //peticion de aceptar o declinar una invitacion de partida
		{
			//la peticion que llega sera del tipo: Codigo del juego/codigo de la partida/Jugador que invita/jugador invitado/Respuesta(si o no)/codigo de respuesta (1 acepta 0 no)
			char respuestaInv[100];
			char respuestaAnfitrion[100];
			char partidas_actuales[1000];
			p = strtok( NULL, "/");
			juego= atoi(p); //0 poker 1 black jack 2 ruleta
			p = strtok( NULL, "/");
			IDpartida= atoi(p);
			p = strtok( NULL, "/");
			strcpy(anfitrion,p);
			int pos = DamePosicion(&miLista,anfitrion);
			int Pos= DamePosicionPartidaID(miPartidas,IDpartida);
			miPartidas[Pos].answer=miPartidas[Pos].answer+1;
			if (pos!=-1)
			{//comprovamos que el anfitrion no se haya desconectado
				sprintf(respuesta,"8/0/%d/%d",juego,IDpartida);
				int sock=DameSocket(&miLista,anfitrion);
				p = strtok( NULL, "/");
				strcpy (invitado, p);
				p = strtok( NULL, "/");
				strcpy(respuestaInv,p);
				p = strtok( NULL, "/");
				int res=atoi(p);
				int pos_partida= DamePosicionPartidaID(miPartidas,IDpartida);
				if (res==0)//el invitado no acepta la invitacion por lo tanto no se anade en la partida
				{
					printf("Jugador %s no acepta por lo tanto eliminado de la partida\n",invitado);
				}
				else
				{
					int pos_inv=DamePosicion(&miLista,invitado);
					int ponA=PonJugadorPartida(&miPartidas[pos_partida],invitado,miLista.conectados[pos_inv].socket);
					DamePartidas(miPartidas,partidas_actuales,invitado);
					sprintf(notificacion,"11/%s",partidas_actuales);
					printf("Notificacion que se envia al jugador %s : %s\n",invitado,notificacion);
					int sock_inv=DameSocketJugadorPartida(miPartidas[pos_partida],invitado);
					write (sock_inv,notificacion, strlen(notificacion));//enviamos las partidas disponibles de cada jugador										
				}
				printf("Respuesta que se envia al invitado:%s\n",respuesta);
				printf("numero de jugadores en la partida %d = %d\n",IDpartida,miPartidas[pos_partida].num);
				printf("numero de invitados %d; numero de respuestas %d\n",miPartidas[pos_partida].num_invitados,miPartidas[pos_partida].answer);
				if (miPartidas[pos_partida].num==1 && miPartidas[pos_partida].answer==miPartidas[pos_partida].num_invitados )
				{//cuando todos los usuarios ya han respondido si solo esta el anfitrion significa que no se ha anadido ningun invitado por lo tanto el anfitrion debe eliminar la partida
					printf("La partida se cancelo\n");
					sprintf(respuestaAnfitrion,"8/2/%d/%d/%s/%s",juego,IDpartida,invitado,respuestaInv);
					write (sock,respuestaAnfitrion, strlen(respuestaAnfitrion));
					printf("Respuesta que se envia al anfitrion:%s\n",respuestaAnfitrion);					
					printf("Notificacion que se envia al jugador %s : %s\n",invitado,notificacion);
					int sock_anf=DameSocketJugadorPartida(miPartidas[pos_partida],anfitrion);
					EliminarPartidaID(miPartidas,IDpartida);
					DamePartidas(miPartidas,partidas_actuales,invitado);
					sprintf(notificacion,"11/%s",partidas_actuales);
					write (sock_anf,notificacion, strlen(notificacion));
				}
				else
				{//todavia no han respondido todos o algun invitado se ha unido a la partida
					sprintf(respuestaAnfitrion,"8/1/%d/%d/%s/%s",juego,IDpartida,invitado,respuestaInv);
					write (sock,respuestaAnfitrion, strlen(respuestaAnfitrion));
					printf("Respuesta que se envia al anfitrion:%s\n",respuestaAnfitrion);
				}
			}
			else
			{//el anfitrion se desconecto
				sprintf(respuesta,"8/-1/%d/%d",juego,IDpartida);
				printf("Respuesta que se envia al invitado:%s\n",respuesta);
			}
		}
		else if (codigo==9)//peticion de enviar por el chat 
			// la peticion que llega es del tipo 9/codigo partida/autor/mensaje
		{
			p = strtok( NULL, "/");
			int Juego;
			Juego= atoi(p);
			p = strtok( NULL, "/");
			IDpartida= atoi(p);
			p=strtok(NULL,"/");
			char autor [20];
			strcpy(autor,p);
			p=strtok(NULL,"/");
			sprintf(notificacion,"9/%d/%d/%s/%s",Juego,IDpartida,autor,p);
			int pos= DamePosicionPartidaID(miPartidas,IDpartida);
			for (int j=0;j<miPartidas[pos].num;j++)//se envia el mensaje del chat de una partida a todos los jugadores de esa partida
			{
				printf("Notificacion que envia el servidor: %s al socket:%d \n",notificacion,miPartidas[pos].conectados[j].socket);
				write (miPartidas[pos].conectados[j].socket,notificacion,strlen(notificacion));
			}
			
			
			
		}
		else if (codigo==10) //esta peticion es la que envia el anfitrion para decirles a aquellos jugadores que hayan aceptado la partida que abran el formulario del juego
		{//esta peticion es del tipo invitado/codigo de juego/codigo de partida
			char respuestaPartida[100];
			p = strtok( NULL, "/");
			strcpy(invitado,p);
			p = strtok( NULL, "/");
			juego= atoi(p); //0 poker 1 black jack 2 ruleta
			p = strtok( NULL, "/");
			IDpartida= atoi(p);
			int sock=DameSocket(&miLista,invitado);
			sprintf(respuestaPartida,"10/%d/%d",juego,IDpartida);
			write (sock,respuestaPartida, strlen(respuestaPartida));
			
		}
		else if (codigo==11) //peticion de finalizar una partida
		{
			strcpy(notificacion,copia);
		}
		if (codigo!=9 && codigo!=10 && codigo!=11)//estos codigos que se excluyen no tienen respuesta o es distinta 
		{
			printf ("Respuesta que envia el servidor al cliente: %s\n", respuesta);
			// Enviamos respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		}
		int j;
		if (codigo==0 || codigo ==2||introC==1||codigo==11)//se envian las notificaciones
		{
			for (j=0;j<miLista.num;j++)
			{
				printf("Notificacion que envia el servidor: %s al socket:%d \n",notificacion,miLista.conectados[j].socket);
				write (miLista.conectados[j].socket,notificacion,strlen(notificacion));
			}
		}
		
	}
	close(sock_conn);
	mysql_close (conn);
}

int main(int argc, char *argv[])
{
	Inicializar_Tabla_Partidas(miPartidas);
	int sock_conn, sock_listen;
	int puerto=9000;
	struct sockaddr_in serv_adr;
	int encontrado=0;
	//bucle para provar puertos hasta que no de errores en el bind
	while (encontrado==0)
	{
		if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
			printf("Error creando socket\n");
		// Fem el bind al port
		
		
		memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
		serv_adr.sin_family = AF_INET;
		
		// asocia el socket a cualquiera de las IP de la m?quina. 
		//htonl formatea el numero que recibe al formato necesario
		serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
		// establecemos el puerto de escucha
		serv_adr.sin_port = htons(puerto);
		if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		{
			printf ("Error al bind en el puerto : %d\n",puerto);
			puerto=puerto+1;
		}
		else
			encontrado=1;
		
	}
	printf("Puerto correcto del bind : %d\n",puerto);
	// INICIALITZACIONS
	// Obrim el socket
	
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen\n");
	
	MYSQL *conn;
	
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
	// Bucle infinito
	for (;;){
		
		printf ("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		char nombre [20];
		strcpy(nombre,"conectar");
		int anadir=Pon(&miLista,nombre,sock_conn);
		if (anadir == 0)
		{
			int posicion=DamePosicion(&miLista,nombre);
			printf ("He recibido conexion\n");
			pthread_t thread;
			pthread_create(&thread,NULL,AtenderCliente,&miLista.conectados[posicion].socket);
			
		}
		else if (anadir==-1)
		{
			printf ("No ha sido posible establecer conexion: servidor lleno\n");
			
		}
		/*
		else if (anadir==-2)
		{
		printf ("No ha sido posible establecer conexion: socket already added\n");
		}
		*/
	}
	// Se acabo el servicio para este cliente
}

