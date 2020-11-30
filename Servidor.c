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

int PonJugadorPartida (Partida *partida,char nombre[20],int socket){
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
{
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


int EliminarJugadorPartida (Partida partida,char nombre[20]) //esta funci￳n retorna -1 si no encuentra el nombre que se debe eliminar de la lista y 0 si se ha eliminado correctamente
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
void DameJugadores (Partida partida,char conectados[300])
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
int PonPartida(partidas Tabla,Partida partida)
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
int DamePosicionPartida(partidas Tabla,Partida partida)
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
int EliminarPartida(partidas Tabla,Partida partida)
{
	int pos=DamePosicionPartida(Tabla,partida);
	if (pos!=-1)
	{
		Tabla[pos].num=0;
		return 0;
	}
	else
	{
		return -1;
	}
}
int DamePosicionPartidaID(partidas Tabla,int ID)
{
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
int EliminarPartidaID(partidas Tabla, int ID)
{
	int pos=DamePosicionPartidaID(Tabla,ID);
	if (pos!=-1)
	{
		Tabla[pos].num=0;
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
int Pon (ListaConectados *lista,char nombre[20],int socket){
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

int DamePosicion (ListaConectados *lista,char nombre[20])
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


int Eliminar (ListaConectados *lista,char nombre[20]) //esta funci￳n retorna -1 si no encuentra el nombre que se debe eliminar de la lista y 0 si se ha eliminado correctamente
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
int DamePosicionSocket (ListaConectados *lista,int socket)
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
void EliminarPosicion(ListaConectados *lista,int posicion)
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





int signIn(MYSQL *conn ,char respuesta[1000],char nombre [20],char contra [20])
{
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	int err1;
	char consulta [512];
	char consulta1[512];
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

int  LogIn(MYSQL *conn ,char respuesta[1000],char nombre [20],char contra [20],ListaConectados *miLista, int sock_conn,char notificacion[100] ) //retorna 0 si no ha podido iniciar sesion o retorna 1 si ha podido iniciar sesion
{
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int err;
	int err1;
	char consulta [512];
	char consulta1[512];
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
			printf("Respuesta en el proceso de Log In: Password incorrecto\n");
			strcpy(respuesta, "2/1/Password incorrecto");
			int eliminar=DamePosicionSocket(miLista,sock_conn);
			EliminarPosicion(miLista,eliminar);
			return 0;
			
		}
		else {
			
			//int s=DameSocket(miLista,nombre);
			
			int already_in=DamePosicion(miLista,nombre);
			if(already_in==-1)
			{
				int update=DamePosicionSocket(miLista,sock_conn);
				strcpy(miLista->conectados[update].nombre,nombre);				
				printf("Respuesta en el proceso de Log In: Bienvenido de nuevo %s al Gran Casino UPC\n",nombre);
				sprintf(respuesta, "2/0/Bienvenido de nuevo %s al Gran Casino UPC",nombre);
				char conectados[1000];
				DameConectados(miLista,conectados);
				sprintf(notificacion,"6/%s/",conectados);
				printf("Notificacion: %s\n",notificacion);
				return 1;
			}
			else
			{
				printf("Respuesta en el proceso de Log In: Usuario %s ya conectado des de otro terminal\n",nombre);
				sprintf(respuesta, "2/1/Usuario %s ya conectado des de otro terminal",nombre);
				int eliminar=DamePosicionSocket(miLista,sock_conn);
				EliminarPosicion(miLista,eliminar);
				return 0;
				//int eliminar=DamePosicionSocket(miLista,sock_conn);
				//EliminarPosicion(miLista,eliminar);
			}
		}
	}
	
	else{
		printf("Respuesta en el proceso de Log In: Nombre de usuario incorrecto\n");
		strcpy(respuesta, "2/1/Nombre de usuario incorrecto");
		int eliminar=DamePosicionSocket(miLista,sock_conn);
		EliminarPosicion(miLista,eliminar);
		
		return 0;
		//int eliminar=DamePosicionSocket(miLista,sock_conn);
		//EliminarPosicion(miLista,eliminar);
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
		printf("La consulta retorna el jugador o los jugadores con el mayor dep￳sito y el menor n￺mero de partidas ganadas:\n");
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
	//consulta adicional para saber la ID de la partida que en la que gan￯﾿ﾯ￯ﾾ﾿￯ﾾﾯ￯﾿ﾯ￯ﾾﾾ￯ﾾ﾿￯﾿ﾯ￯ﾾﾾ￯ﾾﾳ el jugador que se busca en la consulta anterior
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

void *AtenderCliente(void *socket)
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
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		char copia[1000];
		strcpy(copia,peticion);
		
		printf ("Peticion que recibe el servidor: %s\n",peticion);
		
		// vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		// Ya tenemos el c?digo de la petici?n
		char nombre[20];
		char contra[20];
		int introC=0;
		char anfitrion [20];
		char invitado[20];
		char invitacion[100];
		int juego;
		int IDpartida;
		
		
		//if ((codigo!=0)&&(codigo!=7)&&(codigo!=8)&&(codigo!=9))//&&(codigo!=6))
		if ((codigo==1)||(codigo==2)||(codigo==3)||(codigo==4)||(codigo==5))
		{
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			// Ya tenemos el nombre
			
			p = strtok( NULL, "/");
			strcpy (contra, p);
			// Ya tenemos la contra
			
			printf ("Codigo: %d Nombre: %s Contra: %s\n", codigo, nombre,contra);
			
			//iniciamos la conexion a la base de datos
		}
		
		if (codigo ==0) {//peticion de desconexion
			terminar=1;
			printf("Desconectando\n");
			pthread_mutex_lock( &mutex);
			int eliminado=Eliminar (&miLista,nombre); 
			if (eliminado==-1)
				strcpy(respuesta,"0/1/Error en la desconexion");//eliminar de la lista de conectados
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
				introC =LogIn (conn,respuesta,nombre,contra,&miLista,sock_conn,notificacion);
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
				terminar=1;
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
			Partida partidA;
			partidA.ID=IDpartida;
			partidA.juego=juego;
			
			
			
			
			int sockk=DameSocket(&miLista,anfitrion);
			int anadir_anfitrion= PonJugadorPartida(&partidA,anfitrion,sockk);
			
			
			PonPartida(miPartidas,partidA);
			int Pos= DamePosicionPartidaID(miPartidas,IDpartida);
			printf("Anfitrion %s en la partida %d en posicion %d\n",partidA.conectados[0].nombre,partidA.ID,partidA.num);
			printf("numero de jugadores en la partida %d = %d\n",partidA.ID,partidA.num);
			
			p = strtok( NULL, "/");
			sprintf(respuesta,"7/0/%d/%d",juego,IDpartida);
			int nInvitadosConectados=0;
			char invitadosConectados[100];
			char invC[100];
			while (p!=NULL)
			{
				strcpy (invitado, p);
				
				int j=DameSocket(&miLista,invitado);
				if (j==-1)
				{
					printf("El jugador %s se ha desconectado\n",invitado);
					/*int pos =DamePosicionPartidaID(Tabla,IDpartida);
					int del=EliminarJugadorPartida(Tabla[pos],invitado);*/
				}
				else
				{
					//int pos=DamePosicion(&miLista,invitado);
					//int ponA=PonJugadorPartida(miPartidas[Pos],invitado,miLista.conectados[pos].socket);
					//printf("Invitado %s en la partida %d en posicion %d\n",invitado,miPartidas[Pos].ID,miPartidas[Pos].num);
					//printf("numero de jugadores en la partida %d = %d\n",miPartidas[Pos].ID,miPartidas[Pos].num);
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
					//envio la invitacion a cada invitado
					
				}
				p = strtok( NULL, "/");
			}
			
			sprintf(respuesta,"%s/%d",respuesta,nInvitadosConectados);
			strcat(respuesta,"/");
			strcat(respuesta,invitadosConectados);
			printf("Respuesta que se envia al anfitrion:%s\n",respuesta);
			miPartidas[Pos].num_invitados=miPartidas[Pos].num_invitados+nInvitadosConectados;
			
		}
		else if (codigo==8) //peticion de aceptar o declinar una invitacion de partida
		{
			//la peticion que me llega sera del tipo: Codigo del juego/codigo de la partida/Jugador que invita/jugador invitado/Respuesta(si o no)/codigo de respuesta (1 acepta 0 no)
			char respuestaInv[100];
			char respuestaAnfitrion[100];
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
			{
				sprintf(respuesta,"8/0/%d/%d",juego,IDpartida);
				int sock=DameSocket(&miLista,anfitrion);
				p = strtok( NULL, "/");
				strcpy (invitado, p);
				p = strtok( NULL, "/");
				strcpy(respuestaInv,p);
				p = strtok( NULL, "/");
				int res=atoi(p);
				int pos_partida= DamePosicionPartidaID(miPartidas,IDpartida);
				if (res==0)//el invitado no acepta la invitacion por lo tanto hay que eliminarlo
				{
					printf("Jugador %s no acepta por lo tanto eliminado de la partida\n",invitado);
					//int del=EliminarJugadorPartida(miPartidas[pos],invitado);
				}
				else
				{
					int pos_inv=DamePosicion(&miLista,invitado);
					int ponA=PonJugadorPartida(&miPartidas[pos_partida],invitado,miLista.conectados[pos_inv].socket);
					
				}
				printf("Respuesta que se envia al invitado:%s\n",respuesta);
				printf("numero de jugadores en la partida %d = %d\n",IDpartida,miPartidas[pos_partida].num);
				printf("numero de invitados %d; numero de respuestas %d\n",miPartidas[pos_partida].num_invitados,miPartidas[pos_partida].answer);
				if (miPartidas[pos_partida].num==1 && miPartidas[pos_partida].answer==miPartidas[pos_partida].num_invitados )
				{
					printf("La partida se cancelo\n");
					sprintf(respuestaAnfitrion,"8/2/%d/%d/%s/%s",juego,IDpartida,invitado,respuestaInv);
					write (sock,respuestaAnfitrion, strlen(respuestaAnfitrion));
					printf("Respuesta que se envia al anfitrion:%s\n",respuestaAnfitrion);
					EliminarPartidaID(miPartidas,IDpartida);
					
				}
				else
				{
					sprintf(respuestaAnfitrion,"8/1/%d/%d/%s/%s",juego,IDpartida,invitado,respuestaInv);
					write (sock,respuestaAnfitrion, strlen(respuestaAnfitrion));
					printf("Respuesta que se envia al anfitrion:%s\n",respuestaAnfitrion);
				}
			}
			else
			{
				sprintf(respuesta,"8/-1/%d/%d",juego,IDpartida);
				printf("Respuesta que se envia al invitado:%s\n",respuesta);
			}
		}
		else if (codigo==9)//peticion de enviar por el chat
		{
			strcpy(notificacion,copia);
			strcpy(respuesta,copia);
			
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
		if (codigo!=9 && codigo!=10 && codigo!=11)
		{
			printf ("Respuesta que envia el servidor al cliente: %s\n", respuesta);
			// Enviamos respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		}
		int j;
		if (codigo==0 || codigo ==2||introC==1||codigo==9||codigo==11)
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
	//exit(0);
}

int main(int argc, char *argv[])
{
	Inicializar_Tabla_Partidas(miPartidas);
	int sock_conn, sock_listen;
	int puerto=9400;
	struct sockaddr_in serv_adr;
	// INICIALITZACIONS
	// Obrim el socket
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
		printf ("Error al bind\n");
	
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

