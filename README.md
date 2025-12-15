# Sistema de Gestión del Congreso de Mercadotecnia

##  Descripción del Proyecto

Este es un **proyecto integrador transversal** que consiste en un sistema web para la gestión y seguimiento de asistencias del Congreso de Mercadotecnia. El sistema permite a los estudiantes consultar su progreso de asistencia a las diferentes conferencias y actividades del congreso mediante su correo electrónico y matrícula institucional.

##  Objetivos del Proyecto

- Facilitar el registro y control de asistencias de estudiantes al congreso
- Proporcionar una interfaz web intuitiva para consulta de progreso
- Generar estadísticas en tiempo real sobre participación
- Validar la inscripción y asistencia de los participantes

## Tecnologías Utilizadas

- **Framework**: ASP.NET Web Forms (.NET Framework 4.7.2)
- **Lenguaje**: C# 7.3
- **Base de Datos**: SQL Server
- **Frontend**: HTML5, CSS3, Bootstrap
- **Arquitectura**: Modelo de Capas (DAL - Data Access Layer)

## Estructura del Proyecto

```
CONGRESO_WB/
??? Default.aspx              # P�gina principal de consulta
??? Default.aspx.cs           # L�gica de negocio
??? Default.aspx.designer.cs  # Controles de la p�gina
??? Web.config                # Configuraci�n de la aplicaci�n
??? Global.asax.cs            # Configuraci�n global
??? packages.config           # Paquetes NuGet
??? DOCUMENTACION_PROYECTO.docx  # Documentaci�n detallada
??? README.md                 # Este archivo
? Default.aspx              # Página principal de consulta
? Default.aspx.cs           # Lógica de negocio
? Web.config                # Configuración de la aplicación
? Global.asax.cs            # Configuración global
? packages.config           # Paquetes NuGet
? DOCUMENTACION_PROYECTO.docx  # Documentación detallada
```

## Funcionalidades Principales

### 1. Consulta de Asistencias
- Los estudiantes pueden consultar su registro de asistencias
- Validaci�n mediante correo electr�nico y matr�cula
- Visualizaci�n de conferencias inscritas y asistidas
- GridView con informaci�n detallada de cada conferencia
- Validación mediante correo electrónico y matrícula
- Visualización de conferencias inscritas y asistidas

### 2. Dashboard de Estadísticas
- Total de conferencias inscritas
- Total de conferencias asistidas
- Porcentaje de asistencia calculado autom�ticamente
- Indicadores visuales con iconos y colores

### 3. Validaci�n de Datos
- Verificaci�n de campos obligatorios
- Validaci�n de coincidencia correo-matr�cula
- Mensajes de error informativos y amigables
- Manejo de excepciones robusto
### 3. Validación de Datos
- Verificación de campos obligatorios
- Validación de coincidencia correo-matrícula
- Mensajes de error informativos

## Instalación y Configuración

### Requisitos Previos
- Visual Studio 2017 o superior
- SQL Server 2014 o superior
- .NET Framework 4.7.2
- IIS Express o IIS

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/IZTREK/CONGRESO_WB.git
   ```

2. **Abrir la solución**
   - Abrir `CONGRESO_WB.csproj` en Visual Studio

3. **Configurar la cadena de conexión**
   - Editar `Web.config` con los datos de tu servidor SQL

4. **Restaurar paquetes NuGet**
   ```bash
   nuget restore
   ```

5. **Compilar y ejecutar**
   - Presionar F5 en Visual Studio
   - El navegador se abrir� autom�ticamente

## Configuración de Base de Datos

La cadena de conexión se encuentra en `Web.config`:

```xml
<connectionStrings>
  <add name="ConexionBD" 
       connectionString="tu_cadena_de_conexion" 
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

### Estructura de Base de Datos

El sistema utiliza las siguientes tablas principales:
- **Alumnos**: Informaci�n de los estudiantes
- **Conferencias**: Cat�logo de conferencias del congreso
- **Inscripciones**: Registro de inscripciones
- **Asistencias**: Control de asistencias

## ?? Uso del Sistema

1. **Acceder a la p�gina principal**
   - Navegar a `http://localhost:puerto/Default.aspx`

2. **Ingresar credenciales**:
   - Correo electr�nico institucional
   - Matr�cula del estudiante

3. **Consultar informaci�n**:
   - Ver tabla de conferencias inscritas
   - Revisar estad�sticas de asistencia en tiempo real
   - Identificar conferencias pendientes

## ?? Caracter�sticas T�cnicas

### Capa de Acceso a Datos (DAL)
```csharp
// Ejemplo de uso del DAO
ConsultasDAO dao = new ConsultasDAO();
DataTable resultados = dao.ObtenerProgresoAlumno(email, matricula);
```

### Validaciones
- Validaci�n de campos vac�os
- Verificaci�n de formato de correo
- Validaci�n de existencia de registros

### Manejo de Errores
- Try-catch en operaciones cr�ticas
- Mensajes de error descriptivos
- Logging de excepciones
## Uso del Sistema

1. **Acceder a la página principal**
2. **Ingresar credenciales**:
   - Correo electrónico institucional
   - Matrícula del estudiante
3. **Consultar información**:
   - Ver tabla de conferencias
   - Revisar estadísticas de asistencia

## Equipo de Desarrollo

Proyecto desarrollado como parte del **Proyecto Integrador Transversal** de la carrera de Mercadotecnia.

## ?? Contribuciones

Para contribuir al proyecto:
1. Fork el repositorio
2. Crea una rama para tu feature (`git checkout -b feature/nueva-funcionalidad`)
3. Commit tus cambios (`git commit -m 'Agregar nueva funcionalidad'`)
4. Push a la rama (`git push origin feature/nueva-funcionalidad`)
5. Abre un Pull Request

## ?? Licencia
## Licencia

Este proyecto es de uso académico para el Congreso de Mercadotecnia.

## Contacto y Soporte

Para más información, consultar la documentación completa en `DOCUMENTACION_PROYECTO.docx` o revisar el video demostrativo en `Link Video.txt`.

## ?? Reporte de Problemas

Si encuentras alg�n error o tienes sugerencias, por favor abre un issue en el repositorio de GitHub.

---

**�ltima actualizaci�n**: 2024  
**Versi�n**: 1.0.0  
**Última actualización**: 2024
**Repositorio**: [IZTREK/CONGRESO_WB](https://github.com/IZTREK/CONGRESO_WB)
