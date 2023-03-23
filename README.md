**SRP - Saitek Radio Panel para Simuladores de Vuelo**
  

SRP es un software para la integración del Saitek Radio Panel en simuladores de vuelo. Es compatible con los simuladores de vuelo más populares, incluyendo P3D versión 4, y tiene funcionalidades avanzadas de radio, incluyendo selección de frecuencias, modos de transmisión y recepción para COM1, COM2, NAV1, NAV2 y ADF.

  

# Características principales

-   Compatible con los simuladores de vuelo más populares, incluyendo P3D versión 4.
    
-   Integración con el Saitek Radio Panel para una experiencia de simulación más realista.
    
-   Funcionalidades avanzadas de radio, incluyendo selección de frecuencias, modos de transmisión y recepción para COM1, COM2, NAV1, NAV2 y ADF.
    
-   Utiliza el cliente de FSUIPC para la comunicación entre el software y el simulador de vuelo.
    
-   Personalizable por perfil de avión con archivos bien estructurados y simples de tipo JSON. Requiere un poco de documentación que aún estoy preparando.
    
-   Soporta cualquier offset que pueda leer FSUIPC y asignar comandos específicos. Esto le da un potencial increible!
    
-   Compilado para procesadores de 64 bits.
    
-   Desarrollado con la librería de Microsoft .NET CORE 6.
    
-   Compatible con Windows 10 (versión mínima 10.0.19041.0).
    
-   Alta velocidad de respuesta en los rotary encoders y botones, ya que no utiliza código script como LUA. Anteriormente venia utilizando LUA con LINDA, pero no podia lograr alta frecuencia de respuesta y llegué a pensar que se debia a mis Rotary Encoder de baja calidad. Pero luego, descubrí que no. Este código al ser compilado X64 y utilizar lectura Asincronica del dispositivo HID ejecuta muy rápido.
    

  

# TinyHidLibrary

TinyHidLibrary es una biblioteca C# para comunicarse con dispositivos HID (dispositivos de interfaz humana) específicos para simuladores de vuelo, como el Saitek Radio Panel. La biblioteca se basa en gran parte en el código de HidLibrary de Mike O'Brien, pero se han realizado muchas modificaciones para adaptarla a las necesidades específicas del Saitek Radio Panel.

La biblioteca se ha desarrollado porque la empresa que originalmente desarrolló el dispositivo descontinuó el soporte, por lo que se decidió crear una versión propia. Las otras opciones para controlar dispositivos HID no resultaron satisfactorias, ya que son más complejas de configurar y no tienen el rendimiento que se buscaba.

Entre las mejoras y modificaciones realizadas se encuentran la eliminación de los "Delegate" y la forma de invocación asincrónica BeginInvoke, que han sido reemplazados por el método TASK. Además, se ha cambiado completamente la forma en que se manejan los buffers tanto de lectura como de escritura, ya que se consideró innecesaria la creación de un buffer cada vez que se consulta el método Read. Por otro lado, también se eliminó HidReport. El Read solo devuelve el StatusRead, el resto está en el Buffers! Para que encapsular y re-encapsular si está en Buffers!

La biblioteca **TinyHidLibrary** solo implementa lo necesario para el Saitek Radio Panel. Se ha eliminado el Monitor de eventos porque no lo concidero necesario y podría generar problemas futuros. Durante la funcionamiento normal jamas se va a querer desconectar/reconectar el dispositivo intencionalmente. No es práctico para este caso. El control de errores es otra cuestión.

Finalmente, se desea reconocer y agradecer a Mike O'Brien y a su repositorio HidLibrary por su valioso código base. El link a continuación: [https://github.com/mikeobrien/HidLibrary](https://github.com/mikeobrien/HidLibrary)


# Acerca del desarrollador

Me llamo Esteban Maiutto. Vivo en Argentina. Soy un programador .NET con varios años de experiencia y fanático de las aviación en general, especialmente de los simuladores de vuelo. Espero que SRP sea de gran ayuda para aquellos que buscan mejorar su experiencia en la simulación de vuelo. Si bien está distribución es especifica para radios tengo una versión de los archivos de personalización JSON para utilizarlo como autopilot de un Boeing 737 de la serie PMDG. No implementa todas las funcionalidades lógicamente, pero aprovecha los displays, rotarys y pulsadores de manera ingeniosa, o al menos eso creo. Como es esperable, cualquiera puede incorporar parámetros de lectura (denominados offsets) y comandos para cualquier avión. También he desarrollado mi propio Autopilot 737 mas completo con placas ROF (4 placas tipo joystick integradas) y otros componentes del simulador (pedales, throttle simil cessna, landing, flaps, etc...)


# Contribución

¡Toda contribución es bienvenida! Si encuentra algún problema o desea agregar una nueva funcionalidad, no dude en hacer una solicitud de extracción (pull request).


# Licencia

SRP es distribuido con licencia MIT.