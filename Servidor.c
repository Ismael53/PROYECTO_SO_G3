#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

typedef struct {
	char nombre [20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados [100];
	int num;
} ListaConectados;

int i;
ListaConectados miLista;
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
			//strcpy (lista ->conectados[i].nombre=lista->conectados[i+1].nombre);
			//lista->conectados[i].socket=lista->conectados[i+1].socket;
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






void signIn(MYSQL *conn ,char respuesta[1000],char nombre [20],char contra [20])
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
			strcpy(respuesta, "1/Fallo al insertar");
		}
		else {
			printf("Bienvenido %s al Gran Casino UPC\n",nombre);
			sprintf(respuesta, "1/Bienvenido %s al Gran Casino UPC",nombre);
		}
	}
	
	else{
		printf("Nombre de usuario ya registrado pruebe otro nombre\n");
		strcpy(respuesta, "1/Nombre de usuario ya registrado pruebe otro nombre");
	}
	
}

void  LogIn(MYSQL *conn ,char respuesta[1000],char nombre [20],char contra [20],ListaConectados *miLista, int sock_conn )
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
			printf("Password incorrecto\n");
			strcpy(respuesta, "2/1/Password incorrecto");
		}
		else {
			
			//int s=DameSocket(miLista,nombre);
			int conect=Pon(miLista,nombre,sock_conn);
			if (conect==0) //todo correcto y deja conectar al usuario solicitante
			{
				printf("Bienvenido de nuevo %s al Gran Casino UPC\n",nombre);
				sprintf(respuesta, "2/0/Bienvenido de nuevo %s al Gran Casino UPC",nombre);
			}
			
			if (conect==-1) //lista llena por lo tanto no se pueden conectar mas clientes
			{
				printf("Lo siento no se pueden conectar mas clientes\n");
				sprintf(respuesta, "2/1/Lo siento no se pueden conectar mas clientes");
			}
			if (conect==-2) //el usuario ya se ha conectado des de otro terminal
			{
				printf("Usuario %s ya conectado des de otro terminal\n",nombre);
				sprintf(respuesta, "2/1/Usuario %s ya conectado des de otro terminal",nombre);
				
			}
			
		}
	}
	
	else{
		printf("Nombre de usuario incorrecto\n");
		strcpy(respuesta, "2/1/Nombre de usuario incorrecto");
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
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_BBDDCasino",0, NULL, 0);
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
		
		
		printf ("Peticion: %s\n",peticion);
		
		// vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		// Ya tenemos el c?digo de la petici?n
		char nombre[20];
		char contra[20];
		
		
		
		if ((codigo!=0))//&&(codigo!=6))
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
			pthread_mutex_lock( &mutex);
			signIn (conn,respuesta,nombre,contra); 
			pthread_mutex_unlock( &mutex);
		}
		
		
		
		else if (codigo ==2){ //iniciar sesion
			pthread_mutex_lock (&mutex);
			LogIn (conn,respuesta,nombre,contra,&miLista,sock_conn);
			char conectados[1000];
			DameConectados(&miLista,conectados);
			sprintf(notificacion,"6/%s/",conectados);
			printf("Notificacion: %s\n",notificacion);
			pthread_mutex_unlock (&mutex);
			
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
		
		printf ("Respuesta: %s\n", respuesta);
		// Enviamos respuesta
		write (sock_conn,respuesta, strlen(respuesta));
		int j;
		if (codigo==0 || codigo ==2)
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
	int sock_conn, sock_listen;
	int puerto=50058;
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
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_BBDDCasino",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error 2 al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	else{
		printf("Conexion con la base de datos establecida correctamente\n");
	}
	
	
	pthread_t thread[100];
	
	i=0;
	// Bucle infinito
	for (;;){
		
		printf ("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sockets[i]=sock_conn;
		pthread_create(&thread[i],NULL,AtenderCliente,&sock_conn);
		i=i+1;
		
	}
	// Se acabo el servicio para este cliente
}

