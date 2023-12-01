#SRP - Saitek Radio Panel for Flight Simulators
 
**SRP** is a software for the integration of the **Saitek Radio Panel** in flight simulators. It is compatible with the most popular flight simulators, including **P3D version 4**, and has advanced radio functionalities, including selection of frequencies, transmission and reception modes for COM1, COM2, NAV1, NAV2 and ADF.
 
## Main Features
 
-   Compatible with the most popular flight simulators, including **P3D version 4**.
    
-   Integration with the **Saitek Radio Panel** for a more realistic simulation experience.
    
-   Advanced radio functionalities, including frequency selection, transmission and reception modes for COM1, COM2, NAV1, NAV2 and ADF.
    
-   It uses the **FSUIPC** client for communication between the software and the flight simulator.
    
-   Customizable per aircraft profile with well structured and simple files of type **JSON**. It requires a bit of documentation that I'm still preparing.
    
-   It supports any offset that can read **FSUIPC** and assign specific commands. This gives you incredible potential!
    
-   Compiled for 64-bit processors.
    
-   Developed with the Microsoft **.NET CORE 6.** library.
    
-   Compatible with Windows 10 (minimum version 10.0.19041.0)
    
-   High response speed in rotary encoders and buttons, since it does not use script code such as LUA. Previously I was using LUA with LINDA, but I couldn't achieve high frequency response and I came to think that it was due to my low quality Rotary Encoder. But later, I found out no. This code, when compiled X64 and using Asynchronous reading of the HID device, runs very fast.
 
## TinyHidLibrary
 
**TinyHidLibrary** is a C# library for communicating with HID devices (Human Interface Devices) specific to flight simulators, such as the **Saitek Radio Panel**. The library is largely based on the code from Mike O'Brien's **HidLibrary**, but many modifications have been made to suit the specific needs of the Saitek Radio Panel.
 
The library has been developed because the company that originally developed the device discontinued support, so it was decided to create its own version. The other options for controlling HID devices were not satisfactory, as they are more complex to configure and do not have the performance that was sought.
 
Among the improvements and modifications made are the elimination of the "Delegate" and the BeginInvoke form of asynchronous invocation, which have been replaced by the TASK method. In addition, the way both read and write buffers are handled has been completely changed, as creating a buffer every time the Read method is queried was deemed unnecessary. On the other hand, HidReport was also removed. The Read only returns the StatusRead, the rest is in the Buffers! Why encapsulate and re-encapsulate if all that is needed is already in Buffers!
 
The **TinyHidLibrary** library only implements what is necessary for the **Saitek Radio Panel**. The Event Monitor has been removed because I don't think it's necessary and it could cause future problems. During normal operation you will never want to intentionally disconnect/reconnect the device. It is not practical for this case. Error handling is another matter.
 
Finally, we would like to acknowledge and thank **Mike O'Brien** and his **HidLibrary** repository for their valuable code base which is linked below: [https://github.com/mikeobrien/HidLibrary]( https://github.com/mikeobrien/HidLibrary)
 
## About the developer
 
My name is Esteban Maiutto. I live in Argentina. I am a .NET programmer with several years of experience and a fan of aviation in general, especially flight simulators. I hope **SRP** will be of great help to those looking to improve their flight simulation experience. Although this distribution is specific to radios I have a version of the **JSON** customization files to use as autopilot of a Boeing 737 of the **PMDG** series. It does not implement all the functionalities logically, but it takes advantage of the displays, rotary switches and push buttons in an ingenious way, or at least I think so. As expected, anyone can add read parameters (called offsets) and commands for any aircraft. I have also developed my own 737 Autopilot more complete with ROF boards (4 integrated joystick boards) and other simulator components such as pedals, throttle (Cessna style), landing gear lever, flaps, among other panels.
 
## Contribution
 
All contributions are welcome! If you encounter any issues or want to add new functionality, feel free to make a pull request.

## License

SRP is distributed under an MIT license.