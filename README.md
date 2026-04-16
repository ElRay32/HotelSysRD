# HotelSys RD

Sistema web de gestión hotelera desarrollado en **C#** con **ASP.NET Core MVC**, orientado a la administración de habitaciones, clientes y reservaciones.  
El proyecto fue realizado como parte del **Proyecto Final de Programación III**, aplicando metodología **Agile-Scrum**, control de versiones con **GitHub**, gestión de trabajo con **Jira** y pruebas funcionales y automatizadas.

---

## Tabla de contenido

- [Descripción](#descripción)
- [Objetivo](#objetivo)
- [Características principales](#características-principales)
- [Tecnologías utilizadas](#tecnologías-utilizadas)
- [Arquitectura general](#arquitectura-general)
- [Módulos del sistema](#módulos-del-sistema)
- [Reglas de negocio implementadas](#reglas-de-negocio-implementadas)
- [Automatización de pruebas](#automatización-de-pruebas)
- [Estructura del proyecto](#estructura-del-proyecto)
- [Requisitos previos](#requisitos-previos)
- [Configuración del proyecto](#configuración-del-proyecto)
- [Base de datos y migraciones](#base-de-datos-y-migraciones)
- [Configuración de correo](#configuración-de-correo)
- [Cómo ejecutar el sistema](#cómo-ejecutar-el-sistema)
- [Cómo ejecutar las pruebas automatizadas](#cómo-ejecutar-las-pruebas-automatizadas)
- [Credenciales de acceso](#credenciales-de-acceso)
- [Primer release](#primer-release)
- [Estado actual del proyecto](#estado-actual-del-proyecto)
- [Autor](#autor)

---

## Descripción

**HotelSys RD** es un sistema de gestión hotelera que permite administrar de forma centralizada la información de un hotel.  
El sistema incluye funcionalidades para:

- iniciar sesión en el sistema,
- registrar y gestionar habitaciones,
- registrar y gestionar clientes,
- crear y administrar reservaciones,
- visualizar un dashboard con resumen del sistema,
- calcular costos de estadía,
- aplicar reglas de negocio sobre disponibilidad,
- enviar correos de confirmación de reservación.

---

## Objetivo

Desarrollar una solución web funcional para la administración interna de un hotel, permitiendo optimizar el control de habitaciones, clientes y reservaciones, así como demostrar el uso de buenas prácticas de desarrollo de software, Scrum, control de versiones y automatización de pruebas.

---

## Características principales

- Login académico con control de sesión
- Dashboard inicial con métricas básicas
- CRUD de habitaciones
- Generación automática del número de habitación
- CRUD de clientes
- CRUD de reservaciones
- Reservaciones con fecha y hora de entrada/salida
- Cálculo automático de noches y total a pagar
- Vista previa dinámica del costo estimado de la reservación
- Validación de solapamiento de reservaciones por habitación
- Cambio automático de estado de habitación según la reservación
- Finalización automática de reservaciones vencidas
- Liberación automática de habitaciones al finalizar una reservación
- Envío de correo de confirmación de reservación
- Interfaz visual mejorada con Bootstrap
- Pruebas automatizadas con Selenium WebDriver + NUnit

---

## Tecnologías utilizadas

### Backend
- **C#**
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **SQL Server / LocalDB**

### Frontend
- **HTML5**
- **CSS3**
- **Bootstrap**
- **JavaScript**

### Herramientas de desarrollo
- **Visual Studio**
- **Git**
- **GitHub**
- **GitHub Desktop**
- **Jira**

### Pruebas automatizadas
- **Selenium WebDriver**
- **NUnit**
- **ChromeDriver**

### Correos
- **SMTP**
- **Gmail App Password / configuración SMTP**

---

## Arquitectura general

El proyecto sigue una estructura organizada por capas lógicas dentro de ASP.NET MVC:

- **Models**: entidades del sistema
- **Data**: contexto de base de datos
- **Controllers**: lógica de negocio y flujo MVC
- **Views**: interfaz del sistema
- **ViewModels**: modelos específicos para vistas
- **Services**: servicios auxiliares, como correos electrónicos

Además, la automatización se encuentra en un proyecto separado:

- **HotelSysRD.AutomationTests**

---

## Módulos del sistema

### 1. Autenticación
Permite iniciar y cerrar sesión en el sistema mediante un login simple académico con sesión activa.

### 2. Habitaciones
Permite:
- registrar habitaciones,
- listar habitaciones,
- editar habitaciones,
- eliminar habitaciones,
- generar automáticamente el número de habitación.

### 3. Clientes
Permite:
- registrar clientes,
- listar clientes,
- editar clientes,
- eliminar clientes,
- consultar información individual.

### 4. Reservaciones
Permite:
- crear reservaciones,
- editar reservaciones,
- eliminar reservaciones,
- relacionar cliente y habitación,
- registrar fecha y hora de entrada/salida,
- calcular noches y total a pagar,
- evitar reservaciones solapadas,
- cambiar el estado de la habitación automáticamente.

### 5. Dashboard
Permite visualizar un resumen general:
- total de habitaciones,
- total de clientes,
- total de reservaciones,
- habitaciones disponibles,
- habitaciones ocupadas,
- habitaciones en mantenimiento.

---

## Reglas de negocio implementadas

- La **fecha/hora de salida** debe ser mayor que la de entrada.
- Una habitación **no puede reservarse en el mismo rango de tiempo** si ya tiene una reservación activa.
- Al crear una reservación activa, la habitación pasa a estado **Ocupada**.
- Cuando la reservación termina, cambia a **Finalizada** y la habitación vuelve a **Disponible**.
- El **número de habitación** se genera automáticamente.
- El sistema calcula:
  - **precio por noche**,
  - **cantidad de noches**,
  - **total a pagar**.
- El cliente recibe un **correo de confirmación** con el detalle de su reservación.

---

## Automatización de pruebas

Se creó un proyecto de automatización en C# utilizando **Selenium WebDriver** y **NUnit**.

### Flujos automatizados
- Inicio de sesión
- Creación de clientes
- Creación de reservaciones
- Flujo de habitaciones preparado y validado dentro del proceso de automatización

### Estructura del proyecto de pruebas
- `Drivers`
- `Pages`
- `Tests`
- `Utils`

